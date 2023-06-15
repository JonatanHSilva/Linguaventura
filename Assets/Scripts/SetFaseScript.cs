using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Fase
{
    public int fase = 1;

    public Fase(int fase)
    {
        this.fase = fase;
    }
}

public class SetFaseScript : MonoBehaviour
{
    [SerializeField]
    List<Fase> fase = new List<Fase>();
    [SerializeField]
    Fase f;

    int stage;

    // Start is called before the first frame update
    void Start()
    {
        //SetFase();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SetFase()
    {
        try
        {
            if (!System.IO.Directory.Exists(Application.dataPath + "/fase/"))
            {
                System.IO.Directory.CreateDirectory(Application.dataPath + "/fase/");
            }
            SerializableList<Fase> auxiliar = new SerializableList<Fase>();
            auxiliar.Lista = fase;
            string jsonData = JsonUtility.ToJson(auxiliar);
            System.IO.File.WriteAllText(Application.dataPath + "/fase/fase.json", jsonData);
            Debug.Log(jsonData);
            Debug.Log("Salvo em: " + Application.dataPath + "/fase/fase.json");
            return true;
        }
        catch (System.Exception ex)
        {
            Debug.Log("Erro ao salvar: " + ex.ToString());
            return false;
        }
    }

    public bool LoadFase()
    {
        try
        {

            if (!System.IO.Directory.Exists(Application.dataPath + "/fase/"))
            {
                System.IO.Directory.CreateDirectory(Application.dataPath + "/fase/");
            }
            string filePath = System.IO.Path.Combine(Application.dataPath + "/fase/fase.json");
            string data = System.IO.File.ReadAllText(filePath);
            SerializableList<Fase> aux = JsonUtility.FromJson<SerializableList<Fase>>(data);
            fase = aux.Lista;

            Debug.Log("Arquivo lido de: " + Application.dataPath + "/fase/fase.json");
            return true;
        }
        catch (System.Exception ex)
        {
            Debug.Log("Erro ao ler: " + ex.ToString());
            return false;
        }
    }

    public void MudarFase()
    {
        LoadFase();
        f = fase[0];
        stage = f.fase;
        stage++;
        f.fase = stage;
        SetFase();
    }

    public int GetFase()
    {
        LoadFase();
        f = fase[0];
        stage = f.fase;
        return stage;
    }

    public void Reinicio()
    {
        LoadFase();
        f = fase[0];
        stage = f.fase;
        stage = 1;
        f.fase = stage;
        SetFase();
    }
}
