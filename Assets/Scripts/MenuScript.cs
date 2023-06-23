using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    SetFaseScript s;
    MovementPlayerScript p;
    SetDanoScript d;
    SetBauScript b;
    // Start is called before the first frame update
    void Start()
    {
        d = FindObjectOfType<SetDanoScript>();
        p = FindObjectOfType<MovementPlayerScript>();
        s = FindObjectOfType<SetFaseScript>();
        b = FindObjectOfType<SetBauScript>();
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
        StartCoroutine(Jogo());
    }

    public void Fechar()
    {
        s.Reinicio();
        d.SetDano(10);
        b.ResetBau();
        StartCoroutine(WaitFechar());
    }

    public void VoltarMenu()
    {
        s.Reinicio();
        d.SetDano(10);
        b.ResetBau();
        StartCoroutine(VoltarAoMenu());
    }

    public void Fase1()
    {
        StartCoroutine(Level1());
    }

    public void Fase2()
    {
        StartCoroutine(Level2());
    }

    public void Fase3()
    {
        StartCoroutine(Level3());
    }

    public void Fase4()
    {
        StartCoroutine(Level4());
    }

    IEnumerator Level1()
    {
        yield return new WaitForSecondsRealtime(.5f);
        SceneManager.LoadScene("Level1");
    }

    IEnumerator Level2()
    {
        yield return new WaitForSecondsRealtime(.5f);
        SceneManager.LoadScene("Level2");
    }

    IEnumerator Level3()
    {
        yield return new WaitForSecondsRealtime(.5f);
        SceneManager.LoadScene("Level3");
    }
    IEnumerator Level4()
    {
        yield return new WaitForSecondsRealtime(.5f);
        SceneManager.LoadScene("Level4");
    }


    IEnumerator Jogo()
    {
        yield return new WaitForSecondsRealtime(.5f);
        SceneManager.LoadScene("Jogo");
    }


    IEnumerator VoltarAoMenu()
    {
        yield return new WaitForSecondsRealtime(.5f);
        SceneManager.LoadScene("Menu");
    }

    IEnumerator WaitFechar()
    {
        yield return new WaitForSecondsRealtime(.5f);
        Application.Quit();
    }

    public void FecharPause()
    {
        p.menu.SetActive(false);
        p.SetPause();
        Time.timeScale = 1;
    }

    void OnApplicationQuit(){
        s.Reinicio();
        d.SetDano(10);
        b.ResetBau();
    }
}
