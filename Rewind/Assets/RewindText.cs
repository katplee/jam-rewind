using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RewindText : MonoBehaviour
{

    private GameObject gameHandler;
    private GameHandler gameHandlerScript;
    private TextMeshProUGUI textMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.Find("Game Handler");
        gameHandlerScript = gameHandler.GetComponent<GameHandler>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameHandlerScript.score == 1){
            textMeshPro.text = "REWIND";
        }else{
            textMeshPro.text = "REWINDS";
        }     
    }
}
