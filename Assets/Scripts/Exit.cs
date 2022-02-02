using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
    }
    public void Repeat()
    {
        SceneManager.LoadScene("Arena");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
