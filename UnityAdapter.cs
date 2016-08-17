using UnityEngine;
using System.Collections;

public class UnityAdapter : MonoBehaviour {
    public static UnityAdapter instance;
    void Awake() { instance = this; }

    References Ref;

    // Use this for initialization
    void Start () {
        Ref = new References();
        Ref.Initialize();
    }

    void Update() {
        Ref.Update();
    }
}
