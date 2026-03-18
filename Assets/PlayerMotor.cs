using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rigidbody2D;
    public float speed = 10;
    public float jumpForce = 10;
    private bool canJump = true;
    private float maxSpeed = 5;
    public float stoppingForce = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Fixedupdate 40/sec
    void FixedUpdate()
    {
        PlayerMovmentHandle();
        PlayerMovmentStopping();
    }

    private void PlayerMovmentHandle()
    {
        if (direction.x != 0)
        {
            rigidbody2D.AddForce(new Vector2(direction.x * speed, 0));
        }
        else if (rigidbody2D.linearVelocityX != 0)
        {
            rigidbody2D.AddForce(new Vector2(-rigidbody2D.linearVelocityX * stoppingForce, 0));
        }
    }

    private void PlayerMovmentStopping()
    {
        if (rigidbody2D.linearVelocityX >= maxSpeed)
        {
            rigidbody2D.linearVelocityX = maxSpeed;
        }
        else if (rigidbody2D.linearVelocityX <= -maxSpeed)
        {
            rigidbody2D.linearVelocityX = -maxSpeed;
        }
    }

    void OnJump()
    {
        if (canJump)
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canJump = true;
    }
    void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }
}
