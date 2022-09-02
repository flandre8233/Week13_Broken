using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollider : MonoBehaviour
{
    [SerializeField] Bullet Parent;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BossBody"))
        {
            Destroy(Parent.gameObject);
            ResourcesSpawner.Spawn("impactblock", 5f);
        }
        if (other.CompareTag("BossControll"))
        {
            Destroy(Parent.gameObject);
            other.GetComponent<BossSphereControll>().BeHit();

        }
        if (other.CompareTag("BossBullet"))
        {
            ResourcesSpawner.Spawn("impactblock", 5f);
            Destroy(Parent.gameObject);
            if (other.GetComponent<BossBulletCollider>().Parent.transform.localScale.x <= 1)
            {
                Destroy(other.GetComponent<BossBulletCollider>().Parent.gameObject);
            }
        }
    }
}
