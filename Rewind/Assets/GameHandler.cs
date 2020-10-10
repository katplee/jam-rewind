using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    #region General variables
    public int score = 0;
    #endregion

    #region Player instantiation
    public GameObject startMark;
    public GameObject player;
    public GameObject activeContainer;
    public GameObject activePathContainer;
    #endregion

    #region Object segregation
    public bool performMove = false;
    public Active activeContainerScript;
    public GameObject inactiveContainer;
    #endregion

/*
    #region Arena size decision
    public bool isTransitioning;
    private int arenaIndex;
    //0: circleArena, 1; diamondArena, 3: hexagonArena
    private float timeToSpawnArena = 10f;
    //private float timeSinceCreation;
    private int frameCount = 0;
    public GameObject arenaContainer;
    public GameObject circleArena;
    public GameObject diamondArena;
    public GameObject hexagonArena;
    #endregion
*/
    
    // Start is called before the first frame update
    void Start()
    {
        activeContainerScript = activeContainer.GetComponent<Active>();
        Instantiate(player, startMark.transform.position, Quaternion.identity, activeContainer.transform);
/*
        #region Arena logic
        //timeSinceCreation = Time.time;
        arenaIndex = Random.Range(0,3);
        selectArena(arenaIndex);        
        #endregion
*/
    }

    // Update is called once per frame
    void Update()
    {
        if(activeContainerScript.playerHasCollided){
            //activeContainer.transform.GetChild(0).GetChild(0).SetParent(inactiveContainer.transform);
            activePathContainer.transform.GetChild(0).SetParent(inactiveContainer.transform);
            Destroy(activeContainer.transform.GetChild(0).gameObject);
            Instantiate(player, startMark.transform.position, Quaternion.identity, activeContainer.transform);

            score++;            
        }
/*
        #region Arena logic
        if(arenaContainer.transform.GetChild(arenaContainer.transform.childCount - 1).localScale.x > 30f){
            isTransitioning = true;
        }else{
            isTransitioning = false;
            frameCount++;
        }

        if(isTransitioning){
            foreach(Transform child in arenaContainer.transform){
                child.localScale -= Vector3.one * 10f * Time.deltaTime;
            }
        }else{
            if(frameCount == 1){
                StartCoroutine(countdownToSpawn(timeToSpawnArena));
            }
        }
        #endregion
*/
    }
/*
    IEnumerator countdownToSpawn(float timeToSpawnArena){
        Debug.Log("Timer coroutine has started!");
        yield return new WaitForSeconds(5);

        frameCount = 0;
        arenaIndex = Random.Range(0,3);
        selectArena(arenaIndex);
    }

    void selectArena(int arenaIndex){
        GameObject tempArena;
        
        switch(arenaIndex){
            case 0:
                tempArena = Instantiate(circleArena, Vector3.zero, Quaternion.identity, arenaContainer.transform);
                tempArena.transform.localScale = Vector3.one * 60f;
                break;
            case 1:
                tempArena = Instantiate(diamondArena, Vector3.zero, Quaternion.identity, arenaContainer.transform);
                tempArena.transform.localScale = Vector3.one * 60f;
                break;
            case 2:
                tempArena = Instantiate(hexagonArena, Vector3.zero, Quaternion.identity, arenaContainer.transform);
                tempArena.transform.localScale = Vector3.one * 60f;
                break;
        }
    }

*/
}