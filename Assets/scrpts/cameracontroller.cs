﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    public Animator animator;
    public Vector3 move;
    public Vector3 flatten;
    public Vector3 Vect;
    public bool isturning;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        // creates variables and starts "SetStart" as the level flys in
        isturning = true;
        flatten = new Vector3(1,1,1);
        Invoke("SetStart",.75f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            flatten = Vector3.one;
            animator.SetBool("left", true);
            Invoke("stop", .1f);
            Invoke("set", .25f);
            // parents the character to the object below it
            RaycastHit hit;
            if (Physics.Raycast(player.position, Vector3.down, out hit))
            {
                if (hit.collider.gameObject != null)
                {
                    player.SetParent(hit.collider.gameObject.transform,true);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            flatten = Vector3.one;
            animator.SetBool("right", true);
            Invoke("stop", .1f);
            Invoke("set", .25f);
            // parents the character to the object below it
            RaycastHit hit;
            if (Physics.Raycast(player.position, Vector3.down, out hit))
            {
                if (hit.collider.gameObject != null)
                {
                    player.SetParent(hit.collider.gameObject.transform, true);
                }
            }
        }
    }
    public void stop()
    {
        //stops turn after one rotation
        animator.SetBool("left", false);
        animator.SetBool("right", false);
    }
    public void set()
    {
        // sets the flat axis to the correct axis and unparents the character
        flatten = Vect;
        player.SetParent(null, true);
    }
    private void SetStart()
    {
        // starts the game with correct flat axis
        flatten = new Vector3(1, 1, 0);
    }
}
