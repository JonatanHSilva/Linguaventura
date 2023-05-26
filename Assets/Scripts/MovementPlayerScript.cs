using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerScript : MonoBehaviour
{
    public float speed;
    public Vector2 screenLimit = new(-4, 5);
    private Animator animator;

    public GameObject projectile;
    public float shootDistance = 1;
    public float shootSpeed = 300;
    public float shootCD = .5f;
    float shootTimer = 0;
    Vector2 shootDirection = Vector2.right;
    //public GameObject explosion;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        shootTimer += Time.deltaTime;
        Movement();
        Shoot();
    }

    void Movement()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            dir.x = -1;
            animator.SetInteger("Direction", 3);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < screenLimit.x) dir.x = 1;
            animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            dir.y = -1;
            animator.SetInteger("Direction", 0);
        }

        dir.Normalize();
        animator.SetBool("IsMoving", dir.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = speed * dir;
    }

    void Shoot()
    {
        if (Input.GetKey(KeyCode.Space) && shootTimer >= shootCD)
        {
            GameObject shoot = Instantiate(projectile);
            shoot.transform.position = transform.position + Vector3.right * shootDistance;
            shoot.transform.up = shootDirection.normalized;
            shoot.GetComponent<Rigidbody2D>().AddForce(shootDirection.normalized * shootSpeed);
            shootTimer = 0;
        }
    }

}
