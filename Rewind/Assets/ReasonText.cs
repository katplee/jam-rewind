using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReasonText : MonoBehaviour
{
    private TextMeshProUGUI textMeshPro;
    public int reasonNumber = -1;

    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(reasonNumber){
            case 0:
                textMeshPro.text = "You exited the boundary\na tad too late..";
                break;
            case 1:
                textMeshPro.text = "You attempted to cross\na closed boundary..";
                break;
            case 2:
                textMeshPro.text = "You hit a rewind\nof a different color..";
                break;
            case 3:
                textMeshPro.text = "You attempted to leave\nthe cyclic universe..";
                break;
        }
    }
}
