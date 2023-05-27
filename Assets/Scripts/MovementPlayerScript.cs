using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MovementPlayerScript : MonoBehaviour
{
    public float speed;
    public Vector2 screenLimit = new(-4, 5);
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprite;
    public Image lifeBar;
    public TextMeshProUGUI lifeText;
    public int vida = 10;
    public int vidaMaxima = 10;
    public int damage = 1;
    public GameObject perdeu, menu;
    bool pause = false;

    public GameObject projectile;
    public float shootDistance = 1;
    public float shootSpeed = 300;
    public float shootCD = .5f;
    float shootTimer = 0;
    Vector2 shootDirection = Vector2.right;
    //public GameObject explosion;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        vida = vidaMaxima;
        UpdateUI();
    }


    private void Update()
    {
        shootTimer += Time.deltaTime;
        Shoot();
        Movement();
        if (Input.GetKey(KeyCode.Escape))
        {
            pause = !pause;
            if (pause)
            {
                Time.timeScale = 0;
                menu.SetActive(true);
            }
        }
    }

    void UpdateUI()
    {
        lifeBar.fillAmount = (float)vida / vidaMaxima;
        lifeText.text = vida + "/" + vidaMaxima;
    }

    void Movement()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            dir.x = -1;
            spriteRenderer.flipX = true;
            ChangeSprite(sprite[0]);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            dir.x = 1;
            spriteRenderer.flipX = false;
            ChangeSprite(sprite[1]);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            dir.y = 1;
            ChangeSprite(sprite[2]);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            dir.y = -1;
            ChangeSprite(sprite[3]);
        }

        dir.Normalize();

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


    void ChangeSprite(Sprite updateSprite)
    {
        spriteRenderer.sprite = updateSprite;
    }

    void Morrer()
    {
        vida = vidaMaxima;
        Time.timeScale = 0;
        //int oldScore = PlayerPrefs.GetInt("Score");
        //int newScore = (int)gameTimer + score;
        /*if (newScore >= oldScore)
        {
            PlayerPrefs.SetInt("Score", newScore);
        }
        if (newScoreText != null)
            newScoreText.text = "Sua Pontuação: " + newScore.ToString() + "\nPontuação Máxima: " + PlayerPrefs.GetInt("Score");*/
        perdeu.SetActive(true);
        transform.position = new Vector2(-8, 0);
    }
}
