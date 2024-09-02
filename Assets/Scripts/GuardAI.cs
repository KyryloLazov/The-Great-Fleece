using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardAI : MonoBehaviour
{
    public List<Transform> wayPoints;
    private int currentTarget = 0;
    private NavMeshAgent _agent;
    private Animator _anim;
    private bool reverse = false;
    public bool reached = false;
    public bool coinToss = false;
    public Vector3 coinPos;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!coinToss)
        {
            if (wayPoints.Count > 0 && wayPoints.Count != 1 && wayPoints[currentTarget] != null)
            {
                _agent.SetDestination(wayPoints[currentTarget].position);
                float distance = Vector3.Distance(transform.position, wayPoints[currentTarget].position);
                if (distance < 2f && !reached)
                {
                    reached = true;
                    _anim.SetBool("Walk", false);
                    StartCoroutine(WaitForSeconds());
                }
            }
        }
        else
        {
            StopCoroutine(WaitForSeconds());
            float distance = Vector3.Distance(transform.position, coinPos);
            if(distance < 2f)
            {
                _anim.SetBool("Walk", false);
                StartCoroutine(WaitForSeconds());
            }
        }
    }

    IEnumerator WaitForSeconds()
    {
        float wait = Random.Range(2, 5);
        if (!coinToss)
        {
            if (reverse)
            {
                currentTarget--;
                if (currentTarget < 0)
                {
                    currentTarget = 0;
                    reverse = false;
                    yield return new WaitForSeconds(wait);
                }
            }
            else
            {
                currentTarget++;
                if (currentTarget == wayPoints.Count)
                {

                    currentTarget--;
                    reverse = true;
                    yield return new WaitForSeconds(wait);
                }
            }
            reached = false;
            _anim.SetBool("Walk", true);
        }
        else
        {
            yield return new WaitForSeconds(wait);
            coinToss = false;
            reached = false;
            _anim.SetBool("Walk", true);
        }
    }
}
