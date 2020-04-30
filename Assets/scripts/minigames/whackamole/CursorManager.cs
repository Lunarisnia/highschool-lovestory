using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Animator animator;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        applyInput();
        mouseTracker();
    }

    private void mouseTracker()
    {
        Vector3 mousepos = Input.mousePosition;
        mousepos.z = Camera.main.nearClipPlane + 12f;
        transform.position = Camera.main.ScreenToWorldPoint(mousepos);
        if (transform.position.x > 0.01f)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }

    private void applyInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hitAMole();
        }
    }

    private void hitAMole()
    {
        animator.SetBool("hit", true);
    }

    public void returnToIdleState()
    {
        animator.SetBool("hit", false);
    }
}
