using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerJogo : MonoBehaviour
{
    public float speed;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprite;
    bool pause = false;
    public GameObject menu;
    

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Time.timeScale = 1;
    }


    private void Update()
    {
        Vector2 direction = Vector2.zero;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction.x = -1;
            spriteRenderer.flipX = true;
            ChangeSprite(sprite[0]);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction.x = 1;
            spriteRenderer.flipX = false;
            ChangeSprite(sprite[1]);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction.y = 1;
            ChangeSprite(sprite[2]);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction.y = -1;
            ChangeSprite(sprite[3]);
        }

        direction.Normalize();

        GetComponent<Rigidbody2D>().velocity = speed * direction;

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

    void ChangeSprite(Sprite updateSprite)
    {
        spriteRenderer.sprite = updateSprite;
    }
}

