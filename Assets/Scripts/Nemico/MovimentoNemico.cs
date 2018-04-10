using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoNemico : MonoBehaviour {

    public Vector3 StartPoint;
    public Vector3 EndPoint;
    public Vector3 StartPosition;
    public float speed;

    public State currentState = State.Alive;

    // Use this for initialization
    void Start ()
    {
        currentState = State.Alive;
        transform.position = new Vector3(Random.Range(-13f, 14f), 0, 35f);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(transform.position.z >= StartPoint.z)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
      
        if(transform.position.z <= EndPoint.z)
        {
            transform.position = new Vector3(Random.Range(-13f, 14f), 0, 35f);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("proiettile"))
        {
            currentState = State.Death;
        }

        if(currentState == State.Death)
        {

            transform.position = new Vector3 ( Random.Range(-13f, 14f),0, 40f);
        }
    }

    public enum State
    {
        Alive,
        Death,
    }
}
