using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class end_button_script : MonoBehaviour
{
    void Start()
    {

        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(exit);
    }

    void exit()
    {
        Application.Quit();
    }
}
