using System.Collections;
using UnityEngine;
public class SpawnArrows : MonoBehaviour
{
    public GameObject arrows;
    public Transform spawnArrows;
    public float fireRate = 0.5f;
    public float nextFite = 0.0f;
    public int arr = 10;
    public Animator playerAnim;
    public GameObject[] mana, effect;
    public PlayerScript playerScript;
    public AudioSource attackAudio, reoladetAudio;
    IEnumerator recharge()
    {
        yield return new WaitForSeconds(2f);
        effect[0].SetActive(false);
        effect[1].SetActive(false);
        arr = 10;
        yield return new WaitForSeconds(0.1f);
        mana[0].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        mana[1].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        mana[2].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        mana[3].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        mana[4].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        mana[5].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        mana[6].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        mana[7].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        mana[8].SetActive(true);
        yield return new WaitForSeconds(0.1f);
        mana[9].SetActive(true);
        playerScript.walkSpeed = 3f;
        playerScript.runSpeed = 8f;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        playerScript.walkSpeed = 1.5f;
        playerScript.runSpeed = 4f;
        yield return new WaitForSeconds(1f);
        playerScript.walkSpeed = 3f;
        playerScript.runSpeed = 8f;
        
    }
        public void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFite && arr > 0)
        {
            nextFite = Time.time + fireRate;
            Instantiate(arrows, spawnArrows.position, spawnArrows.rotation);
            arr--;
            playerAnim.SetTrigger("Attack");
            playerScript.walkSpeed = 0f;
            playerScript.runSpeed = 0f;
            StartCoroutine(Wait());
            attackAudio.Play();
        }

        if (arr < 10)
        { mana[arr].SetActive(false); }

        if (Input.GetButtonDown("Fire2") && arr == 0 && playerScript.pointsReoladet == 1)
        {
            StartCoroutine(recharge());
            playerAnim.SetTrigger("Reoladed");
            effect[0].SetActive(true);
            effect[1].SetActive(true);
            playerScript.walkSpeed = 0f;
            playerScript.runSpeed = 0f;
            playerScript.pointsReoladet = playerScript.pointsReoladet - 1;
            reoladetAudio.Play();
        }
    }
}