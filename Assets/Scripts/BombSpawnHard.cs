using UnityEngine;
public class BombSpawnHard : MonoBehaviour
{
    public GameObject myPrefab;
    public float Timer = 0;

    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            Instantiate(myPrefab, new Vector3(-6, 9, -1), Quaternion.identity);
            Timer = 10f;
        }
    }
}