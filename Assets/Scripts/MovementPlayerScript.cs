using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MovementPlayerScript : MonoBehaviour
{
    public float speed;
    public Vector2 screenLimit = new(-4, 5);
    public Animator animator;
    public Image lifeBar;
    public TextMeshProUGUI lifeText, nome;
    public int vida = 10;
    public int vidaMaxima = 10;
    public int damage = 10;
    public GameObject perdeu, menu;
    bool pause = false, morto = false;
    public GameObject quiz;
    public TextMeshProUGUI hitText;
    int hit = 0;
    SetNomeJogador s;
    

    Vector2 direction;
    public Rigidbody2D rb;
    BoxCollider2D collide;
    public GameObject projectile;
    public float shootDistance = 1;
    public float shootSpeed = 300;
    public float shootCD = .5f;
    float shootTimer = 0;
    Vector2 shootDirection = Vector2.right;
    //public GameObject explosion;

    private void Start()
    {
        s = FindObjectOfType<SetNomeJogador>();
        collide = gameObject.GetComponent<BoxCollider2D>();
        nome.text = s.GetNome();
        vida = vidaMaxima;
        UpdateUI();
    }


    private void Update()
    {
        shootTimer += Time.deltaTime;
        Shoot();
        Movement(collide);
        if (Input.GetButtonDown("Cancel"))
        {
            pause = !pause;
            if (pause && !quiz.activeSelf && !morto)
            {
                menu.SetActive(true);
                Time.timeScale = 0;
            }
            else if (quiz.activeSelf)
            {
                menu.SetActive(false);
                Time.timeScale = 0;
            }
            else if (!morto)
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

    void UpdateUI()
    {
        if (hit == 1) hitText.text = hit + " Hit";
        else hitText.text = hit + " Hits";
        lifeBar.fillAmount = (float)vida / vidaMaxima;
        lifeText.text = vida + "/" + vidaMaxima;
    }


    void Movement(Collider2D obj)
    {
        if(obj.GetType() == typeof(BoxCollider2D))
        {
            direction.x = Input.GetAxisRaw("Horizontal");
            direction.y = Input.GetAxisRaw("Vertical");
            direction.Normalize();

            if (transform.position.x > screenLimit.x)
            {
                transform.position = new Vector3(screenLimit.x, transform.position.y);
            }
            if(transform.position.y > 2.5)
            {
                transform.position = new Vector3(transform.position.x, 2.5f);
            }

            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Speed", direction.sqrMagnitude);
        }
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Jump") && shootTimer >= shootCD)
        {
            animator.SetTrigger("Attack");
            GameObject shoot = Instantiate(projectile);
            shoot.transform.position = transform.position + Vector3.right * shootDistance;
            shoot.GetComponent<Rigidbody2D>().AddForce(shootDirection.normalized * shootSpeed);
            shootTimer = 0;
        }
    }

    public void TakeDamage()
    {

        if (damage < 0)
            return;
        if (vida - damage > 0)
        {
            vida -= damage;
            hit++;
        }
        else
        {
            vida = 0;
            Morrer();
        }
        UpdateUI();
    }


    void Morrer()
    {
        if (!quiz.activeSelf)
        {
            morto = true;
            Time.timeScale = 0;
            perdeu.SetActive(true);
        }
    }

    public void SetPause()
    {
        pause = !pause;
    }
}
