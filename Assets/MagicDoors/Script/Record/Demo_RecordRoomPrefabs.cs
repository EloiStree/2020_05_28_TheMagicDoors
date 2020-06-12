using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Demo_RecordRoomPrefabs : MonoBehaviour
{

    public MagicRoomLoader m_roomsLoader;
    public ScreenshotAroundObject m_recorder;
    public FFMPEG_Images2VideoBuilder m_imagesToVideo;
    public FFMPEG_Video2VideoCycles m_videosToVideoWithCycles;
    public Transform m_whereToRecord;
    public GameObject[] m_unnamedPrefab;


    [Header("Debug")]
    public GameObject m_instanceFocused;


    [System.Serializable]
    public class PrefabToVideo
    {
        public string m_videoName;
        public GameObject m_prefabToRecord;
    }


    public void RecordThemAll()
    {
        if (m_recorder != null && m_imagesToVideo != null)
            StartCoroutine(Coroutine_RecordThemAll());

    }
    public IEnumerator Coroutine_RecordThemAll()
    {
        m_unnamedPrefab = m_roomsLoader.GetRoomsLoaded(true).ToArray();
        float t = Time.timeScale;
        Time.timeScale = 0f;

        for (int i = 0; i < m_unnamedPrefab.Length; i++)
        {

            if (m_unnamedPrefab[i] == null)
                continue;
            m_instanceFocused = GameObject.Instantiate(m_unnamedPrefab[i], m_whereToRecord.position, m_whereToRecord.rotation);

            m_recorder.SetStartFrame(0);
            m_recorder.StayInPauseAfterRecord();
            yield return new WaitForEndOfFrame();
            string name = ClampFormat(m_unnamedPrefab[i].name);
            m_imagesToVideo.SetImageStartNameFormat(name);
            m_imagesToVideo.SetImagesExtensions(m_recorder.GetExtensionUsedAsString());
            m_imagesToVideo.SetExportName(name);
            m_imagesToVideo.SetImportImagesRelativePath(m_recorder.m_screenManager.m_folderName);

            m_recorder.SetFileNameFormat(name);
            m_recorder.TakeScreenshotsAround();
            while (!m_recorder.HasFinishRecording())
            {
                yield return new WaitForEndOfFrame();
            }
            Debug.Log("CMD:" + m_imagesToVideo.GetPrebuildCommand().GetCmdReadyCommandLine());
            m_imagesToVideo.ExecuteWithCurrentPrebuild();
            Destroy(m_instanceFocused);
        }
        m_videosToVideoWithCycles.m_pathOrigineVideoFile = m_imagesToVideo.m_pathExportFolder;

        Time.timeScale = t;
        yield break;
    }

    private string ClampFormat(string text)
    {
        Regex rgx = new Regex("[^a-zA-Z0-9_]");
        return rgx.Replace(text, "");
    }
}
