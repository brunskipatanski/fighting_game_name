using System;
using UnityEngine;
//!!!!!!!!!! only for player 2! naming is cos of playermovement! theres 2 scripts for both players
public class Player_Controls2 : MonoBehaviour
{
    public KeyCode Left = KeyCode.LeftArrow;
    public KeyCode Right = KeyCode.RightArrow;
    public KeyCode Jump = KeyCode.UpArrow;
    public KeyCode Down = KeyCode.DownArrow;
    public KeyCode A_Attack = KeyCode.J;
    public KeyCode B_Attack = KeyCode.K;

    public void Start()
    {
        Left = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveLeftKeyP2", "J"));
        Right = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveRightKeyP2", "L"));
        Jump = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpKeyP2", "I"));
        Down = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CrouchKeyP2", "K"));
        A_Attack = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("A_attackKeyP2", "Y"));
        B_Attack = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("B_attackKeyP2", "U"));
    }

}



