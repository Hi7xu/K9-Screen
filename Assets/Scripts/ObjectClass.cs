using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_Client
{
    class ObjectClass
    {
    }

    public enum CommBaseType
    {
        GameClient_PlayGame = 0,
        Server_WinPrize = 1,
        DisplayMonitor_PoolPrize = 2,
        Server_PoolPrize = 3,
        SettingClient_GameSetting = 4,
        SettingClient_SaveGameSetting = 5,
        SettingClient_JackPotSetting = 6,
        SettingClient_SaveJackPotSetting = 7,
        Server_MachineOn = 8,
        GameClient_MachineOn = 9,
        Connection = 10,


    }

    public class CommBase
    {
        public CommBaseType Type;
        public string Internal_IP;
        public string MsgJson;
    }


    public class Machine
    {
        public string current_coins { get; set; } //機台上還有的餘額
    }

    public class Account
    {
        public string account_id { get; set; } //帳號
        public string password { get; set; } //密碼
        public string permission { get; set; } //權限
        public DateTime log_time { get; set; }  //記錄時間
        public bool delete_mark { get; set; }  //軟刪除
    }


    public class GamePlay
    {
        public int recno { get; set; } //PK
        public string store_id { get; set; } //店家代號
        public int game_type { get; set; } //遊戲種類
        public int bet { get; set; } //押注金額
        public string machine_detail { get; set; } //機台詳細資料
        //public string commission { get; set; } //結算抽成結果紀錄
        public double commission_king { get; set; } //結算抽成結果紀錄
        public double commission_queen { get; set; } //結算抽成結果紀錄
        public double commission_jack { get; set; } //結算抽成結果紀錄
        public DateTime log_time { get; set; } //記錄時間
        public bool delete_mark { get; set; } //軟刪除
    }

    public class JackPotSetting
    {
        public int recno { get; set; } //PK
        public string pool_name { get; set; } //彩池名稱種類        
        public string high_win_rate_bound { get; set; } //開關與高機率中獎區間
        public double chance_raise_ratio { get; set; } //機率提升比例
        public bool default_data { get; set; } //開啟server後自動生成的假資料 如果是的話呈現1
        public DateTime log_time { get; set; } //記錄時間
        public bool delete_mark { get; set; } //軟刪除
    }

    public class JackPotSetting_Log
    {
        public int recno { get; set; } //PK
        public string pool_name { get; set; } //彩池名稱種類
        public double reset_prize_bound { get; set; } //獎池爆掉或中獎後從最小值至最小值加15 %之間隨機出一數值 開始重新累績
        public string high_win_rate_bound { get; set; } //開關與高機率中獎區間
        public DateTime log_time { get; set; } //記錄時間
        public bool delete_mark { get; set; } //軟刪除
    }


    public class PoolSetting
    {
        public int recno { get; set; } //PK
        public string pool_name { get; set; } //彩池名稱種類
        public string pool_bound { get; set; } //彩池上下限區間
        public int least_bet { get; set; } //最小押注
        public string commission { get; set; } //獎池爆掉或中獎後從最小值至最小值加15 %之間隨機出一數值 開始重新累績
        public double share_ratio { get; set; } //抽成彩池分配比例
        public double reset_prize_bound { get; set; } //最小起始比例
        public double chances_per_point { get; set; } //每分機率
        public bool jackpot_win_priority { get; set; } //優先開獎
        public bool bound_difference_pool_cycle { get; set; } //是否開啟差額併入上階功能
        public bool default_data { get; set; } //開啟server後自動生成的假資料 如果是的話呈現1
        public DateTime log_time { get; set; } //記錄時間
        public bool delete_mark { get; set; } //軟刪除

    }

    public class PoolSetting_Log
    {
        public int recno { get; set; } //PK
        public string pool_name { get; set; } //彩池名稱種類
        public string pool_bound { get; set; } //彩池上下限區間
        public int least_bet { get; set; } //最小押注
        public string commission { get; set; } //獎池爆掉或中獎後從最小值至最小值加15 %之間隨機出一數值 開始重新累績
        public double share_ratio { get; set; } //抽成彩池分配比例
        public double reset_prize_bound { get; set; } //最小起始比例
        public double chances_per_point { get; set; } //每分機率
        public bool jackpot_win_priority { get; set; } //優先開獎
        public bool default_data { get; set; } //開啟server後自動生成的假資料 如果是的話呈現1
        public DateTime log_time { get; set; } //記錄時間
        public bool delete_mark { get; set; } //軟刪除
    }



    public class PoolStatus
    {
        public int recno { get; set; } //PK
        public string pool_name { get; set; } //彩池名稱種類
        public double initial_start { get; set; } //彩池初始分數
        public double lower_pool_exceed_prize { get; set; } //低池子上下限差額的獎金 
        public bool default_data { get; set; } //開啟server後自動生成的假資料 如果是的話呈現1
        public DateTime log_time { get; set; } //記錄時間
        public bool delete_mark { get; set; } //軟刪除
    }

    public class PrizeWinner
    {
        public int recno { get; set; } //PK
        public int game_type { get; set; } //遊戲種類
        public string machine_detail { get; set; } //機台詳細資料
        public string pool_name { get; set; } //中獎彩池
        public double points { get; set; } //池子中獎金額      
        public bool default_data { get; set; } //開啟server後自動生成的假資料 如果是的話呈現1
        public DateTime log_time { get; set; } //記錄時間
        public bool delete_mark { get; set; } //軟刪除
    }

    public class StoreBranch
    {
        public int recno { get; set; } //PK
        public string store_name { get; set; } //店家名稱 (店家可自行命名)
        public string store_id { get; set; } //店家代號
        public DateTime log_time { get; set; } //記錄時間
        public bool delete_mark { get; set; } //軟刪除
    }

}
