using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    bool isRunning,isJump;

    private void Awake()
    {
        Debug.Log("Player COntroller is awake");
    }

    public BoxCollider2D PlayerCollider;
    private float sizeX, sizeY;

    private void Start()
    {
        animator = GetComponent<Animator>();
        PlayerCollider = GetComponent<BoxCollider2D>();
        sizeX = PlayerCollider.size.x;
        sizeY = PlayerCollider.size.y;
    }


    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //Debug.Log("collision: " + collision.gameObject.name);
    //}

    private void Update()
    {
        float speed = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        // bool isRunning = true;
     

        //Running
        if (speed != 0 && !isRunning)
        {
            
                animator.SetBool("isRunning", true);
                animator.SetFloat("Speed", Mathf.Abs(speed));
                isRunning = true;
            
            if (isRunning) flip();
        }
        else
        {
            isRunning = false;
            animator.SetBool("isRunning", false);
        }

        //Jumping
        if (vertical != 0 && !isJump)
        {
            
                animator.SetBool("isJump", true);
                isJump = true;
            
        }else
        {
            isJump = false;
            animator.SetBool("isJump", false);
        }

        // Crouching
        if (Input.GetKey(KeyCode.LeftControl))
        {
           // isCrouch = true;
           // isRunning = false;
            animator.SetBool("isCrouch", true);
            PlayerCollider.size = new Vector2(x: sizeX, 2.24f);
            Debug.Log("player is crouched");
        }
        else
        {
           // isCrouch = false;
            //isRunning = true;
            animator.SetBool("isCrouch", false);
            PlayerCollider.size = new Vector2(x: sizeX, sizeY);
            Debug.Log("player is not crouched");
        }
     
        void flip()
        {
            Vector3 scale = transform.localScale;
            if (speed < 0) { 
                scale.x = -1f * Mathf.Abs(scale.x);
            }
            else if (speed > 0){
                scale.x = Mathf.Abs(scale.x);
            }
            transform.localScale = scale;
        }

    }

}