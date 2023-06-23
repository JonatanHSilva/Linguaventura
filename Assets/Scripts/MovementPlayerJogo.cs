using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MovementPlayerJogo : MonoBehaviour
{
    public float speed;
    bool pause = false;
    public GameObject menu, mensagem, painel, proxPainel, msgVitoria;
    public Rigidbody2D rb;
    public Animator animator, vitoria;
    Vector2 direction;
    SetNomeJogador s;
    SetFaseScript f;
    int fase, prox = 0, acabou = 0;
    float time = 0;

    public TextMeshProUGUI nome;
    

    private void Start()
    {
        s = FindObjectOfType<SetNomeJogador>();
        f = FindObjectOfType<SetFaseScript>();
        fase = f.GetFase();
        if(fase == 1)
        {
            mensagem.SetActive(true);
        }
        if(fase == 5)
        {
            
            msgVitoria.SetActive(true);
        }
        Time.timeScale = 1;
        nome.text = s.GetNome();
    }


    private void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        direction.Normalize();

        animator.SetFloat("Horizontal", direction.x);
        animator.SetFloat("Vertical", direction.y);
        animator.SetFloat("Speed", direction.sqrMagnitude);

        if(fase == 1)
        {
            if(prox == 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                {
                    painel.SetActive(false);
                    proxPainel.SetActive(true);
                    prox = 1;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
                {
                    proxPainel.SetActive(false);
                }

            }
        }
        else if(fase == 5)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                vitoria.SetTrigger("close");
                acabou = 1;
            }
            if(acabou == 1)
            {
                time += Time.deltaTime;
                if (time > 1) VoltarMenu();
            }
        }
        

        if (Input.GetButtonDown("Cancel"))
        {
            Pausa();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }

    void VoltarMenu()
    {
        f.Reinicio();
        StartCoroutine(Menu());
    }

    IEnumerator Menu()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Menu");
    }

    public void Pausa()
    {
        pause = !pause;
        if (pause)
        {
            menu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (pause == false)
        {
            menu.SetActive(false);
            Time.timeScale = 1;
        }
    }

    void OnApplicationPause(bool saiu){ 
         if(saiu) Pausa(); 
    }
}

