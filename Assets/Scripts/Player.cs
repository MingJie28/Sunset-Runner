using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static int health = 2;
    public GameObject Death;
    public GameObject GameOverText;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GameOverText.SetActive(true);
            Death.SetActive(true);
            gameObject.SetActive(false);
        }else if (health == 1)
        {
            Invoke("gainHp", 5.0f);
        }
        Debug.Log(health);
    }

    private void gainHp()
    {
        health++;
        CancelInvoke();
    }

}
