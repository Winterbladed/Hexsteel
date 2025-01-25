using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShieldUI : MonoBehaviour
{
    #region Variables
    [SerializeField] private Shield _shield;
    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _text;
    #endregion

    #region Private Functions
    private void Update()
    {
        if (_shield.GetSp() <= 0) _slider.gameObject.SetActive(false);
        else
        {
            _slider.gameObject.SetActive(true);
            _slider.value = _shield.GetCurrentSp();
            _slider.maxValue = _shield.GetSp();
            _text.text = _shield.GetCurrentSp().ToString();
        }
    }
    #endregion
}