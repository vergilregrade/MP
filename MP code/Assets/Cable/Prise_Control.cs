using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prise_Control : MonoBehaviour
{

    private bool _isGrab = false;
    private GameObject _playerGrab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_isGrab)
        {
            transform.position = _playerGrab.transform.position;
            transform.rotation = _playerGrab.transform.rotation;
            //transform.Rotate(new Vector3(0, -90, 0));
        }
    }

    public void setGrab(bool isGrab, GameObject playerGrab = null)
    {
        _playerGrab = playerGrab;
        _isGrab = isGrab;
        GetComponent<Rigidbody>().isKinematic = isGrab;
        GetComponent<Collider>().enabled = !isGrab;
        if (!isGrab)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 5, 0);
            GetComponent<Rigidbody>().mass = 1;
            
        }

    }
}
