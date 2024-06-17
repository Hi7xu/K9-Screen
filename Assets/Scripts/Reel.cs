using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using System;

public class Reel : MonoBehaviour
{
    //使用時因為當前數字座標會回到000，所以假設要回到數字四，抓該數字列的第五個物件，當物件座標等於000的時候就停止

    public bool isReel;
    public int speed;
    public List<Transform> NumbersList;

    public List<GameObject> Number_childern;
    Transform Numbers;
    public int TopTransform, DownTransform;
    public int NumberSide;
    public float visible;
    double afternum = 0.00;
    double beforenum = 0.00;
    public int afterlenth ;
    public int beforelenth;
    public char[] g_after;
    public char[] g_before;
    CanvasRenderer NumberDisplay;
    Image ImageDisplay;
    protected void Awake()
    {
        Numbers = transform.GetChild(0);
        NumbersList.Clear();

        foreach (Transform item in Numbers) NumbersList.Add(item);

        NumberDisplay = gameObject.GetComponentInChildren<CanvasRenderer>();

        ImageDisplay = gameObject.GetComponentInChildren<Image>();

        visible = NumberDisplay.GetAlpha();

    }


    void ChangeImageAlpha(Transform ts, float alpha)
    {

        GameObject obj = ts.gameObject;

        obj.GetComponent<CanvasRenderer>().SetAlpha(alpha);


        if (alpha > 0) obj.GetComponent<Image>().color =  new Color32(255, 255, 225, 255);
        else obj.GetComponent<Image>().color = new Color32(255, 255, 225, 0);


    }


    protected void Update()
    {
     

        visible = NumberDisplay.GetAlpha();
        // System.Random rnd = new System.Random(Guid.NewGuid().GetHashCode());
        //測試數字
        if (gameObject.CompareTag("King"))
        {
            afternum = Client.KingNumber;
        }
        else if (gameObject.CompareTag("Queen"))
        {
            afternum = Client.QueenNumber;
        }
        else if (gameObject.CompareTag("Jack"))
        {
            afternum = Client.JackNumber;
        }
        else
        {
            afternum = Client.current_win_prize;
            Client.isWin = true;
        }
        //Debug.Log(afternum.ToString("#0.00"));
        //Debug.Log(Time.deltaTime + " " + NumberSide);
        char[] After = afternum.ToString("#0.00").ToCharArray();
        char[] Before = beforenum.ToString("#0.00").ToCharArray();

        afterlenth = After.Length;
        beforelenth = Before.Length;
        g_after = afternum.ToString("#0.00").ToCharArray();
        g_before = beforenum.ToString("#0.00").ToCharArray();
        //反轉數字由小到大
        Array.Reverse(After);
        Array.Reverse(Before);
        //int num = After.Length
        int j = NumberSide;
        int originSpeed =speed;

        //if (afternum < beforenum)
        //{
        //    beforenum = 0.00;
        //    foreach (Transform child in NumbersList) ChangeImageAlpha(child, 0);
        //    for (int i = 0; i < Before.Length; i++)
        //    {
        //        Before[i] = '0';
        //    }
        //}


        if (j > (After.Length - 1))
        {
            //TestStop();
            isReel = false;

            //NumberDisplay.SetAlpha(0);
            //ImageDisplay.color = new Color32(255, 255, 225, 0);
            foreach (Transform child in NumbersList) ChangeImageAlpha(child,0);

        }

        else
        {
            //if(NumberDisplay.GetAlpha() == 0)
            //{
               
                //NumberDisplay.SetAlpha(1);
                //ImageDisplay.color = new Color32(255, 255, 225, 255);
                foreach (Transform child in NumbersList) ChangeImageAlpha(child, 1);
            //}
            isReel = true;
            if (After.Length > Before.Length)
            {
                int a = Before.Length;
                Array.Resize(ref Before, Before.Length+(After.Length-Before.Length));
                for(int i = a;i<Before.Length;i++)
                {
                    Before[i] = '0';
                }
                //Before[Before.Length - 1] = '0';
            }




            if (j == (After.Length - 1))
            {
                speed -= 55;
            }
        }
        if(After.Length >= 6)
        {
            if(j ==11)
            {
                
              //  NumberDisplay.SetAlpha(1);
              //  ImageDisplay.color = new Color32(255, 255, 225, 255);
                foreach (Transform child in NumbersList) ChangeImageAlpha(child, 1);
            }

            if (After.Length >= 10)
            {
                if(j ==12)
                {
                   
                //    NumberDisplay.SetAlpha(1);
                //   ImageDisplay.color = new Color32(255, 255, 225, 255);
                    foreach (Transform child in NumbersList) ChangeImageAlpha(child, 1);
                }
            }
        }

        if (After.Length < 10)
        {
            if (j == 12)
                foreach (Transform child in NumbersList) ChangeImageAlpha(child, 0);
        }
        if (After.Length < 6)
        {
            if (j == 11)
                foreach (Transform child in NumbersList) ChangeImageAlpha(child, 0);
        }

        //if(After.Length>6)
        //{
        //    if(j == 11)
        //    {
        //        gameObject.
        //    }
        //}
        //isReel = true;
        if (isReel)
        {
            //foreach (var item in NumbersList)
            //{
            //    item.localPosition += (Vector3.up * Time.deltaTime * speed);
            //    if (item.localPosition.y >= TopTransform)
            //        item.localPosition = new Vector3(0, DownTransform, 0);
            //}
            //if (After.Length > Before.Length)
            //{
            //    for (int i = 0; i < (int)char.GetNumericValue(After[num - 1]); i++)
            //    {
            //        NumbersList[i].localPosition += (Vector3.up * Time.deltaTime * speed);
            //        if (NumbersList[i].localPosition.y >= TopTransform)
            //            NumbersList[i].localPosition = new Vector3(0, DownTransform, 0);
            //    }
            //    num -= 1;
            //}

            int testSpeed = 250 * (Math.Abs(After[j] - Before[j]) != 0 ? Math.Abs(After[j] - Before[j]) : 1)*4;
            #region test 1
            //if (After[j] != Before[j])
            //{
            //    if (After[j] > Before[j])
            //    {
            //        for (int i = (int)char.GetNumericValue(Before[j]); i <= (int)char.GetNumericValue(After[j]); i++)
            //        {
            //            NumbersList[i].localPosition += (Vector3.up * Time.deltaTime * testSpeed);
            //            if (NumbersList[i].localPosition.y >= TopTransform)
            //                NumbersList[i].localPosition = new Vector3(0, DownTransform, 0);
            //        }
            //    }
            //    else
            //    {
            //        for (int i = (int)char.GetNumericValue(Before[j]); i <= 9; i++)
            //        {
            //            NumbersList[i].localPosition += (Vector3.up * Time.deltaTime * testSpeed);
            //            if (NumbersList[i].localPosition.y >= TopTransform)
            //                NumbersList[i].localPosition = new Vector3(0, DownTransform, 0);
            //        }

            //        for (int i = 0; i <= (int)char.GetNumericValue(After[j]); i++)
            //        {
            //            NumbersList[i].localPosition += (Vector3.up * Time.deltaTime * testSpeed);
            //            if (NumbersList[i].localPosition.y >= TopTransform)
            //                NumbersList[i].localPosition = new Vector3(0, DownTransform, 0);
            //        }
            //    }

            //    for (int i = 0; i <= (int)char.GetNumericValue(After[j]); i++)
            //    {
            //        if (i == (int)char.GetNumericValue(After[j]))
            //        {
            //            if (i == 0)
            //            {
            //                if (NumbersList[9].localPosition.y > 0)
            //                {
            //                    NumbersList[i].localPosition = new Vector3(0, NumbersList[9].localPosition.y - 150, 0);
            //                }
            //                else
            //                {
            //                    NumbersList[i].localPosition = new Vector3(0, NumbersList[9].localPosition.y + 1350, 0);
            //                }
            //            }
            //            else
            //            {
            //                if (NumbersList[i - 1].localPosition.y > 0)
            //                {
            //                    NumbersList[i].localPosition = new Vector3(0, NumbersList[i - 1].localPosition.y - 150, 0);
            //                }
            //                else
            //                {
            //                    NumbersList[i].localPosition = new Vector3(0, NumbersList[i - 1].localPosition.y + 1350, 0);
            //                }
            //            }
            //        }
            //        else
            //        {
            //            if (i == 0)
            //            {
            //                NumbersList[i].localPosition = new Vector3(0, NumbersList[9].localPosition.y - 150, 0);
            //            }
            //            else
            //            {
            //                NumbersList[i].localPosition = new Vector3(0, NumbersList[i - 1].localPosition.y - 150, 0);
            //            }
            //        }
            //    }
            //}
            //else
            //{
            //  if ((int)char.GetNumericValue(After[j]) == 0)
            //  {
            //      NumbersList[NumbersList.Count - 1].localPosition += (Vector3.up * Time.deltaTime * testSpeed);
            //  }
            //  else if (NumbersList[(int)char.GetNumericValue(After[j]) - 1].localPosition.y != DownTransform )
            //  {
            //      NumbersList[(int)char.GetNumericValue(After[j]) - 1].localPosition += (Vector3.up * Time.deltaTime * testSpeed);
            //  }

            //  if (NumbersList[(int)char.GetNumericValue(After[j])].localPosition.y < -59)
            //  {
            //        if ((int)char.GetNumericValue(After[j]) == 9)
            //        {
            //            NumbersList[(int)char.GetNumericValue(After[j])].localPosition += (Vector3.up * Time.deltaTime * testSpeed);
            //            NumbersList[0].localPosition += (Vector3.up * Time.deltaTime * testSpeed);
            //        }
            //        else
            //        {
            //            NumbersList[(int)char.GetNumericValue(After[j])].localPosition += (Vector3.up * Time.deltaTime * testSpeed);
            //            NumbersList[(int)char.GetNumericValue(After[j]) + 1].localPosition += (Vector3.up * Time.deltaTime * testSpeed);
            //        }                   
            //  }
            //  else
            //  {
            //      NumbersList[(int)char.GetNumericValue(After[j])].localPosition = new Vector3(0, -59, 0);
            //  }
            //}
            #endregion test 1

            #region test 2

            if (After[j] != Before[j])
            {
                for(int i = 0;i< NumbersList.Count;i++)
                {
                   //if(j == 5)
                   // {
                   //     Debug.Log(testSpeed + " A " + j);
                   // }

                    NumbersList[i].localPosition += (Vector3.up * Time.fixedDeltaTime * testSpeed);
                    if (NumbersList[i].localPosition.y >= TopTransform)
                        NumbersList[i].localPosition = new Vector3(0, DownTransform, 0);

                    if (i == (int)char.GetNumericValue(After[j]))
                    {
                        if (NumbersList[i].localPosition.y < 0)
                        {
                            if (i != 9)
                            {
                                for (int k = (int)char.GetNumericValue(After[j]) + 1; k < 10; k++)
                                {
                                    NumbersList[k].localPosition += (Vector3.up * Time.fixedDeltaTime * testSpeed);
                                    if (NumbersList[k].localPosition.y >= TopTransform)
                                        NumbersList[k].localPosition = new Vector3(0, DownTransform, 0);
                                }
                            }
                            //Debug.Log(i);
                            //NumbersList[i].localPosition = new Vector3(0, -59, 0);
                            //if (i == 0)
                            //{
                            //    NumbersList[i + 1].localPosition = new Vector3(0, -59 - 150, 0);
                            //    NumbersList[9].localPosition = new Vector3(0, -59 + 150, 0);
                            //}
                            //else if (i == 9)
                            //{
                            //    NumbersList[0].localPosition = new Vector3(0, -59 - 150, 0);
                            //    NumbersList[i - 1].localPosition = new Vector3(0, -59 + 150, 0);
                            //}
                            //else
                            //{
                            //    NumbersList[i + 1].localPosition = new Vector3(0, -59 - 150, 0);
                            //    NumbersList[i - 1].localPosition = new Vector3(0, -59 + 150, 0);
                            //}

                            break;
                        }
                    }
                }

                for (int i = 0; i < 9; i++)
                {
                    int k = (int)(NumbersList[i].localPosition.y - NumbersList[i + 1].localPosition.y);
                    //Debug.Log(k + " " + i +"A "+j);
                    if(k<0)
                    {
                        //Debug.LogError(k+" "+" PA "+j);
                        NumbersList[i + 1].localPosition = new Vector3(0, NumbersList[i].localPosition.y + 1350);
                    }
                    else if (k!= 150)
                    {
                        NumbersList[i + 1].localPosition = new Vector3(0, NumbersList[i].localPosition.y - 150);
                    }
                }
            }
            else
            {
                if (NumbersList[(int)char.GetNumericValue(After[j])].localPosition.y < 0)
                {
                    for (int i = 0; i < NumbersList.Count; i++)
                    {
                        NumbersList[i].localPosition += (Vector3.up * Time.fixedDeltaTime * testSpeed);
                        if (NumbersList[i].localPosition.y >= TopTransform)
                            NumbersList[i].localPosition = new Vector3(0, DownTransform, 0);
                    }

                    for (int i = 0; i < 9; i++)
                    {
                        int k = (int)(NumbersList[i].localPosition.y - NumbersList[i + 1].localPosition.y);
                        //Debug.Log(k + " " + i +"A "+j);
                        if (k < 0)
                        {
                            //Debug.LogError(k+" "+" PA "+j);
                            if (k > -1350)
                                NumbersList[i + 1].localPosition = new Vector3(0, NumbersList[i].localPosition.y - 1350);
                            else
                                NumbersList[i + 1].localPosition = new Vector3(0, NumbersList[i].localPosition.y + 1350);
                        }
                        else if (k != 150)
                        {
                            NumbersList[i + 1].localPosition = new Vector3(0, NumbersList[i].localPosition.y - 150);
                        }
                    }
                }
                else
                {
                    NumbersList[(int)char.GetNumericValue(After[j])].localPosition = new Vector3(0, 0, 0);
                    if ((int)char.GetNumericValue(After[j]) == 0)
                    {
                        NumbersList[(int)char.GetNumericValue(After[j]) + 1].localPosition = new Vector3(0, -150, 0);
                        NumbersList[9].localPosition = new Vector3(0, +150, 0);
                    }
                    else if ((int)char.GetNumericValue(After[j]) == 9)
                    {
                        NumbersList[0].localPosition = new Vector3(0, -150, 0);
                        NumbersList[(int)char.GetNumericValue(After[j]) - 1].localPosition = new Vector3(0, -1350, 0);
                    }
                    else
                    {
                        NumbersList[(int)char.GetNumericValue(After[j]) + 1].localPosition = new Vector3(0, -150, 0);
                        NumbersList[(int)char.GetNumericValue(After[j]) - 1].localPosition = new Vector3(0, -1350, 0);
                    }
                }
            }

            #endregion test 2

            #region old code
            //for (int i = 0; i < 10; i++)
            //{
            //    if (i == 9)
            //    {
            //        Debug.Log(After[j]);
            //        if ((int)char.GetNumericValue(After[j]) == 9)
            //        {
            //            NumbersList[0].localPosition = new Vector3(0, DownTransform, 0);
            //        }
            //        else
            //        {
            //            int k = (int)(NumbersList[i].localPosition.y - NumbersList[0].localPosition.y);
            //            if (k != 150)
            //            {
            //                NumbersList[0].localPosition = new Vector3(0, NumbersList[i].localPosition.y - 150, 0);
            //            }
            //        }
            //    }
            //    else
            //    {
            //        int k = (int)(NumbersList[i].localPosition.y - NumbersList[i + 1].localPosition.y);
            //        if (k != 150)
            //        {
            //            NumbersList[i + 1].localPosition = new Vector3(0, NumbersList[i].localPosition.y - 150, 0);
            //        }
            //    }
            //}

            //for(int i = 0; i<10; i++)
            //{
            //    if (i == (int)char.GetNumericValue(After[j]))
            //    {
            //        if (i == 0)
            //        {
            //            if (NumbersList[9].localPosition.y > 0)
            //            {
            //                NumbersList[i].localPosition = new Vector3(0, NumbersList[9].localPosition.y - 150, 0);
            //            }
            //            else
            //            {
            //                NumbersList[i].localPosition = new Vector3(0, NumbersList[9].localPosition.y + 1350, 0);
            //            }
            //        }
            //        else
            //        {
            //            if (NumbersList[i - 1].localPosition.y > 0)
            //            {
            //                NumbersList[i].localPosition = new Vector3(0, NumbersList[i - 1].localPosition.y - 150, 0);
            //            }
            //            else
            //            {
            //                NumbersList[i].localPosition = new Vector3(0, NumbersList[i - 1].localPosition.y + 1350, 0);
            //            }
            //        }
            //    }
            //    else
            //    {
            //       if(i == 0)
            //       {
            //            NumbersList[i].localPosition = new Vector3(0, NumbersList[9].localPosition.y - 150, 0);
            //       }
            //       else
            //       {
            //            NumbersList[i].localPosition = new Vector3(0, NumbersList[i - 1].localPosition.y - 150, 0);
            //       }
            //    }
            //}
            #endregion old code
        }
        beforenum = afternum;
        speed = originSpeed;

    }

    public void ResetWin()
    {
        beforenum = 0.00;
        foreach (Transform child in NumbersList) ChangeImageAlpha(child, 0);
        if (NumbersList.Count > 1)
        {
            for (int i = 0; i < NumbersList.Count; i++)
            {
                NumbersList[i].localPosition = new Vector3(0, i*-150f ,0);
            }
        }
    }

    //測試停止的工具
    public int stopNumber;
    public bool isTestStop;
    public void TestStop()
    {
        if (NumbersList[stopNumber].position.y >= 0)
        {
            NumbersList[stopNumber].position = Vector3.zero;
            isReel = false;
        }
    }
}
