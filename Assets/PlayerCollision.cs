using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Player player;

    public void Close()
    {
        player.Close();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("KZ"))
        {
            player.PlayerDeadByFall();
        }
        if (other.CompareTag("EZ"))
        {
            player.PlayerDeadByExp();
        }
        if (other.CompareTag("BossBullet"))
        {
            player.PlayerDeadByExp();
        }
    }
}
