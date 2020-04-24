using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_controller : MonoBehaviour
{
    Rigidbody2D player;
    [SerializeField] private float speed;
    [SerializeField] private float runningSpeed;
    private Vector2 moveVelocity;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
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
}
