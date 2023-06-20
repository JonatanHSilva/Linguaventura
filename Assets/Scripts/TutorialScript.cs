using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
{
    public GameObject tutorial;
    bool click;
    // Start is called before the first frame update
    void Start()
    {
        tutorial.SetActive(true);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || click)
        {
            tutorial.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Clicked()
    {
        click = true;
    }
}
