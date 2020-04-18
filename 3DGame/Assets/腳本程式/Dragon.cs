
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [Header("移動速度"), Range(1, 1000)]
    public float speed = 300;

    [Header("虛擬搖桿")]
    public Joystick joy;
    //第一種寫法:需要欄位 public Transform tra;

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
        transform.position = pos; //飛龍座標 = 夾住座標
    }
    
    private void Update()
    {
        Move();
    }
}
