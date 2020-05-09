using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [Header("生成資料")]
    public SpawnData data;
    private GameManager gm;
    public bool pass;
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        StartCoroutine(StartSpawn());
    }
    private IEnumerator StartSpawn()
    {
        for (int i = 0; i < data.spawn.Length; i++)
        {
            yield return new WaitForSeconds(data.spawn[i].time);
            for (int j = 0; j < data.spawn[i].monsters.Length; j++)
            {
                Vector3 pos = new Vector3(data.spawn[i].monsters[j].x, 20, 50); //座標
                Quaternion qua = Quaternion.Euler(0, 180, 0); //角度
                Instantiate(data.spawn[i].monsters[j].monster, pos, qua); //生成

            }
        }
        yield return new WaitForSeconds(2);
        gm.Win();
    }
}
