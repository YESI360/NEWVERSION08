using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public Animator anim;
    public float speed;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

   
    void Update()
    {
        //float translation = Input.GetAxis("Vertical") * speed;
        //translation *= Time.deltaTime;

        transform.Translate (0, 0, speed);

        //if (Input.GetButtonDown("Jump"))
        //{
        //    anim.SetTrigger("moving");
        //}


        //if (speed != 0)
        //{
        //    anim.SetBool("isRunning", true);
        //}
        //else
        //{
        //    anim.SetBool("isRunning", false);
        //}
    }
}
