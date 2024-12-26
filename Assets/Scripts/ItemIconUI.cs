using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemIconUI : MonoBehaviour
{
    #region Variables
    [SerializeField] private TMP_Text _string;
    [SerializeField] private Image _image;
    #endregion

    #region Private Functions
    public void SetItemIcon(string _newString, Color _newColor, Sprite _newImage)
    {
        _string.text = _newString;
        _string.color = _newColor;
        _image.sprite = _newImage;
    }

    public void SetItemIcon1(string _newString, Color _newColor)
    {
        _string.text = _newString;
        _string.color = _newColor;
        _image.enabled = false;
    }
    #endregion
}