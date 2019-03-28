using UnityEngine;
using System;


public class MenuGameButton : MonoBehaviour
{
    #region Varibles

    public static Action OnMenuGameButtonClick;

    #endregion



    #region Event handlers

    public void OnClick()
    {
        if(OnMenuGameButtonClick != null)
        {
            OnMenuGameButtonClick();
        }
    }

    #endregion
}
