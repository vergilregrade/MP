using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objet_Main : MonoBehaviour
{
    // Start is called before the first frame update
    private bool playerCollision;
    private GameObject player;
    void Start()
    {
        playerCollision = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E ) && playerCollision == true) {
            
            player.GetComponent <Interaction_Objet>().EnableCard();
            Destroy(gameObject);

            }
    }

    void OnTriggerEnter(Collider other) {

        if (other.gameObject.tag == "Player") {

            player = other.gameObject;
            playerCollision = true;

        }

    }

    void OnTriggerExit(Collider other) {

        if (other.gameObject.tag == "Player") {

            playerCollision = false;

        }
    }

}
