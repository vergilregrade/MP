using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffre_action : MonoBehaviour
{
    public Animator anim;
    private bool isOpen = false;

    //private bool playerCollision;
    //private GameObject player;

    public int CardValue = 1;
    public GameObject kirbo;
    public GameObject tableau;

    public void Open()
    {
        anim.speed = 1;
        anim.SetTrigger("open");
        isOpen = true;
    }

    public void Close()
    {
        kirbo.SetActive(false);
        anim.speed = 1;
        anim.SetTrigger("close");
        isOpen = false;
        tableau.GetComponent<Tableau>().setActiveCimac(true);
    }

    public bool IsOpen()
    {
        return isOpen;
    }

    public void PlayerInteract(GameObject player)
    {
        if (isOpen)
        {
            Close();
            isOpen = false;
        }
        else
        {
            if (player.GetComponent<Interaction_Objet>().getCardValue() == CardValue)
            {
                Open();
                player.GetComponent<Interaction_Objet>().DisableCard();
                isOpen = true;
            }

        }
    }
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E) && playerCollision)
        //{
        //    if (isOpen)
        //    {
        //        Close();
        //        isOpen = false;
        //    }
        //    else
        //    {
        //        if(player.GetComponent<Interaction_Objet>().getCardValue() == CardValue)
        //        {
        //            Open();
        //            player.GetComponent<Interaction_Objet>().DisableCard();
        //            isOpen = true;
        //        }
                
        //    }
            
        //}
    }

    //void OnTriggerEnter(Collider other)
    //{

    //    if (other.gameObject.tag == "Player")
    //    {
    //        player = other.gameObject;
    //        playerCollision = true;
    //    }

    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        playerCollision = false;
    //    }
    //}
}
