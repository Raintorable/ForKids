using UnityEngine;
using System;


public class MenuScreenButtons : MonoBehaviour
{
    #region Varibles

    public static Action onResumeButtonClick;
    public static Action onSettingsButtonClick;

    #endregion



    #region Event handlers

    public void OnResumeButtonClick()
    {
        if(onResumeButtonClick != null)
        {
            onResumeButtonClick();
        }
    }


    public void OnSettingsButtonClick()
    {
        if(onSettingsButtonClick != null)
        {
            onSettingsButtonClick();
        }
    }

    #endregion
}
