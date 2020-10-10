using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

#region Line creation
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    public List<Vector2> movePositions;
    public GameObject activePlayer; //added
    private bool endReached = false;

    #region Material selection
        private Material mat;
        private int matSelect;
        private GameObject arena;
    #endregion
#endregion

#region Line recreation
    public GameObject activeContainer;
    public Active activeContainerScript;
    private int listCount;
    public bool isRedrawing;
    private IEnumerator redrawCoroutine;
    public Vector3[] lineRendererPosArray;
    public Vector2[] lineRendererPosArray2D;

#endregion

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Vector3.zero;

        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        activeContainer = GameObject.Find("Active");
        activeContainerScript = activeContainer.GetComponent<Active>();
        activePlayer = activeContainer.transform.GetChild(0).gameObject; //added

    #region Material selection

        arena = GameObject.FindWithTag("Arena");
        matSelect = arena.GetComponent<ArenaBehavior>().matSelect;
        MatSelect(matSelect);
        CreateLine();

    #endregion
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!endReached){
            Vector2 tempPlayerPos = (Vector2)(activePlayer.transform.position); //changed
            //Vector2 tempPlayerPos = (Vector2)(transform.parent.position);
            if(Vector2.Distance(tempPlayerPos, movePositions[movePositions.Count - 1]) > .05f){
                tempPlayerPos = 
                    new Vector2((Mathf.Round(tempPlayerPos.x * 10f) / 10f),
                                (Mathf.Round(tempPlayerPos.y * 10f) / 10f));
                UpdateLine(tempPlayerPos);
            }
        }
    }

    void Update(){

        if(activeContainerScript.playerHasCollided){
            endReached = true;
            isRedrawing = true;
            listCount = movePositions.Count;
        }

        if(isRedrawing){
            redrawCoroutine = ReDrawLine();
        
            if(lineRenderer.positionCount == listCount){
                lineRenderer.positionCount = 0;
                Destroy(edgeCollider);
                StartCoroutine(redrawCoroutine);
            }
        }

        isRedrawing = false;
    }

#region MatSelect()
    public void MatSelect(int matSelect){
        switch(matSelect){
            case 0:
                mat = Resources.Load("Materials/Active Line Material_1") as Material;
                break;
            case 1:
                mat = Resources.Load("Materials/Active Line Material_2") as Material;
                break;
            case 2:
                mat = Resources.Load("Materials/Active Line Material_3") as Material;
                break;
        }

        lineRenderer.material = mat;
    }
#endregion

#region CreateLine()
    void CreateLine(){
        movePositions.Clear();
        //movePositions.Add(transform.parent.position);
        //movePositions.Add(transform.parent.position);
        movePositions.Add(activePlayer.transform.position);
        movePositions.Add(activePlayer.transform.position);
        lineRenderer.SetPosition(0, movePositions[0]);
        lineRenderer.SetPosition(1, movePositions[1]);
        edgeCollider.points = movePositions.ToArray();
    }
#endregion

#region UpdateLine()
    void UpdateLine(Vector2 newPlayerPos){
        movePositions.Add(newPlayerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPlayerPos);
        edgeCollider.points = movePositions.ToArray();
    }
#endregion

#region IEnumerator ReDrawLine()
    IEnumerator ReDrawLine(){
        Debug.Log("Coroutine Start!");
        edgeCollider = gameObject.AddComponent<EdgeCollider2D>();
        lineRenderer.positionCount++;
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(0, movePositions[0]);
        lineRenderer.SetPosition(1, movePositions[1]);
        
        yield return null;

        for(int i = 2; i < movePositions.Count; i++){
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, movePositions[i]);
            lineRendererPosArray = new Vector3[lineRenderer.positionCount];
            lineRendererPosArray2D = new Vector2[lineRenderer.positionCount];
            lineRenderer.GetPositions(lineRendererPosArray);
                for(int j = 0; j < lineRenderer.positionCount; j++){
                    lineRendererPosArray2D[j] = (Vector2) lineRendererPosArray[j];
                }
            edgeCollider.points = lineRendererPosArray2D;

            yield return null;
        }

        yield return null;
    }
#endregion

}
