using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class inOut_s : MonoBehaviour
{
    public enum INOUT { IN, OUT};

    public INOUT type;
    public bool etat = false;

    public Material on;
    public Material off;

    public GameObject[] outs;

    // Start is called before the first frame update
    void Start()
    {
        if(etat)
        {
            this.GetComponent<Renderer>().material = on;
        }else
        {
            this.GetComponent<Renderer>().material = off;
        }
    }

    // Update is called once per frame
    public void next_setrp(bool b,int ttl,GameObject previous)
    {
        if (ttl <= 0) { return; }
        if (type == INOUT.IN)
        {
            foreach (GameObject next in outs)
            {
                if (next.GetComponent<logic_slot_s>() != null)
                {
                    next.GetComponent<logic_slot_s>().next_setrp(etat, ttl - 1, this.gameObject);
                }
            }
        }else
        {
            etat = b;
            if (etat)
            {
                this.GetComponent<Renderer>().material = on;
            }
            else
            {
                this.GetComponent<Renderer>().material = off;
            }
            if(b)
                transform.parent.gameObject.transform.parent.GetComponent<intercat_pcb_s>().triggerOut();
        }
    }
}
