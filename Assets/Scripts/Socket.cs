using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Protocol_LianCai;
using System.IO;
using System.Text;
using System;
using UnityEngine.UI;

public class Socket : MonoBehaviour
{
    private static CommBase_CHA.TcpSocketClient Client_tcp;
    //public TcpSocketClient client_main;
    //public TcpSocketClient client_sub;

    //public GameObject BackGround;
    //public GameObject KingBorder;
    //public GameObject QueenBorder;
    //public GameObject JackBorder;

    public GameObject WinObject;
    public GameObject WinObject_KingAnimation;
    public GameObject WinObject_QueenAnimation;
    public GameObject WinObject_JackAnimation;
    //public GameObject NormalScreen;

    //private string current_win_king_prize = "";
    //private string current_win_queen_prize = "";
    //private string current_win_jack_prize = "";
    //private bool king_winning = false;
    //private bool queen_winning = false;
    //private bool jack_winning = false;
    public double kingOldNum, queenOldNum, jackOldNum;

    public string ServerIP;
    public int ServerPort=8600;

    public GameObject EmptyScene3;
    public GameObject UICanvas;
    //public GameObject EmptyScene;
    public GameObject RuleCanvas;
    //public GameObject EmptyScene2;
    public GameObject LeaderboardsCanvas;

    //private bool ShowRule = false;

    public int EmptyScene3ShowTime_S;
    public int UIShowTime_S;
    //public int EmptySceneShowTime_S;
    public int RuleShowTime_S;
    //public int EmptyScene2ShowTime_S;
    public int LeaderboardsShowTime_S;

    //private DateTime ChangeShowTime = new DateTime();
    // Start is called before the first frame update

    public Text[] KingLeaderboards_MachineNumber;
    public Text[] KingLeaderboards_Score;
    public Text[] KingLeaderboards_Time;
    public Text[] QueenLeaderboards_MachineNumber;
    public Text[] QueenLeaderboards_Score;
    public Text[] QueenLeaderboards_Time;
    public Text[] JackLeaderboards_MachineNumber;
    public Text[] JackLeaderboards_Score;
    public Text[] JackLeaderboards_Time;
    Client.IniFile iniFile;

    private float gcCollectTimer = 0f;
    public enum CanvasState
    {
        EmptyScene3,
        UICanvas,
        RuleCanvas,
        LeaderboardsCanvas,
    }
    private CanvasState currentCanvasState = CanvasState.EmptyScene3;
    private DateTime nextCanvasChangeTime;
   

    public CanvasState GetCurrentCanvas()
    {
        return currentCanvasState;
    }

    void Start()
    {
        ServerIP = readtxt("Server_IP.txt");
        Application.targetFrameRate = 60;
        gcCollectTimer = 0f;

        List<CommBase> CommBase_msgs = new List<CommBase>();
        Client_tcp = new CommBase_CHA.TcpSocketClient(ServerIP, ServerPort);

        //KingBorder = GameObject.Find("King");
        //QueenBorder = GameObject.Find("Queen");
        //JackBorder = GameObject.Find("Jack");
        ////NormalScreen = GameObject.Find("NormalScreen");
        //BackGround = GameObject.Find("BackGround");
        if (Debug.isDebugBuild) Debug.Log("--------------Test---------------");

        nextCanvasChangeTime = DateTime.Now.AddSeconds(EmptyScene3ShowTime_S);
        iniFile = new Client.IniFile(Application.streamingAssetsPath + @"\ShowTimeSetting.ini");

        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        Debug.Log(" *** Start game at " + timestamp + " ***");

        UIShowTime_S = int.Parse(iniFile.Read("UIShowTime" , "Time"));
        RuleShowTime_S = int.Parse(iniFile.Read("RuleShowTime" , "Time"));
        LeaderboardsShowTime_S = int.Parse(iniFile.Read("LeaderboardsShowTime " , "Time"));
        EmptyScene3ShowTime_S = int.Parse(iniFile.Read("EmptySceneShowTime" , "Time"));
    }

    // Update is called once per frame
    void Update()
    {
    
        //if (Debug.isDebugBuild) Debug.Log("Update");
        if (Client_tcp.RecvMsgs.Count > 0)
        {
            //if (Debug.isDebugBuild)Debug.Log("Update_while");
            
            var RecvMsg = Client_tcp.RecvMsgs[0];
            Client_tcp.RecvMsgs.RemoveAt(0); //Client_tcp.RecvMsgs.RemoveAll(x => x == RecvMsg);
            
            try
            {

                CommBase Command = new CommBase(RecvMsg);
                try
                {
                    //if (Debug.isDebugBuild) Debug.Log(RecvMsg);
                    switch (Command.Type)
                    {
                        #region Token
                        case CommBaseType.ConnectCheck:
                            ConnectCheck connectCheck = new ConnectCheck(Command.MsgJson);
                            break;
                        #endregion
                        #region 彩池累積狀況
                        case CommBaseType.PoolInfo:
                            PoolInfo poolInfo = new PoolInfo(Command.MsgJson);
                            //if (Debug.isDebugBuild) Debug.Log(string.Format("King:{0},Queen:{1},Jack:{2}", poolInfo.pool_value.King, poolInfo.pool_value.Queen, poolInfo.pool_value.Jack));

                            #region 設定更新
                            Client.KingSetting = poolInfo.pool_bound.King;
                            Client.QueenSetting = poolInfo.pool_bound.Queen;
                            Client.JackSetting = poolInfo.pool_bound.Jack;
                            Client.KingLeastBet = poolInfo.least_bet.King;
                            Client.QueenLeastBet = poolInfo.least_bet.Queen;
                            Client.JackLeastBet = poolInfo.least_bet.Jack;
                            #endregion

                            #region 滾輪更新
                            if (poolInfo.pool_value.King != kingOldNum)
                            {
                               Client.KingNumber = poolInfo.pool_value.King;
                            }
                            kingOldNum = poolInfo.pool_value.King;

                            if (poolInfo.pool_value.Queen != queenOldNum)
                            {
                                Client.QueenNumber = poolInfo.pool_value.Queen;
                            }
                            queenOldNum = poolInfo.pool_value.Queen;

                            if (poolInfo.pool_value.Jack != jackOldNum)
                            {
                                Client.JackNumber = poolInfo.pool_value.Jack;
                            }
                            jackOldNum = poolInfo.pool_value.Jack;
                            #endregion

                            break;
                        #endregion
                        #region 中獎資訊
                        case CommBaseType.LianCai_PrizeInfo:
                            Debug.LogError("中獎");
                            PrizeWinner prizeWinner = new PrizeWinner(Command.MsgJson);
                            //if (Debug.isDebugBuild) Debug.Log(string.Format("machine_id:{0},machine_no:{1},points:{2}", prizeWinner.game_id, prizeWinner.machine_no, prizeWinner.points));
                            Debug.Log("-----------start winning-----------");
                            WinObject_KingAnimation.transform.gameObject.SetActive(false);
                            WinObject_QueenAnimation.transform.gameObject.SetActive(false);
                            WinObject_JackAnimation.transform.gameObject.SetActive(false);

                            if (prizeWinner.pool_name == "King")
                            {
                                //king_winning = true;
                                Client.current_win_prize = prizeWinner.points;
                                WinObject_KingAnimation.transform.gameObject.SetActive(true);
                            }
                            else if (prizeWinner.pool_name == "Queen")
                            {
                                //queen_winning = true;
                                Client.current_win_prize = prizeWinner.points;
                                WinObject_QueenAnimation.transform.gameObject.SetActive(true);
                            }
                            else if (prizeWinner.pool_name == "Jack")
                            {
                                //jack_winning = true;
                                Client.current_win_prize = prizeWinner.points;
                                WinObject_JackAnimation.transform.gameObject.SetActive(true);
                            }
                            WinObject.transform.gameObject.SetActive(true);
                            break;
                        #endregion
                        #region 排名榜資訊
                        case CommBaseType.SelectPrizeWinnerLog:
                            List<PrizeWinner> prizeWinners = String_CHA.JsonCHA.DeserializeObject< List<PrizeWinner>>(Command.MsgJson);

                            if(prizeWinners.Count != 0)
                            {
                                if (prizeWinners[0].pool_name == "King")
                                {
                                    for (int i = 0; i < KingLeaderboards_MachineNumber.Length; i++)
                                    {
                                        if (i <= prizeWinners.Count)
                                        {

                                            KingLeaderboards_MachineNumber[i].text = (prizeWinners[i].machine_no.ToString()+ "號機");
                                            KingLeaderboards_Score[i].text = prizeWinners[i].points.ToString("N0");
                                            KingLeaderboards_Time[i].text = prizeWinners[i].log_time.ToString("MM/dd HH:mm");
                                        }
                                        else
                                        {
                                            KingLeaderboards_MachineNumber[i].text = "";
                                            KingLeaderboards_Score[i].text = "";
                                            KingLeaderboards_Time[i].text = "";
                                        }
                                    }
                                }
                                else if (prizeWinners[0].pool_name == "Queen")
                                {
                                    for (int i = 0; i < QueenLeaderboards_MachineNumber.Length; i++)
                                    {
                                        if (i <= prizeWinners.Count)
                                        {
                                            QueenLeaderboards_MachineNumber[i].text = (prizeWinners[i].machine_no.ToString()+ "號機");
                                            QueenLeaderboards_Score[i].text = prizeWinners[i].points.ToString("N0");
                                            QueenLeaderboards_Time[i].text = prizeWinners[i].log_time.ToString("MM/dd HH:mm");
                                        }
                                        else
                                        {
                                            QueenLeaderboards_MachineNumber[i].text = "";
                                            QueenLeaderboards_Score[i].text = "";
                                            QueenLeaderboards_Time[i].text = "";
                                        }
                                    }
                                }
                                else if (prizeWinners[0].pool_name == "Jack")
                                {
                                    for (int i = 0; i < JackLeaderboards_MachineNumber.Length; i++)
                                    {
                                        if (i <= prizeWinners.Count)
                                        {
                                            JackLeaderboards_MachineNumber[i].text = (prizeWinners[i].machine_no.ToString()+"號機");
                                            JackLeaderboards_Score[i].text = prizeWinners[i].points.ToString("N0");
                                            JackLeaderboards_Time[i].text = prizeWinners[i].log_time.ToString("MM/dd HH:mm");
                                        }
                                        else
                                        {
                                            JackLeaderboards_MachineNumber[i].text = "";
                                            JackLeaderboards_Score[i].text = "";
                                            JackLeaderboards_Time[i].text = "";
                                        }

                                    }
                                }
                            }

                            break;
                        #endregion
                        default:
                            break;
                    }
                    RecvMsg = null;
                }
                
                catch (Exception e)
                {
                    Console.WriteLine(string.Format("通訊內容不符合規定，錯誤代碼:{0}", e.ToString()));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("通訊內容不符合規定，錯誤代碼:{0}", e.ToString()));
            }
            
           
        }
        if ( !WinObject.transform.gameObject.activeInHierarchy ) {
            if ( DateTime.Now > nextCanvasChangeTime  ) {
                SwitchCanvas();
                nextCanvasChangeTime = DateTime.Now.AddSeconds(GetCurrentCanvasShowTime());
            }
        }
        else {
            UICanvas.transform.gameObject.SetActive(true);
            RuleCanvas.transform.gameObject.SetActive(false);
            LeaderboardsCanvas.transform.gameObject.SetActive(false);
            EmptyScene3.transform.gameObject.SetActive(false);
            currentCanvasState = CanvasState.UICanvas;
        }

        //TODO: 拿掉sleep並新增GC.Collect
        //Thread.Sleep(10);
        /*
        gcCollectTimer += Time.deltaTime;

        if (gcCollectTimer >= 1800f)
        {
            if (!WinObject.transform.gameObject.activeInHierarchy)
            {
                Debug.Log(DateTime.Now + ":" + "GC_Collecting");
                StartCoroutine(ClearAsset());
                gcCollectTimer = 0f;
            }
        }
        */


        //if (!WinObject.transform.gameObject.activeInHierarchy)
        //{
        //    if (ShowRule)
        //    {
        //        if (DateTime.Now > ChangeShowTime.AddSeconds(RuleShowTime_S))
        //        {
        //            ShowRule = false;
        //            RuleCanvas.transform.gameObject.SetActive(false);
        //            UICanvas.transform.gameObject.SetActive(true);
        //            ChangeShowTime = DateTime.Now;
        //        }
        //    }
        //    else
        //    {
        //        if (DateTime.Now > ChangeShowTime.AddSeconds(UIShowTime_S))
        //        {
        //            ShowRule = true;
        //            RuleCanvas.transform.gameObject.SetActive(true);
        //            UICanvas.transform.gameObject.SetActive(false);
        //            ChangeShowTime = DateTime.Now;
        //        }
        //    }
        //}
        //else
        //{
        //    ShowRule = false;
        //    ShowLeaderboards = false;
        //    LeaderboardsCanvas.transform.gameObject.SetActive(false);
        //    RuleCanvas.transform.gameObject.SetActive(false);
        //    UICanvas.transform.gameObject.SetActive(true);
        //}



        //通訊檢測
        //if (BroadcastTime.AddMilliseconds(BroadcastDelaytime) < DateTime.Now)
        //{
        //    Broadcast();
        //    BroadcastTime = DateTime.Now;
        //}

    }


    IEnumerator ClearAsset() {
        Debug.Log(DateTime.Now + ":" + "釋放資源");
        Resources.UnloadUnusedAssets();
        yield return new WaitForSeconds(0.1f);
        System.GC.Collect();
    }
    void SwitchCanvas()
    {
        switch (currentCanvasState)
        {

            case CanvasState.EmptyScene3:
                EmptyScene3.transform.gameObject.SetActive(false);
                UICanvas.transform.gameObject.SetActive(true);
                RuleCanvas.transform.gameObject.SetActive(false);
                LeaderboardsCanvas.transform.gameObject.SetActive(false);
                currentCanvasState = CanvasState.UICanvas;
                break;

            case CanvasState.UICanvas:
                EmptyScene3.transform.gameObject.SetActive(false);
                UICanvas.transform.gameObject.SetActive(false);
                RuleCanvas.transform.gameObject.SetActive(true);  
                LeaderboardsCanvas.transform.gameObject.SetActive(false);
                currentCanvasState = CanvasState.RuleCanvas;
                break;

            case CanvasState.RuleCanvas:
                EmptyScene3.transform.gameObject.SetActive(false);
                UICanvas.transform.gameObject.SetActive(false);
                RuleCanvas.transform.gameObject.SetActive(false);
                LeaderboardsCanvas.transform.gameObject.SetActive(true); 
                currentCanvasState = CanvasState.LeaderboardsCanvas; 
                break;

            case CanvasState.LeaderboardsCanvas:
                EmptyScene3.transform.gameObject.SetActive(true);
                UICanvas.transform.gameObject.SetActive(false);
                RuleCanvas.transform.gameObject.SetActive(false);
                LeaderboardsCanvas.transform.gameObject.SetActive(false);
                currentCanvasState = CanvasState.EmptyScene3;
                break;
        }
    }

    int GetCurrentCanvasShowTime()
    {
        switch (currentCanvasState)
        {
            case CanvasState.EmptyScene3:
                return EmptyScene3ShowTime_S;
            case CanvasState.UICanvas:
                return UIShowTime_S;
            case CanvasState.RuleCanvas:
                return RuleShowTime_S;
            case CanvasState.LeaderboardsCanvas:
                return LeaderboardsShowTime_S;
            default:
                return 0;
        }
    }

    //private static int BroadcastDelaytime = 10000;//毫秒
    //private static DateTime BroadcastTime = new DateTime();

    //private static void Broadcast()
    //{
    //    ConnectCheck connectCheck = new ConnectCheck { Token = "Test", Time = DateTime.Now };
    //    CommBase commBase = new CommBase(CommBaseType.ConnectCheck, connectCheck);
    //    Client.SendMsgStr(commBase.ToJson());
    //}

    public static string readtxt(string text_file_name)
    {
        string settxt = "";
        try
        {
            string pathstr = Application.streamingAssetsPath + "/" + text_file_name;
            if (Debug.isDebugBuild) Debug.Log(pathstr);

            StreamReader sr = new StreamReader(pathstr, Encoding.Default);
            settxt = sr.ReadLine();
        }
        catch
        {

        }
        return settxt;
    }
}
