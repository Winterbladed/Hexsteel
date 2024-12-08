using UnityEngine;
using UnityEngine.UI;

public class ArmorUI : MonoBehaviour
{
    #region Variables
    [SerializeField] private Armor _armor;
    [SerializeField] private Slider _slider;
    #endregion

    #region Private Functions
    private void Update()
    {
        _slider.value = _armor.GetCurrentAp();
        _slider.maxValue = _armor.GetAp();
    }
    #endregion
}