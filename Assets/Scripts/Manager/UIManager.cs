using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text sunNumText;

    void Start()
    {
        instance = this;
    }

    public void InitUI()
    {
        sunNumText.text = gameManager.instance.sunNum.ToString();
    }

    public void UpdateUI()
    {
        sunNumText.text = gameManager.instance.sunNum.ToString();
    }
}
