using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port_Interaction : MonoBehaviour
{
    
    public List<GameObject> port;
    private GameObject[] portConnect;
    public int p1Value;
    public int p2Value;
    public GameObject p1;
    private bool p1IsSet = false;
    public GameObject p2;
    private bool p2IsSet = false;

    void Start()
    {
        portConnect = new GameObject[port.Count];    
    }

    public void connectP(GameObject po,GameObject pl)
    {
        if(!(p1IsSet || p2IsSet))
        {
            int index = port.IndexOf(po);
            portConnect[index] = pl;
            portConnect[index].transform.SetParent(po.transform);
            portConnect[index].transform.position = po.transform.position;
            portConnect[index].transform.rotation = po.transform.rotation;
            port[index].GetComponent<MeshRenderer>().enabled = false;
            port[index].GetComponent<Collider>().enabled = false;
        }
        
    }

}
