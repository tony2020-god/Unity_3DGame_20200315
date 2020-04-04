using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemy1, enemy2;

    private void Start()
    {
        print(enemy1.HP); //取得欄位
        enemy2.HP = 200; //設定欄位

        enemy1.attack = 999; //設定屬性
        print("怪物1號的攻擊力:" + enemy1.attack); //取得屬性
    }
}
