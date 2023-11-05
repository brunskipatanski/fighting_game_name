using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }
}

public class PlayerControl1 : MonoBehaviour
{
    public KeyCode Left = KeyCode.A;
    public KeyCode Right = KeyCode.D;
    public KeyCode Jump = KeyCode.W;
    public KeyCode Down = KeyCode.S;
    public KeyCode A_Attack = KeyCode.T;
    public KeyCode B_Attack = KeyCode.Y;
}

public class PlayerControl2 : MonoBehaviour
{
    public KeyCode Left = KeyCode.LeftArrow;
    public KeyCode Right = KeyCode.RightArrow;
    public KeyCode Jump = KeyCode.UpArrow;
    public KeyCode Down = KeyCode.DownArrow;
    public KeyCode A_Attack = KeyCode.K;
    public KeyCode B_Attack = KeyCode.L;
}
