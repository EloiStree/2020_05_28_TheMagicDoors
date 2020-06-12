using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivorProximityChecker : MonoBehaviour
{
    public LayerMask m_triggerMask;

    public Transform[] raycasts;
    public float m_lenght=0.1f;
    public bool m_detectObject;
    public bool HasObjectToEat() {

        return m_detectObject;
    }
    void  Start()
    {
        InvokeRepeating("Check", 0f, 0.5f);
    }
    void Check() {

        for (int i = 0; i < raycasts.Length; i++)
        {
            if (CheckHit(raycasts[i])) { 
                m_detectObject = true;
                return;
            }
        }
        m_detectObject = false;

    }

    public bool CheckHit(Transform origine) {
        if (origine == null) 
            return false;
        return Physics.Raycast(origine.position, origine.forward, m_lenght, m_triggerMask);

    }
}
