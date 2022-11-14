using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itchio_button_s : MonoBehaviour
{
    //Application.OpenURL("http://fischhaus.com/");
    void Start()
    {

        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(openWeb);
    }

    void openWeb()
    {
        //SceneManager.LoadScene(scene.name);
        Application.OpenURL("https://von-renald.itch.io/");
    }
}
