using UnityEngine;
using UnityEngine.UI;
using System;


public class MenuSettingsButtons : MonoBehaviour
{
    #region Varibles

    public static Action onBackButtonClick;
    public static Action<int> OnLevelChanged;

    [SerializeField] Text levelText;

    int gameLevel;

    #endregion



    #region Unity lifecycle

    void Start()
    {
        gameLevel = Convert.ToInt32(levelText.text);
    }

    #endregion



    #region Event handlers

    public void OnUpArrowClick()
    {
        gameLevel++;
        levelText.text = gameLevel.ToString();
    }


    public void OnDownArrowClick()
    {
        if (gameLevel > 1)
        {
            gameLevel--;
            levelText.text = gameLevel.ToString();
        }
    }


    public void OnBackButtonClick()
    {
        if(OnLevelChanged != null)
        {
            OnLevelChanged(gameLevel);
        }

        if(onBackButtonClick != null)
        {
            onBackButtonClick();
        }
    }

    #endregion
}
