using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMessage : MonoBehaviour
{
    public Animator animator;
    int set;

    public void PopUp()
    {
        animator.SetTrigger("pop");
        set = 0;
    }

    public void ClosePopUp()
    {
        animator.SetTrigger("close");
        set = 1;
    }

    public bool Pop()
    {
        if (set == 1) return true;
        else return false;
    }
}