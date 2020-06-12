using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_SwitchOnOffActions : MonoBehaviour
{
    public UnityEvent m_onOn;
    public UnityEvent m_onOff;
    public bool m_state;

    public void Switch() {
        SetOnOff(!m_state);
    }

    public void SetOnFor(float seconds)
    {
        SetOnOff(true);
        Invoke("Off", seconds);
    }
    public void SetOffFor(float seconds)
    {
        SetOnOff(false);
        Invoke("On", seconds);
    }

    public void On()
    {

        SetOnOff(true);
    }
    public void Off()
    {

        SetOnOff(false);
    }
    public void SetOnOff(bool setAsOn)
    {
        m_state = setAsOn;

        if (m_state)
        {
            m_onOn.Invoke();
        }
        else
        {
            m_onOff.Invoke();
        }
    }
}
