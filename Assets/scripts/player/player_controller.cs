using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_controller : MonoBehaviour
{
    Rigidbody2D player;
    [SerializeField] private float speed;
    [SerializeField] private float runningSpeed;
    private Vector2 moveVelocity;
    private Animator animator;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        applyInput();
    }

    private void FixedUpdate()
    {
        player.MovePosition(player.position + moveVelocity * Time.fixedDeltaTime);
    }

    void applyInput()
    {
        move();
        animate();
    }

    void move()
    {
        Vector2 axis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetAxisRaw("Run") > 0)
        {
            moveVelocity = axis.normalized * (speed + runningSpeed);
        }
        else
        {
            moveVelocity = axis.normalized * speed;
        }
    }

    void animate()
    {
        Vector2 axis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        animator.SetFloat("horizontal", axis.normalized.x);
        animator.SetFloat("vertical", axis.normalized.y);
        animator.SetFloat("magnitude", axis.normalized.magnitude);
    }
}
