using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    private static bool _oneInformationEnabled = false;
    [SerializeField] GameObject _imageToDisable;
    InventoryButton[] _allInventoryButtons;

    void Start()
    {
        _allInventoryButtons = FindObjectsOfType<InventoryButton>();
        _imageToDisable.SetActive(false);
    }

    public void EnableImage(bool isImageEnabled)
    {
        if (_oneInformationEnabled == false && isImageEnabled == true)
        {
            _imageToDisable.SetActive(isImageEnabled);
            _oneInformationEnabled = true;
            Time.timeScale = 0;
            Debug.Log(Time.timeScale);
        }
        else if (_oneInformationEnabled == true && isImageEnabled == true)
        {
            Debug.Log("Must close image window.");
        }
        else if (isImageEnabled == false)
        {
            _imageToDisable.SetActive(isImageEnabled);
            _oneInformationEnabled = false;
            Time.timeScale = 1;
        }
    }
}

