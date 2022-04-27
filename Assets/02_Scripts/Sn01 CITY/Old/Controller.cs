using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Animator anim;
    public float speed;

    void Start()
    {
        anim = GetComponent<Animator>();     
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        Debug.Log("arrow");
        float rotation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);


        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("jump");
            //anim.SetTrigger("isMoving");
        }

        //if (translation != 0)
        //{
        //    anim.SetBool("isRunning", true);
        //    anim.SetBool("idle", false);
        //}
        //else
        //{
        //    anim.SetBool("isRunning", false);
        //    anim.SetBool("idle", true);
        //}
    }
}
