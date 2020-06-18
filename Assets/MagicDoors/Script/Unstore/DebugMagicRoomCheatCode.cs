using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMagicRoomCheatCode : MonoBehaviour
{
    public Light m_defautLight;
    public JimmyScreamer m_jimmy;
    public PerfsDestroy m_perfDestroyer;

    

    public GameObject [] m_debugCanvas;
    public GameObject m_contentRoomARef;
    public GameObject m_contentRoomBRef;
    public GameObject m_doorOfficalPosition;

    public bool m_displayBestLoader=true;
    public MagicDoubleDoorSwitcher m_magicSwitcher;
    public MagicRoomLoader m_allStudentTechno;
    public MagicRoomLoader m_bestOf;
    public bool m_displayHand = true;
    public GameObject [] m_handLinkedGameObject;

    public void SetScreamerFPS(bool isOn)
    {
        m_jimmy.gameObject.SetActive(isOn);
        for (int i = 0; i < m_debugCanvas.Length; i++)
        {
            m_debugCanvas[i].SetActive( isOn);
        }
    }

    public void SpawnObjectInSceneForDebugging()
    {
        m_perfDestroyer.CreateAnInstance();
    }

    public void SetOnOffDoorDebugJoinHighlight()
    {
        SwitchGameObject(m_doorOfficalPosition);
    }

    public void SetOnOffRoomB()
    {
        SwitchGameObject(m_contentRoomBRef);
    }

    public void SetOnOffRoomA()
    {
        SwitchGameObject(m_contentRoomARef);
    }

    public void SetJimmyFPSToHight()
    {
        m_jimmy.m_boundaryJimmyStart = 60;
    }

    public void SetJimmyFPSToMedium()
    {
        m_jimmy.m_boundaryJimmyStart = 50;
    }

    public void SetJimmyFPSToLow()
    {
        m_jimmy.m_boundaryJimmyStart = 40;
    }

    public void LoadAnOtherRoomInZoneB()
    {
        m_magicSwitcher.SwitchRoomB();
    }

    public void LoadAnOtherRoomInZoneA()
    {
        m_magicSwitcher.SwitchRoomA();
    }

    public void SwitchLightOnOff()
    {
        SwitchGameObject(m_defautLight);
    }

    public void SwitchBetweenBestOfAndAll()
    {
        m_displayBestLoader = !m_displayBestLoader;
        if (m_displayBestLoader)
        {
            SetLoadedToBestParticipants();
        }
        else
        {
            SetLoaderToAllParticipants();
        }
    }

    public void SetLoadedToBestParticipants()
    {
        m_magicSwitcher.m_roomsQueue = m_bestOf.GetRoomsInShuffleQueue(true);
        m_magicSwitcher.m_roomLoader = (m_bestOf);
    }

    public void SetLoaderToAllParticipants()
    {
        m_magicSwitcher.m_roomsQueue = m_allStudentTechno.GetRoomsInShuffleQueue(true);
        m_magicSwitcher.m_roomLoader = (m_allStudentTechno);
    }

    public void SwitchHandsOnOff() {
        SetHandOnOff(!m_displayHand);
    }
    public void SetHandOnOff(bool isOn)
    {
        m_displayHand = isOn;
        for (int i = 0; i < m_handLinkedGameObject.Length; i++)
        {
            m_handLinkedGameObject[i].SetActive(isOn);

        }
       
    }

    public void SwitchJimmyScreamerAndTexts()
    {
        SwitchGameObject(m_jimmy);
        for (int i = 0; i < m_debugCanvas.Length; i++)
        {

            SwitchGameObject(m_debugCanvas[i]);
        }
    }

    public void SwitchGameObject(GameObject target) {
        target.SetActive(!target.activeSelf);

    }
    public void SwitchGameObject(Component target) {
        SwitchGameObject(target.gameObject);
    }
}
