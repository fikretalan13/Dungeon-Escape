using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI playerGemCountText;
    public Image selectionImg;

    [SerializeField] TextMeshProUGUI gemCountText;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = "" + gemCount + "G";
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImg.rectTransform.anchoredPosition = new Vector2(selectionImg.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int count)
    {
        gemCountText.text = "" + count;
    }

    public void ReStartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene(0);
    }

}
