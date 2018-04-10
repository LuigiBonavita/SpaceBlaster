using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HearthScript : MonoBehaviour {

    public static int HearthValue = 3;
    Text Hearth;

    // Use this for initialization
    void Start ()
    {
        Hearth = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        Hearth.text = "Hearth" + HearthValue;
    }
}
