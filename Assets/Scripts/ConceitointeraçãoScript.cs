using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConceitointeraçãoScript : MonoBehaviour
{
    public Animator animator;
    public GameObject janela, bauAberto, bauFechado;
    bool playerInRange = false;
    int vez = 0;

    public void PopUp()
    {
        animator.SetTrigger("pop");
    }

    public void ClosePopUp()
    {
        animator.SetTrigger("close");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        janela.SetActive(true);
        playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerInRange = false;
        ClosePopUp();
        vez = 0;
    }

    public void GetInfo()
    {
        if (playerInRange)
        {
            bauAberto.SetActive(true);
            bauFechado.SetActive(false);
        }
    }
}
