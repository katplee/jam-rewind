using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active : MonoBehaviour
{

    public bool playerHasCollided;

    #region Boundary setting
    private float timeSinceCreation;
    private float timeUntilWallCloses;
    private Rigidbody2D rigidBody;
    private GameObject leftWallBoundary;
    private GameObject rightWallBoundary;
    public bool isInsideLeftWall; //change to private
    public bool isInsideRightWall; //change to private
    #endregion

    #region Trigger setting
    private GameObject inactiveContainer;
    private GameObject activePathContainer;
    public Material colliderMaterial;
    public Material currentMaterial;
    #endregion

    #region ColorDecider setting
    public bool colorCanChange;
    #endregion

    #region Reason setting
    private GameObject reasonTextObject;
    private ReasonText reasonTextObjectScript;
    #endregion

    #region Start and end setting
    private GameObject onPlayCanvas;
    private GameObject gameOverCanvas;
    #endregion

    #region Audio
    private AudioSource audioSource;
    public AudioClip hit;
    public AudioClip goal;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        timeSinceCreation = Time.time;
        timeUntilWallCloses = 2f;

        rigidBody = GetComponent<Rigidbody2D>();
        leftWallBoundary = GameObject.Find("Left Rigid Boundary");
        rightWallBoundary = GameObject.Find("Right Rigid Boundary");

        inactiveContainer = GameObject.Find("Inactive");
        activePathContainer = GameObject.Find("Active Path");        

        onPlayCanvas = GameObject.Find("OnPlayCanvas");
        gameOverCanvas = GameObject.Find("GameOverCanvas");
        gameOverCanvas.SetActive(false);

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerHasCollided = false;
        colorCanChange = false;
    }

    void Update(){
        //isOutsideLeftWall = !rigidBody.IsTouching(leftWallBoundary.GetComponent<BoxCollider2D>());
        //isOutsideRightWall = !rigidBody.IsTouching(rightWallBoundary.GetComponent<BoxCollider2D>());
    }

    void OnTriggerEnter2D(Collider2D collider){
        if(collider.gameObject == GameObject.Find("Goal")){
            audioSource.clip = goal;
            audioSource.Play();
            playerHasCollided = true;
            timeSinceCreation = Time.time;
        }

        #region Outer boundary collision
        if(Time.time >= timeSinceCreation + timeUntilWallCloses){
            if(collider.gameObject == leftWallBoundary){
                GameOver(1);                
                Debug.Log("Player has attempted to enter the left wall beyond time limit! Game over!");
            }
        }

        if(collider.gameObject == GameObject.Find("Upper Wall")){
            GameOver(3);
            Debug.Log("Upper Wall! Game over!");
        }

        if(collider.gameObject == GameObject.Find("Lower Wall")){
            GameOver(3);
            Debug.Log("Lower Wall! Game over!");
        }
        #endregion

        if(collider.gameObject == GameObject.Find("Left Wing Boundary")){
            GameOver(3);
            Debug.Log("Left Wing! Game over!");
        }

        if(collider.gameObject == GameObject.Find("Right Wing Boundary")){
            GameOver(3);
            Debug.Log("Right Wing! Game over!");
        }
        
        #region ColorDecider logic
        if(collider.gameObject == GameObject.Find("Color Decider")){
            Debug.Log("Change color!");
            colorCanChange = true;
        }
        #endregion

        #region Line collision logic
        if(collider.gameObject.transform.IsChildOf(inactiveContainer.transform)){
            
            LineRenderer colliderLR = collider.gameObject.GetComponent<LineRenderer>();
            colliderMaterial = colliderLR.material;
            currentMaterial = activePathContainer.transform.GetChild(0).GetComponent<LineRenderer>().material;
            isInsideLeftWall = rigidBody.IsTouching(leftWallBoundary.GetComponent<BoxCollider2D>());
            isInsideRightWall = rigidBody.IsTouching(rightWallBoundary.GetComponent<BoxCollider2D>());

            if(colliderMaterial.name != currentMaterial.name){
                if(isInsideLeftWall || isInsideRightWall){
                    Debug.Log("Player has hit different color line inside! Okay!");
                }else{
                    GameOver(2);
                    Debug.Log("Player has hit different color line outside! Game over!");
                }  
            }else{
                Debug.Log("Player has hit same color line! Okay!");
            }
        }
        #endregion
    }
    
    void OnTriggerExit2D(Collider2D collider){
        #region Outer boundary collision                  

        if(Time.time >= timeSinceCreation + timeUntilWallCloses){
            if(collider.gameObject == GameObject.Find("Left Wall")){
                GameOver(0);
                Debug.Log("Player has bumped the left wall beyond time limit! Game over!");
            }
        }
        #endregion
    }

    private void GameOver(int reasonNumber){
        Time.timeScale = 0f;
        onPlayCanvas.SetActive(false);        
        gameOverCanvas.SetActive(true);

        audioSource.clip = hit;
        audioSource.Play();

        reasonTextObject = GameObject.Find("ReasonText");
        reasonTextObjectScript = reasonTextObject.GetComponent<ReasonText>();
        reasonTextObjectScript.reasonNumber = reasonNumber;
    }
}
