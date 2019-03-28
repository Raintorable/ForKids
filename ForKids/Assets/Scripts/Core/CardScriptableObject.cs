using UnityEngine;


[CreateAssetMenu(fileName = "New card", menuName = "Card")]
public class CardScriptableObject : ScriptableObject
{
    #region Varibles

    [SerializeField] int id;
    [SerializeField] Sprite cardImage;

    #endregion



    #region Properties

    public int Id => id;
    public Sprite CardImage => cardImage;

    #endregion
}
