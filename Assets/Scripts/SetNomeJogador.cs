using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public class Nome
{
    public string nome = "Jogador";

    public Nome(string nome)
    {
        this.nome = nome;
    }
}

public class SetNomeJogador : MonoBehaviour
{
    [SerializeField]
    List<Nome> nome = new List<Nome>();
    [SerializeField]
    Nome n;
    MenuScript m;

    bool click = false;

    public TMP_InputField nomePlayer;

    string nomeJogador;
    // Start is called before the first frame update
    void Start()
    {
        m = FindObjectOfType<MenuScript>();
        //LoadNome();
    }

    // Update is called once per frame
    void Update()
    {
        //MudarNome();
    }

    public void SetNome()
    {
        try
        {
            if (!System.IO.Directory.Exists(Application.dataPath + "/nome/"))
            {
                System.IO.Directory.CreateDirectory(Application.dataPath + "/nome/");
            }
            SerializableList<Nome> auxiliar = new SerializableList<Nome>();
            auxiliar.Lista = nome;
            string jsonData = JsonUtility.ToJson(auxiliar);
            System.IO.File.WriteAllText(Application.dataPath + "/nome/nomejogador.json", jsonData);
            Debug.Log(jsonData);
            Debug.Log("Salvo em: " + Application.dataPath + "/nome/nomejogador.json");
        }
        catch (System.Exception ex)
        {
            Debug.Log("Erro ao salvar: " + ex.ToString());
        }
    }

    public void LoadNome()
    {
        try
        {

            if (!System.IO.Directory.Exists(Application.dataPath + "/nome/"))
            {
                System.IO.Directory.CreateDirectory(Application.dataPath + "/nome/");
            }
            string filePath = System.IO.Path.Combine(Application.dataPath + "/nome/nomejogador.json");
            string data = System.IO.File.ReadAllText(filePath);
            SerializableList<Nome> aux = JsonUtility.FromJson<SerializableList<Nome>>(data);
            nome = aux.Lista;

            Debug.Log("Arquivo lido de: " + Application.dataPath + "/fase/fase.json");
        }
        catch (System.Exception ex)
        {
            Debug.Log("Erro ao ler: " + ex.ToString());
        }
    }

    public void MudarNome()
    {
        if(Input.GetButtonDown("Submit") || click == true)
        {
            if (nomePlayer.text != "")
            {
                n.nome = new(nomePlayer.text);
                nome.Add(n);
                SetNome();
            }
            else
            {
                n = new("Jogador");
                nome.Add(n);
                SetNome();
            }
            m.Jogar();
        }
    }

    public string GetNome()
    {
        LoadNome();
        n = nome[0];
        nomeJogador = n.nome;
        return nomeJogador;
    }

    public void clicked()
    {
        click = true;
    }
}
