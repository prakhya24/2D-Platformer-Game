using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public BoxCollider2D PlayerCollider;
    private float sizeX, sizeY;
    public float speed;
    public float jump;
    private Rigidbody2D rb2d;


    
    private void Start()
    {
        animator = GetComponent<Animator>();
        PlayerCollider = GetComponent<BoxCollider2D>();
        sizeX = PlayerCollider.size.x;
        sizeY = PlayerCollider.size.y;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Jump");
        PlayerRun(horizontal);
        MoveCharacter(horizontal, vertical);
        PlayerCrouch();
        PlayerJump(vertical);

    }
    void MoveCharacter(float horizontal,float vertical)
    {
        // horizonyal movement
        Vector3 position = transform.position;
        position.x += horizontal * speed * Time.deltaTime;
        transform.position = position;
        // vertical movement
        if (vertical > 0)
        {
            rb2d.AddForce(Vector2.up*jump);
        }

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
    void PlayerJump(float vertical)
    {
        if (vertical > 0)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }
    }
    
}