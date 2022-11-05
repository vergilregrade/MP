using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intercat_pcb_s : MonoBehaviour
{
    public GameObject pcb;
    public Camera cam;

    private void Start()
    {
        cam.enabled = false;
    }
    public void setEnable(GameObject p)
    {
        //screen.GetComponent<ScreenInteraction>().SetEnable(p);
        this.GetComponent<pcb_s>().SetEnable(p);
        cam.enabled = true;
    }
    public void setCamEnable(bool b)
    {
        cam.enabled = b;
    }
}
