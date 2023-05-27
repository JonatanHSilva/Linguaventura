using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuisButtonsScript : MonoBehaviour
{
    QuisScript quis;
    
    // Start is called before the first frame update
    void Start()
    {
        quis = FindObjectOfType<QuisScript>();
    }
    public void Clicked(bool certa)
    {
        if (certa)
        {
            quis.Certo();
        } 
            
        else quis.Errado();
    }
}
