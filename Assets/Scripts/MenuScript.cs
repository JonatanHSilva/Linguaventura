using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    SetFaseScript s;
    // Start is called before the first frame update
    void Start()
    {
        s = FindObjectOfType<SetFaseScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pausa()
    {
        Time.timeScale = 1;
    }

    public void Jogar()
    {
        SceneManager.LoadScene("Jogo");
        //StartCoroutine(Jogo());
        Time.timeScale = 1; 
    }

    public void Fechar()
    {
        s.Reinicio();
        Time.timeScale = 1;
        StartCoroutine(WaitFechar());
    }

    public void VoltarMenu()
    {
        StartCoroutine(VoltarAoMenu());
        Time.timeScale = 1;
    }

    IEnumerator Jogo()
    {
        yield return new WaitForSecondsRealtime(.5f);
        SceneManager.LoadScene("Jogo");
    }


    IEnumerator VoltarAoMenu()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator WaitFechar()
    {
        yield return new WaitForSeconds(.5f);
        Application.Quit();
    }

    
}
