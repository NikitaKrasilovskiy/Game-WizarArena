using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class PokupkaMagic : MonoBehaviour
{
    public GameObject predmet, text, mana2;
    public Button button;
    public Image imButt;
    public PlayerScript playerScript;
    public void pokupka()
    {
        if (playerScript.points >= 2)
        {
            predmet.SetActive(true);
            playerScript.points = playerScript.points - 2;
            button.enabled = false;
            imButt.color = new Color(0, 0, 0, 0.5f);
            mana2.SetActive(true);
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
