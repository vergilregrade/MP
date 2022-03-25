using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cable_interact : MonoBehaviour
{
    public bool isGrab=true;
    public GameObject p1;
    public GameObject p2;
    public bool p1IsSet = false;
    public bool p2IsSet = false;
    public Collider GlobalCollider;
    // Start is called before the first frame update
    void Start()
    {
        setGlobalCollider(!isGrab);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setGlobalCollider(bool b)
    {
        GlobalCollider.enabled = b;
    }

    public void grabed()
    {
        setGlobalCollider(true);
        isGrab = true;
    }
    public bool isP1IsSet()
    {
        return p1IsSet;
    }
    public bool isP2IsSet()
    {
        return p2IsSet;
    }
    public GameObject setP1()
    {
        p1IsSet = true;
        if (p2IsSet)
            isGrab = false;
        return p1;
    }
    public GameObject setP2()
    {
        p2IsSet = true;
        if (p1IsSet)
            isGrab = false;
        return p2;
    }
    public bool isIsGrad()
    {
        return isGrab;
    }
}
