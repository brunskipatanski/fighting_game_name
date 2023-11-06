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
            if (Input.anyKeyDown)
            {
                foreach (KeyCode keyCode in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(keyCode))
                    {
                        Debug.Log("Key pressed: " + keyCode);
                        focusedButtonTextObject.text = "\"" + keyCode.ToString().ToLower() + "\"";
                        // You can perform actions based on the specific key press here.
                    }
                }
                isFocused = false;
                focusedButtonTextObject = null;
            }
        }

        
        if (focusedButtonTextObject != null)
        {
            // focusedButtonOldText = focusedButtonTextObject.text;
            focusedButtonTextObject.text = "\" \"";
            isFocused = true;
            
        }


    }
    // AT, PLEASE add some comments on this bruh v_v, figured most of it out but plz. 
    public void JumpKeyReassign()
    {
        focusedButtonTextObject = jumpKeyButtonText;
    }

    public void MotionRightKeyReasign()
    {
        focusedButtonTextObject = motionRightKeyButtonText;

    }

    public void MotionLeftKeyReasign()
    {
        focusedButtonTextObject = motionLeftKeyButtonText;
    }
}
