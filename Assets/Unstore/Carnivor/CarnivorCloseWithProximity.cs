using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarnivorCloseWithProximity : MonoBehaviour
{
    public CarnivorBeath m_targetPlant;
    public CarnivorProximityChecker m_poximityChecker;
    public float m_closeFactor = 0.1f;
    public float m_openFactor = 0.1f;

    public void Update()
    {
        if (m_poximityChecker.HasObjectToEat())
            m_targetPlant.AddOpenPoucent(-m_closeFactor * Time.deltaTime);
        else 
            m_targetPlant.AddOpenPoucent( m_openFactor * Time.deltaTime);
    }
}
