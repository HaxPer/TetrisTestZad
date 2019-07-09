using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameTetris : MonoBehaviour
{
    public GameObject[] Go;

    void Update()
    {
        
    }

    public void LoadShen1()
    {
        SceneManager.LoadScene("1shena");
    }

    public void LoadShen2()
    {
        SceneManager.LoadScene("2shena");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void openLoadScen()
    {
        Go[0].SetActive(false);
        Go[1].SetActive(true);
        Go[2].SetActive(true);
    }
}
