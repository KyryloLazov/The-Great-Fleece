using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject _player;
    public Transform startPos;
    private void Start()
    {
        transform.position = startPos.position;
        transform.rotation = startPos.rotation;
    }

    void Update()
    {
        transform.LookAt(_player.transform.position);
    }
}
