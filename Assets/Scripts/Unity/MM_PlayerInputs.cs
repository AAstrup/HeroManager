using UnityEngine;
using System.Collections;

public class MM_PlayerInputs : MonoBehaviour {
    public static MM_PlayerInputs instance;
    void Awake() { instance = this; }

    public delegate void TriggerAction();
    public static event TriggerAction OnJump;

    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
            if(OnJump != null)
                OnJump();
	}
    
}
