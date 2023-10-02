using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Karakterin ilerleme hýzý
    public float maxSpeed = 10.0f; // Maksimum hýz sýnýrý
    public Image fuel;
    public float timer = 2f;

    private Rigidbody2D rb;
    private Animator anim;

    private bool isGrounded;
    public float GroundCheckRadius;
    public LayerMask groundLayer;
    public GameObject groundCheck;
    public float jumpPower;


    public GameObject panel;
    public float jumpVelocity = 5f;
    public float jumpHeight = 5f; // Yükselme yüksekliði (mesafe)
    private bool isJumping = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        InvokeRepeating("UpdateFuel", timer, timer);
    }

    private void Update()
    {
        CheckSurface();
        float currentSpeed = rb.velocity.x;
        if (currentSpeed < maxSpeed)
        {
            rb.velocity = new Vector2(currentSpeed + moveSpeed * Time.deltaTime, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            anim.SetBool("isGrounded", false);
        }
        

        if (Input.GetKeyUp(KeyCode.Space) && fuel.fillAmount > 0f)
        {
            isJumping = false;
            fuel.fillAmount -= 0.1f;
            anim.SetBool("isGrounded", true);
        }
    }
    void CheckSurface()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, GroundCheckRadius, groundLayer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.transform.position, GroundCheckRadius);
    }
    void UpdateFuel()
    {
        fuel.fillAmount += 0.3f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Engel")
        {
            panel.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
