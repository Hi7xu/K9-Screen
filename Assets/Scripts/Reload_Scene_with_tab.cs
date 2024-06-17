using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class Reload_Scene_with_tab : MonoBehaviour
{
    // Start is called before the first frame update
    private bool button_status;
    public GameObject button;
    void Start()
    {
        button.SetActive(false);
        button_status = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Tab) && button_status == false)
        {

            button_status = true;
            button.SetActive(true);
            HideAfterDelay(5f);
        }

        else if (Input.GetKeyUp(KeyCode.Tab) && button_status == true)
        {
            button_status = false;
            button.SetActive(false);
        }
    }


    IEnumerator HideAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        button.SetActive(false);
    }

    public void GameReset()
    {

            Application.Quit();

            // 獲取遊戲的進程
            var process = Process.GetCurrentProcess();

            // 重新啟動遊戲
            Process.Start(process.ProcessName);
        
    }
}
