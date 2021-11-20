using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuffs : MonoBehaviour
{
    private Player_Controller controller;

    private void Awake()
    {
        controller = GetComponent<Player_Controller>();
    }

    public void CdrBuff()
    {
        controller.DecreaseCdr();
    }

    public void SpeedBuff()
    {
        controller.RaiseMoveSpeed();
    }

    public void HpBuff()
    {
        controller.IncreaseHealth();
    }

    public void JumpBuff()
    {
        controller.RaiseJumpHeight();
    }
}
