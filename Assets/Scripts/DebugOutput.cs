using UnityEngine;
using System.IO;
using System;

public class DebugOutput : MonoBehaviour
{
    private string logFilePath;
    bool isDebugOutput = false;

    void Start()
    {
        LoadFile();

        if (isDebugOutput)
        {
            // 定義日誌文件的路徑，可以是任何你想要保存日誌的地方
            logFilePath = Application.streamingAssetsPath + "/debug_log.txt";

            if (File.Exists(logFilePath))
                File.Delete(logFilePath);

            // 訂閱 Unity 的 logMessageReceived 事件，以獲取 Debug 輸出
            Application.logMessageReceived += LogMessageReceived;
        }
    }

    void OnDestroy()
    {
        // 取消訂閱 logMessageReceived 事件，避免內存泄漏
        Application.logMessageReceived -= LogMessageReceived;
    }
    void OnDisable() {
        // 取消訂閱 logMessageReceived 事件，避免內存泄漏
        Application.logMessageReceived -= LogMessageReceived;
    }

    // 當 Unity 有 Debug 輸出時，會調用這個方法
    private void LogMessageReceived(string logString, string stackTrace, LogType type)
    {
        if (isDebugOutput)
        {
            // 將 Debug 訊息寫入日誌文件中
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine(logString);
                //sw.WriteLine(stackTrace);
                sw.WriteLine(type);
                sw.WriteLine("--------------------");
            }
        }
    }

    private void LoadFile()
    {
        Client.IniFile iniFile = new Client.IniFile(Application.streamingAssetsPath + @"\DebugSetting.ini");

        int tempLog = int.Parse(iniFile.Read("log_file", "Setting"));
        isDebugOutput = Convert.ToBoolean(tempLog);
    }
}
