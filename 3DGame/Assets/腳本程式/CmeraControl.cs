using UnityEngine;

public class CmeraControl : MonoBehaviour
{
    public Transform dragon;

    [Header("追蹤速度"), Range(0, 100)]
    public float speed;

    /// <summary>
    /// 追蹤飛龍
    /// </summary>
    private void Track()
    {
        Vector3 draPos = dragon.position; //飛龍座標
        draPos.y = 50;
        draPos.z -= 5;
        transform.position = Vector3.Lerp(transform.position, draPos, 0.3f * Time.deltaTime * speed ); //攝影機座標


    }   
     
    private void LateUpdate()
    {
        Track();
    }
}
