using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Loads from lvl 0 by adding 1 sequentially.
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
