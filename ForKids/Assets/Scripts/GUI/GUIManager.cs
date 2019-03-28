using UnityEngine;
using UnityEngine.UI;


public class GUIManager : MonoBehaviourSingleton<GUIManager>
{
    #region Varibles

    [SerializeField] GameObject menuScreen;
    [SerializeField] GameObject menuGameButton;
    [SerializeField] GameObject menuSettingsScreen;
    [SerializeField] GameObject background;

    #endregion



    #region Unity lifecycle

    void OnEnable()
    {
        MenuGameButton.OnMenuGameButtonClick += MenuGameButton_OnMenuGameButtonClick;
        MenuScreenButtons.onResumeButtonClick += MenuScreenButtons_OnResumeButtonClick;
        MenuScreenButtons.onSettingsButtonClick += MenuScreenButtons_OnSettingsButtonClick;
        MenuSettingsButtons.onBackButtonClick += MenuSettingsScreen_OnBackButtonClick;
    }


    void OnDisable()
    {
        MenuGameButton.OnMenuGameButtonClick -= MenuGameButton_OnMenuGameButtonClick;
        MenuScreenButtons.onResumeButtonClick -= MenuScreenButtons_OnResumeButtonClick;
        MenuScreenButtons.onSettingsButtonClick -= MenuScreenButtons_OnSettingsButtonClick;
        MenuSettingsButtons.onBackButtonClick -= MenuSettingsScreen_OnBackButtonClick;
    }

    #endregion



    #region Event handlers

    void MenuGameButton_OnMenuGameButtonClick()
    {
        menuGameButton.SetActive(false);
        menuScreen.SetActive(true);
        background.SetActive(true);
    }


    void MenuScreenButtons_OnResumeButtonClick()
    {
        menuGameButton.SetActive(true);
        menuScreen.SetActive(false);
        background.SetActive(false);
    }


    void MenuScreenButtons_OnSettingsButtonClick()
    {
        menuScreen.SetActive(false);
        menuSettingsScreen.SetActive(true);
    }


    void MenuSettingsScreen_OnBackButtonClick()
    {
        menuScreen.SetActive(true);
        menuSettingsScreen.SetActive(false);
    }

    #endregion
}
