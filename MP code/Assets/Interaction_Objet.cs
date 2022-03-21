using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Objet : MonoBehaviour

{
    public GameObject card;
    // Start is called before the first frame update
    void Start()
    {
        card.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnableCard()
    {
        card.SetActive(true);

    }
}
