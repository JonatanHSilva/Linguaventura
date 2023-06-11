
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class SerializableList<T>
{
    public List<T> Lista;
}
[System.Serializable]
public class Pergunta
{
    public string pergunta = "";
    public string respostaCerta = "";
    public string respostaErradaA = "";
    public string respostaErradaB = "";
    public string respostaErradaC = "";
    public int qtdRespostas = 0;
    public Pergunta() { qtdRespostas = 2; }
    public Pergunta(string pergunta, string respostaCerta, string respostaErrada)
    {
        this.pergunta = pergunta;
        this.respostaCerta = respostaCerta;
        this.respostaErradaA = respostaErrada;
        qtdRespostas = 2;
    }
    public Pergunta(string pergunta, string respostaCerta, string respostaErradaA, string respostaErradaB)
    {
        this.pergunta = pergunta;
        this.respostaCerta = respostaCerta;
        this.respostaErradaA = respostaErradaA;
        this.respostaErradaB = respostaErradaB;
        qtdRespostas = 3;
    }
    public Pergunta(string pergunta, string respostaCerta, string respostaErradaA, string respostaErradaB, string respostaErradaC)
    {
        this.pergunta = pergunta;
        this.respostaCerta = respostaCerta;
        this.respostaErradaA = respostaErradaA;
        this.respostaErradaB = respostaErradaB;
        this.respostaErradaC = respostaErradaC;
        qtdRespostas = 4;
    }
}

[System.Serializable]
public class Resposta
{
    public string pergunta = "";
    public string respostaCerta = "";
    public int quantidadeErros = 0;
    public Resposta(string pergunta, string respostaCerta,int quantidadeErros)
    {
        this.pergunta = pergunta;
        this.respostaCerta = respostaCerta;
        this.quantidadeErros = quantidadeErros;

    }
}

public class QuisScript : MonoBehaviour
{
    public GameObject PainelRespostas, quiz;
    public TextMeshProUGUI Pergunta;

    public GameObject[] buttons;
    [SerializeField]
    public GameObject buttonCerto;
    [SerializeField]
    public GameObject buttonErrado;
    [SerializeField]
    public List<Pergunta> perguntas;
    public List<Pergunta> perguntasSelecionadas;
    [SerializeField]
    public List<Resposta> respostas = new List<Resposta>();
    Pergunta perguntaAtual;
    [SerializeField]
    public string ProximoLevel;
    [SerializeField]
    public string fileName;
    void Start()
    {
        LoadPerguntas();
        Random.InitState((int)(System.DateTime.Now.Second));
        SelecionarPergunta();
        IniciarButtons();
        SetResposta();
    }

    void Update()
    {
    }

    public bool SalvarPerguntas()
    {
        try
        {
            if (!System.IO.Directory.Exists(Application.dataPath + "/data/"))
            {
                System.IO.Directory.CreateDirectory(Application.dataPath + "/data/");
            }
            SerializableList<Pergunta> aux = new SerializableList<Pergunta>();
            aux.Lista = perguntas;
            string jsonData = JsonUtility.ToJson(aux);
            System.IO.File.WriteAllText(Application.dataPath + "/data/" + fileName + ".json", jsonData);
            Debug.Log(jsonData);
            Debug.Log("Salvo em: " + Application.dataPath + "/data/" + fileName + ".json");
            return true;
        }
        catch (System.Exception ex)
        {
            Debug.Log("Erro ao salvar: " + ex.ToString());
            return false;
        }
    }

    public bool LoadPerguntas()
    {
        try
        {

            if (!System.IO.Directory.Exists(Application.dataPath + "/data/"))
            {
                System.IO.Directory.CreateDirectory(Application.dataPath + "/data/");
            }
            string filePath = System.IO.Path.Combine(Application.dataPath + "/data/" + fileName + ".json");
            string data = System.IO.File.ReadAllText(filePath);
            SerializableList<Pergunta> aux = JsonUtility.FromJson<SerializableList<Pergunta>>(data);
            perguntas = aux.Lista;

            Debug.Log("Arquivo lido de: " + Application.dataPath + "/data/" + fileName + ".json");
            return true;
        }
        catch (System.Exception ex)
        {
            Debug.Log("Erro ao ler: " + ex.ToString());
            return false;
        }
    }

    public bool SalvarRespostas()
    {
        try
        {
            if (!System.IO.Directory.Exists(Application.dataPath + "/data/Respostas/"))
            {
                System.IO.Directory.CreateDirectory(Application.dataPath + "/data/Respostas/");
            }
            SerializableList<Resposta> aux = new SerializableList<Resposta>();
            aux.Lista = respostas;
            string jsonData = JsonUtility.ToJson(aux);
            System.IO.File.WriteAllText(Application.dataPath + "/data/Respostas/" + fileName + ".json", jsonData);
            Debug.Log(jsonData);
            Debug.Log("Salvo em: " + Application.dataPath + "/data/Respostas/" + fileName + ".json");
            return true;
        }
        catch (System.Exception ex)
        {
            Debug.Log("Erro ao salvar: " + ex.ToString());
            return false;
        }
    }

    private void SetResposta()
    {
        for (int i = 0; i < buttons.Length; i++) buttons[i].transform.SetParent(null);
        for (int i = 0; i < buttons.Length; i++)
        {

            GameObject temp = buttons[i];
            int r = Random.Range(i, buttons.Length);
            buttons[i] = buttons[r];
            buttons[r] = temp;
            buttons[i].transform.SetParent(PainelRespostas.transform);
        }
    }
    void SelecionarPergunta()
    {
        if (perguntas.Count == 0 || perguntas == null)
        {
            SalvarRespostas();
            //SceneManager.LoadScene(ProximoLevel);
            return;
        }
        
        perguntaAtual = perguntas[Random.Range(0, perguntas.Count)];
        perguntasSelecionadas.Add(perguntaAtual);
        perguntas.Remove(perguntaAtual);
        respostas.Add(new Resposta(perguntaAtual.pergunta,perguntaAtual.respostaCerta,0));
    }
    void IniciarButtons()
    {
        foreach (var button in buttons)
        {
            Destroy(button.gameObject);
        }
        buttons = new GameObject[perguntaAtual.qtdRespostas];
        buttons[0] = Instantiate(buttonCerto, PainelRespostas.transform);
        for (int i = 1; i < perguntaAtual.qtdRespostas; i++)
        {
            buttons[i] = Instantiate(buttonErrado, PainelRespostas.transform);
        }
        Pergunta.text = perguntaAtual.pergunta;
        buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = perguntaAtual.respostaCerta;
        buttons[1].GetComponentInChildren<TextMeshProUGUI>().text = perguntaAtual.respostaErradaA;
        if (perguntaAtual.qtdRespostas > 2)
        {
            buttons[2].GetComponentInChildren<TextMeshProUGUI>().text = perguntaAtual.respostaErradaB;
        }
        else
        {
            //buttons[2].SetActive(false); 
        }
        if (perguntaAtual.qtdRespostas > 3)
        {
            buttons[3].GetComponentInChildren<TextMeshProUGUI>().text = perguntaAtual.respostaErradaC;
        }
        else
        {
            //buttons[3].SetActive(false); 
        }

    }
    public void Certo()
    {
        quiz.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("Certo: " + perguntaAtual.respostaCerta);
        SelecionarPergunta();
        IniciarButtons();
        SetResposta();
    }
    public void Errado()
    {
        respostas[respostas.Count - 1].quantidadeErros++;
        SelecionarPergunta();
        IniciarButtons();
        SetResposta();
        Time.timeScale = 1;
        quiz.SetActive(false);
    }
}