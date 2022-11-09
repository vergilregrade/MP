using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boitier_P_C_s : MonoBehaviour
{
    public int keyNeeded = 2;
    private bool isOpen = false;
    public Animator anim;

    public enum openSize { OPEN, BIGOPEN}
    public openSize my_type = openSize.OPEN;

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
        if(my_type == openSize.OPEN)
            anim.SetTrigger("open");
        else
            anim.SetTrigger("bigOpen");
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
