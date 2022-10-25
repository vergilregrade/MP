using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class digicode_s : MonoBehaviour
{
    public Camera cam;
    public TextMeshPro textDisplay;
    public string code = "3621";
    public GameObject door;

    bool enable = false;
    GameObject player;

    void Start()
    {
        cam.enabled = false;
        textDisplay.text = "";
    }
    void Update()
    {
        if (enable)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                enable = false;
                player.GetComponent<Move_Personnage>().setEnable(true);
                player.GetComponent<Move_Personnage>().SetCamEnable(true);
                cam.enabled = false;
                return;
            }
            string input = Input.inputString;
            if(input.Length != 0)
            {
                if(input[0] >= '0' && input[0] <= '9')
                {
                    textDisplay.text += input[0];
                }
            }

            if(textDisplay.text.Length == 4)
            {
                print(textDisplay.text);
                if (textDisplay.text == code)
                {
                    door.transform.Translate(new Vector3(2, 0, 0));
                }
                textDisplay.text = "";
            }
            
        }

    }

    public void setScreenEnable(GameObject p)
    {
        cam.enabled = true;
        enable = true;
        player = p;
    }
}
