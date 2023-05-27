using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float tempo = 1;
    public GameObject explosion;
    public GameObject dissipate;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroySelf());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(tempo);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "Player" && this.tag != "MagiaPlayer")
        {
            if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);
            obj.GetComponent<MovementPlayerScript>().TakeDamage();
            Destroy(this.gameObject);
        }
        if (obj.tag == "Enemy" && this.tag != "MagiaInimigo")
        {
            if (explosion != null) Instantiate(explosion, transform.position, Quaternion.identity);
            obj.GetComponent<MovementEnemyScript>().TakeDamage();
            Destroy(this.gameObject);
        }

        if (obj.tag == "MagiaInimigo" || obj.tag == "MagiaPlayer")
        {
            if (dissipate != null) Instantiate(dissipate, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
    }
}
