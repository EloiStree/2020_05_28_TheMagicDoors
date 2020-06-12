using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivorBeath : MonoBehaviour
{
    public CarnivorPlantLogic m_targetPlan;
    public AnimationCurve m_breathCurved;
    [Range(0,1)]
    public float m_pourcentMouthState;
    public float m_multiplicatorTime = 1f;
    public float m_multiplicatorBreath = 1f;

    void Update()
    {
        float pct = m_pourcentMouthState;
        float t = (Time.time * (1f / m_multiplicatorTime)) % 1f;
        t = Mathf.Clamp(t, 0f, 1f);
        pct += m_breathCurved.Evaluate( t)* m_multiplicatorBreath;
        m_targetPlan.SetAngle(pct);
    }

    internal void AddOpenPoucent(float valueInPourcent)
    {
        m_pourcentMouthState += valueInPourcent;
        m_pourcentMouthState = Mathf.Clamp(m_pourcentMouthState, 0f, 1f);
    }

    private void Reset()
    {
        m_targetPlan = GetComponent<CarnivorPlantLogic>();
    }
}
