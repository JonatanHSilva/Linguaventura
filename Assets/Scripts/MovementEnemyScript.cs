using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemyScript : MonoBehaviour
{
    public float speed;
    public Vector2 screenLimit = new(4, 3);
    private Animator animator;
    int direction = 1;
    Vector2 posicao;

    public GameObject projectile;
    public float shootDistance = 1;
    public float shootSpeed = 300;
    public float shootCD = .8f;
    float shootTimer = 0;
    Vector2 shootDirection = Vector2.left;

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
        transform.Translate(new Vector2(0, direction * speed * Time.deltaTime));

        if (transform.position.y > 2)
        {
            direction *= -1;
            transform.position = (new Vector2(transform.position.x, Mathf.Sign(transform.position.y) * (screenLimit.y - 1)));
        }
        if (transform.position.y < -3)
        {
            direction *= -1;
            transform.position = (new Vector2(transform.position.x, Mathf.Sign(transform.position.y) * screenLimit.y));
        }

        if (direction == 1)
        {
            animator.SetInteger("Direction", 1);
        }
        if (direction == -1)
        {
            animator.SetInteger("Direction", 0);
        }

        /*
         * animator.SetInteger("Direction", 3);
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            animator.SetInteger("Direction", 2);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            
        }

        dir.Normalize()*/
        animator.SetBool("IsMoving", posicao.magnitude > 0);

        GetComponent<Rigidbody2D>().velocity = speed * posicao;
    }

    void Shoot()
    {
        if (shootTimer > shootCD)
        {
            GameObject shoot = Instantiate(projectile);
            shoot.transform.position = transform.position + Vector3.left * shootDistance;
            shoot.transform.up = shootDirection.normalized;
            shoot.GetComponent<Rigidbody2D>().AddForce(shootDirection.normalized * shootSpeed);
            shootTimer = 0;
        }
    }
}
