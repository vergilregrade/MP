using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start_button_s : MonoBehaviour
{
    public Object scene;

    void Start()
    {
        
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(change_scene);
    }

    void change_scene()
    {
        //SceneManager.LoadScene(scene.name);
        SceneManager.LoadScene("classe", LoadSceneMode.Single);
    }
}
