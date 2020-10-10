using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{

/*
    private GameObject gameHandler;
    private GameHandler gameHandlerScript;
    private bool isTransitioning;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.Find("Game Handler");
        gameHandlerScript = gameHandler.GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        isTransitioning = gameHandlerScript.isTransitioning;

        if(isTransitioning){
            foreach(Transform child in transform){
                if(child.gameObject.GetComponent<CircleCollider2D>() != null){
                    child.gameObject.GetComponent<CircleCollider2D>().enabled = false;
                }
                
                if(child.gameObject.GetComponent<PolygonCollider2D>() != null){
                    child.gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                }
            }
        }else{
            foreach(Transform child in transform){
                if(child.gameObject.GetComponent<CircleCollider2D>() != null){
                    child.gameObject.GetComponent<CircleCollider2D>().enabled = true;
                }

                if(child.gameObject.GetComponent<PolygonCollider2D>() != null){
                    child.gameObject.GetComponent<PolygonCollider2D>().enabled = true;
                }
            }
        }
    }
*/
}
