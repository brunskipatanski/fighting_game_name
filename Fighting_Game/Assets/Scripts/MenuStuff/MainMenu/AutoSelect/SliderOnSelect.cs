using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderOnSelect : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField] public Color onSelectColor;
    [SerializeField] public Color onDeselectColor;

    public void OnSelect(BaseEventData eventData)
    {
        Transform fillObj = transform.Find("Fill Area")
                                   .Find("Fill");

        Image imageComponent = fillObj.GetComponent<Image>();
        imageComponent.color = onSelectColor;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Transform fillObj = transform.Find("Fill Area")
                                   .Find("Fill");

        Image imageComponent = fillObj.GetComponent<Image>();
        imageComponent.color = onDeselectColor;
    }
}
