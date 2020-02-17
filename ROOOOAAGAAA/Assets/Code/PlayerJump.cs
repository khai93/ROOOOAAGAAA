using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private Transform GroundCheck;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private KeyCode jumpKey;

    [SerializeField]
    private float jumpForce;

    private Rigidbody2D rb;

    public bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.15f, groundLayer);
    }
}
