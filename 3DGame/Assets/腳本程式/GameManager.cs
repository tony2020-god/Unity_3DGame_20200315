using UnityEngine;
using UnityEngine.SceneManagement;
 
public class GameManager : MonoBehaviour
{
    [Header("地板陣列")]
    public Transform[] terrains; //陣列:儲存多筆相同類型的資料
    [Header("地板移動速度"), Range(1f, 50f)]
    public float speedTerrain = 1.5f;
    public GameObject pass;
    public GameObject lose;

    public bool passLv;
    public void Lose() //失敗:飛龍血量小於0，遊戲顯示失敗畫面
    {
        lose.SetActive(true);
    }
    public void Win() //過關:怪物生成完成
    {
        passLv = true;
        pass.SetActive(true);
    }

    public void NextLv()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// 移動地板
    /// </summary>
    private void MoveTerrain() 
    {
        for (int i = 0; i < terrains.Length; i++)  //for迴圈:重複執行敘述
        {
            if (terrains[i].position.z <= -100)
            {
                terrains[i].position = new Vector3(0, 0, terrains[1-i].position.z + 100); //移到另一個地板的前方100的位置
            }

            terrains[i].Translate(0, 0, -speedTerrain * Time.deltaTime); //移動
        }
    }

    /// <summary>
    /// 固定禎數更新事件: 1秒50禎
    /// </summary>
    private void FixedUpdate()
    {
        MoveTerrain();
    }

}
