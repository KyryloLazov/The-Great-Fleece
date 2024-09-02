using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCutscene : MonoBehaviour
{
    public GameObject Cutscene;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(GameManager.Instance.HasCard == true)
            {
                Cutscene.SetActive(true);
            }           
        }
    }
}
