using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivorPlantLogic : MonoBehaviour
{

    [Range(0, 1)]
    public float m_openingAngle = 1;
    public float m_angleMin =10f;
    public float m_angleMax = 80f;
    public Transform m_rootAnchor;

    [Header("What to move")]
    public Transform m_topPart;
    public Transform m_downPart;
    [Header("If adjustement needed")]
    public float m_adjustementAngle = 0f;




    public void SetAngle (float valueInPourcent){

        float angle = m_angleMin+ (m_angleMax - m_angleMin) * valueInPourcent;

        m_topPart.position = m_rootAnchor.position;
        m_downPart.position = m_rootAnchor.position;
        m_topPart.rotation = m_rootAnchor.rotation * Quaternion.Euler(angle+ m_adjustementAngle, 0, 0);
        m_downPart.rotation = m_rootAnchor.rotation * Quaternion.Euler(-angle+ m_adjustementAngle, 0, 0);
    }

    private void OnValidate()
    {
        SetAngle(m_openingAngle);
    }
}
