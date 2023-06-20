using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConceitointeraçãoScript : MonoBehaviour
{
    public Animator animator;
    public GameObject janela, bauAberto, bauFechado;
    public float timeFechar;
    int vez = 0, fechou = 0, time = 0;

    void Update()
    {
        if(fechou == 1)
        {
            time += Time.deltaTime;
            if(time > timeFechar)
            {
                janela.SetActive(false);
            }
    }
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            ClosePopUp();
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
        bauFechado.SetActive(false);
        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        janela.SetActive(true);
        vez = 1;
        GetInfo();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        //ClosePopUp();
    }

    public void GetInfo()
    {
        if (vez == 1)
        {
            Time.timeScale = 0;
            PopUp();
        }
    }
}
