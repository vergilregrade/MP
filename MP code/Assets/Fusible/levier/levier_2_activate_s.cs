using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levier_2_activate_s : MonoBehaviour
{
    public GameObject serveur;
    public void activate()
    {
        print("active");
        serveur.GetComponent<Port_Interaction>().activate();
    }
}
