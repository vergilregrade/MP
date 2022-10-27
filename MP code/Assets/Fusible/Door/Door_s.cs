using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_s : MonoBehaviour
{
    public Animator anim;
    bool isOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Open()
    {
        anim.SetTrigger("open");
        print("ok");
        isOpen = true;
    }

    public void Close()
    {
        anim.SetTrigger("close");
        isOpen = false;
    }

    public bool changement_etat()
    {
        if(isOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
        print("change etat");
        return isOpen;
    }
}
