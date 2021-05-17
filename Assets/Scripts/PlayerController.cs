﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float translation;
    private float rotation;

    private Animator ani;

    private void start()
    {
        ani = GetComponent<Animator>();
    }

    void Update()
    {
        translation = Input.GetAxis("Vertical") * 10f;
        rotation = Input.GetAxis("Horizontal") * 100f;

        transform.Translate(0, 0, translation * Time.deltaTime);
        transform.Rotate(0, rotation * Time.deltaTime, 0);

        if(translation != 0 || rotation != 0)
        {
            ani.SetBool("walk", true);
        }
        else
        {
            ani.SetBool("walk", false);
        }
    }

    private void OncollisionEenter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            ani.SetTrigger("damage");
        }
    }
}
