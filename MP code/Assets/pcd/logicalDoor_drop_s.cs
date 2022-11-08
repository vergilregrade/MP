using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class logicalDoor_drop_s : MonoBehaviour
{
    public logic_slot_s.LOGIC mylogic;
    void Start()
    {
        GetComponentInChildren<TextMeshPro>().text = mylogic.ToString();
        GetComponentInChildren<TextMeshPro>().fontSize = 3;
    }
}
