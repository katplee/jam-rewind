using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaBehavior : MonoBehaviour
{
    
    private SpriteRenderer spriteRenderer;
    private GameObject activeContainer;
    private Active activeContainerScript;
    private bool colorCanChange;
    public int matSelect;

    private Color32 _blue;
    private Color32 _red;
    private Color32 _yellow;

    // Start is called before the first frame update
    void Start()
    {
    #region Color construction
        _blue = new Color32(193, 210, 211, 255);
        _red = new Color32 (241, 219, 195, 255);
        _yellow = new Color32 (243, 231, 182, 255);
    #endregion

        spriteRenderer = GetComponent<SpriteRenderer>();
        activeContainer = GameObject.Find("Active");
        activeContainerScript = activeContainer.GetComponent<Active>();

        matSelect = Random.Range(0,3);
        setArenaColor(matSelect);
    }

    // Update is called once per frame
    void Update()
    {
        colorCanChange = activeContainerScript.colorCanChange;

        if(colorCanChange){
            matSelect = Random.Range(0,3);
            setArenaColor(matSelect);
        }
    }

    void setArenaColor(int matSelect){
        switch(matSelect){
            case 0:
                spriteRenderer.color = _blue;
                break;
            case 1:
                spriteRenderer.color = _red;
                break;
            case 2:
                spriteRenderer.color = _yellow;
                break;
        }

    }
}
