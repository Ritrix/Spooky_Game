using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float Friction;

    [Header("Misc")]
    [SerializeField] private LayerMask platformLayerMask;
    private int direction = 1;
    private bool m_FacingRight;

    [Header("Jump")]
    [SerializeField] private float JumpForce = 5;
    [SerializeField] private float coyoteTime; //how much time a player gets to input a jump after falling off a platform
    private float coyoteCounter; //how much time has passed since a player fell off a platform

    public float xVelocity;
    public float yVelocity;

    private BoxCollider2D boxCollider;
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        xVelocity = body.velocity.x;
        yVelocity = body.velocity.y;

        float horizontalInput = Input.GetAxis("Horizontal");
        //flip player sprite horizontally when moving left and right
        if (horizontalInput > 0.01f)
        {
            m_FacingRight = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (horizontalInput < -0.01f)
        {
            m_FacingRight = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        //move left right
        if (Input.GetKey(KeyCode.A))
        {
            direction = -1;
            body.velocity = new Vector2(body.velocity.x - 1, body.velocity.y);

            if ((body.velocity.x * -1) > moveSpeed)
            {
                body.velocity = new Vector2(Mathf.Floor(body.velocity.x + Friction), body.velocity.y);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = 1;
            body.velocity = new Vector2(body.velocity.x + 1, body.velocity.y);
            if (body.velocity.x > moveSpeed)
            {
                body.velocity = new Vector2(Mathf.Floor(body.velocity.x - Friction), body.velocity.y);
            }
        }

        //jump
        if (Input.GetKeyDown(KeyCode.J))
        {
            Jump();
        }

        //coyote time
        if (IsGrounded() && !(body.velocity.y >= JumpForce - 1))
        {
            coyoteCounter = coyoteTime;
        }
        else
        {
            coyoteCounter -= Time.deltaTime;
        }

        //friction calculation
        if (IsGrounded())
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                if (body.velocity.x > moveSpeed)
                {
                    body.velocity = new Vector2(Mathf.Floor(body.velocity.x - Friction), body.velocity.y);
                }
                else if ((body.velocity.x * -1) > moveSpeed)
                {
                    body.velocity = new Vector2(Mathf.Floor(body.velocity.x + (Friction * 2)), body.velocity.y);
                }
            }
            else
            {
                if (body.velocity.x > 1f)
                {
                    body.velocity = new Vector2(Mathf.Floor(body.velocity.x - Friction), body.velocity.y);
                }
                else if ((body.velocity.x * -1) > 1f)
                {
                    body.velocity = new Vector2(Mathf.Floor(body.velocity.x + Friction), body.velocity.y);
                }
            }
        }

    }

    public void Jump()
    {
        if (IsGrounded() || coyoteCounter > 0)
        {
            body.velocity = new Vector2(body.velocity.x, JumpForce);
        }
        coyoteCounter = 0;
    }

    public bool IsGrounded()
    {

        float extraHeightText = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeightText, platformLayerMask);
        return raycastHit.collider != null;
    }
}
