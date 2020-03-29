using UnityEngine; //引用Unity Engine API(窗口:開發人員用的倉庫)

public class LearnCSharp : MonoBehaviour //class(類別) LearnCSharp(腳本名稱)
{
    //開始事件:播放遊戲時執行一次
    private void Start()
    {
        print("嗨");
    }
    //更新事件:每秒約執行60次
    private void Update()
    {
        print("哈哈哈");
    }
}
