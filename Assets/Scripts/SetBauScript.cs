using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bau
{
    public int indice, aberto;

    public Bau(int indice, int aberto)
    {
        this.indice = indice;
        this.aberto = aberto;
    }
}

public class SetBauScript : MonoBehaviour
{
    [SerializeField]
    List<Bau> baus;
    [SerializeField]
    Bau bau;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SaveBau()
    {
        try
        {
            if (!System.IO.Directory.Exists(Application.dataPath + "/bau/"))
            {
                System.IO.Directory.CreateDirectory(Application.dataPath + "/bau/");
            }
            SerializableList<Bau> auxiliar = new SerializableList<Bau>();
            auxiliar.Lista = baus;
            string jsonData = JsonUtility.ToJson(auxiliar);
            System.IO.File.WriteAllText(Application.dataPath + "/bau/bau.json", jsonData);
            Debug.Log(jsonData);
            Debug.Log("Salvo em: " + Application.dataPath + "/bau/bau.json");
        }
        catch (System.Exception ex)
        {
            Debug.Log("Erro ao salvar: " + ex.ToString());
        }
    }

    void LoadBau()
    {
        try
        {

            if (!System.IO.Directory.Exists(Application.dataPath + "/bau/"))
            {
                System.IO.Directory.CreateDirectory(Application.dataPath + "/bau/");
            }
            string filePath = System.IO.Path.Combine(Application.dataPath + "/bau/bau.json");
            string data = System.IO.File.ReadAllText(filePath);
            SerializableList<Bau> aux = JsonUtility.FromJson<SerializableList<Bau>>(data);
            baus = aux.Lista;

            Debug.Log("Arquivo lido de: " + Application.dataPath + "/bau/bau.json");
        }
        catch (System.Exception ex)
        {
            Debug.Log("Erro ao ler: " + ex.ToString());
        }
    }
    public void SetBau(int indice)
    {
        LoadBau();
        bau = baus[indice];
        bau.aberto = 1;
        SaveBau();
    }

    public int GetBau(int indice)
    {
        LoadBau();
        bau = baus[indice];
        return bau.aberto;
    }

    public void ResetBau()
    {
        baus = new List<Bau>();
        for (int i = 0; i < 12; i++)
        {
            bau = new(i, 0);
            baus.Add(bau);
        }
        SaveBau();
    }

    private void OnApplicationQuit()
    {
        ResetBau();
    }
}
