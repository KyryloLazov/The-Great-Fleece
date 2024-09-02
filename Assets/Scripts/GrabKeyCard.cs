using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabKeyCard : MonoBehaviour
{
    public GameObject Cutscene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Cutscene.SetActive(true);
            GameManager.Instance.HasCard = true;
        }
    }
}
