using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuisEditScript : QuisScript
{
    public GameObject perguntaUIPrefab;
    public GameObject painel;
    public Button novaPerguntaBtn, salvarBtn, voltarBtn;
    public string sceneToLoad;
    List<GameObject> perguntasUI = new List<GameObject>();
    public Scrollbar scroll;
    // Start is called before the first frame update
    void Start()
    {
        salvarBtn.onClick.AddListener(Salvar);
        novaPerguntaBtn.onClick.AddListener(NovaPergunta);
        voltarBtn.onClick.AddListener(Voltar);
        Load();
        //Add();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void NovaPergunta()
    {
        var novaPergunta = Instantiate(perguntaUIPrefab, painel.transform);
        novaPergunta.GetComponent<PerguntaUIScript>().AtualizarPergunta(new Pergunta());
        perguntasUI.Add(novaPergunta);
        StartCoroutine(WaitScroll());
    }
    IEnumerator WaitScroll()
    {
        yield return new WaitForSeconds(.3f);
        scroll.value = ((float)1/(perguntasUI.Count))/3.3f;
    }
    void Salvar()
    {
        perguntas = new List<Pergunta>();
        foreach(var pergunta in perguntasUI)
        {
            if(pergunta != null)
                perguntas.Add(pergunta.GetComponent<PerguntaUIScript>().pergunta);
        }
        SalvarPerguntas();
    }
    void Load()
    {
        LoadPerguntas();
        foreach(var pergunta in perguntas)
        {
            var novaPergunta = Instantiate(perguntaUIPrefab,painel.transform);
            novaPergunta.GetComponent<PerguntaUIScript>().AtualizarPergunta(pergunta);
            perguntasUI.Add(novaPergunta);
        }
    }
    void Voltar()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
    
}
