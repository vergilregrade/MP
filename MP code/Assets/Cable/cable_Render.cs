using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cable_Render : MonoBehaviour
{
    //public GameObject ligneRender;
    public GameObject l_render ;
    public GameObject[] cubes;
    
    // Start is called before the first frame update
    void Start()
    {

        l_render.GetComponent<LineRenderer>().positionCount = cubes.Length;
        for (int i = 0; i < cubes.Length; i++)
        {
            l_render.GetComponent<LineRenderer>().SetPosition(i, cubes[i].transform.localPosition);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i =0;i<cubes.Length;i++)
        {
            l_render.GetComponent<LineRenderer>().SetPosition(i, cubes[i].transform.localPosition); 
        }
    }
}
