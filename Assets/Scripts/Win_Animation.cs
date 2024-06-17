using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win_Animation : MonoBehaviour
{
    public Reel[] winReel;
    public GameObject UI;
    private float Scale_UI_base=0.01f;
    private float Scale_UI = 0;
    private float Scale_UI_base_y = 0f;
    private float Scale_UI_y = 0;


    public GameObject King_Animator;
    public GameObject Queen_Animator;
    public GameObject Jack_Animator;
    public AudioSource SnarlSound;
    public AudioSource YellingSound;
    public AudioSource TearOffSound;
    public AudioSource YellingInEndSound;
    public AudioSource MusicAgerTigerScratch;
    public AudioSource BeatGongSound;
    private string King_Animator_Name = "";
    private string Queen_Animator_Name = "";
    private string Jack_Animator_Name = "";
    private bool Animator_End = false;
    public float Animator_Speed;
    private int SameTimes = 0;
    private int SameTimes_End = 15;
    public float SnarlDelayTime;
    public float BeatGongDelayTime;
    public float YellingDelayTime;
    public float TearOffDelayTime;
    public float YellingInEndDelayTime;
    public float MusicAfterTigerScratchDelayTime;
    public static bool IsPlayingSound = false;

    public int AnimationDelayTimeToEnd_S;
    private DateTime PlayEndTime = new DateTime();
    // Start is called before the first frame update
    void Start()
    {
        Scale_UI = Scale_UI_base;
        Scale_UI_y = Scale_UI_base_y;
        King_Animator.transform.gameObject.GetComponent<Animator>().speed = Animator_Speed;
        Queen_Animator.transform.gameObject.GetComponent<Animator>().speed = Animator_Speed;
        Jack_Animator.transform.gameObject.GetComponent<Animator>().speed = Animator_Speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isActiveAndEnabled && !IsPlayingSound)
        {
            SnarlSound.PlayDelayed(SnarlDelayTime);
            BeatGongSound.PlayDelayed(BeatGongDelayTime);
            YellingSound.PlayDelayed(YellingDelayTime);
            TearOffSound.PlayDelayed(TearOffDelayTime);
            YellingInEndSound.PlayDelayed(YellingInEndDelayTime);
            MusicAgerTigerScratch.PlayDelayed(MusicAfterTigerScratchDelayTime);
            IsPlayingSound = true;
        }

        if (Animator_End)
        {
            if (DateTime.Now > PlayEndTime.AddSeconds(AnimationDelayTimeToEnd_S))
            {
                Scale_UI = Scale_UI_base;
                Scale_UI_y = Scale_UI_base_y;
                Animator_End = false;
                King_Animator.transform.gameObject.SetActive(false);
                Queen_Animator.transform.gameObject.SetActive(false);
                Jack_Animator.transform.gameObject.SetActive(false);
                UI.transform.gameObject.GetComponent<RectTransform>().localScale = new Vector3(Scale_UI_base, Scale_UI_base, 1);
                UI.transform.gameObject.GetComponent<RectTransform>().position = new Vector3(0, Scale_UI_base_y, 0);

                if (Client.isWin )
                {
                    for (int i = 0; i < winReel.Length; i++)
                    {
                        winReel[i].ResetWin();
                    }
                    Client.isWin = false;
                }

                transform.gameObject.SetActive(false);

                Debug.Log("-----------end winning-----------");
                IsPlayingSound = false;
            }
        }
        else
        {
            if (Scale_UI < 1)
                Scale_UI += 0.001f;
            if (Scale_UI_y < 200)
                Scale_UI_y += 0.2f;
            
            UI.transform.gameObject.GetComponent<RectTransform>().localScale = new Vector3(Scale_UI, Scale_UI, 1);
            UI.transform.gameObject.GetComponent<RectTransform>().position = new Vector3(0, Scale_UI_y, 0);
        }
        CheckAnimatorEnd();
    }


    //脤嶨离?岆瘁磐旰
    void CheckAnimatorEnd()
    {
        if (Animator_End)
            return;
        if (King_Animator.transform.gameObject.activeInHierarchy)
        {
            if (King_Animator.transform.gameObject.GetComponent<SpriteRenderer>().sprite.name == King_Animator_Name)
            {
                SameTimes++;
                if (SameTimes > SameTimes_End)
                {
                    Animator_End = true;
                    SameTimes = 0;
                    PlayEndTime = DateTime.Now;
                }
            }
            else
            {
                SameTimes = 0;
            }
            King_Animator_Name = King_Animator.transform.gameObject.GetComponent<SpriteRenderer>().sprite.name;
        }

        if (King_Animator.transform.gameObject.activeInHierarchy)
        {
            if(King_Animator.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {

            }
        }

        if (Queen_Animator.transform.gameObject.activeInHierarchy)
        {
            if (Queen_Animator.transform.gameObject.GetComponent<SpriteRenderer>().sprite.name == Queen_Animator_Name)
            {
                SameTimes++;
                if (SameTimes > SameTimes_End)
                {
                    Animator_End = true;
                    SameTimes = 0;
                    PlayEndTime = DateTime.Now;
                }
            }
            else
            {
                SameTimes = 0;
            }
            Queen_Animator_Name = Queen_Animator.transform.gameObject.GetComponent<SpriteRenderer>().sprite.name;
        }
        if (Jack_Animator.transform.gameObject.activeInHierarchy)
        {
            if (Jack_Animator.transform.gameObject.GetComponent<SpriteRenderer>().sprite.name == Jack_Animator_Name)
            {
                SameTimes++;
                if (SameTimes > SameTimes_End)
                {
                    Animator_End = true;
                    SameTimes = 0;
                    PlayEndTime = DateTime.Now;
                }
            }
            else
            {
                SameTimes = 0;
            }
            Jack_Animator_Name = Jack_Animator.transform.gameObject.GetComponent<SpriteRenderer>().sprite.name;
        }
    }
}
