using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    bool isRunning;

    private void Awake()
    {
        Debug.Log("Player COntroller is awake");
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //Debug.Log("collision: " + collision.gameObject.name);
    //}
    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        // bool isRunning = true;

         if(speed>0)
        {
            isRunning = true;
            animator.SetBool("isRunning", true);
            animator.SetFloat("Speed",speed);
            Debug.Log("Player running right");
            if (isRunning) flip();
            //Vector3 scale = transform.localScale;

            //scale.x = Mathf.Abs(scale.x);
           // transform.localScale = scale;

        }
         else if (speed < 0)
        {
            isRunning = true;
            animator.SetBool("isRunning", true);
            animator.SetFloat("Speed", Mathf.Abs(speed));
            Debug.Log("Player running left");
            if (isRunning) flip();
          
        }
     
        void flip()
        {
            Vector3 scale = transform.localScale;
            if (speed < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
            }
            else if (speed > 0)
            {
                scale.x = Mathf.Abs(scale.x);
            }
            transform.localScale = scale;
        }

    }

}
