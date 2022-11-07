using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class logic_slot_s : MonoBehaviour
{
    public GameObject in1 = null;
    public GameObject in2 = null;
    public GameObject[] out1 = null;
    public GameObject  loupiote = null;
    public Material on = null;
    public Material off = null;
    public Material nul = null;

    public bool a_supr = false;

    public enum LOGIC { AND, OR, NAND, XOR , NAN};

    public bool state = false;
    public bool logic_on = true;
    public LOGIC my_logic = LOGIC.AND;

    public GameObject master = null;
    

    // Start is called before the first frame update
    void Start()
    {
        change_color();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        this.GetComponent<Renderer>().material.color = Color.blue;
    }

    private void OnMouseExit()
    {
        this.GetComponent<Renderer>().material.color = Color.black;
    }
    private void OnMouseUp()
    {
        master.GetComponent<intercat_pcb_s>().start_loop();
    }

    private void change_color()
    {
        if(logic_on)
        {
            if(state)
            {
                loupiote.GetComponent<Renderer>().material = on;
            }
            else
            {
                loupiote.GetComponent<Renderer>().material = off;
            }
        }else
        {
            loupiote.GetComponent<Renderer>().material = nul;
        }
    }

    public void next_setrp(bool b,int ttl, GameObject previous)
    {
        if (ttl <= 0) { return; }
        //if (previous == in1)
        //{
        //    print("uwu1");
        //}
        //else if (previous == in2)
        //{
        //    print("uwu2");
        //}
        //else
        //{
        //    print("uwui");
        //}
        bool one,two;
        if(in1.GetComponent<inOut_s>() != null) { one = in1.GetComponent<inOut_s>().etat; }
        else { one = in1.GetComponent<logic_slot_s>().state; }

        if (in2.GetComponent<inOut_s>() != null) { two = in2.GetComponent<inOut_s>().etat; }
        else { two = in2.GetComponent<logic_slot_s>().state; }


        //print(my_logic);
        switch(my_logic)
        {
            case LOGIC.AND:
                state = one && two;
                break;
            case LOGIC.OR:
                state = one || two;
                break;
            case LOGIC.XOR:
                state = one ^ two;
                break;
            case LOGIC.NAND:
                state = !(one && two);
                break;
        }

        change_color();
        if(a_supr)
            print(one.ToString() + " "+ two.ToString() + " "+state.ToString() +" "+ this.name);

        foreach(var elem in out1)
        {
            if (elem.GetComponent<inOut_s>() != null) { elem.GetComponent<inOut_s>().next_setrp(state,ttl-1,this.gameObject); }
            else if(elem.GetComponent<logic_slot_s>() != null) { elem.GetComponent<logic_slot_s>().next_setrp(state,ttl-1,this.gameObject); }
        }

    }
}
