using UnityEngine;


public class CardController : MonoBehaviour
{
    #region Varibles

    [SerializeField] Camera _camera;

    bool isClicked;

    Vector2 startPosition;
    Vector2 position;

    #endregion



    #region Unity lifecycle

    void OnEnable()
    {
        CheckCorrectCard.OnWrongCard += CheckCorrectCard_OnWrongCard;
    }


    void OnDisable()
    {
        CheckCorrectCard.OnWrongCard -= CheckCorrectCard_OnWrongCard;
    }

    void OnMouseDown()
    {
        isClicked = true;
    }


    void OnMouseUp()
    {
        isClicked = false;
        ReturnToStartPosition();
    }


    private void Start()
    {
        startPosition = transform.position;
    }


    private void Update()
    {
        if(isClicked)
        {
            position = _camera.ScreenToWorldPoint(Input.mousePosition);
            transform.position = position;
        }
    }

    #endregion



    #region Public Methods

    public void ReturnToStartPosition()
    {
        transform.position = startPosition;
    }

    #endregion



    #region Event handlers

    void CheckCorrectCard_OnWrongCard()
    {
        isClicked = false;
    }

    #endregion
}
