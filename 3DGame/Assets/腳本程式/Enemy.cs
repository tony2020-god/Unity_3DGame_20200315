using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// 這是怪物的血量
    /// </summary>
    [Header("血量")]
    public float HP = 50;

    //屬性(property)可以設定權限:唯獨、允許所有權限
    /// <summary>
    /// 攻擊力
    /// </summary>
    public int attack { get; set; } 
}
