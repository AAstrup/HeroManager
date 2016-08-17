using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InputFieldScript : MonoBehaviour {

    InputField inputField;
    string value;

	// Use this for initialization
	void Start () {
        inputField = gameObject.GetComponent<InputField>();
        
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        inputField.onEndEdit = se;

    }

    private void SubmitName(string arg0)
    {
        value = arg0;
    }

    public string GetValue()
    {
        return value;
    }
}
