using UnityEngine;
public class player_controller : MonoBehaviour
{
    private Player player;
    Rigidbody2D playerRb;
    [SerializeField] private float speed;
    [SerializeField] private float runningSpeed;
    private Inventory inventory;
    private Vector2 moveVelocity;
    private Animator animator;

    void Start()
    {
        player = GetComponent<Player>();
        inventory = GetComponent<Inventory>();
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        applyInput();
    }

    private void FixedUpdate()
    {
        playerRb.MovePosition(playerRb.position + moveVelocity * Time.fixedDeltaTime);
    }

    void applyInput()
    {
        move();
        animate();
        openInventory();
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
