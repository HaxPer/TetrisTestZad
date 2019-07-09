using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chena2GameOver : MonoBehaviour
{
    public void LoadGameOver()
    {
        SceneManager.LoadScene("Menu");
    }
}
