using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConceitointeraçãoScript : MonoBehaviour
{
    public Animator animator;
    public GameObject janela, bauAberto, bauFechado;
    public float timeFechar;
    public int indice;
    bool playerInRange = false;
    int vez = 0, fechou = 0, entrou = 0;
    float time = 0;
    SetBauScript b;

    private void Start()
    {
        b = FindObjectOfType<SetBauScript>();
        BauFechado();
    }

    void Update()
    {
        if (playerInRange)
        {
            Fechar();
            if (vez == 0)
            {
                PopUp();
                vez++;
            }
        }

        if (entrou == 1) Fechar();

        if(fechou == 1)
        {
            time += Time.deltaTime;
            if(time > timeFechar)
            {
                bauFechado.SetActive(false);
                janela.SetActive(false);
            }
        }
    }

    public void PopUp()
    {
        animator.SetTrigger("pop");
    }

    public void ClosePopUp()
    {
        animator.SetTrigger("close");
        fechou = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        janela.SetActive(true);
        bauAberto.SetActive(true);
        playerInRange = true;
        AbriuBau();
        entrou = 1;
    }

    void Fechar()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            ClosePopUp();
        }
    }

    void BauFechado()
    {
        if(b.GetBau(indice) == 1)
        {
            bauAberto.SetActive(true);
            bauFechado.SetActive(false);
        }
    }

    void AbriuBau()
    {
        b.SetBau(indice);
    }
}
