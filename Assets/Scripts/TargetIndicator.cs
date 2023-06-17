using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public Transform[] fases;
    SetFaseScript f;
    public float esconder;

    int fase;
    // Start is called before the first frame update
    void Start()
    {
        f = FindObjectOfType<SetFaseScript>();
        fase = f.GetFase();
    }

    // Update is called once per frame
    void Update()
    {
        if (fase == 1)
        {
            var dir = fases[0].position - transform.position;
            if(dir.magnitude < esconder)
            {
                SetActive(false);
            }
            else
            {
                SetActive(true);

                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
            
        }
        else if (fase == 2)
        {
            var dir = fases[1].position - transform.position;
            if (dir.magnitude < esconder)
            {
                SetActive(false);
            }
            else
            {
                SetActive(true);

                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        else if (fase == 3)
        {
            var dir = fases[2].position - transform.position;
            if (dir.magnitude < esconder)
            {
                SetActive(false);
            }
            else
            {
                SetActive(true);

                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
        else if(fase == 4)
        {
            var dir = fases[3].position - transform.position;
            if (dir.magnitude < esconder)
            {
                SetActive(false);
            }
            else
            {
                SetActive(true);

                var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }

    void SetActive(bool value)
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }
}
