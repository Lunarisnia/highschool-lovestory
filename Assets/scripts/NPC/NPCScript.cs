using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NPCScript : MonoBehaviour
{
    private float maxRadius = 4.00f;
    private float radius;

    private void OnMouseOver()
    {
        radius = (gameObject.transform.position - Player.playerPosition).magnitude;
        if (radius <= maxRadius)
        {
            if (Time.timeScale > 0)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    gameObject.GetComponent<DialogueTrigger>().triggerDialog();
                }
            }
        }
    }

    private void OnMouseEnter()
    {
        FindObjectOfType<game_manager>().setCursorSelecting();
    }

    private void OnMouseExit()
    {
        FindObjectOfType<game_manager>().setCursorNorm();
    }
}
