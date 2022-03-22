using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tableau : MonoBehaviour
{
    public GameObject postCimac;

    // Start is called before the first frame update
    void Start()
    {
        postCimac.SetActive(false);
    }

    public void setActiveCimac(bool b)
    {
        postCimac.SetActive(b);
    }
}
