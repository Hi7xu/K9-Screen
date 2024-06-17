using UnityEngine;
using UnityEngine.UI;
using System.Net.Sockets;
using System;
using CommBase_CHA;
using Protocol_LianCai;
using System.Reflection;
using System.Runtime.InteropServices;
using System.IO;
using System.Text;

public class Client : MonoBehaviour
{
    //private const string IP = "192.168.1.117";
    //private const int PORT = 8600;
    //private ClientSocket clientSocket = new ClientSocket();
    //JSONObject jsonObj = new JSONObject();

    public static Bound KingSetting=new Bound() { Max=250000, Min=140000 };
    public static Bound QueenSetting = new Bound() { Max = 250000, Min = 140000 };
    public static Bound JackSetting = new Bound() { Max = 250000, Min = 140000 };

    public static int KingLeastBet = 600;
    public static int QueenLeastBet = 300;
    public static int JackLeastBet = 0;

    public static double KingNumber=0;
    public static double QueenNumber = 0;
    public static double JackNumber = 0;

    public static double current_win_prize = 0;
    public static double current_win_king_prize = 0;
    public static double current_win_queen_prize = 0;
    public static double current_win_jack_prize = 0;

    public static bool isWin = false;

    public static int idleAniCount = 0;
    public static int winAniCount = 0;

    void Start()
    {
        idleAniCount = 0;
        winAniCount = 0;
        //if (clientSocket.connected)
        //{
        //    // 斷開
        //    clientSocket.CloseSocket();

        //}
        //else
        //{
        //    // 連接
        //    //clientSocket.Connect(IP, PORT);

        //}
        isWin = false;
    }

    private void Update()
    {
        //if (clientSocket.connected)
        //{
        //    //clientSocket.BeginReceive();
        //}
        //var msg = clientSocket.GetMsgFromQueue();
        //if (!string.IsNullOrEmpty(msg))
        //{
        //    Debug.Log("RecvCallBack: " + msg);
        //    string[] Numbmer = msg.Split('&');
        //    KingNumber = Convert.ToDouble(Numbmer[0]);
        //    QueenNumber = Convert.ToDouble(Numbmer[1]);
        //    JackNumber = Convert.ToDouble(Numbmer[2]);
        //}
    }
    //private void OnApplicationQuit()
    //{
    //    if (clientSocket.connected)
    //    {
    //        clientSocket.CloseSocket();
    //    }
    //}

    /// <summary>
    /// 新撰寫的IniFile檔讀取和寫入
    /// </summary>
    public class IniFile
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
           
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
        }
    }
}