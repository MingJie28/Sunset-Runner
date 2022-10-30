using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    public CanvasGroup DamageScreen;
    private int hit = 0;
    public AudioSource HurtSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HurtSound.Play();
            Player.health -= 1;
            hit++;
            CameraMovement.Shake = true;
            DamageScreen.alpha = 1.0f;
            InvokeRepeating("FadeBlood", 0.0f, 0.5f);
        }
    }

    private void FadeBlood()
    {
        if (DamageScreen.alpha > 0)
        {
            DamageScreen.alpha -= 0.1f;
        }
        else
        {
            CancelInvoke();
        }
    }
}