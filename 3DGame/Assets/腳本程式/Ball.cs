using UnityEngine;

public class Ball : MonoBehaviour
{
    public float damage;
    /// <summary>
    /// 玩家:可以打到怪物
    /// 怪物:可以打到玩家
    /// </summary>
    public string type;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag=="怪物" && type =="玩家")//碰到怪物物件
        {
            other.GetComponent<Monster>().Damage(damage);//將傷害值傳給怪物
        }
        if (other.name == "飛龍" && type == "怪物")//碰到怪物物件玩家
        {
            other.GetComponent<Dragon>().Damage(damage);//將傷害值傳給玩家

        }
    }
}
