using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Port_Interaction : MonoBehaviour
{
    
    public List<GameObject> _port;
    private GameObject[] _portConnect;
    private bool[] _portPluged;

    public Vector2Int[] _pair2set;

    void Start()
    {
        _portConnect = new GameObject[_port.Count];
        _portPluged = new bool[_port.Count];
        for(int i=0;i<_port.Count;i++)
        {
            _portPluged[i] = false;
        }
    }

    public bool PlugPrise(GameObject port,GameObject prise)
    {
        int index = _port.IndexOf(port);
        print("index port :" + index.ToString() + " used ? " + _portPluged[index].ToString());
        if (_portPluged[index]) return false;
        _portPluged[index] = true;
        prise.GetComponent<Prise_Control>().setGrab(true, port);
        _portConnect[index] = prise;
        _port[index].GetComponent<MeshRenderer>().enabled = false;
        //_port[index].GetComponent<Collider>().enabled = false;

        foreach(Vector2Int elem in _pair2set)
        {
            if((index==elem.x && _portPluged[elem.y]) || (index == elem.y && _portPluged[elem.x]))
            {
                if(_portConnect[elem.x].transform.parent == _portConnect[elem.y].transform.parent)
                {
                    print("ca marche !!!");
                }
            }
        }

        return true;

    }

    public GameObject UnplugPrise(GameObject port,GameObject player)
    {
        int index = _port.IndexOf(port);
        if (!_portPluged[index]) return null;

        GameObject prisePlayer = _portConnect[index];
        _portConnect[index] = null;
        prisePlayer.GetComponent<Prise_Control>().setGrab(true, player);
        _port[index].GetComponent<MeshRenderer>().enabled = true;
        _portPluged[index] = false;
        return prisePlayer;
    }

}
