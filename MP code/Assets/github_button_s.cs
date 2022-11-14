using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class github_button_s : MonoBehaviour
{
    //Application.OpenURL("http://fischhaus.com/");
    void Start()
    {

        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(openWebGit);
    }

    void openWebGit()
    {
        //SceneManager.LoadScene(scene.name);
        Application.OpenURL("https://github.com/VonRenald/");
        Application.OpenURL("https://github.com/vergilregrade/MP");
    }
}
