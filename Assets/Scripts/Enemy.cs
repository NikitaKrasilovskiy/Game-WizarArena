using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    public GameObject target;
    public float uron;
    private float a = 0;
    private Animator animator;
    public GameObject zona, textWin;
    private NavMeshAgent agent;
    public PlayerScript playerScript;
    public GameObject[] miniBoss;
    public AudioSource deadAudio;
    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (a < uron)
        {
            agent.destination = target.transform.position;
            transform.LookAt(target.transform);
        }
    }
    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Arrow"))
        {
            Destroy(coll.gameObject);
            a++;
        }

        if (a == uron)
        {
            agent.destination = agent.transform.position;
            animator.SetTrigger("Dead");
            Destroy(zona);
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            playerScript.points++;
            deadAudio.Play();
        }

        if (a == 5)
        {
            animator.SetTrigger("Spawn");
            agent.speed = 0;
            StartCoroutine(Wait());
        }
        else animator.SetTrigger("Run");

        IEnumerator Wait()
        {
            yield return new WaitForSeconds(0.1f);
            miniBoss[0].transform.position = agent.transform.position;
            miniBoss[1].transform.position = agent.transform.position;
            yield return new WaitForSeconds(1f);
            miniBoss[0].SetActive(true);
            miniBoss[1].SetActive(true);
            yield return new WaitForSeconds(1f);
            agent.speed = 3;
        }
        if (miniBoss[0].GetComponent<NavMeshAgent>().enabled == false && miniBoss[1].GetComponent<NavMeshAgent>().enabled == false && GetComponent<NavMeshAgent>().enabled == false)
        {
            textWin.SetActive(true);
        }
    }
}
