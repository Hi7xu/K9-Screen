using Protocol_LianCai;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSetting : MonoBehaviour
{
   private Bound Setting = new Bound();
    private int LeastBet = 0;
    private string LeastBet_Str = "";
    private string Show_str = "";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.CompareTag("King"))
        {
            Setting = Client.KingSetting;
            LeastBet = Client.KingLeastBet;
        }
        else if (gameObject.CompareTag("Queen"))
        {
            Setting = Client.QueenSetting;
            LeastBet = Client.QueenLeastBet;
        }
        else if (gameObject.CompareTag("Jack"))
        {
            Setting = Client.JackSetting;
            LeastBet = Client.JackLeastBet;
        }

        if (LeastBet == 0)
        {
            LeastBet_Str = "無限制";
        }
        else
        {
            LeastBet_Str = string.Format("需押{0}分", LeastBet);
        }

        Show_str = string.Format("{0}~{1}", Setting.Min.ToString("N0"), Setting.Max.ToString("N0"));
        GetComponent<Text>().text = Show_str;
    }
}
