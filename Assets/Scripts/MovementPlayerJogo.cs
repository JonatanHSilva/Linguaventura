using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerJogo : MonoBehaviour
{
    public float speed;
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprite;
    

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }


    private void Update()
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

    void ChangeSprite(Sprite updateSprite)
    {
        spriteRenderer.sprite = updateSprite;
    }
}

