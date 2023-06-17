using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float tempo = 1;
    public GameObject explosion;
    public GameObject dissipate;
    MovementEnemyScript1 inimigo;
    MovementEnemyScript inimigo1;
    MovementPlayerScript player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<MovementPlayerScript>();
        inimigo = FindObjectOfType<MovementEnemyScript1>();
        inimigo1 = FindObjectOfType<MovementEnemyScript>();
        StartCoroutine(DestroySelf());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(tempo);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.CompareTag("Player") && !CompareTag("MagiaPlayer"))
        {
            if (obj.GetType() == typeof(CircleCollider2D))
            {
                if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);
                player.TakeDamage();
                Destroy(gameObject);
            }
        }
        else if (obj.CompareTag("Enemy") && !CompareTag("MagiaInimigo"))
        {
            if (obj.GetType() == typeof(CircleCollider2D))
            {
                if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);
                inimigo.TakeDamage();
                Destroy(gameObject);
            }
        }
        else if (obj.CompareTag("Enemy4") && !CompareTag("MagiaInimigo"))
        {
            if (obj.GetType() == typeof(CircleCollider2D))
            {
                if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);
                inimigo1.TakeDamage();
                Destroy(gameObject);
            }
        }
        else if (obj.CompareTag ("MagiaInimigo") || obj.CompareTag("MagiaPlayer"))
        {
            if (dissipate != null) Instantiate(dissipate, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
