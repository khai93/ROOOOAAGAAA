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

    [SerializeField]
    private float maxJumps;

    private Rigidbody2D rb;

    public bool isGrounded;
    private float JumpsLeft;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        JumpsLeft = maxJumps;
    }

    private void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            if (JumpsLeft >0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                JumpsLeft--;
            }
        }

        if (isGrounded && JumpsLeft <= 0)
        {
            JumpsLeft = maxJumps;
        }

        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, 0.15f, groundLayer);
    }
}
