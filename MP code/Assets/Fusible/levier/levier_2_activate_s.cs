using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levier_2_activate_s : MonoBehaviour
{
    public enum intercat { SERV, KEYDOOR};

    public intercat type = intercat.SERV;
    public bool precondition = true;
    public GameObject serveur;
    public GameObject keyDoor;

    private void Start()
    {
        if(type == intercat.KEYDOOR)
        {
            precondition = false;
        }
    }
    public void activate()
    {
        if(precondition)
            switch(type)
            {
                case intercat.SERV:
                    serveur.GetComponent<Port_Interaction>().activate();
                    break;
                case intercat.KEYDOOR:
                    keyDoor.GetComponent<Animator>().SetTrigger("open");
                    break;
            }
        
    }

    public void setPrecondition(bool b)
    {
        precondition = b;
    }
}
