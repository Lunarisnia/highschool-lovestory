using UnityEngine;

public class camera_movement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float tresshold;
    private Vector2 playerPosition;
    void Update()
    {
        playerPosition = new Vector2(player.position.x, player.position.y);
    }

    private void LateUpdate()
    {
        moveCamera();
    }

    private void moveCamera()
    {
        horizontally();
        vertically();
    }

    private void horizontally()
    {
        if (playerPosition.x > transform.position.x + tresshold)
        {
            transform.position = new Vector3(playerPosition.x - tresshold, transform.position.y, transform.position.z);
        }
        else if (playerPosition.x < transform.position.x - tresshold)
        {
            transform.position = new Vector3(playerPosition.x + tresshold, transform.position.y, transform.position.z);
        }
    }

    private void vertically()
    {
        if (playerPosition.y > transform.position.y + tresshold)
        {
            transform.position = new Vector3(transform.position.x, playerPosition.y - tresshold, transform.position.z);
        }
        else if (playerPosition.y < transform.position.y - tresshold)
        {
            transform.position = new Vector3(transform.position.x, playerPosition.y + tresshold, transform.position.z);
        }
    }
}
