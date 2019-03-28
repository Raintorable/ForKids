using System.Collections.Generic;
using UnityEngine;
using System;

public enum GameState
{
    GamePause,
    GameResume,
    GameReload
}
//попап

sealed class GameManager : MonoBehaviourSingleton<GameManager>
{
    #region Varibles

    const int LOW_LEVEL_CARDS_COUNT = 3;
    const int HIGH_LEVEL_CARDS_COUNT = 4;

    public static Action<GameState> OnMenuStateChange;

    [SerializeField] CardState card;
    [SerializeField] Camera _camera;
    [SerializeField] GameObject gameCanvas;
    [SerializeField] List<CardScriptableObject> cards;

    static int correctId;

    GameObject cardObjects;

    GameState gameState = GameState.GameResume;

    Vector2 cardPosition;

    float deltaCardPositionX;
    float cardCount;

    bool isLevelChanged;

    int gameLevel = 1;

    #endregion



    #region Properties

    public static int CorrectCardId => correctId;

    public int GameLevel => gameLevel;


    public GameState GameStateProperty
    {
        get
        {
            return gameState;
        }
        private set
        {
            gameState = value;

            OnMenuStateChangeInvoke();
        }
    }

    #endregion

    
    //нужны ли ивенты для состояния игры, как можно сделать легче
    //можно ли сделать так, чтобы при паузе мы не могли кликать на карточки, не отключая коллайдер
    #region Unity lifecycle

    void OnEnable()
    {
        MenuSettingsButtons.OnLevelChanged += MenuSettingsButtons_OnLevelChanged;
        MenuGameButton.OnMenuGameButtonClick += MenuGameButton_OnMenuGameButtonClick;
        MenuScreenButtons.onResumeButtonClick += MenuScreenButtons_OnResumeButtonClick;
    }


    void OnDisable()
    {
        MenuSettingsButtons.OnLevelChanged -= MenuSettingsButtons_OnLevelChanged;
        MenuGameButton.OnMenuGameButtonClick -= MenuGameButton_OnMenuGameButtonClick;
        MenuScreenButtons.onResumeButtonClick -= MenuScreenButtons_OnResumeButtonClick;
    }


    void Start()
    {
        FillGameFields();
        SpawnCards();
    }

    #endregion



    #region Private methods

    void FillGameFields()
    {
        Debug.Log("Level: " + gameLevel);
        switch(gameLevel)
        {
            case 1:
                correctId = 0;
                cardCount = LOW_LEVEL_CARDS_COUNT;
                break;

            case 2:
                correctId = 1;
                cardCount = LOW_LEVEL_CARDS_COUNT;
                break;

            case 3:
                correctId = 0;
                cardCount = HIGH_LEVEL_CARDS_COUNT;
                break;

            default: Debug.Log("No this level!");
                break;
        } 
    }


    void SpawnCards()
    {
        float cameraHalfWidth = _camera.orthographicSize * _camera.aspect;
        deltaCardPositionX = (cameraHalfWidth * 2f) / (cardCount + 1);
        cardPosition = new Vector2(_camera.transform.position.x - cameraHalfWidth, -_camera.orthographicSize * 0.5f);

        cardObjects = new GameObject("Cards");
        cardObjects.transform.SetParent(gameCanvas.transform);
        cardObjects.transform.localScale = Vector2.one;

        for (int i = 0; i < cardCount; i++)
        {
            cardPosition += Vector2.right * deltaCardPositionX;
            CardState tempCard = Instantiate(card, cardPosition, Quaternion.identity);
            tempCard.transform.SetParent(cardObjects.transform);
            tempCard.transform.localScale = Vector3.one;

            tempCard.SetCardInfo(cards[i]);
        }
    }


    void ClearBoard()
    {
        Destroy(cardObjects);
    }

    #endregion



    #region Event handlers

    void OnMenuStateChangeInvoke()
    {
        if(OnMenuStateChange != null)
        {
            OnMenuStateChange(gameState);
        }

        if(gameState == GameState.GameResume)
        {
            if(isLevelChanged)
            {
                ClearBoard();
                SpawnCards();
                isLevelChanged = false;
            }
        }
    }


    void MenuSettingsButtons_OnLevelChanged(int gameLevel)
    {
        this.gameLevel = gameLevel;
        FillGameFields();
        isLevelChanged = true;
    }


    void MenuGameButton_OnMenuGameButtonClick()
    {
        GameStateProperty = GameState.GamePause;
    }


    void MenuScreenButtons_OnResumeButtonClick()
    {
        GameStateProperty = GameState.GameResume;
    }

    #endregion
}