using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuisButtonsScript : MonoBehaviour
{
    QuisScript quis;
    MovementPlayerScript dano;
    MovementEnemyScript1 danoInimigo;
    
    // Start is called before the first frame update
    void Start()
    {
        quis = FindObjectOfType<QuisScript>();
        dano = FindObjectOfType<MovementPlayerScript>();
        danoInimigo = FindObjectOfType<MovementEnemyScript1>();
    }
    public void Clicked(bool certa)
    {
        if (certa)
        {
            danoInimigo.TakeDamage();
            quis.Certo();
        }

        else
        {
            dano.TakeDamage();
            quis.Errado();
        }
    }
}
