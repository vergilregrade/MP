using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Port_comportement : MonoBehaviour
{
    public GameObject _light;
    public TextMeshPro _display;

    public bool is_online = false;
    private bool is_green = false;

    // Start is called before the first frame update
    void Start()
    {
        setIsGoodConnect(false);
        //_light_Materialk.SetColor("_Color", new Color(1, 0, 0));
    }

    // Update is called once per frame
    public void setIsGoodConnect(bool b)
    {
        is_green = b;
        if (is_online)
        {
            if (b) _light.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 1, 0));
            else _light.GetComponent<Renderer>().material.SetColor("_Color", new Color(1, 0, 0));
        }
        else
        {
            _light.GetComponent<Renderer>().material.SetColor("_Color", new Color(0.2f, 0.2f, 0.2f));
        }
    }
    public void setParent(GameObject parent)
    {
        transform.SetParent(parent.transform);
    }

    public void setText(string text)
    {
        _display.text = text;
    }
    public void set_online()
    {
        print("set color");
        is_online = true;
        if (is_green) _light.GetComponent<Renderer>().material.SetColor("_Color", new Color(0, 1, 0));
        else _light.GetComponent<Renderer>().material.SetColor("_Color", new Color(1, 0, 0));
    }
}
