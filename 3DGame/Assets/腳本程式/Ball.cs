using UnityEngine;

public class Ball : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag=="怪物")//碰到怪物物件
        {
            other.GetComponent<Monster>().Damage(damage);//將傷害值傳給怪物
        }
    }
}
