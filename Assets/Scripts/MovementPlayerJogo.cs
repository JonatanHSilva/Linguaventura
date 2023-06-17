using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerJogo : MonoBehaviour
{
    public float speed;
    bool pause = false;
    public GameObject menu;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 direction;
    

    private void Start()
    {
        Time.timeScale = 1;
    }


    private void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction.Normalize();

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);


        if (Input.GetButtonDown("Cancel"))
        {
            pause = !pause;
            if (pause)
            {
                menu.SetActive(true);
                Time.timeScale = 0;
            }
            else if (pause == false)
            {
                menu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
}

