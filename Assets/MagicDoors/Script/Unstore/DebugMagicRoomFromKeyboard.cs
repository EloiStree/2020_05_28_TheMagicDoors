using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMagicRoomFromKeyboard : MonoBehaviour
{
    public DebugMagicRoomCheatCode m_cheatCode;

    private void Start()
    {
        m_cheatCode.SetScreamerFPS(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            m_cheatCode.SwitchBetweenBestOfAndAll();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            m_cheatCode.SwitchLightOnOff();
        }
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.KeypadPeriod))
        {
            m_cheatCode.SwitchJimmyScreamerAndTexts();
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            m_cheatCode.LoadAnOtherRoomInZoneA();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            m_cheatCode.LoadAnOtherRoomInZoneB();
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            m_cheatCode.SetJimmyFPSToLow();
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            m_cheatCode.SetJimmyFPSToMedium();
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            m_cheatCode.SetJimmyFPSToHight();
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            m_cheatCode.SetOnOffRoomA();
        }
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            m_cheatCode.SetOnOffRoomB();
        }
        if (Input.GetKeyDown(KeyCode.KeypadDivide))
        {
            m_cheatCode.SetOnOffDoorDebugJoinHighlight();
        }
        if (Input.GetButton("Fire1"))
        {
            m_cheatCode.SpawnObjectInSceneForDebugging();
        }

    }
}
