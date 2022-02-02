using UnityEngine;
public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject panel, player;
    [SerializeField] private bool paused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(!panel.activeInHierarchy);

            if (paused)
                paused = false;
            else
                paused = true;
        }
        if (paused)
        {
            player.SetActive(false);
            Time.timeScale = 0;
        }
        else
        {
            player.SetActive(true);
            Time.timeScale = 1f;
        }
    }
}
