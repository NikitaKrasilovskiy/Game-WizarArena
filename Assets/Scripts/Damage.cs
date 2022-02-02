using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Damage : MonoBehaviour
{
    public Animator animator;
    public PlayerScript playerScript;
    public float nextFite = 0f;
    public float rate = 4f;
    private int vzone = 0;
    public NavMeshAgent agent;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            vzone = 1;
            playerScript.hpPlayer--;
            nextFite = Time.time + rate;
            animator.SetTrigger("Attack");
            agent.speed = 0;
            StartCoroutine(Wait());
        }
    }
        private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            vzone = 0;
            animator.SetTrigger("Run");
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        agent.speed = 3;
    }
    private void Update()
    {
        if (vzone == 1 && Time.time > nextFite)
        {
            nextFite = Time.time + rate;
            playerScript.hpPlayer--;
        }
    }
}