using UnityEngine;
public class Magazin : MonoBehaviour
{
    [SerializeField]
    private GameObject panel, text, text1, text2;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        { panel.SetActive(true); }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            panel.SetActive(false);
            text.SetActive(false);
            text1.SetActive(false);
            text2.SetActive(false);
        }
    }
}
