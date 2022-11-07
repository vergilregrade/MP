using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intercat_pcb_s : MonoBehaviour
{
    public GameObject pcb;
    public Camera cam;
    public GameObject inter;

    public GameObject[] startModule;

    private void Start()
    {
        cam.enabled = false;
        inter.SetActive(false);
    }
    public void setEnable(GameObject p)
    {
        //screen.GetComponent<ScreenInteraction>().SetEnable(p);
        this.GetComponent<pcb_s>().SetEnable(p);
        //cam.enabled = true;
        //this.GetComponent<BoxCollider>().enabled = false;
        setCamEnable(true);
    }
    public void setCamEnable(bool b)
    {
        cam.enabled = b;
        this.GetComponent<BoxCollider>().enabled = !b;
        inter.SetActive(b);

        if (Cursor.lockState == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    
    public void start_loop()
    {
        foreach(var elem in startModule)
        {
            elem.GetComponent<inOut_s>().next_setrp(true,255,this.gameObject);
        }
    }


}
