using UnityEngine;
using System;
using UnityEngine.Profiling;

public class FPSDisplay : MonoBehaviour
{
    private float deltaTime = 0.0f; // fps顯示用

    private float checkInterval = 1.0f; // 檢查間隔（秒）
    private float lastCheckTime; // 上次檢查時間
    private int lastFrameCount; // 上次檢查時的幀數

    [SerializeField] Socket _socket;

    float totalReservedMemory = 0f;
    float totalAllocatedMemory = 0f;
    float totalUnusedReservedMemory = 0f;
    float memoryPercent = 0f;
    bool isFPSDispaly = false;

    void Start()
    {
        lastCheckTime = Time.time;
        lastFrameCount = Time.frameCount;

        LoadFile();

    }

    void Update()
    {
        
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;


        // 每隔一段時間(1s)檢查一次幀數是否掉幀
        if (Time.time - lastCheckTime >= checkInterval)
        {
            int currentFrameCount = Time.frameCount;
            float deltaTime = Time.time - lastCheckTime;
            int framesPassed = currentFrameCount - lastFrameCount;
            float fps = framesPassed / deltaTime;

            // 檢查是否掉幀
            if (fps < 57f)
            {
                GetMemoryInfo();

                string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                UnityEngine.Debug.Log(string.Format("==== Frame drop detected at {0} ==== FPS: {1}, currentCanvas: {2}, idlAniLoopCount: {3}, winAniCount: {4}",
                                        timestamp, fps, _socket.GetCurrentCanvas(), Client.idleAniCount, Client.winAniCount));
                UnityEngine.Debug.Log(string.Format("total memory {0} MB, aloocated {1} MB, unused: {2}, percent: {3}%",
                        totalReservedMemory, totalAllocatedMemory, totalUnusedReservedMemory, memoryPercent * 100f));
            }

            // 更新上次檢查的時間和幀數
            lastCheckTime = Time.time;
            lastFrameCount = currentFrameCount;
        }
        
    }

    void OnGUI()
    {
        
        if (isFPSDispaly)
        {
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(0, 0, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperLeft;
            style.fontSize = h * 5 / 100;
            style.normal.textColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            float msec = deltaTime * 1000.0f;
            float fps = 1.0f / deltaTime;
            string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
            GUI.Label(rect, text, style);
        }
        
    }


    private void GetMemoryInfo()
    {
        totalReservedMemory = Profiler.GetTotalReservedMemoryLong() / (float)1000000;
        totalAllocatedMemory = Profiler.GetTotalAllocatedMemoryLong() / (float)1000000;
        totalUnusedReservedMemory = Profiler.GetTotalUnusedReservedMemoryLong() / (float)1000000;
        memoryPercent = (float)Math.Round((totalAllocatedMemory / totalReservedMemory), 2);
    }

    private void LoadFile()
    {
        Client.IniFile iniFile = new Client.IniFile(Application.streamingAssetsPath + @"\DebugSetting.ini");

        int tempFps = int.Parse(iniFile.Read("show_fps", "Setting"));
        isFPSDispaly = Convert.ToBoolean(tempFps);
    }
}
