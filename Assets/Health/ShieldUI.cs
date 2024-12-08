using UnityEngine;
using UnityEngine.UI;

public class ShieldUI : MonoBehaviour
{
    #region Variables
    [SerializeField] private Shield _shield;
    [SerializeField] private Slider _slider;
    #endregion

    #region Private Functions
    private void Update()
    {
        if (_shield.GetSp() <= 0) _slider.enabled = false;
        else
        {
            _slider.enabled = true;
            _slider.value = _shield.GetCurrentSp();
            _slider.maxValue = _shield.GetSp();
        }
    }
    #endregion
}