using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MovementEnemyScript1 : MonoBehaviour
{
    SetFaseScript s;

    public float speed;
    Vector2 dir;
    public Image lifeBar;
    public TextMeshProUGUI lifeText;
    public int vida = 10;
    public int vidaMaxima = 10;
    public int damage = 1;
    public GameObject proxFase;
    int ativaQuiz = 0, vidaAntiga, hit = 0;
    public TextMeshProUGUI hitText;
    BoxCollider2D collide;
    int direcao;

    public Rigidbody2D rb;
    public Animator animator;
    public GameObject projectile, quiz;
    public float shootDistance = 1;
    public float shootSpeed = 300;
    public float shootCoolDown = .8f;
    float shootTimer = 0;
    Vector2 shootDirection = Vector2.left;

    private void Start()
    {
        Time.timeScale = 1;
        s = FindObjectOfType<SetFaseScript>();
        direcao = Random.Range(0, 4);
        switch (direcao)
        {
            case 0:
                dir.y = -1;
                dir.x = Eixo();
                animator.SetFloat("Horizontal", dir.x);
                animator.SetFloat("Vertical", dir.y);
                break;
            case 1:
                dir.x = -1;
                dir.y = Eixo();
                animator.SetFloat("Horizontal", dir.x);
                animator.SetFloat("Vertical", dir.y);
                break;
            case 2:
                dir.y = 1;
                dir.x = Eixo();
                animator.SetFloat("Horizontal", dir.x);
                animator.SetFloat("Vertical", dir.y);
                break;
            case 3:
                dir.x = 1;
                dir.y = Eixo();
                animator.SetFloat("Horizontal", dir.x);
                animator.SetFloat("Vertical", dir.y);
                break;
        }
        vida = vidaMaxima;
        UpdateUI();
        collide = gameObject.GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        shootTimer += Time.deltaTime;
        Movement(collide);
        Shoot();
        if(vida == 0)
        {
            Morrer();
        }
        Quiz();
    }
    void UpdateUI()
    {
        if(hit == 1) hitText.text = hit + " Hit";
        else hitText.text = hit + " Hits";
        lifeBar.fillAmount = (float)vida / vidaMaxima;
        lifeText.text = vida + "/" + vidaMaxima;
    }

    void Movement(Collider2D obj)
    {
        if (obj.GetType() == typeof(BoxCollider2D))
        {
            /*if (dir.x != 0)
            {
                transform.Translate(new Vector2(dir.x * speed * Time.deltaTime, 0));
            }
            if (dir.y != 0)
            {
                transform.Translate(new Vector2(0, dir.y * speed * Time.deltaTime));
            }*/
            animator.SetFloat("Horizontal", dir.x);
            animator.SetFloat("Vertical", dir.y);
            animator.SetFloat("Speed", dir.sqrMagnitude);

            if (transform.position.y > 2.6)
            {
                do
                {
                    direcao = Random.Range(0, 4);
                    //Debug.Log(direcao);
                } while (direcao == 2);
                switch (direcao)
                {
                    case 0:
                        dir.y = -1;
                        dir.x = Eixo();
                        break;
                    case 1:
                        dir.x = -1;
                        dir.y = Eixo();
                        break;
                    case 3:
                        dir.x = 1;
                        dir.y = Eixo();
                        break;
                }
                transform.position = new Vector2(transform.position.x, transform.position.y);
            }
            if (transform.position.y < -1.5)
            {
                do
                {
                    direcao = Random.Range(0, 4);
                    //Debug.Log(direcao);
                } while (direcao == 0);
                switch (direcao)
                {
                    case 1:
                        dir.x = -1;
                        dir.y = Eixo();
                        break;
                    case 2:
                        dir.y = 1;
                        dir.x = Eixo();
                        break;
                    case 3:
                        dir.x = 1;
                        dir.y = Eixo();
                        break;
                }
                transform.position = new Vector2(transform.position.x, transform.position.y);

            }
            if (transform.position.x < 1)
            {
                do
                {
                    direcao = Random.Range(0, 4);
                    //Debug.Log(direcao);
                } while (direcao == 1);

                switch (direcao)
                {
                    case 0:
                        dir.y = -1;
                        dir.x = Eixo();
                        break;
                    case 2:
                        dir.y = 1;
                        dir.x = Eixo();
                        break;
                    case 3:
                        dir.x = 1;
                        dir.y = Eixo();
                        break;
                }
                transform.position = new Vector2(transform.position.x, transform.position.y);
            }
            if (transform.position.x > 8)
            {
                do
                {
                    direcao = Random.Range(0, 4);
                } while (direcao == 3);
                switch (direcao)
                {
                    case 0:
                        dir.y = -1;
                        dir.x = Eixo();
                        break;
                    case 1:
                        dir.x = -1;
                        dir.y = Eixo();
                        break;
                    case 2:
                        dir.y = 1;
                        dir.x = Eixo();
                        break;
                }
                transform.position = new Vector2(transform.position.x, transform.position.y);
            }

            //GetComponent<Rigidbody2D>().velocity = speed * dir;
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + dir * speed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        if (shootTimer > shootCoolDown)
        {
            animator.SetTrigger("Attack");
            GameObject shoot = Instantiate(projectile);
            shoot.transform.position = transform.position + Vector3.left * shootDistance;
            shoot.transform.up = shootDirection.normalized;
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
            s.MudarFase();
            Morrer();
        }
        UpdateUI();
    }

    void Morrer()
    {
        if (!quiz.activeSelf)
        {
            Time.timeScale = 0;
            proxFase.SetActive(true);
        }
    }

    void Quiz()
    {
        if ((float)vida == (float)vidaMaxima * 0.2 && ativaQuiz == 0)
        {
            //Debug.Log("Entrou");
            Time.timeScale = 0;
            quiz.SetActive(true);
            ativaQuiz = 1;
            vidaAntiga = vida;
        }
        else if ((float)vida == (float)vidaMaxima * 0.4 && ativaQuiz == 0)
        {
            Time.timeScale = 0;
            quiz.SetActive(true);
            ativaQuiz = 1;
            vidaAntiga = vida;
        }
        else if ((float)vida == (float)vidaMaxima * 0.6 && ativaQuiz == 0)
        {
            Time.timeScale = 0;
            quiz.SetActive(true);
            ativaQuiz = 1;
            vidaAntiga = vida;
        }
        else if ((float)vida == (float)vidaMaxima * 0.8 && ativaQuiz == 0)
        {
            Time.timeScale = 0;
            quiz.SetActive(true);
            ativaQuiz = 1;
            vidaAntiga = vida;
        }
        else if ((float)vida == (float)vidaMaxima * 0.1 && ativaQuiz == 0)
        {
            Time.timeScale = 0;
            quiz.SetActive(true);
            ativaQuiz = 1;
            vidaAntiga = vida;
        }

        if (vidaAntiga != vida && (float)vida >= (float)vidaMaxima * 0.1)
        {
            ativaQuiz = 0;
        }
    }

    int Eixo()
    {
        return Random.Range(-1, 2);
    }
}
