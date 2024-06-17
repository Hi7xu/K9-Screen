using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standby_Animation : MonoBehaviour
{
    public GameObject Standby_ALL;
    //public GameObject Standby_White;
    //public GameObject Standby_Yellow;
    private string Standby_ALL_Name = "";
    //private string Standby_White_Name = "";
    //private string Standby_Yellow_Name = "";
    private int SameTimes = 0;
    private int SameTimes_End = 10;

    private int PlayNum = 0;

    public int AnimationDelayTime_S;
    //private DateTime PlayEndTime = new DateTime();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (!Standby_ALL.transform.gameObject.activeInHierarchy && !Standby_White.transform.gameObject.activeInHierarchy && !Standby_Yellow.transform.gameObject.activeInHierarchy)
        //{
        //    if (DateTime.Now > PlayEndTime.AddSeconds(AnimationDelayTime_S))
        //    {
        //        switch (PlayNum)
        //        {
        //            case 0:
        //                Standby_ALL.transform.gameObject.SetActive(true);
        //                break;
        //            case 1:
        //                Standby_White.transform.gameObject.SetActive(true);
        //                break;
        //            case 2:
        //                Standby_Yellow.transform.gameObject.SetActive(true);
        //                break;
        //        }
        //        PlayNum++;
        //        if (PlayNum > 2)
        //            PlayNum = 0;
        //    }
        //} 
        CheckAnimatorEnd();
    }
    //ôz≤ÈÈf÷√Ñ”? «∑ÒΩY ¯
    void CheckAnimatorEnd() {
        //if (Standby_ALL.transform.gameObject.activeInHierarchy)
        //{
        //    if (Standby_ALL.transform.gameObject.GetComponent<SpriteRenderer>().sprite.name == Standby_ALL_Name)
        //    {
        //        SameTimes++;
        //        if (SameTimes > SameTimes_End)
        //        {
        //            Standby_ALL.transform.gameObject.SetActive(false);
        //            SameTimes = 0;
        //            PlayEndTime = DateTime.Now;
        //        }
        //    }
        //    else
        //    {
        //        SameTimes = 0;
        //    }
        //    Standby_ALL_Name = Standby_ALL.transform.gameObject.GetComponent<SpriteRenderer>().sprite.name;
        //}

        //if (Standby_White.transform.gameObject.activeInHierarchy)
        //{
        //    if (Standby_White.transform.gameObject.GetComponent<SpriteRenderer>().sprite.name == Standby_White_Name)
        //    {
        //        SameTimes++;
        //        if (SameTimes > SameTimes_End)
        //        {
        //            Standby_White.transform.gameObject.SetActive(false);
        //            SameTimes = 0;
        //            PlayEndTime = DateTime.Now;
        //        }
        //    }
        //    else
        //    {
        //        SameTimes = 0;
        //    }
        //    Standby_White_Name = Standby_White.transform.gameObject.GetComponent<SpriteRenderer>().sprite.name;
        //}
        //if (Standby_Yellow.transform.gameObject.activeInHierarchy)
        //{
        //    if (Standby_Yellow.transform.gameObject.GetComponent<SpriteRenderer>().sprite.name == Standby_Yellow_Name)
        //    {
        //        SameTimes++;
        //        if (SameTimes > SameTimes_End)
        //        {
        //            Standby_Yellow.transform.gameObject.SetActive(false);
        //            SameTimes = 0;
        //            PlayEndTime = DateTime.Now;
        //        }
        //    }
        //    else
        //    {
        //        SameTimes = 0;
        //    }
        //    Standby_Yellow_Name = Standby_Yellow.transform.gameObject.GetComponent<SpriteRenderer>().sprite.name;
        //}
    }
}
