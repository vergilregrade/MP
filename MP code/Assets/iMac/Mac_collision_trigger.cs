using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mac_collision_trigger : MonoBehaviour
{
    //private bool playerCollision;
    //private GameObject player;
    public GameObject screen;
    public Camera cam;

    public void setScreenEnable(GameObject p)
    {
        screen.GetComponent<ScreenInteraction>().SetEnable(p);
        cam.enabled = true;
    }
    public void setCamEnable(bool b)
    {
        cam.enabled = b;
    }
    //void OnTriggerEnter(Collider other)
    //{

    //    if (other.gameObject.tag == "Player")
    //    {
    //        print("ok");
    //        player = other.gameObject;
    //        playerCollision = true;
    //        screen.GetComponent<ScreenInteraction>().setPlayerTriggerEnter(player);
    //    }

    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        playerCollision = false;
    //        screen.GetComponent<ScreenInteraction>().setPlayerTriggerEExit();
    //    }
    //}
}
