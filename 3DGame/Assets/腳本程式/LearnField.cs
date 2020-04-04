using UnityEngine;

public class LearnField : MonoBehaviour
{
    //定義欄位field
    //存放遊戲資料
    //修飾詞 類型 名稱(指定值);
    //不指定:數值型為0, 布林值為false,  字串為""
    public int speed = 10;
    public float jump = 50.5f;
    public string prop = "小刀";
    public bool complete = true;

    [Header("武器"), Tooltip("這是角色的主要武器。")] //Header標題, Tooltip提示
    public string weapon = "BB槍";
    [Header("分數"), Range(0, 100)] //Range範圍:int、float
    public int score = 60;

    private void Start()
    {
        
    }
}
