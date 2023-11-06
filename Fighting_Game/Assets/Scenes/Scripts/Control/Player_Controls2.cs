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
        Left = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveLeftKey", "J"));
        Right = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveRightKey", "L"));
        Jump = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpKey", "I"));
    }

}



