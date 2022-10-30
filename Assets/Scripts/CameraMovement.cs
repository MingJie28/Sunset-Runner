using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public float timeOffset;
    public Vector2 posOffset;
    public float bottomLimit;
    public Camera camera;
    public static bool Shake = false;
    private float size = 5.0f;


    void Update()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = player.transform.position;

        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        if (Shake)
        {
            ScreenShake(endPos);
            Invoke("stopShake", 0.4f);
        }
        else
        {
            transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);
        }

        transform.position = new Vector3
            (
                transform.position.x,
                Mathf.Clamp(transform.position.y, bottomLimit, 100),
                transform.position.z
            );

        if (Player.health == 1)
        {
            InvokeRepeating("reduceScreen", 0.0f, 5.0f);
        }
        else if (Player.health == 2)
        {
            InvokeRepeating("increaseScreen", 0.0f, 5.0f);
        }
    }

    private void OnDrawGizmos()
    {
        //draw red lines
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(-50, bottomLimit), new Vector2(300, bottomLimit));
    }

    private void reduceScreen()
    {
        if (size <= 4.0f)
        {
            CancelInvoke();
        }
        else
        {
            camera.orthographicSize = size;
            size -= 0.005f;
        }
    }

    private void increaseScreen()
    {
        if (size >= 5.0f)
        {
            CancelInvoke();
        }
        else
        {
            camera.orthographicSize = size;
            size += 0.005f;
        }
    }

    private void ScreenShake(Vector3 endPos)
    {
        float elapsed = 0f;

        while (elapsed < 10.0f)
        {
            float x = Random.Range(-1f, 1f)*0.1f;
            float y = Random.Range(-1f, 1f)*0.1f;
            transform.position = new Vector3(player.transform.position.x + x + posOffset.x, player.transform.position.y + y, -10f);
            elapsed += Time.deltaTime*5;
        }
    }

    private void stopShake()
    {
        Shake = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.health = 0;
        }
    }
}