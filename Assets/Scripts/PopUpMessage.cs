using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpMessage : MonoBehaviour
{
    public Animator animator;

    public void PopUp()
    {
        animator.SetTrigger("pop");
    }

    public void ClosePopUp()
    {
        animator.SetTrigger("close");
    }
}
