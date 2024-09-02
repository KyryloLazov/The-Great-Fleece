using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    public GameObject GameOverCutscene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameOverCutscene.SetActive(true);
        }
    }
}
