using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    #region Variables
    [SerializeField] private Slider _slider;
    [SerializeField] private Health _hp;
    [SerializeField] private TMP_Text _text;
    #endregion

    #region Private Functions
    private void Update()
    {
        _slider.value = _hp.GetCurrentHp();
        _slider.maxValue = _hp.GetHp();
        _text.text = _hp.GetCurrentHp().ToString();
    }
    #endregion
}