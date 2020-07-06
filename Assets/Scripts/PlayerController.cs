using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D PlayerCollider;
    private float sizeX, sizeY;
    public float speed;


    
    private void Start()
    {
        animator = GetComponent<Animator>();
        PlayerCollider = GetComponent<BoxCollider2D>();
        sizeX = PlayerCollider.size.x;
        sizeY = PlayerCollider.size.y;
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        PlayerRun(horizontal);
        MoveCharacter(horizontal);
        PlayerCrouch();
        PlayerJump();

    }
    void MoveCharacter(float horizontal)
    {
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;

    }
    void PlayerRun(float horizontal)
    {
        
            animator.SetBool("isRunning", true);
            animator.SetFloat("Speed", Mathf.Abs(horizontal));

            Vector3 scale = transform.localScale;
            if (horizontal < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
            }
            else if (horizontal > 0)
            {
                scale.x = Mathf.Abs(scale.x);
            }
            transform.localScale = scale;
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
        if (vertical != 0)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }
    }
    
}