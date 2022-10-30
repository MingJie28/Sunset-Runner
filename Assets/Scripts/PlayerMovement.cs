using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public Rigidbody2D rb;
    [SerializeField] private Transform posGroundCheck;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private LayerMask WinLayer;
    [SerializeField] private float groundRadius;
    private bool isGrounded = false;
    private bool win = false;
    public Animator animator;
    public GameObject WinText;
    public AudioSource jumpSound;


    // Update is called once per frame
    private void Update()
    {
        if (win == false)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            WinText.SetActive(true);
            rb.velocity = new Vector2(0, 0);
        }
        isGrounded = GroundCheck();
        win = WinCheck();
        animator.SetBool("isGrounded", isGrounded);

        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            jumpSound.Play();
            rb.velocity = Vector2.up * jumpForce;
            isGrounded = false;
        }   
    }

    private bool GroundCheck()
    {
        return Physics2D.OverlapCircle(posGroundCheck.position, groundRadius, GroundLayer);
    }

    private bool WinCheck()
    {
        return Physics2D.OverlapCircle(posGroundCheck.position, groundRadius, WinLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jumps"))
        {
            jumpSound.Play();
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
