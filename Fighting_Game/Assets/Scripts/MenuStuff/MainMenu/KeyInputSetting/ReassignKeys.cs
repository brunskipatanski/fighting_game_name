using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ReassignKeys : MonoBehaviour
{

    bool isFocused = false;


    //[SerializeField] public TextMeshProUGUI jumpKeyButton;
    //[SerializeField] public TextMeshProUGUI motionRightKeyButton;
    //[SerializeField] public TextMeshProUGUI motionLeftKeyButton;

    [SerializeField] public TextMeshProUGUI jumpKeyButtonText;
    [SerializeField] public TextMeshProUGUI motionRightKeyButtonText;
    [SerializeField] public TextMeshProUGUI motionLeftKeyButtonText;


    // TextMeshProUGUI focusedButton = null;
    TextMeshProUGUI focusedButtonTextObject = null;


    //string focusedButtonOldText = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isFocused)
        {
            if (focusedButtonTextObject != null)
            {
                // focusedButtonOldText = focusedButtonTextObject.text;

                focusedButtonTextObject.text = "\" \"";
                isFocused = false;
            }
        }

    }

    public void JumpKeyReassign()
    {
        isFocused = true;
        focusedButtonTextObject = jumpKeyButtonText;
    }

    public void MotionRightKeyReasign()
    {
        isFocused = true;
        focusedButtonTextObject = motionRightKeyButtonText;

    }

    public void MotionLeftKeyReasign()
    {
        isFocused = true;
        focusedButtonTextObject = motionLeftKeyButtonText;
    }
}
