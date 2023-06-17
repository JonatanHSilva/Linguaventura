using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuisButtonsScript : MonoBehaviour
{
    QuisScript quis;
    SetFaseScript s;
    MovementPlayerScript dano;
    MovementEnemyScript1 danoInimigo;
    MovementEnemyScript danoInimigo1;
    
    // Start is called before the first frame update
    void Start()
    {
        s = FindObjectOfType<SetFaseScript>();
        quis = FindObjectOfType<QuisScript>();
        dano = FindObjectOfType<MovementPlayerScript>();
        danoInimigo = FindObjectOfType<MovementEnemyScript1>();
        danoInimigo1 = FindObjectOfType<MovementEnemyScript>();
    }
    public void Clicked(bool certa)
    {
        if (certa)
        {
            if(s.GetFase() == 4)
            {
                danoInimigo1.TakeDamage();
            }
            else
            {
                danoInimigo.TakeDamage();
            }
            quis.Certo();
        }

        else
        {
            dano.TakeDamage();
            quis.Errado();
        }
    }
}
