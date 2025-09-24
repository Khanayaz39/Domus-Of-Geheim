using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Cutscene"); // Step 2: load cutscene scene
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

