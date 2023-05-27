using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public static LevelScript Instance;
    public GameObject canvas;
    // Start is called before the first frame update
    void Awake()
    { 
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
