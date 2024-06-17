using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CommBase_CHA;
using Game_Client;
using System;
using CommBase = Game_Client.CommBase;
using String_CHA;
using Newtonsoft.Json;
using System.IO;
using System.Text;

public class ButtonHandler : MonoBehaviour
{
    //public string s_string;
    public void Bet()
    {
        TcpSocketClient client;
        string ServerIP = readtxt("Server_IP");

        client = new TcpSocketClient(ServerIP, 8500);
        
        if (client.Connected)
        {
            Console.WriteLine("連線成功");
        }
        else
        {
            Console.WriteLine("連線失敗");
        }
        GamePlay game_play = new GamePlay()
        {
            store_id = "A",
            game_type = 0,
            bet = 1000000000,
            machine_detail = "{\"machine_no\":\"no.1\",\"machine_id\":\"0\"}",
            //commission = ,
            log_time = DateTime.Now,
            delete_mark = false,
        };
        CommBase commBase = new CommBase { Type = CommBaseType.GameClient_PlayGame, MsgJson = JsonConvert.SerializeObject(game_play) };
        client.SendMsgStr(JsonCHA.SerializeObject(commBase));
        
        client.Close();

    }

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("path : " + Application.streamingAssetsPath+$"/Database_IP.txt");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public string readtxt(string text_file_name)
    {
        string settxt = "";
        //將setting檔放在工作目錄內(bin/debug)
        try
        {
            //讀不到檔或沒資料就關閉程式並開啟RO官網
            string pathstr = Application.streamingAssetsPath + "/" + text_file_name;
            //string pathstr = @"d:/setting.txt";

            //抓的到檔就將IP讀出
            StreamReader sr = new StreamReader(pathstr, Encoding.Default);
            settxt = sr.ReadLine();
        }
        catch
        {
            

        }
        return settxt;
    }
}
