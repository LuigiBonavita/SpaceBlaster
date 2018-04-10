using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerMovement pmove;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        pmove = GetComponent<PlayerMovement>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("xAxis", pmove.XAxisMovement);
        anim.SetInteger("yAxis", pmove.YAxisMovement);
    }
}
