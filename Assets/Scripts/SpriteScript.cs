using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpriteScript : MonoBehaviour
{
    int vez = 0;
    bool playerInRange = false;
    public GameObject panel;
    public Text text;
    public Button button;
    PopUpMessage pop1;
    SetFaseScript s;
    int fase;

    // Start is called before the first frame update
    void Start()
    {
        s = FindObjectOfType<SetFaseScript>();
        fase = s.GetFase();

        if(fase == 1)
        {
            text.text = "Deseja jogar a fase 1?";
            button.onClick.AddListener(Fase1);
        }else if(fase == 2)
        {
            text.text = "Deseja jogar a fase 2?";
            button.onClick.AddListener(Fase2);
        }else if(fase == 3)
        {
            text.text = "Deseja jogar a fase 3?";
            button.onClick.AddListener(Fase3);
        }
        else
        {
            text.text = "Deseja jogar a fase 4?";
            button.onClick.AddListener(Fase4);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        panel.SetActive(true);
        playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerInRange = false;
        pop1.ClosePopUp();
        vez = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (playerInRange == true)
        {
            if (vez == 0)
            {
                pop1.PopUp();
                vez++;
            }
        }*/
        if (GameObject.FindGameObjectWithTag("Level 1") && playerInRange)
        {
            if (vez == 0)
            {
                pop1 = GameObject.FindGameObjectWithTag("Level 1").GetComponent<PopUpMessage>();
                pop1.PopUp();
                vez++;
            }
        }

        
        if (GameObject.FindGameObjectWithTag("Level 2") && playerInRange)
        {
            if (vez == 0)
            {
                pop1 = GameObject.FindGameObjectWithTag("Level 2").GetComponent<PopUpMessage>();
                pop1.PopUp();
                vez++;
            }
        }

        if (GameObject.FindGameObjectWithTag("Level 3") && playerInRange)
        {
            if (vez == 0)
            {
                pop1 = GameObject.FindGameObjectWithTag("Level 3").GetComponent<PopUpMessage>();
                pop1.PopUp();
                vez++;
            }
        }

        if (GameObject.FindGameObjectWithTag("Level 4") && playerInRange)
        {
            if (vez == 0)
            {
                pop1 = GameObject.FindGameObjectWithTag("Level 4").GetComponent<PopUpMessage>();
                pop1.PopUp();
                vez++;
            }
        }
    }

    public void Fase1()
    {
        StartCoroutine(Level1());
    }

    public void Fase2()
    {
        StartCoroutine(Level2());
    }

    public void Fase3()
    {
        StartCoroutine(Level3());
    }

    public void Fase4()
    {
        StartCoroutine(Level4());
    }

    IEnumerator Level1()
    {
        yield return new WaitForSecondsRealtime(.5f);
        SceneManager.LoadScene("Level1");
    }

    IEnumerator Level2()
    {
        yield return new WaitForSecondsRealtime(.5f);
        SceneManager.LoadScene("Level2");
    }

    IEnumerator Level3()
    {
        yield return new WaitForSecondsRealtime(.5f);
        SceneManager.LoadScene("Level3");
    }
    IEnumerator Level4()
    {
        yield return new WaitForSecondsRealtime(.5f);
        SceneManager.LoadScene("Level4");
    }


}
