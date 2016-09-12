using UnityEngine.UI;
using UnityEngine;
using System.Linq;
using System.Collections;


public class CanvasController
{

    private Canvas canvas;
    private InGameController _IGC;

    public void Init(InGameController igc)
    {
        _IGC = igc;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void AddUIGameObject(GameObject gb)
    {
        gb.transform.SetParent(canvas.transform,true);
    }

}