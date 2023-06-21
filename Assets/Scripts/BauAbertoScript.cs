using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BauAbertoScript : MonoBehaviour
{
    public Animator animator, animator1;
    public GameObject janela, bauAberto, bauFechado, mensagem;
    public float timeFechar;
    bool playerInRange = false;
    int vez = 0, fechouTela = 0, fechou = 0;
    int abriuMensagem = 0;
    float time = 0, timeFechado = 0;
    public int dano;
    SetDanoScript d;

    private void Start()
    {
        d = FindObjectOfType<SetDanoScript>();   
    }

    void Update()
    {
        if (playerInRange)
        {
            if (vez == 0)
            {
                PopUp();
                vez++;
            }
        }

        if(fechouTela == 1)
        {
            if(abriuMensagem == 0)
            {
                mensagem.SetActive(true);
                PopUpMensagem();
                abriuMensagem = 1;
            }
            
            time += Time.deltaTime;
            if(time > timeFechar)
            {
                bauFechado.SetActive(false);
                janela.SetActive(false);
                fechouTela = 2;
            }
        }


        if(fechou == 1)
        {
            Debug.Log("A");
            timeFechado += Time.deltaTime;
            if (timeFechado > timeFechar)
            {
                mensagem.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (fechouTela == 0) ClosePopUp();
            if (abriuMensagem == 1) ClosePopUpMensagem();
        } 
    }

    public void PopUp()
    {
        animator.SetTrigger("pop");
    }

    public void ClosePopUp()
    {
        animator.SetTrigger("close");
        bauAberto.SetActive(true);
        fechouTela = 1;
    }

    public void PopUpMensagem()
    {
        animator1.SetTrigger("pop");
        d.SetDano(dano);
    }

    public void ClosePopUpMensagem()
    {
        animator1.SetTrigger("close");
        fechou = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        janela.SetActive(true);
        playerInRange = true;
    }
}
