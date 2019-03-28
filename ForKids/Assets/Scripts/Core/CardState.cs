using UnityEngine;
using UnityEngine.UI;


public class CardState : MonoBehaviour
{
    #region Varibles

    [SerializeField] BoxCollider2D boxCollider2D;
    [SerializeField] CardController cardController;
    [SerializeField] Image image;
    [SerializeField] Color wrongCardColor;

    Sprite cardImage;
    Color startColor;

    Vector2 startPosition;

    int id;

    bool hasTry = true;

    #endregion



    #region Properties

    public int Id => id;

    #endregion



    #region Unity lifecycle

    void OnEnable()
    {
        CheckCorrectCard.OnWrongCard += CheckCorrectCard_OnWrongCard;
        CheckCorrectCard.OnRigthCard += CheckCorrectCard_OnRigthCard;
        GameManager.OnMenuStateChange += GameManager_OnMenuStateChange;
    }


    void OnDisable()
    {
        CheckCorrectCard.OnWrongCard -= CheckCorrectCard_OnWrongCard;
        CheckCorrectCard.OnRigthCard -= CheckCorrectCard_OnRigthCard;
        GameManager.OnMenuStateChange -= GameManager_OnMenuStateChange;
    }


    void Start()
    {
        startColor = image.color;
    }

    #endregion



    #region Public methods

    public void SetCardInfo(CardScriptableObject card)
    {
        id = card.Id;
        cardImage = card.CardImage;

        image.sprite = cardImage;
    }

    #endregion



    #region Event handlers

    void CheckCorrectCard_OnWrongCard()
    {
        if(GameManager.CorrectCardId != id)
        {
            image.color = wrongCardColor;
            boxCollider2D.enabled = false;
            hasTry = false;
            cardController.ReturnToStartPosition();
        }
    }


    void CheckCorrectCard_OnRigthCard()
    {
        if (GameManager.CorrectCardId != id)
        {
            hasTry = true;
            image.color = startColor;
            boxCollider2D.enabled = true;
        }
    }


    void GameManager_OnMenuStateChange(GameState gameState)
    {
        switch(gameState)
        {
            case GameState.GamePause:
                boxCollider2D.enabled = false;
                break;

            case GameState.GameResume:
                if(hasTry)
                {
                    boxCollider2D.enabled = true;
                }
                break;

            case GameState.GameReload:

                break;
        }
    }

    #endregion
}
