using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AutoSelect : MonoBehaviour
{
    [SerializeField] public Selectable defaultMainMenuSelectedButton;
    [SerializeField] public Selectable defaultSettingsMenuSelectedButton;
    [SerializeField] public Selectable defaultKeyboardSettingSelectedButton;
    [SerializeField] public Selectable defaultVolumeSettingSelectedButton;
    [SerializeField] public Selectable mainMenuSelectedButtonUponSettingsQuit;
    [SerializeField] public Selectable settingsMenuSelectedButtonUponVolumeQuit;

    private void OnEnable()
    {
        if (defaultMainMenuSelectedButton != null)
        {
            EventSystem.current.SetSelectedGameObject(defaultMainMenuSelectedButton.gameObject);
        }
    }

    public void EnableFocusOnMainMenu()
    {
        if (mainMenuSelectedButtonUponSettingsQuit != null)
        {
            EventSystem.current.SetSelectedGameObject(mainMenuSelectedButtonUponSettingsQuit.gameObject);
        }
    }

    public void EnableFocusOnSettingsMenu()
    {
        if (defaultSettingsMenuSelectedButton != null)
        {
            EventSystem.current.SetSelectedGameObject(defaultSettingsMenuSelectedButton.gameObject);
        }
    }

    public void EnableFocusOnKeyboardSettingMenu()
    {
        if (defaultKeyboardSettingSelectedButton != null)
        {
            EventSystem.current.SetSelectedGameObject(defaultKeyboardSettingSelectedButton.gameObject);
        }
    }

    public void EnableFocusOnVolumeSettingMenu()
    {
        if (defaultVolumeSettingSelectedButton != null)
        {
            EventSystem.current.SetSelectedGameObject(defaultVolumeSettingSelectedButton.gameObject);
        }
    }

    public void EnableFocusOnSettingsMenuUponVolumeSettingQuit()
    {
        if (settingsMenuSelectedButtonUponVolumeQuit != null)
        {
            EventSystem.current.SetSelectedGameObject(settingsMenuSelectedButtonUponVolumeQuit.gameObject);
        }
    }
}
