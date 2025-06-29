using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IsMirror
{
    NO = 1,
    YES = -1
}
public class PlayerController : MonoBehaviour
{
    public IsMirror isMirror;
    [Header("Movement Buttons")]
    public HandleMoveButton moveRightButton;
    public HandleMoveButton moveLeftButton;
    public HandleMoveButton jumpButton;
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float gravityForce;
    public bool beginJump;
    public float moveDirection;

    [Header("Ground Check (Box)")]
    public Vector2 boxSize = new Vector2(0.5f, 0.1f);  // Kích thước box để kiểm tra
    public Transform groundCheckPosition;
    public LayerMask groundLayer;
    public string tag_name;

    public Rigidbody2D rb;
    private bool isGrounded;
    //public float jumpTime = 0;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        moveRightButton.RegisterListener(HandleButtonInput);
        moveLeftButton.RegisterListener(HandleButtonInput);
        jumpButton.RegisterListener(HandleButtonInput);
        Physics2D.gravity = new Vector2(0, gravityForce);
        ChangeTag();
    }
    public void ChangeTag()
    {
        gameObject.tag = tag_name;       
    }
    void Update()
    {
        // Nhận input trái/phải
        //moveInput = Input.GetAxisRaw("Horizontal");

        // Nhảy nếu đang đứng trên mặt đất
        if (beginJump && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //jumpTime = 0;
        }
        beginJump = false;
        // Kiểm tra đang đứng trên mặt đất
        isGrounded = Physics2D.OverlapBox((Vector2)groundCheckPosition.position, boxSize, 0f, groundLayer);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
        /*if (!isGrounded)
        { // tăng vận tốc khi rơi xuống
            //jumpTime += Time.deltaTime;
            rb.velocity += Vector2.down * fallingSpeed * jumpTime;
        }*/

    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
        Gizmos.DrawWireCube((Vector2)groundCheckPosition.position, boxSize);
    }
    public void HandleButtonInput(object[] values)
    {
        string type = values[0] as string;

        if (type == "jump")
        {
            beginJump = (bool)values[1];
        }
        else if (type == "move")
        {
            int newDirection = (int)values[1] * (int)isMirror;
            if (moveDirection != newDirection)
            {
                moveDirection = newDirection;
            }
        }
    }

}
