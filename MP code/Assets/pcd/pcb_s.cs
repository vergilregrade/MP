using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class pcb_s : MonoBehaviour
{
    private GameObject player;
    private bool enable = false;

    // Update is called once per frame
    void Update()
    {
        if (enable)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                enable = false;
                player.GetComponent<Move_Personnage>().setEnable(true);
                player.GetComponent<Move_Personnage>().SetCamEnable(true);
                this.GetComponent<intercat_pcb_s>().setCamEnable(false);
                return;
            }
        }
    }

    public void SetEnable(GameObject p)
    {
        player = p;
        enable = true;
    }
}
