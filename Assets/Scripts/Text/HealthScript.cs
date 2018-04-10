using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {

    public static int HealthValue = 10;
    Text Health;

    // Use this for initialization
    void Start ()
    {
        Health = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Health.text = "Health" + HealthValue;
    }
}
