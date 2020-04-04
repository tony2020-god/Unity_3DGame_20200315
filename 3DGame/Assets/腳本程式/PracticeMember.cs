using UnityEngine;

public class PracticeMember : MonoBehaviour
{
    public SpriteRenderer logo;

    public Transform cam;
    private void Start()
    {
        Cursor.visible = false; //隱藏鼠標

        logo.flipX = true; //旋轉字體

        print(Mathf.Floor (1.23456f)); //去除小數點

        cam.Rotate(0, 90, 0); //相機轉90度
    }

}
