using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

#region Control variables
    private float movementSpeed = 1f;
    private float delta = 0.1f;
    private int keyPressed;
#endregion

#region Path instantiation
    public GameObject pathPrefab;
    public GameObject activeContainer; //added
    public GameObject activePathContainer; //added
#endregion

#region Path expiration & line re-creation
    private GameObject gameHandler;
    private GameHandler gameHandlerScript;
    private GameObject pathInst;    
#endregion

#region Boundary variables
    private float timeSinceCreation;
#endregion


    // Start is called before the first frame update
    void Start()
    {
        timeSinceCreation = Time.time;
        activeContainer = GameObject.Find("Active");
        activePathContainer = GameObject.Find("Active Path");
        pathInst = Instantiate(pathPrefab, transform.position, Quaternion.identity, activePathContainer.transform);
        //pathInst = Instantiate(pathPrefab, transform.position, Quaternion.identity, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {

#region Boundary logic
        
#endregion

#region Control logic
        if(transform.parent.gameObject == GameObject.Find("Active")){
            if(Input.GetKey("right")){
                keyPressed = 0;
            }

            if(Input.GetKey("left")){
                keyPressed = 1;
            }

            if(Input.GetKey("up")){
                keyPressed = 2;
            }

            if(Input.GetKey("down")){
                keyPressed = 3;
            }
        }

        switch(keyPressed){
            case -1:
            case 0:
                transform.Translate(Vector3.right * delta * (movementSpeed/Time.deltaTime) * Time.deltaTime);
                break;
            case 1:
                transform.Translate(Vector3.left * delta * (movementSpeed/Time.deltaTime) * Time.deltaTime);
                break;
            case 2:
                transform.Translate(Vector3.up * delta * (movementSpeed/Time.deltaTime) * Time.deltaTime);
                break;
            case 3:
                transform.Translate(Vector3.down * delta * (movementSpeed/Time.deltaTime) * Time.deltaTime);
                break;
        }

#endregion
    }
    
    /*
    void OnCollisionEnter2D(Collision2D collider){
        if(collider.gameObject != GameObject.Find("Goal") && collider.gameObject != GameObject.Find("Player(Clone)")){
            if(collider.gameObject.GetComponent<LineRenderer>().material == activeContainer.transform.GetChild(0).GetComponent<LineRenderer>().material){
                Debug.Log("Same color line was hit!");
            }

            if(collider.gameObject.GetComponent<LineRenderer>().material != activeContainer.transform.GetChild(0).GetComponent<LineRenderer>().material){
                Debug.Log("Game over!");
            }
        }      
    }
    */    
}
