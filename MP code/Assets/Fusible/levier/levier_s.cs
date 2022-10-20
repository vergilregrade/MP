using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levier_s : MonoBehaviour
{
    public Animator anim;
    private bool isDown = false;
    private bool fusibleSet = false;

    public GameObject[] toEnable;
    

    private void Start()
    {
        foreach (GameObject obj in toEnable)
        {
            obj.SetActive(false);
        }
    }
    public void fail()
    {
        anim.SetTrigger("fail");
        isDown = false;
    }
    public void down()
    {
        anim.SetTrigger("down");
        foreach (GameObject obj in toEnable)
        {
            obj.SetActive(true);
        }
        this.GetComponent<levier_2_activate_s>().activate();
        isDown = true;
    }
    public bool changement_etat()
    {
        if (!fusibleSet)
        {
            fail();
        }
        else if(!isDown)
        {
            down();
        }
        return isDown;
    }
    public void set_fusible_on()
    {
        fusibleSet = true;
    }

}
