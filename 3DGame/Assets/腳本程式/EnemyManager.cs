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
        print("怪物2號的防禦力:" + enemy2.defend); //取得屬性 (不能用 "enemy1.defend = 999;" 因為defend為唯獨屬性)

        enemy2.lv = 99;
        print("怪物2號的MP:" + enemy2.mp);

        enemy2.damage = 500;

    }
}
