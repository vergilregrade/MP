using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class pcb_s : MonoBehaviour
{
    private GameObject player;
    private bool enable = false;
    private GameObject logic_selected = null;

    public GameObject addSelect;
    public GameObject orSelect;
    public GameObject nandSelect;
    public GameObject xorSelect;

    // Update is called once per frame
    void Update()
    {
        if (enable)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                enable = false;
                player.GetComponent<Move_Personnage>().setEnable(true);
                player.GetComponent<Move_Personnage>().SetCamEnable(true);
                this.GetComponent<intercat_pcb_s>().setCamEnable(false);
                return;
            }
        }
    }

    public void SetEnable(GameObject p)
    {
        player = p;
        enable = true;
        addSelect.GetComponent<select_s>().quantity = p.GetComponent<Interaction_Objet>().logicCount[logic_slot_s.LOGIC.AND];
        addSelect.GetComponent<select_s>().updateText();
        orSelect.GetComponent<select_s>().quantity = p.GetComponent<Interaction_Objet>().logicCount[logic_slot_s.LOGIC.OR];
        orSelect.GetComponent<select_s>().updateText();
        nandSelect.GetComponent<select_s>().quantity = p.GetComponent<Interaction_Objet>().logicCount[logic_slot_s.LOGIC.NAND];
        nandSelect.GetComponent<select_s>().updateText();
        xorSelect.GetComponent<select_s>().quantity = p.GetComponent<Interaction_Objet>().logicCount[logic_slot_s.LOGIC.XOR];
        xorSelect.GetComponent<select_s>().updateText();
    }

    public bool nothing_select()
    {
        return logic_selected == null;
    }

    public logic_slot_s.LOGIC GetLOGIC_select()
    {
        if (logic_selected == null)
            return logic_slot_s.LOGIC._null_;
        return logic_selected.GetComponent<select_s>().get_my_logic();
    }

    public void logic_clique(bool b = false)
    {


        if (logic_selected != null)
        { 
            logic_selected.GetComponent<select_s>().sub(b);
            player.GetComponent<Interaction_Objet>().edit_logicCount(logic_selected.GetComponent<select_s>().my_logic, 1);
        }
        logic_selected = null;

        
    }

    public void setSelect(GameObject obj)
    {
        logic_selected = obj;
    }

    public void freeAnd()
    {
        addSelect.GetComponent<select_s>().add();
    }

    public void freelogic(logic_slot_s.LOGIC lo)
    {
        switch (lo)
        {
            case logic_slot_s.LOGIC.AND:
                addSelect.GetComponent<select_s>().add();
                break;
            case logic_slot_s.LOGIC.OR:
                orSelect.GetComponent<select_s>().add();
                break;
            case logic_slot_s.LOGIC.NAND:
                nandSelect.GetComponent<select_s>().add();
                break;
            case logic_slot_s.LOGIC.XOR:
                xorSelect.GetComponent<select_s>().add();
                break;
        }
        player.GetComponent<Interaction_Objet>().edit_logicCount(lo, 1);
    }

    
}
