using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Port_comportement : MonoBehaviour
{
    public GameObject _light;
    public TextMeshPro _display;

    // Start is called before the first frame update
    void Start()
    {
        setIsGoodConnect(false);
        //_light_Materialk.SetColor("_Color", new Color(1, 0, 0));
    }

    // Update is called once per frame
    public void setIsGoodConnect(bool b)
    {
        if(b) _light.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 1, 0));
        else _light.GetComponent<Renderer>().material.SetColor("_Color", new Color(1, 0, 0));
    }
    public void setParent(GameObject parent)
    {
        transform.SetParent(parent.transform);
    }

    public void setText(string text)
    {
        _display.text = text;
    }
}
