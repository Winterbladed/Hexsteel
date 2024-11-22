using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    #region Variables
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _hp;
    #endregion

    #region Private Functions
    private void Update()
    {
        _slider.value = _hp.GetCurrentHp();
        _slider.maxValue = _hp.GetHp();
    }
    #endregion
}