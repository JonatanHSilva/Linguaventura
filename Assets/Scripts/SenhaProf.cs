using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

[Serializable]
public class Senha
{
    public string senha = "";

    public Senha(string senha)
    {
        this.senha = senha;
    }
}

public class SenhaProf : MonoBehaviour
{
    [SerializeField]
    List<Senha> senha = new List<Senha>();
    [SerializeField]
    Senha s;
    public TMP_InputField password;
    public TMP_InputField changePassword;
    public TMP_InputField matchedPassword;
    public GameObject areaProf, senhaCorreta;
    public Text mensagem;
    public Button botao;
    bool click = false;
    int campo = 1;

    private void Start()
    {
        LoadSenha();
    }

    private void Update()
    {
        botao.onClick.AddListener(clicked);
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            campo++;
            if(campo == 4)
            {
                campo = 1;
            }
        }

        switch (campo)
        {
            case 1:
                password.Select();
                break;
            case 2:
                changePassword.Select();
                break;
            case 3:
                matchedPassword.Select();
                break;
        }
    }


    public bool SetSenha()
    {
        try
        {
            if (!System.IO.Directory.Exists(Application.dataPath + "/senha/"))
            {
                System.IO.Directory.CreateDirectory(Application.dataPath + "/senha/");
            }
            SerializableList<Senha> auxiliar = new SerializableList<Senha>();
            auxiliar.Lista = senha;
            string jsonData = JsonUtility.ToJson(auxiliar);
            System.IO.File.WriteAllText(Application.dataPath + "/senha/senha.json", jsonData);
            Debug.Log(jsonData);
            Debug.Log("Salvo em: " + Application.dataPath + "/senha/senha.json");
            return true;
        }
        catch (System.Exception ex)
        {
            Debug.Log("Erro ao salvar: " + ex.ToString());
            return false;
        }
    }

    public bool LoadSenha()
    {
        try
        {

            if (!System.IO.Directory.Exists(Application.dataPath + "/senha/"))
            {
                System.IO.Directory.CreateDirectory(Application.dataPath + "/senha/");
            }
            string filePath = System.IO.Path.Combine(Application.dataPath + "/senha/senha.json");
            string data = System.IO.File.ReadAllText(filePath);
            SerializableList<Senha> aux = JsonUtility.FromJson<SerializableList<Senha>>(data);
            senha = aux.Lista;

            Debug.Log("Arquivo lido de: " + Application.dataPath + "/senha/senha.json");
            return true;
        }
        catch (Exception ex)
        {
            Debug.Log("Erro ao ler: " + ex.ToString());
            return false;
        }
    }

    public void VerificarSenha()
    {
        LoadSenha();
        s = senha[0];
        if (Input.GetButtonDown("Submit") || click == true)
        {
            if (password.text == s.senha)
            {
                areaProf.SetActive(false);
                senhaCorreta.SetActive(true);
                password.text = "";
                Erase();
            }
            else
            {
                password.text = "";
                mensagem.text = "Senha Incorreta. Tente Novamente.";
                Invoke("Erase", 5);
            }
            click = false;
        }
    }

    public void AlterarSenha()
    {
        s = senha[0];
        if(Input.GetButtonDown("Submit") || click == true)
        {
            if (password.text != s.senha)
            {
                mensagem.text = "Senha Atual Incorreta. Tente Novamente.";
                Invoke("Erase", 5);
            }
            else if(password.text == changePassword.text)
            {
                mensagem.text = "Digite uma senha diferente da atual.";
                Invoke("Erase", 5);
            }
            else
            {
                if (changePassword.text != matchedPassword.text)
                {
                    mensagem.text = "Senhas nao conferem. Digite novamente.";
                    Invoke("Erase", 5);
                }
                else if (changePassword.text != "")
                {
                    s.senha = changePassword.text;
                    SetSenha();
                    areaProf.SetActive(false);
                    senhaCorreta.SetActive(true);
                    changePassword.text = "";
                    password.text = "";
                    matchedPassword.text = "";
                    Erase();
                }
                else
                {
                    mensagem.text = "Digite uma nova senha.";
                    Invoke("Erase", 5);
                }
            }

            
        }
    }
    
    void clicked()
    {
        click = true;
    }

    void Erase()
    {
        mensagem.text = "";
    }
}
