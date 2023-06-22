using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BauAbertoScript : MonoBehaviour
{
    public Animator animator, animator1;
    public GameObject janela, bauAbertoA, bauFechado, mensagem;
    public float timeFechar;
    bool playerInRange = false;
    int vez = 0, fechouTela = 0, fechou = 0, inputVez = 0;
    int abriuMensagem = 0, entrou = 0;
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
            Fechar();
            if (vez == 0)
            {
                PopUpBauAberto();
                vez++;
            }
        }

        if(entrou == 1) Fechar();

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
                janela.SetActive(false);
                fechouTela = 2;
            }
        }


        if(fechou == 1)
        {
            timeFechado += Time.deltaTime;
            if (timeFechado > timeFechar)
            {
                mensagem.SetActive(false);
                bauFechado.SetActive(false);          
            }
        }
    }

    public void PopUpBauAberto()
    {
        animator.SetTrigger("pop");
    }

    public void ClosePopUpAberto()
    {
        animator.SetTrigger("close");
        bauAbertoA.SetActive(true);
        fechouTela = 1;
    }

    public void PopUpMensagem()
    {
        animator1.SetTrigger("pop");
        dano += d.GetDano();
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
        entrou = 1;
    }


    void Fechar()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            if (fechouTela == 0) ClosePopUpAberto();
            if (inputVez == 1) ClosePopUpMensagem();
            inputVez++;
        }
    }
}
