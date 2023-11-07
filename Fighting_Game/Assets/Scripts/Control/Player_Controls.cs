using System;
using UnityEngine;
//!!!!!!!!!! only for player 1! naming is bacause of playermovement! theres 2 scripts for both players
public class Player_Controls : MonoBehaviour
{
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;
    public KeyCode Jump = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public KeyCode A_Attack = KeyCode.T;
    public KeyCode B_Attack = KeyCode.Y;

    public void Start()
    {
        Left = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveLeftKeyP1", "A"));
        Right = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("MoveRightKeyP1", "D"));
        Jump = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("JumpKeyP1", "W"));
        Down = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("CrouchKeyP1", "S"));
        A_Attack = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("A_attackKeyP1", "R"));
        B_Attack = (KeyCode) Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("B_attackKeyP1", "T"));
    }
}



