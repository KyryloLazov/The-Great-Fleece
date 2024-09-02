using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public GameObject coin;
    private NavMeshAgent _agent;
    private Animator _animator;
    private Vector3 _destination;
    private bool _thrown = false;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        Throw();

    }

    private void AlertAI(Vector3 CoinPos)
    {
        GameObject[] Guards = GameObject.FindGameObjectsWithTag("Guard1");

        foreach(var guard in Guards)
        {
            GuardAI AI = guard.GetComponent<GuardAI>();
            AI.coinToss = true;
            AI.coinPos = CoinPos;

            guard.GetComponent<Animator>().SetBool("Walk", true);
            guard.GetComponent<NavMeshAgent>().SetDestination(CoinPos);
        }
    }

    private void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                _agent.SetDestination(hit.point);
                _destination = hit.point;
                _animator.SetBool("Walk", true);
            }
        }
        float distance = Vector3.Distance(transform.position, _destination);
        if (distance <= 1.5f)
        {
            _animator.SetBool("Walk", false);
        }
    }

    private void Throw()
    {
        if (Input.GetMouseButtonDown(1) && !_thrown)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100))
            {
                _animator.SetTrigger("Throw");
                GameObject _coin = Instantiate(coin, hit.point, Quaternion.identity);
                AudioSource coinAudio = _coin.GetComponentInChildren<AudioSource>();
                coinAudio.Play();
                _thrown = true;
                AlertAI(hit.point);               
            }
        }
    }

}
