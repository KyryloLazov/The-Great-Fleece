using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCamera : MonoBehaviour
{
    public GameObject GameOverCutscene;
    private Renderer mesh;
    public Animator Animator;

    private void Start()
    {
        mesh = GetComponent<Renderer>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {           
            Color customColor = new Color(0.6f, 0.11f, 0.11f, 0.3f);
            mesh.material.SetColor("_TintColor", customColor);
            StartCoroutine(FreezeCamera());
        }
    }

    IEnumerator FreezeCamera()
    {
        Animator.enabled = false;
        yield return new WaitForSeconds(0.5f);
        GameOverCutscene.SetActive(true);
    }
}
