using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAtPlayer : MonoBehaviour
{
    void Update()
    {
        Player player = GameModel.instance.GetPlayer();
        if (player != null)
        {
            Vector2 lookDir = player.transform.position - transform.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            transform.eulerAngles = new Vector3(0, 0, angle + 180);
        }

    }
}
