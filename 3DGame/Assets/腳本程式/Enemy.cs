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

    //public int defend { get; } //怪物的防禦力"唯獨"
    public float defend
    {
        get {
            return 77.5f;
        }
    }
    public int lv = 5;
    public int mp  //不能使用 public int mp = lv*8;
    {
        get
        {
            return lv*8;
        }   
    }

    private float _damage ;
    public float damage
    {
        set
        {
            _damage = Mathf.Clamp(value - defend, 1, 99999);//傷害直範圍1~99999
        }
        get
        {
            return _damage;
        }
    }
    
}
