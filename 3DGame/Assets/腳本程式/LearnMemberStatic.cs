using UnityEngine;

public class LearnMemberStatic : MonoBehaviour
{
    //定義屬性(類別 名稱 = 值;)
    float a = 0.5f; //浮點數
    int b = 7; //整數
    bool c = true; //布林值
    bool d = false;
    string e = "我是字串"; //字串

    //修飾詞(類別 名稱 = 值;)
    public int score = 10; //公開public : 允許所有文件存取，顯示在屬性面板
    private int speed = 99; //私人private : 僅限此類別存取，隱藏在屬性面板

    public Camera cam; //定義一個類行為 Camera 的物件，名稱為 cam
    private void Start()
    {
        
        print(Random.value); //使用靜態屬性(類別.靜態屬性)

        Time.timeScale = 1; //取得get(類別.靜態屬性)、設定set(類別.靜態屬性 = 值) ※Read Only 為不能設定的屬性

        //使用靜態方法
        print(Random.Range(0.1f,99.9f)); //第一個多載
        print(Random.Range(100, 500)); //第二個多載


        //Mathf = Mathfunction 數學用法
        print(Mathf.PI);//使用靜態成員取得數學PI 
        print(Mathf.Abs(-999));//使用靜態成員取得數學絕對值 

        print("攝影機數量" + Camera.allCamerasCount); //靜態(類別.成員)
        print(cam.depth); //非靜態(物件.成員)

    }
    
}
