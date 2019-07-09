using UnityEngine;
using UnityEngine.UI;

public class Ohki : MonoBehaviour
{
    public Text Kol_vo;
    public int osnov = 0;

    void Update()
    {
        Kol_vo.text = osnov.ToString();
    }
}
