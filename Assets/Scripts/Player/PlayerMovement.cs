using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [Header("Input Settings")]
    public KeyCode ForwardInput = KeyCode.W;
    public KeyCode BackwardInput = KeyCode.S;
    public KeyCode LeftInput = KeyCode.A;
    public KeyCode RightInput = KeyCode.D;


    public int XAxisMovement = 0;
    public int YAxisMovement = 0;

    public float MovementSpeed = 1;
    public float Timer = 0f;
    private void Update()
    {

        // Up Down
        if (Input.GetKey(ForwardInput))
        {
            transform.position += Vector3.forward * MovementSpeed;
            YAxisMovement = 1;
        }
        else if (Input.GetKey(BackwardInput))
        {
            transform.position += Vector3.back * MovementSpeed;
            YAxisMovement = -1;
        }
        else
            YAxisMovement = 0;
        // Left Right
        if (Input.GetKey(LeftInput))
        {
            transform.position += Vector3.left * MovementSpeed;
            XAxisMovement = -1;
        }
        else if (Input.GetKey(RightInput))
        {
            transform.position += Vector3.right * MovementSpeed;
            XAxisMovement = 1;
        }
        else
            XAxisMovement = 0;

        if (transform.position == new Vector3(500,500,500))
        {
            Timer = Timer + Time.deltaTime;
        }
        if (Timer >= 3f)
        {
            transform.position = new Vector3(0, 0, 0);
            HealthScript.HealthValue = 10;
            HearthScript.HearthValue -= 1;
            Timer = 0f;
        }

        if(HearthScript.HearthValue < 0)
        {
            transform.position = new Vector3(700, 700, 700);
            HealthScript.HealthValue = 0;
            HearthScript.HearthValue = 0;
            Timer = 0f;
            Destroy(gameObject);
        }
    }

}
