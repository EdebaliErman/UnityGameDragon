using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void Setings()
    {
        Debug.Log("Setingse t�kland�");
    }
    public void Quit()
    {
        Debug.Log("Oyundan �iki�");
        Application.Quit();
    }
}
