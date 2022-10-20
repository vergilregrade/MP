using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fusible_s : MonoBehaviour
{
    public GameObject levier;
    void Start()
    {
        this.GetComponent<MeshRenderer>().enabled = false;
    }

    public void set_fusible()
    {
        this.GetComponent<MeshRenderer>().enabled = true;
        levier.GetComponent<levier_s>().set_fusible_on();
    }
    
}
