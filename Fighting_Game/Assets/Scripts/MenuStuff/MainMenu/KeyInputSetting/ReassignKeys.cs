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



    // all buttons here
    [SerializeField] public Button jumpKeyButton;
    [SerializeField] public Button motionRightKeyButton;
    [SerializeField] public Button motionLeftKeyButton;
    [SerializeField] public Button crouchKeyButton;
    [SerializeField] public Button A_attackKeyButton;
    [SerializeField] public Button B_attackKeyButton;
    [SerializeField] public Button backButton;

    // TextMeshProUGUI focusedButton = null;
    TextMeshProUGUI focusedButtonTextObject = null;
    // Focused Button
    // private Button focusedButton = null;

    Navigation navNone = new Navigation();

    string player;


    // Start is called before the first frame update
    void Start()
    {
        navNone.mode = Navigation.Mode.None;

        if (gameObject.name == "Player1_setUp")
        {
            player = "P1";
        }
        else
        {
            player = "P2";
        }

        // Get all previously set reassgned keys and display them
        if (player == "P1")
        {
            jumpKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"" + PlayerPrefs.GetString("JumpKeyP1", "W").ToLower() + "\"";
            motionRightKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"" + PlayerPrefs.GetString("MoveRightKeyP1", "D").ToLower() + "\"";
            motionLeftKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"" + PlayerPrefs.GetString("MoveLeftKeyP1", "A").ToLower() + "\"";
            crouchKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"" + PlayerPrefs.GetString("CrouchKeyP1", "S").ToLower() + "\"";
            A_attackKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"" + PlayerPrefs.GetString("A_attackKeyP1", "R").ToLower() + "\"";
            B_attackKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"" + PlayerPrefs.GetString("B_attackKeyP1", "T").ToLower() + "\"";
        }
        //else if (player == "P2")
        //{
        //    jumpKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"i\"";
        //    motionRightKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"l\"";
        //    motionLeftKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"j\"";
        //    crouchKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"k\"";
        //    A_attackKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"o\"";
        //    B_attackKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"p\"";
        //}
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

                        if (focusedButtonTextObject == jumpKeyButton.GetComponentInChildren<TextMeshProUGUI>())
                        {
                            PlayerPrefs.SetString("JumpKey" + player, keyCode.ToString());

                            // bring back to the explicit navigation state
                            Navigation nav = new Navigation();
                            nav.mode = Navigation.Mode.Explicit;
                            nav.selectOnDown = motionRightKeyButton;
                            nav.selectOnUp = backButton;
                            jumpKeyButton.navigation = nav;
                        }
                        else if (focusedButtonTextObject == motionRightKeyButton.GetComponentInChildren<TextMeshProUGUI>())
                        {
                            PlayerPrefs.SetString("MoveRightKey" + player, keyCode.ToString());

                            // bring back to the vertical navigation state
                            Navigation nav = new Navigation();
                            nav.mode = Navigation.Mode.Vertical;
                            motionRightKeyButton.navigation = nav;
                        }
                        else if (focusedButtonTextObject == motionLeftKeyButton.GetComponentInChildren<TextMeshProUGUI>())
                        {
                            PlayerPrefs.SetString("MoveLeftKey" + player, keyCode.ToString());

                            // bring back to the vertical navigation state
                            Navigation nav = new Navigation();
                            nav.mode = Navigation.Mode.Vertical;
                            motionLeftKeyButton.navigation = nav;
                        }
                        else if (focusedButtonTextObject == crouchKeyButton.GetComponentInChildren<TextMeshProUGUI>())
                        {
                            PlayerPrefs.SetString("CrouchKey" + player, keyCode.ToString());

                            // bring back to the vertical navigation state
                            Navigation nav = new Navigation();
                            nav.mode = Navigation.Mode.Vertical;
                            crouchKeyButton.navigation = nav;
                        }
                        else if (focusedButtonTextObject == A_attackKeyButton.GetComponentInChildren<TextMeshProUGUI>())
                        {
                            PlayerPrefs.SetString("A_attackKey" + player, keyCode.ToString());

                            // bring back to the vertical navigation state
                            Navigation nav = new Navigation();
                            nav.mode = Navigation.Mode.Vertical;
                            A_attackKeyButton.navigation = nav;
                        }
                        else
                        {
                            PlayerPrefs.SetString("B_attackKey" + player, keyCode.ToString());

                            // bring back to the vertical navigation state
                            Navigation nav = new Navigation();
                            nav.mode = Navigation.Mode.Vertical;
                            B_attackKeyButton.navigation = nav;
                        }
                    }
                }
                // prevent navigation during reassignment mode
                // EventSystem.current.sendNavigationEvents = true;


                // Set navigation back to explicit in order to revert cycling through reassignment fields
                // if (focusedButtonTextObject == jumpKeyButton.GetComponentInChildren<TextMeshProUGUI>())
                

                Debug.Log("we are here");

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
        // Set the navigation mode to "None" in order to block it
        jumpKeyButton.navigation = navNone;

        // jumpKeyButton
        focusedButtonTextObject = jumpKeyButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void MotionRightKeyReasign()
    {
        // Set the navigation mode to "None" in order to block it
        motionRightKeyButton.navigation = navNone;

        focusedButtonTextObject = motionRightKeyButton.GetComponentInChildren<TextMeshProUGUI>();

    }

    public void MotionLeftKeyReasign()
    {
        // Set the navigation mode to "None" in order to block it
        motionLeftKeyButton.navigation = navNone;

        focusedButtonTextObject = motionLeftKeyButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void CrouchKeyReassign()
    {
        // Set the navigation mode to "None" in order to block it
        crouchKeyButton.navigation = navNone;

        focusedButtonTextObject = crouchKeyButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void A_attackKeyReassign()
    {
        // Set the navigation mode to "None" in order to block it
        A_attackKeyButton.navigation = navNone;

        focusedButtonTextObject = A_attackKeyButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void B_attackKeyReassign()
    {
        // Set the navigation mode to "None" in order to block it
        B_attackKeyButton.navigation = navNone;

        focusedButtonTextObject = B_attackKeyButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void ToDefault()
    {
        if (player == "P1")
        {
            jumpKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"w\"";
            motionRightKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"d\"";
            motionLeftKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"a\"";
            crouchKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"s\"";
            A_attackKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"r\"";
            B_attackKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"t\"";
        }
        else if (player == "P2")
        {
            jumpKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"i\"";
            motionRightKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"l\"";
            motionLeftKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"j\"";
            crouchKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"k\"";
            A_attackKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"o\"";
            B_attackKeyButton.GetComponentInChildren<TextMeshProUGUI>().text = "\"p\"";
        }

        PlayerPrefs.DeleteKey("JumpKey" + player);
        PlayerPrefs.DeleteKey("MoveRightKey" + player);
        PlayerPrefs.DeleteKey("MoveLeftKey" + player);
        PlayerPrefs.DeleteKey("CrouchKey" + player);
        PlayerPrefs.DeleteKey("A_attackKey" + player);
        PlayerPrefs.DeleteKey("B_attackKey" + player);

    }
}
