using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Objet : MonoBehaviour

{
    public GameObject card;
    public int CardValue = 0;
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
    public void DisableCard()
    {
        card.SetActive(false);
        CardValue = 0;
    }
    public void SetCard(int val) 
    {
        card.SetActive(true);
        CardValue = val;
    }
    public int getCardValue()
    {
        return CardValue;
    }
}
