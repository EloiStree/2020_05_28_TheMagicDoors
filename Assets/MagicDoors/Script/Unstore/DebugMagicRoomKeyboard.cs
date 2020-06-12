using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMagicRoomKeyboard : MonoBehaviour
{
    public Light m_defautLight;
    public JimmyScreamer m_jimmy;
    public PerfsDestroy m_destroyer;
    public GameObject [] m_debugCanvas;
    public MagicDoubleDoorSwitcher m_magicSwitcher;
    public GameObject m_contentRoomARef;
    public GameObject m_contentRoomBRef;
    public GameObject m_doorOfficalPosition;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L)){
            SwitchGameObject(m_defautLight);
        }
        if (Input.GetKeyDown(KeyCode.J)|| Input.GetKeyDown(KeyCode.KeypadPeriod))
        {
            SwitchGameObject(m_jimmy);
            for (int i = 0; i < m_debugCanvas.Length; i++)
            {

            SwitchGameObject(m_debugCanvas[i]);
            }
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            m_magicSwitcher.SwitchRoomA();
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {

            m_magicSwitcher.SwitchRoomB();
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            m_jimmy.m_boundaryJimmyStart = 40;
        }
        if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            m_jimmy.m_boundaryJimmyStart = 50;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            m_jimmy.m_boundaryJimmyStart = 60;
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            SwitchGameObject(m_contentRoomARef);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMultiply))
        {
            SwitchGameObject(m_contentRoomBRef);
        }
        if (Input.GetKeyDown(KeyCode.KeypadDivide))
        {
            SwitchGameObject(m_doorOfficalPosition);
        }
        if (Input.GetButton("Fire1")) {
            m_destroyer.CreateAnInstance();
        }

    }
    public void SwitchGameObject(GameObject target) {
        target.SetActive(!target.activeSelf);

    }
    public void SwitchGameObject(Component target) {
        SwitchGameObject(target.gameObject);
    }
}
