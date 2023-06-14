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
    [SerializeField]
    public TMP_InputField password;
    [SerializeField]
    public TMP_InputField changePassword;
    public TMP_InputField matchedPassword;
    public GameObject areaProf, senhaCorreta;
    public Text mensagem;
    int ok = 0;

    private void Start()
    {
        LoadSenha();
    }

    private void Update()
    {
        
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
        s = senha[0];

        if (password.text == s.senha)
        {
            areaProf.SetActive(false);
            senhaCorreta.SetActive(true);
            password.text = "";
        }
        else
        {
            password.text = "";
            mensagem.text = "Senha Incorreta. Tente Novamente.";
            Hide();
        }
    }

    public void AlterarSenha()
    {
        s = senha[0];
        if(password.text != s.senha)
        {
            mensagem.text = "Senha Atual Incorreta. Tente Novamente.";
        }
        else
        {
            ok++;
        }

        if(changePassword.text != matchedPassword.text)
        {
            mensagem.text = "Senhas nao conferem. Digite novamente.";
        }

        else if(ok == 1)
        {
            s.senha = changePassword.text;
            SetSenha();
            areaProf.SetActive(false);
            senhaCorreta.SetActive(true);
        }
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(5);
        mensagem.text = "";
    }
    
}
