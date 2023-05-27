using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerguntaUIScript : MonoBehaviour
{
    public TMP_InputField perguntaIF, respostaCertaIF, respostaErradaAIF, respostaErradaBIF, respostaErradaCIF;
     
    public Pergunta pergunta;
    public Button deleteBtn, salvarBtn, btn2, btn3, btn4;
    public GameObject respostaErradaBObj, respostaErradaCObj;

    // Start is called before the first frame update
    void Start()
    {
        deleteBtn.onClick.AddListener(Delete);
        salvarBtn.onClick.AddListener(Salvar);
        btn2.onClick.AddListener(Btn1);
        btn3.onClick.AddListener(Btn2);
        btn4.onClick.AddListener(Btn3);
        AtualizarPergunta(pergunta);

    }

    // Update is called once per frame
    void Update()
    {
        pergunta.pergunta = perguntaIF.text;
        pergunta.respostaCerta = respostaCertaIF.text;
        pergunta.respostaErradaA = respostaErradaAIF.text;
        pergunta.respostaErradaB = respostaErradaBIF.text;
        pergunta.respostaErradaC = respostaErradaCIF.text;
        if (pergunta.qtdRespostas >= 3)
        {
            respostaErradaBObj.SetActive(true);
        }
        else
        {
            respostaErradaBObj.SetActive(false);
        }
        if (pergunta.qtdRespostas >= 4)
        {
            respostaErradaCObj.SetActive(true);
        }
        else
        {
            respostaErradaCObj.SetActive(false);
        }
        //AtualizarPergunta(pergunta);

    }
    public void AtualizarPergunta(Pergunta novaPergunta = null)
    {
        if (novaPergunta != null)
        {
            pergunta = novaPergunta;
            perguntaIF.text = pergunta.pergunta;
            respostaCertaIF.text = pergunta.respostaCerta;
            respostaErradaAIF.text = pergunta.respostaErradaA;
            respostaErradaBIF.text = pergunta.respostaErradaB;
            respostaErradaCIF.text = pergunta.respostaErradaC;
        }
    }
    void Btn1()
    {
        pergunta.qtdRespostas = 2;
    }
    void Btn2()
    {
        pergunta.qtdRespostas = 3;
    }
    void Btn3()
    {
        pergunta.qtdRespostas = 4;
    }
    void Delete()
    {
        Destroy(this.gameObject);
    }
    void Salvar()
    {
        Debug.Log("Salvar");
    }
}
