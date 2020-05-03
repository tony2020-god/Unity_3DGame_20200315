using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("怪物資料")]
    public MonsterData data;
    [Header("回血藥水")]
    public GameObject propHP;
    [Header("加速藥水")]
    public GameObject propCd;
    [Header("發射雷射球")]
    public GameObject bullet;

    private Animator ani;
    private float hp;
    private float timer;
    private void Start()
    {
        hp = data.hp;
        ani = GetComponent<Animator>();
    }
    public void Update()
    {
        Attack();
    }
    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage"></param>
    public void Damage(float damage)
    {
        hp -= damage;
        if (hp <= 0) dead();
    }
    /// <summary>
    /// 死亡
    /// </summary>
    private void dead()
    {
        ani.SetBool("死亡開關", true);
        DropProp();
    }

    /// <summary>
    /// 掉落道具
    /// </summary>
    private void DropProp()
    {
        float rHP = Random.Range(0f, 1f); //回血藥水掉落機率30% (0.3),Random.Range(0,1)
        if (rHP <= data.propHP) Instantiate(propHP, transform.position, Quaternion.identity); //if (隨機 <= 0.3) 掉落回血藥水
        float rCd = Random.Range(0f, 1f); 
        if (rCd <= data.propCd) Instantiate(propCd, transform.position, Quaternion.identity); 
    }
    private void Attack()
    {
        timer += Time.deltaTime;

        if (timer >= data.cd)
        {
            timer = 0;
            GameObject temp = Instantiate(bullet, transform.position + transform.forward, Quaternion.identity);
            temp.AddComponent<Move>().speed = data.bulletSpeed;
            temp.AddComponent<Ball>().damage = data.attack;
            temp.GetComponent<Ball>().type = "怪物";
        }
    }    
}
