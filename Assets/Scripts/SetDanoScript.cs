using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dano
{
    public int dano;

    public Dano(int dano)
    {
        this.dano = dano;
    }
}

public class SetDanoScript : MonoBehaviour
{
    [SerializeField]
    List<Dano> dano = new List<Dano>();
    [SerializeField]
    Dano d;

    int damage;

    void SalvarDano()
    {
        try
        {
            if (!System.IO.Directory.Exists(Application.dataPath + "/dano/"))
            {
                System.IO.Directory.CreateDirectory(Application.dataPath + "/dano/");
            }
            SerializableList<Dano> auxiliar = new SerializableList<Dano>();
            auxiliar.Lista = dano;
            string jsonData = JsonUtility.ToJson(auxiliar);
            System.IO.File.WriteAllText(Application.dataPath + "/dano/dano.json", jsonData);
            Debug.Log(jsonData);
            Debug.Log("Salvo em: " + Application.dataPath + "/dano/dano.json");
        }
        catch (System.Exception ex)
        {
            Debug.Log("Erro ao salvar: " + ex.ToString());
        }
    }

    void LoadDano()
    {
        try
        {

            if (!System.IO.Directory.Exists(Application.dataPath + "/dano/"))
            {
                System.IO.Directory.CreateDirectory(Application.dataPath + "/dano/");
            }
            string filePath = System.IO.Path.Combine(Application.dataPath + "/dano/dano.json");
            string data = System.IO.File.ReadAllText(filePath);
            SerializableList<Dano> aux = JsonUtility.FromJson<SerializableList<Dano>>(data);
            dano = aux.Lista;

            Debug.Log("Arquivo lido de: " + Application.dataPath + "/dano/dano.json");
        }
        catch (System.Exception ex)
        {
            Debug.Log("Erro ao ler: " + ex.ToString());
        }
    }

    public void SetDano(int damage)
    {
        LoadDano();
        d = dano[0];
        this.damage = damage;
        d.dano += this.damage;
        SalvarDano();
    }

    public int GetDano()
    {
        LoadDano();
        d = dano[0];
        damage = d.dano;
        return damage;
    }
}
