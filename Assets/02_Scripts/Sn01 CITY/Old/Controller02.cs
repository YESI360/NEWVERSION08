using System.Collections;
using UnityEngine;

public class Controller02 : MonoBehaviour
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
        float rotation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);


        //if (Input.GetButtonDown("Jump"))
        //{
        //    //anim.SetTrigger("Move");
        //    anim.SetTrigger("jump");
        //}

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    anim.SetBool("Move", false);
        //}


    }
}
