using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MovementEnemyScript : MonoBehaviour
{
    public float speed;
    public Vector2 screenLimit = new(4, 3);
    int direction = -1;
    Vector2 posicao;
    public Image lifeBar;
    public TextMeshProUGUI lifeText;
    public int vida = 10, vidaAntiga;
    public int vidaMaxima = 10;
    public int damage = 1;
    public GameObject proxFase;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprite;
    int vez = 0, ativaQuiz = 0;

    public GameObject projectile, quiz;
    public float shootDistance = 1;
    public float shootSpeed = 300;
    public float shootCD = .8f;
    float shootTimer = 0;
    Vector2 shootDirection = Vector2.left;

    private void Start()
    {
        vida = vidaMaxima;
        UpdateUI();
    }


    private void Update()
    {
        shootTimer += Time.deltaTime;
        Movement();
        Shoot();
        Quiz();
    }
    void UpdateUI()
    {
        lifeBar.fillAmount = (float)vida / vidaMaxima;
        lifeText.text = vida + "/" + vidaMaxima;
    }

    void Movement()
    {
        transform.Translate(new Vector2(0, direction * speed * Time.deltaTime));

        if(direction == -1 && vez == 0)
        {
            ChangeSprite(sprite[0]);
            vez++;
        }
        if (transform.position.y > 2.5)
        {
            direction *= -1;
            ChangeSprite(sprite[0]);
            transform.position = (new Vector2(transform.position.x, transform.position.y));
        }
        if (transform.position.y < -1.8)
        {
            direction *= -1;
            ChangeSprite(sprite[1]);
            transform.position = (new Vector2(transform.position.x, transform.position.y));
        }

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

    void ChangeSprite(Sprite updateSprite)
    {
        spriteRenderer.sprite = updateSprite;
    }

    public void TakeDamage()
    {
        if (this.damage < 0)
            return;
        if (vida - this.damage > 0)
            vida -= this.damage;
        else
        {
            vida = 0;
            Morrer();
        }
        UpdateUI();
    }

    void Morrer()
    {
        Time.timeScale = 0;
        proxFase.SetActive(true);
        
        /*try
        {
            //FindObjectOfType<MovementPlayerScript>().AddScore(scoreBonus);
        }
        catch { }*/
        
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
        else if (vida == 1 && ativaQuiz == 0)
        {
            Time.timeScale = 0;
            quiz.SetActive(true);
            ativaQuiz = 1;
            vidaAntiga = vida;
        }

        if(vidaAntiga != vida)
        {
            ativaQuiz = 0;
        }
    }
}
