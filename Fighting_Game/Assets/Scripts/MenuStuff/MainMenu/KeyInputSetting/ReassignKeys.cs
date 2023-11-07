using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReassignKeys : MonoBehaviour
{

    bool isFocused = false;


    [SerializeField] public TextMeshProUGUI jumpKeyButton;
    //[SerializeField] public TextMeshProUGUI motionRightKeyButton;
    //[SerializeField] public TextMeshProUGUI motionLeftKeyButton;

    [SerializeField] public TextMeshProUGUI jumpKeyButtonText;
    [SerializeField] public TextMeshProUGUI motionRightKeyButtonText;
    [SerializeField] public TextMeshProUGUI motionLeftKeyButtonText;
    [SerializeField] public TextMeshProUGUI crouchKeyButtonText;
    [SerializeField] public TextMeshProUGUI A_attackKeyButtonText;
    [SerializeField] public TextMeshProUGUI B_attackKeyButtonText;

    // TextMeshProUGUI focusedButton = null;
    TextMeshProUGUI focusedButtonTextObject = null;

    Navigation jumpKeyButtonNavigation = new Navigation();

    string player;


    //string focusedButtonOldText = null;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name == "Player1_setUp")
        {
            player = "P1";
        }
        else
        {
            player = "P2";
        }
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

                        if (focusedButtonTextObject == jumpKeyButtonText)
                        {
                            PlayerPrefs.SetString("JumpKey" + player, keyCode.ToString());
                        }
                        else if (focusedButtonTextObject == motionRightKeyButtonText)
                        {
                            PlayerPrefs.SetString("MoveRightKey" + player, keyCode.ToString());
                        }
                        else if (focusedButtonTextObject == motionLeftKeyButtonText)
                        {
                            PlayerPrefs.SetString("MoveLeftKey" + player, keyCode.ToString());
                        }
                        else if (focusedButtonTextObject == crouchKeyButtonText)
                        {
                            PlayerPrefs.SetString("CrouchKey" + player, keyCode.ToString());
                        }
                        else if (focusedButtonTextObject == A_attackKeyButtonText)
                        {
                            PlayerPrefs.SetString("A_attackKey" + player, keyCode.ToString());
                        }
                        else
                        {
                            PlayerPrefs.SetString("B_attackKey" + player, keyCode.ToString());
                        }
                    }
                }
                // prevent navigation during reassignment mode
                EventSystem.current.sendNavigationEvents = true;

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
        // Set the navigation mode to "None"
        jumpKeyButtonNavigation.mode = Navigation.Mode.None;
        jumpKeyButton.GetComponent<Button>().navigation = jumpKeyButtonNavigation;
        // BlockNavigation();
    }

    public void MotionRightKeyReasign()
    {
        focusedButtonTextObject = motionRightKeyButtonText;
        BlockNavigation();

    }

    public void MotionLeftKeyReasign()
    {
        focusedButtonTextObject = motionLeftKeyButtonText;
        BlockNavigation();
    }

    public void CrouchKeyReassign()
    {
        focusedButtonTextObject = crouchKeyButtonText;
        BlockNavigation();
    }

    public void A_attackKeyReassign()
    {
        focusedButtonTextObject = A_attackKeyButtonText;
        BlockNavigation();
    }

    public void B_attackKeyReassign()
    {
        focusedButtonTextObject = B_attackKeyButtonText;
        BlockNavigation();
    }

    public void ToDefault()
    {
        if (player == "P1")
        {
            jumpKeyButtonText.text = "\"w\"";
            motionRightKeyButtonText.text = "\"d\"";
            motionLeftKeyButtonText.text = "\"a\"";
            crouchKeyButtonText.text = "\"s\"";
            A_attackKeyButtonText.text = "\"r\"";
            B_attackKeyButtonText.text = "\"t\"";
        }
        else if (player == "P2")
        {
            jumpKeyButtonText.text = "\"i\"";
            motionRightKeyButtonText.text = "\"l\"";
            motionLeftKeyButtonText.text = "\"j\"";
            crouchKeyButtonText.text = "\"k\"";
            A_attackKeyButtonText.text = "\"o\"";
            B_attackKeyButtonText.text = "\"p\"";
        }

        PlayerPrefs.DeleteKey("JumpKey" + player);
        PlayerPrefs.DeleteKey("MoveRightKey" + player);
        PlayerPrefs.DeleteKey("MoveLeftKey" + player);
        PlayerPrefs.DeleteKey("CrouchKey" + player);
        PlayerPrefs.DeleteKey("A_attackKey" + player);
        PlayerPrefs.DeleteKey("B_attackKey" + player);

    }

    private void BlockNavigation()
    {
        EventSystem.current.sendNavigationEvents = false;
    }
}
