using System.Collections;
using UnityEngine;
public class PokupkaMana : MonoBehaviour
{
    public GameObject text, manaIcon;
    public PlayerScript playerScript;
    public void pokupka()
    {
        if (playerScript.points >= 2 && playerScript.pointsReoladet == 0)
        {
            playerScript.points = playerScript.points - 2;
            playerScript.pointsReoladet = 1;
            manaIcon.SetActive(true);
        }
        else
        {
            StartCoroutine(Wait());
            text.SetActive(true);
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        text.SetActive(false);
    }
}
