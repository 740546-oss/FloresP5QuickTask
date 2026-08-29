
using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    // Left/Right Movement
    private Rigidbody2D _rigidbody;
    private float moveX;
    private Vector2 movement;
    public float MoveSpeed = 5f;

    // Jumping
    public float JumpForce = 10f;
    public LayerMask GroundLayer;
    public BoxCollider2D GroundCollider;
    public bool OnGround;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        OnGround = true;
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && OnGround)
        {
            // Make our player jump
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, JumpForce);
            OnGround = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        // Check if we collided with the ground
        if (GroundLayer == (1 << other.gameObject.layer))
        {
            OnGround = true;
        }
    }

    void FixedUpdate()
    {
        // Determine our movement vector based on our speed and move inputs
        movement = new Vector2(moveX * MoveSpeed, _rigidbody.velocity.y);

        // Make our player move left/right
        _rigidbody.velocity = movement;
    }

}
