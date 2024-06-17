using CommBase_CHA;
using Game_Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using String_CHA;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;//須加上
using CommBase = Game_Client.CommBase;

public class UpdatePoolPrize : MonoBehaviour
{
    public static UpdatePoolPrize instance;
    public TcpSocketClient client;
    [SerializeField]
    Text king, queen, jack;
    //string old_king_price = "";
    //string old_queen_price = "";
    //string old_jack_price = "";
    Transform KingDecimalNumber2;
    public int speed = 50;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        string ServerIP = readtxt("Server_IP.txt");

        client = new TcpSocketClient(ServerIP, 8500);
        if (client.Connected)
        {
            CommBase commBase = new CommBase { Type = CommBaseType.Connection, Internal_IP = ServerIP, MsgJson = "Display" };
            client.SendMsgStr(JsonCHA.SerializeObject(commBase));
            if (Debug.isDebugBuild)
            {
                Debug.Log("連線成功");
                Debug.LogWarning("連線成功");
            }
        }
        else
        {
            if (Debug.isDebugBuild)
            {
                Debug.Log("連線失敗");
                Debug.LogWarning("連線失敗");
            }
        }

        KingDecimalNumber2 = GameObject.Find("KingDecimalNumber2").transform;
        //Debug.Log(KingDecimalNumber2);
        //Vector2 movementDirection = Vector2.up * speed * Time.deltaTime;
        //KingDecimalNumber2.Translate(movementDirection);




    }

    private void FixedUpdate()
    {
        //KingDecimalNumber2.transform.Translate(new Vector2(0, 2000) * speed * Time.deltaTime);

    }

    void Update()
    {
        
       // KingDecimalNumber2.position = new Vector3(KingDecimalNumber2.position.x, KingDecimalNumber2.position.y + speed * Time.deltaTime);
       /*
        if (KingDecimalNumber2.position.y >= 1930f)
        {
            KingDecimalNumber2.position = new Vector3(612f, -43f);
        }
        //KingDecimalNumber2.transform.Translate(new Vector2(0f, 5f) * speed * Time.deltaTime);
        if (Debug.isDebugBuild)
        {
            Debug.Log("position:" + KingDecimalNumber2.position);
            try
            {
                Debug.Log("123:" + KingDecimalNumber2);
            }
            catch (Exception ex)
            {
                Debug.Log("ex:" + ex);

            }
        }
       */

        //Vector2 movementDirection = Vector2.up * speed * Time.deltaTime;
        //KingDecimalNumber2.Translate(movementDirection);

        //Debug.Log()


        //try
        //{
        //    bool a = old_king_price != king.text;
        //    bool b = old_queen_price != queen.text;
        //    bool c = old_jack_price != jack.text;
        //    if (old_king_price != king.text || old_queen_price != queen.text || old_jack_price != jack.text)
        //    {
        //        if (JsonCHA.DeserializeObject<Game_Client.CommBase>(client.RecvMsg).Type == CommBaseType.DisplayMonitor_PoolPrize)
        //        {
        //            string commission_json = JsonCHA.DeserializeObject<Game_Client.CommBase>(client.RecvMsg).MsgJson;
        //            JObject commission = JsonConvert.DeserializeObject<JObject>(commission_json);

        //            king = GameObject.Find("KingPoolText").GetComponent<Text>();
        //            queen = GameObject.Find("QueenPoolText").GetComponent<Text>();
        //            jack = GameObject.Find("JackPoolText").GetComponent<Text>();
        //            king.text = commission["King"].ToString(); ;
        //            queen.text = commission["Queen"].ToString();
        //            jack.text = commission["Jack"].ToString();



        //            old_king_price = king.text;
        //            old_queen_price = queen.text;
        //            old_jack_price = jack.text;

        //        }

        //    }
        //}
        //catch (Exception ex)
        //{


        //}



    }
    public string readtxt(string text_file_name)
    {
        string settxt = "";
        //將setting檔放在工作目錄內(bin/debug)
        try
        {
            //讀不到檔或沒資料就關閉程式並開啟RO官網
            string pathstr = Application.streamingAssetsPath + "/" + text_file_name;
            if (Debug.isDebugBuild) Debug.Log(pathstr);
            //string pathstr = @"d:/setting.txt";

            //抓的到檔就將IP讀出
            StreamReader sr = new StreamReader(pathstr, Encoding.Default);
            settxt = sr.ReadLine();
        }
        catch
        {

            Debug.Log(" ");
        }
        return settxt;
    }
}
