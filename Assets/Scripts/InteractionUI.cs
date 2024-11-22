using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    #region Variables
    [SerializeField] private TMP_Text _interactionText;
    #endregion

    #region Public Functions
    public void EnableText(string _text)
    {
        _interactionText.text = _text;
    }

    public void DisableText()
    {
        _interactionText.text = null;
        _interactionText.text = "";
    }
    #endregion
}