using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Explosion : MonoBehaviour
{
    public GameObject myPrefab;


    void OnTriggerEnter2D(Collider2D other)
    {      

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            Instantiate(myPrefab, new Vector3(15, -16, -1), Quaternion.identity);
            SceneManager.LoadScene("Loss");
        }
    }
}

