using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpriteScript : MonoBehaviour
{
    int vez = 0;
    bool playerInRange = false;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerInRange = false;
        canvas.SetActive(false);
        vez = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Level 1") && playerInRange)
        {
            if(vez == 0) canvas.SetActive(true);
            PopUpMessage pop1 = GameObject.FindGameObjectWithTag("Level 1").GetComponent<PopUpMessage>();
            pop1.PopUp();
            vez++;
        }

        
        if (GameObject.FindGameObjectWithTag("Level 2") && playerInRange)
        {
            if (vez == 0) canvas.SetActive(true);
            PopUpMessage pop2 = GameObject.FindGameObjectWithTag("Level 2").GetComponent<PopUpMessage>();
            pop2.PopUp();
            vez++;
        }

        if (GameObject.FindGameObjectWithTag("Level 3") && playerInRange)
        {
            if (vez == 0) canvas.SetActive(true);
            PopUpMessage pop3 = GameObject.FindGameObjectWithTag("Level 3").GetComponent<PopUpMessage>();
            pop3.PopUp();
            vez++;
        }

    }

    public void Fase1()
    {
        StartCoroutine(Fase());
        Time.timeScale = 1;
    }

    IEnumerator Fase()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Level1");
    }

    
}
