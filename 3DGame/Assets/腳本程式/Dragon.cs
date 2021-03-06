﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Dragon : MonoBehaviour
{
    public static float hp = 100;
    public static float cd = 1.5f;

    [Header("移動速度"), Range(1, 1000)]
    public float speed = 300;

    [Header("虛擬搖桿")]
    public Joystick joy;
    //第一種寫法:需要欄位 public Transform tra;

    [Header("火球")]
    public GameObject FireBall;

    [Header("延遲生成火球時間")]
    public float delayFire = 0.5f;

    [Header("火球移動速度"), Range(1, 5000)]
    public float speedFireBall = 800;

    [Header("攻擊力"), Range(1, 5000)]
    public float attack = 35;

   
    

    [Header("血條")]
    public Image hpBar;

    private GameManager gm;
    /// <summary>
    /// 動畫控制器
    /// </summary>
    private Animator ani;

    /// <summary>
    /// 計時器
    /// </summary>
    private float timer;
    /// <summary>
    /// 移動
    /// </summary>
    public void Move()
    {
       print("移動中");
        float v = Input.GetAxis("Vertical"); //判斷WS上下，上為1、下為-1
        float h = Input.GetAxis("Horizontal"); //判斷AD左右 
        //第一種寫法 tra.Translate(0,0,speed)
        transform.Translate(speed * Time.deltaTime * h, 0, speed * Time.deltaTime * v); //第二種寫法:僅限於 Transform ，Tine.deltatime(讓所有裝置速度一樣)，v方向上還下

        float joyV = joy.Vertical;
        float joyH = joy.Horizontal;
        transform.Translate(speed * Time.deltaTime * joyH, 0, speed * Time.deltaTime * joyV);

        Vector3 pos = transform.position; //取得飛龍座標
        pos.x = Mathf.Clamp(pos.x, 30, 70); //數學.夾住(值,最小,最大)
        pos.z = Mathf.Clamp(pos.z, 20, 30);
        transform.position = pos; //飛龍座標 = 夾住座標
    }

    private void Attack()
    {
        timer += Time.deltaTime; //計時器 遞增

        if (timer >= cd)  //如果計時器 >= 冷卻時間
        {
            timer = 0;  //計時器歸零
            ani.SetTrigger("攻擊觸發"); //動畫控制器.設定觸發器("參數名稱")

            StartCoroutine(DelayFireBall()); //呼叫協程

        }
    }

    private IEnumerator DelayFireBall()
    {
        yield return new WaitForSeconds(delayFire); //延遲生成火球

        Vector3 posFire = transform.position; //火球座標 = 飛龍座標
        posFire.z += 5.2f; //微調z軸
        posFire.y += 2.2f;  //微調y軸


        GameObject temp = Instantiate(FireBall, posFire, Quaternion.identity); //生成(物件,座標,角度)，Quaternion.identity 角度類型-零角度

        temp.AddComponent<Ball>();  //暫存火球.添加元件<球>
        temp.GetComponent<Ball>().damage = attack; //暫存火球.取得元件<球>().傷害值 = 攻擊力

        temp.GetComponent<Rigidbody>().AddForce(0, 0, speedFireBall);
        temp.GetComponent<Ball>().damage = attack;
        temp.GetComponent<Ball>().type = "玩家";
    }

    private void EatPropCd() //吃掉加速藥水效果
    {
        hp -= 0.5f;
        hp = Mathf.Clamp(cd, 0.6f, 100);
    }
    private void EatPropHP() //吃掉補血藥水效果
    {
        StartCoroutine(HpBarEffect());
    }

    private IEnumerator HpBarEffect()
    {
        float hpAdd = hp + 20;

        while (hp < hpAdd)
        {
            hp++;
            hp = Mathf.Clamp(hp, 0, 100);
            hpBar.fillAmount = hp / 100;
            yield return null;
        }

    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收收到的傷害值</param>
    public void Damage(float damage)
    {
        if (gm.passLv) return;
        hp -= damage;
        hpBar.fillAmount = hp / 100;
        if (hp <= 0) Dead();
    }
    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        ani.SetBool("死亡開關", true);
        gm.Lose();
    }
    private void Start()
    {
        ani = GetComponent<Animator>(); //取得元件<泛型>()
        hpBar.fillAmount = hp / 100; //每關血量更新
        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (ani.GetBool("死亡開關")) return;
        Move();
        Attack();
    }

    private void OnTriggerEnter(Collider other) //物件撞到藥水
    {
        if (other.tag == "加速藥水")
        {
            EatPropCd();
            Destroy(other.gameObject);
        }
        if (other.tag == "回血藥水")
        {
            EatPropHP();
            Destroy(other.gameObject);
        }
    }
}
