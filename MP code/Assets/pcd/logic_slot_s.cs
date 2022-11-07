using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using TMPro;

public class logic_slot_s : MonoBehaviour
{
    public GameObject in1 = null;
    public GameObject in2 = null;
    public GameObject[] out1 = null;
    public GameObject  loupiote = null;
    public Material on = null;
    public Material off = null;
    public Material nul = null;

    public enum LOGIC { AND, OR, NAND, XOR , _null_};

    public bool state = false;
    public bool logic_on = false;
    public LOGIC my_logic = LOGIC.AND;

    public GameObject master = null;

    public bool toPrint = false;
    

    // Start is called before the first frame update
    void Start()
    {
        print("logic on " + logic_on.ToString());
        change_color();
        upd_text();
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
        var selected = GetComponentInParent<pcb_s>().GetLOGIC_select();
        if(selected == LOGIC._null_)
        {
            switch(my_logic)
            {
                case LOGIC.AND:
                    GetComponentInParent<pcb_s>().freeAnd();
                    break;
            }
        }
        bool sameLogic = selected == my_logic;


        logic_on = selected != LOGIC._null_;
        my_logic = selected;
        change_color();
        upd_text();
        if (logic_on)
        {
            master.GetComponent<intercat_pcb_s>().start_loop();
        }
        GetComponentInParent<pcb_s>().logic_clique(sameLogic);
    }

    private void change_color()
    {
        if (toPrint) print("logic state" + logic_on.ToString());
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


        foreach(var elem in out1)
        {
            if (elem.GetComponent<inOut_s>() != null) { elem.GetComponent<inOut_s>().next_setrp(state,ttl-1,this.gameObject); }
            else if(elem.GetComponent<logic_slot_s>() != null) { elem.GetComponent<logic_slot_s>().next_setrp(state,ttl-1,this.gameObject); }
        }

    }

    public void upd_text()
    {
        this.GetComponentInChildren<TextMeshPro>().text = my_logic.ToString();
    }
}
