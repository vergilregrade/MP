using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class switch_code_action : MonoBehaviour
{
    public PC pc;
    public GameObject actionMonitor;
    public void action_connect(int i)
    {
        print("connect"); 
        switch (pc)
        {
            case PC.SECU:
                print("secu");
                if (i==0)
                {
                    actionMonitor.GetComponent<action>().enableSwitch(true);
                }
                break;
        }
    }

    public void action_disconnect(int i)
    {

        switch (pc)
        {
            case PC.SECU:
                if (i == 0)
                {
                    actionMonitor.GetComponent<action>().enableSwitch(false);
                }
                break;
        }
    }
}
