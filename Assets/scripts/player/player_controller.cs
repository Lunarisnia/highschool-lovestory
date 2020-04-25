using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player_controller : MonoBehaviour
{
    Rigidbody2D player;
    [SerializeField] private float speed;
    [SerializeField] private float runningSpeed;
    private Inventory inventory;
    private Vector2 moveVelocity;
    private Animator animator;

    void Start()
    {
        inventory = GetComponent<Inventory>();
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
        openInventory();
        addMoneh(1252);
    }

    void addMoneh(int amount)
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {

            inventory.addMoney(amount);
            Debug.Log(GameManager.player.money);
        }

    }
    void openInventory()
    {
        inventory.openInventory();
    }
    void move()
    {
        Vector2 axis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetButton("Run"))
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
