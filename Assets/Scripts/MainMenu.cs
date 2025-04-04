using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

   public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Salió del juego");
    }

    public void menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
