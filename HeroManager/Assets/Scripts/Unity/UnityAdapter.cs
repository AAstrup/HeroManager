using UnityEngine;
using System.Collections;
using System;

public class UnityAdapter : MonoBehaviour, IUnityAdapter {

    public References Ref;
    public CardCreatorManager creatorManager;

    // Use this for initialization
    void Start () {
        Ref = new References();
        Ref.Initialize(this);

        creatorManager.Initialize(this);
    }

    void Update() {
        Ref.Update();
    }

    public GameObject InstatiateUI(GameObject toCreate)
    {
        return (GameObject)Instantiate(toCreate, transform.position, Quaternion.identity);
    }
}
