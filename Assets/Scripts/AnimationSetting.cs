using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSetting : MonoBehaviour
{
    public float Speed;
    public AudioSource LongTigerRoar;
    public AudioSource ShortTigerRoar;
    public AudioSource RightTigerRoar;
    public AudioSource ShortTigerRoar2;

    public float LongTigerRoarDelayTime;
    public float ShortTigerRoarDelayTime;
    public float RightRoarDelayTime;
    public float ShortTigerRoar2DelayTime;
    public static bool IsPlayingSound = false;
    //public float StandbyAnimationTimer = 0;
    Client.IniFile iniFile;
    public float RoarLoopTime;
    public float TimePerMin;

    // 目前需求不要音效
    private bool isAudioEnable = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.gameObject.GetComponent<Animator>().speed = Speed;
        iniFile = new Client.IniFile(Application.streamingAssetsPath + @"\TigerSoundSetting.ini");
        LongTigerRoar.volume = float.Parse(iniFile.Read("WhiteTigerLongRoar" , "Volume"));
        ShortTigerRoar.volume = float.Parse(iniFile.Read("WhiteTigerShortRoar" , "Volume"));
        RightTigerRoar.volume = float.Parse(iniFile.Read("RightRoarDelayTime" , "Volume"));
        ShortTigerRoar2.volume = float.Parse(iniFile.Read("BrownTigerShortRoar" , "Volume"));
    }

    // Update is called once per frame
    void Update()
    {
        if (isAudioEnable)
        {
            if (!AnimationSetting.IsPlayingSound && !Win_Animation.IsPlayingSound)
            {

                // 150大約是一分鐘
                //TimePerMin = float.Parse(iniFile.Read("TimePerMin", "Time")); // TODO: 150
                //TimePerMin = float.IsNaN(TimePerMin) ? 150 : TimePerMin;
                //RoarLoopTime = float.Parse(iniFile.Read("TigerRoarTime", "Time")) * TimePerMin; // TODO: 30
                LongTigerRoar.PlayDelayed(LongTigerRoarDelayTime); // TODO: 1
                ShortTigerRoar.PlayDelayed(ShortTigerRoarDelayTime); // TODO: 3.5
                RightTigerRoar.PlayDelayed(RightRoarDelayTime); // TODO: 3.5
                ShortTigerRoar2.PlayDelayed(ShortTigerRoar2DelayTime); // TODO: 22.5
                AnimationSetting.IsPlayingSound = true;
            }


           // IdlAniAdjust.OnStateExitEvent += ResetIdleAniAudioPara;
        }

        //if (StandbyAnimationTimer == 0)
        //    Debug.Log("START: " + DateTime.Now.ToString("o"));
        ////目前當StandbyAnimationTimer = 75左右時，閒置動畫一個循環
        //StandbyAnimationTimer += Time.deltaTime * Speed;
        //if ((int)Math.Round(StandbyAnimationTimer) % 1500 == 0)
        //    Debug.Log(DateTime.Now.ToString("o")+" ----- "+ StandbyAnimationTimer);
        //if (StandbyAnimationTimer >= RoarLoopTime)
        //{
        //    Debug.Log("END: " + DateTime.Now.ToString("o"));
        //    IsPlayingSound = false;
        //    StandbyAnimationTimer = 0;
        //}
    }

/*    private void OnEnable() {
        IdlAniAdjust.OnStateExitEvent += ResetIdleAniAudioPara;
    }

    private void OnDisable() {
        IdlAniAdjust.OnStateExitEvent -= ResetIdleAniAudioPara;
    }
*/
    private void ResetIdleAniAudioPara()
    {
        IsPlayingSound = false;
        //StandbyAnimationTimer = 0;
    }
}
