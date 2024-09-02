using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameratrigger : MonoBehaviour
{
    public GameObject _camPos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Trigger Activated");
            Camera.main.transform.position = _camPos.transform.position;
            Camera.main.transform.rotation = _camPos.transform.rotation;
        }
    }
}
