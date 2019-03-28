using UnityEngine;
using System;


public class CheckCorrectCard : MonoBehaviourSingleton<CheckCorrectCard>
{
    #region Varibles

    public static Action OnWrongCard;
    public static Action OnRigthCard;

    #endregion



    #region Unity lifecycle

    void OnTriggerEnter2D(Collider2D collision)
    {
        CardState cardState = collision.GetComponent<CardState>();

        if(cardState != null)
        {
            if (GameManager.CorrectCardId == cardState.Id)
            {
                Debug.Log("Correct!");

                if(OnRigthCard != null)
                {
                    OnRigthCard();
                }
            }
            else
            {
                Debug.Log("Not Correct!");

                if (OnWrongCard != null)
                {
                    OnWrongCard();
                }
            }
        }
    }

    #endregion
}
