using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boitier_P_C_s : MonoBehaviour
{
    public int keyNeeded = 2;
    private bool isOpen = false;
    public Animator anim;

    public bool tryKey(int key)
    {
        if(key == keyNeeded && !isOpen)
        {
            Open();
            return true;
        }
        if(!isOpen)
        {
            Fail();
        }
        return false;
    }

    private void Open()
    {
        anim.SetTrigger("open");
        isOpen = true;
    }
    private void Close()
    {
        anim.SetTrigger("close");
        isOpen = false;
    }
    private void Fail()
    {
        anim.SetTrigger("fail");
    }
}
