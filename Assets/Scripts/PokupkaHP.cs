using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PokupkaHP : MonoBehaviour
{
    public GameObject text;
    public Button button;
    public Image imButt;
    public PlayerScript playerScript;
    public GameObject[] hp;
    public void pokupka()
    {
        if (playerScript.points >= 2 && playerScript.hpPlayer < 5)
        {
            playerScript.points = playerScript.points - 2;
            playerScript.hpPlayer = 5;
            button.enabled = false;
            imButt.color = new Color(0, 0, 0, 0.5f);
            hp[0].SetActive(true);
            hp[1].SetActive(true);
            hp[2].SetActive(true);
            hp[3].SetActive(true);
            hp[4].SetActive(true);
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
