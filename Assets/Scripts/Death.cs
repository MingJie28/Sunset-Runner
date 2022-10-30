using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.position = new Vector3(target.transform.position.x, target.transform.position.y, 2f);
        Invoke("destroy", 0.4f);
    }

    private void destroy()
    {
        Destroy(gameObject);
    }
}
