using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jogar()
    {
        StartCoroutine(Jogo());
        Time.timeScale = 1;
    }

    public void AreaProf()
    {
        Time.timeScale = 1;
        StartCoroutine(AreaP());
    }
    public void Fechar()
    {
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
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Jogo");
    }

    IEnumerator AreaP()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("AreaProf");
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
