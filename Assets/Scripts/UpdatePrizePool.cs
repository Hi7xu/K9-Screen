using Game_Client;
using Newtonsoft.Json;
using String_CHA;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatePrizePool : MonoBehaviour
{ /*
    //±±¨î¼ú¦Àª÷ÃB
    void Update()
    {
       
        try
        {
            if (JsonCHA.DeserializeObject<CommBase>(UpdatePoolPrize.instance.client.RecvMsgs[0]).Type == CommBaseType.Server_PoolPrize)
            {

                if (JsonCHA.DeserializeObject<CommBase>(UpdatePoolPrize.instance.client.RecvMsgs[0]).Internal_IP == "")
                {

                    double points = JsonConvert.DeserializeObject<PrizeWinner>(JsonCHA.DeserializeObject<CommBase>
                        (UpdatePoolPrize.instance.client.RecvMsgs[0]).MsgJson).points;
                    string pool_name = JsonConvert.DeserializeObject<PrizeWinner>(JsonCHA.DeserializeObject<CommBase>
                        (UpdatePoolPrize.instance.client.RecvMsgs[0]).MsgJson).pool_name;
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogWarning(ex);
        }
    }
    */
}
