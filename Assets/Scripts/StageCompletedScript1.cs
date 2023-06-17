using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCompletedScript1 : MonoBehaviour
{
    public GameObject[] PortaoAFase;
    public GameObject[] PortaoFFase;

    SetFaseScript setFase;

    int fase;
    // Start is called before the first frame update
    void Start()
    {
        setFase = FindObjectOfType<SetFaseScript>();
        fase = setFase.GetFase();
        switch (fase)
        {
            case 1:
                PortaoAFase[0].SetActive(true);
                PortaoFFase[0].SetActive(false);
                break;
            case 2:
                PortaoAFase[1].SetActive(true);
                PortaoFFase[1].SetActive(false);
                break;
            case 3:
                PortaoAFase[2].SetActive(true);
                PortaoFFase[2].SetActive(false);
                break;
            case 4:
                PortaoAFase[3].SetActive(true);
                PortaoFFase[3].SetActive(false);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
