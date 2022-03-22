using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction_Objet : MonoBehaviour

{
    public GameObject card;
    public int CardValue = 0;

    Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        card.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray hitRay = new Ray(cam.transform.position, cam.transform.TransformDirection(Vector3.forward));
            Debug.DrawRay(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 3, Color.red);
            if (Physics.Raycast(hitRay, out hit, 3))
            {
                print(hit.collider.tag);
                if (hit.collider.tag == "Key")
                {
                    card.SetActive(true);
                    CardValue = hit.collider.gameObject.GetComponent<Objet_Main>().getCartValue();
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.tag == "Mac")
                {
                    hit.collider.gameObject.GetComponent<Mac_collision_trigger>().setScreenEnable(this.gameObject);
                    this.GetComponent<Move_Personnage>().setEnable(false);
                    this.GetComponent<Move_Personnage>().SetCamEnable(false);
                }
                else if (hit.collider.tag == "Safe")
                {
                    hit.collider.gameObject.GetComponent<Coffre_action>().PlayerInteract(this.gameObject);
                }
            }
        }
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
