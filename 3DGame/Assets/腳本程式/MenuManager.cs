
using UnityEngine;
using UnityEngine.UI;//引用介面API
using UnityEngine.SceneManagement;//引用場景管理API
using System.Collections;//引用系統集合、管理API(協同程式:非同步處理)


public class MenuManager : MonoBehaviour
{
    [Header("載入畫面")]
    /// <summary>
    /// 載入畫面
    /// </summary>
    public GameObject PanelLoading;

    [Header("載入畫面文字")]
    /// <summary>
    /// 載入畫面文字
    /// </summary>
    public Text textLoading;

    [Header("載入畫面吧條")]
    /// <summary>
    /// 載入畫面吧條
    /// </summary>
    public Image imgLoading;

    /// <summary>
    /// 開始載入背景場景
    /// </summary>
    public void StartLoading()
    {
        print("開始載入.... ");

        PanelLoading.SetActive(true);      //顯示載入畫面
        
        

        

        StartCoroutine(Loading());         //啟動協程
    }

    /// <summary>
    /// 協程方法:載入
    /// </summary>
    /// <returns></returns>
    private IEnumerator Loading() 
    {
        //SceneManager.LoadScene("關卡一");  //載入場景
        AsyncOperation ao = SceneManager.LoadSceneAsync("關卡一");

        ao.allowSceneActivation = false;     //關閉自動載入場景


        while (ao.progress < 1)        //迴圈 while(布林值) "當布林值為 true 時執行敘述"
        {
            print("關卡進度:" + ao.progress);                                      //progress關卡進度
            textLoading.text =(ao.progress /0.9f * 100).ToString("F2") + " %";     //更新載入文字
            imgLoading.fillAmount = ao.progress / 0.9f;                            //更新載入吧條
            yield return null;                                                     //等待
            if(ao.progress == 0.9f)    //判斷式 if(布林值) "當布林值為true時執行一次"  
            {
                ao.allowSceneActivation = true;    //允許自動載入場景
            }
        }
    }
}
