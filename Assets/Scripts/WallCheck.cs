using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    [SerializeField] private Transform posWallCheck;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] private float wallRadius;
    private bool isWall = false;


    // Update is called once per frame
    private void Update()
    {
        isWall = wallCheck();

        if (isWall)
        {
            Player.health -= 2;
        }
    }

    private bool wallCheck()
    {
        return Physics2D.OverlapCircle(posWallCheck.position, wallRadius, GroundLayer);
    }
}
