using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ErrorMessagesScript : MonoBehaviour
{
    TextMeshProUGUI _errorMessageText;
    private void Start()
    {
        _errorMessageText = GetComponent<TextMeshProUGUI>();
        _errorMessageText.text = "";
    }

    public void DisplayErrorMessage(string errorMessage, bool isEmergency)
    {
        StartCoroutine(errorMessageDisappear(errorMessage, isEmergency));
    }

    private IEnumerator errorMessageDisappear(string errorMessage, bool isEmergency)
    {
        if (isEmergency)
        {
            _errorMessageText.color = new Color32(188, 17, 8, 255);
            _errorMessageText.fontSize = 70;
            _errorMessageText.text = errorMessage;
        }
        else
        {
            _errorMessageText.color = new Color32(50, 50, 50, 255);
            _errorMessageText.fontSize = 60;
            _errorMessageText.text = errorMessage;
        }

        yield return new WaitForSeconds(2.0f);
        _errorMessageText.text = "";
    }
}
