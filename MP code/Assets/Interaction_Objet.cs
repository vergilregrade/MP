using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Objet : MonoBehaviour

{
    public GameObject card;
    private GameObject cable;
    //private bool cableGrab = false;
    public int CardValue = 0;

    private List<int> list_key;
    private int count_Fusible = 0;

    public GameObject model_cable;

    private bool _priseGrab = false;
    private GameObject _prise;

    public Dictionary<logic_slot_s.LOGIC, int> logicCount = new Dictionary<logic_slot_s.LOGIC, int>(){ 
        {logic_slot_s.LOGIC.AND,    0 }, 
        { logic_slot_s.LOGIC.OR,    0 },
        { logic_slot_s.LOGIC.NAND,  0 },
        { logic_slot_s.LOGIC.XOR,   0 }
    };

    Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        card.SetActive(false);
        list_key = new List<int>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray hitRay = new Ray(cam.transform.position, cam.transform.TransformDirection(Vector3.forward));
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 3, Color.red);

            //if (_priseGrab)
            //{
            //    _prise.GetComponent<Prise_Control>().setGrab(false);
            //    _prise = null;
            //    _priseGrab = false;
            //}
            //else


            if (Physics.Raycast(hitRay, out hit, 3))
            {
                print(hit.collider.name + " " + hit.collider.tag);
                if (_priseGrab)
                {



                    if (hit.collider.tag == "port")
                    {
                        GameObject c_port = hit.collider.gameObject;
                        GameObject c_parent = c_port.transform.parent.gameObject;
                        if (c_parent.gameObject.GetComponent<Port_Interaction>().PlugPrise(c_port, _prise))
                        {
                            _prise = null;
                            _priseGrab = false;
                        }

                        //_prise.gameObject.GetComponent<Prise_Control>().setGrab(true, c_port);
                    }
                    else
                    {
                        _prise.GetComponent<Prise_Control>().setGrab(false);
                        _prise = null;
                        _priseGrab = false;
                    }

                    return;
                }


                if (hit.collider.tag == "Key")
                {
                    //card.SetActive(true);
                    //CardValue = hit.collider.gameObject.GetComponent<Objet_Main>().getCartValue();
                    list_key.Add(hit.collider.gameObject.GetComponent<Objet_Main>().getCartValue());
                    Destroy(hit.collider.gameObject);

                }
                else if (hit.collider.tag == "Mac")
                {
                    hit.collider.gameObject.GetComponent<Mac_collision_trigger>().setScreenEnable(this.gameObject);
                    this.GetComponent<Move_Personnage>().setEnable(false);
                    this.GetComponent<Move_Personnage>().SetCamEnable(false);
                }
                else if (hit.collider.tag == "Digicode")
                {
                    hit.collider.gameObject.GetComponent<digicode_s>().setScreenEnable(this.gameObject);
                    this.GetComponent<Move_Personnage>().setEnable(false);
                    this.GetComponent<Move_Personnage>().SetCamEnable(false);
                }
                else if (hit.collider.tag == "Safe")
                {
                    //hit.collider.gameObject.GetComponent<Coffre_action>().PlayerInteract(this.gameObject);
                    foreach (int key in list_key)
                    {
                        hit.collider.gameObject.GetComponent<Coffre_action>().Try_Key(key);
                    }
                }
                else if (hit.collider.tag == "Fusible")
                {
                    count_Fusible++;
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.tag == "Fusible_door" || hit.collider.tag == "Casier")
                {
                    hit.collider.gameObject.GetComponent<Door_s>().changement_etat();
                }
                else if (hit.collider.tag == "Fusible_levier")
                {
                    hit.collider.gameObject.GetComponent<levier_s>().changement_etat();
                }
                else if (hit.collider.tag == "Fusible_place")
                {
                    if(count_Fusible > 0)
                    {
                        hit.collider.gameObject.GetComponent<fusible_s>().set_fusible();
                        count_Fusible--;
                    }
                }
                else if (hit.collider.tag == "port")
                {
                    if (!_priseGrab)
                    {
                        GameObject c_port = hit.collider.gameObject;
                        GameObject c_parent = c_port.transform.parent.gameObject;
                        _prise = c_parent.GetComponent<Port_Interaction>().UnplugPrise(c_port, card);
                        _priseGrab = _prise != null;
                    }
                }
                else if (hit.collider.tag == "grabedPrise")
                {
                    _priseGrab = true;
                    hit.collider.gameObject.GetComponent<Prise_Control>().setGrab(true, card);
                    _prise = hit.collider.gameObject;
                }
                else if(hit.collider.tag == "Boitier_Porte_C")
                {
                    if(list_key.Count == 0)
                    {
                        hit.collider.gameObject.GetComponent<boitier_P_C_s>().tryKey(-1);
                    }else
                    foreach (int key in list_key)
                    {
                        hit.collider.gameObject.GetComponent<boitier_P_C_s>().tryKey(key);
                    }
                }
                else if (hit.collider.tag == "pcb")
                {
                    hit.collider.gameObject.GetComponent<intercat_pcb_s>().setEnable(this.gameObject);
                    this.GetComponent<Move_Personnage>().setEnable(false);
                    this.GetComponent<Move_Personnage>().SetCamEnable(false);
                }
                else if(hit.collider.tag == "Logical_door")
                {
                    logicCount[hit.collider.gameObject.GetComponent<logicalDoor_drop_s>().mylogic] += 1;
                    Destroy(hit.collider.gameObject);
                }
                else if(hit.collider.tag == "Key_Door")
                {
                    hit.collider.gameObject.GetComponent<Animator>().SetTrigger("fail");
                }
            }
            else
            {
                if (_priseGrab)
                {
                    _prise.GetComponent<Prise_Control>().setGrab(false);
                    _prise = null;
                    _priseGrab = false;
                }
            }
        }
    }
    public void EnableCard()
    {
        card.SetActive(true);
    }
    public void DisableCard()
    {
        card.SetActive(false);
        CardValue = 0;
    }
    public void SetCard(int val) 
    {
        card.SetActive(true);
        CardValue = val;
    }
    public int getCardValue()
    {
        return CardValue;
    }

    public void edit_logicCount(logic_slot_s.LOGIC lo, int val)
    {
        if(lo != logic_slot_s.LOGIC._null_)
            logicCount[lo] += val;
    }
}
