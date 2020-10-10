using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWall : MonoBehaviour
{

    #region Signal setting
    private float timeSinceCreation;
    private float timeUntilWallCloses;
    private GameObject activeContainer;
    private Active activeContainerScript;
    #endregion

    #region Material selection
    private LineRenderer lineRenderer;
    private Material mat;
    private int matSelect;
    private GameObject arena;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        activeContainer = GameObject.Find("Active");
        activeContainerScript = activeContainer.GetComponent<Active>();

        lineRenderer = GetComponent<LineRenderer>();

        timeSinceCreation = Time.time;
        timeUntilWallCloses = 2f;        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time < timeSinceCreation + timeUntilWallCloses){
            arena = GameObject.FindWithTag("Arena");
            matSelect = arena.GetComponent<ArenaBehavior>().matSelect;
            MatSelect(matSelect);
        }

        if(Time.time >= timeSinceCreation + timeUntilWallCloses){
            arena = GameObject.FindWithTag("Arena");
            matSelect = arena.GetComponent<ArenaBehavior>().matSelect;
            lineRenderer.material = Resources.Load("Materials/Wall") as Material;
        }

        if(activeContainerScript.playerHasCollided){
            timeSinceCreation = Time.time;
        }
    }

    private void MatSelect(int matSelect){
        switch(matSelect){
            case 0:
                mat = Resources.Load("Materials/Arena Material_1") as Material;
                break;
            case 1:
                mat = Resources.Load("Materials/Arena Material_2") as Material;
                break;
            case 2:
                mat = Resources.Load("Materials/Arena Material_3") as Material;
                break;
        }

        lineRenderer.material = mat;
    }
}
