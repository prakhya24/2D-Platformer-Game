using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    bool isRunning, isJump;
    public BoxCollider2D PlayerCollider;
    private float sizeX, sizeY;


    
    private void Start()
    {
        animator = GetComponent<Animator>();
        PlayerCollider = GetComponent<BoxCollider2D>();
        sizeX = PlayerCollider.size.x;
        sizeY = PlayerCollider.size.y;
    }

    private void Update()
    {
        
        PlayerRun();
        PlayerCrouch();
        PlayerJump();

    }
    void PlayerRun()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        
        if (Horizontal != 0 && !isRunning)
        {

            animator.SetBool("isRunning", true);
            animator.SetFloat("Speed", Mathf.Abs(Horizontal));
            isRunning = true;

            Vector3 scale = transform.localScale;
            if (Horizontal < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
            }
            else if (Horizontal > 0)
            {
                scale.x = Mathf.Abs(scale.x);
            }
            transform.localScale = scale;
        }
        else
        {
            isRunning = false;
            animator.SetBool("isRunning", false);
        }
    }
    void PlayerCrouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", true);
            PlayerCollider.size = new Vector2(sizeX, sizeY);
            Debug.Log("player is crouched");
        }
        else
        {
            animator.SetBool("isCrouch", false);
            PlayerCollider.size = new Vector2(sizeX, sizeY);
            Debug.Log("player is not crouched");
        }
    }
    void PlayerJump()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        if (vertical != 0 && !isJump)
        {

            animator.SetBool("isJump", true);
            isJump = true;

        }
        else
        {
            isJump = false;
            animator.SetBool("isJump", false);
        }
    }
    
}