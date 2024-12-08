using UnityEngine;
using UnityEngine.UI;

public class ArmorUI : MonoBehaviour
{
    #region Variables
    [SerializeField] private Armor _armor;
    [SerializeField] private Image _color;
    #endregion

    #region Private Functions
    private void Update()
    {
        if (_armor.GetAp() <= 0) _color.color = Color.red;
        else
        {
            if (_armor.GetCurrentAp() <= 0) _color.color = Color.red;
            else _color.color = Color.gray;
        }
    }
    #endregion
}