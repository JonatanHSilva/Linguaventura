using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SelecionarFaseQuiz : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Quiz1()
    {
        Time.timeScale = 1;
        StartCoroutine(QuizFase1());
    }
    public void Quiz2()
    {
        Time.timeScale = 1;
        StartCoroutine(QuizFase2());
    }
    public void Quiz3()
    {
        Time.timeScale = 1;
        StartCoroutine(QuizFase3());
    }
    public void Quiz4()
    {
        Time.timeScale = 1;
        StartCoroutine(QuizFase4());
    }
    IEnumerator QuizFase1()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Set Quiz Level1");
    }

    IEnumerator QuizFase2()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Set Quiz Level2");
    }

    IEnumerator QuizFase3()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Set Quiz Level3");
    }

    IEnumerator QuizFase4()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Set Quiz Level4");
    }

}
