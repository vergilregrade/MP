using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class select_s : MonoBehaviour
{
    public logic_slot_s.LOGIC my_logic;
    public int quantity = 0;
    private bool is_select = false;
    void Start()
    {
        GetComponentInChildren<TextMeshPro>().text = my_logic.ToString() + " x"+ quantity.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        if(!is_select)
            GetComponent<Renderer>().material.color = Color.red;
    }


    private void OnMouseExit()
    {
        if(!is_select)
            GetComponent<Renderer>().material.color = Color.black;
    }

    private void OnMouseUpAsButton()
    {
        if(GetComponentInParent<pcb_s>().nothing_select())
        {
            GetComponentInParent<pcb_s>().setSelect(this.gameObject);
            is_select = true;
            GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    public logic_slot_s.LOGIC get_my_logic()
    {
        
        return my_logic;
    }

    public void sub(bool b)
    {
        if(!b)
            quantity -= 1;
        GetComponentInChildren<TextMeshPro>().text = my_logic.ToString() + " x" + quantity.ToString();
        is_select = false;
        GetComponent<Renderer>().material.color = Color.black;

    }

    public void add()
    {
        quantity += 1;
        GetComponentInChildren<TextMeshPro>().text = my_logic.ToString() + " x" + quantity.ToString();
    }
}
