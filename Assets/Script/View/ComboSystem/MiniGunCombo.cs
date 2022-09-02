using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGunCombo : Combo
{
    LockAtPlayer LockAtPlayer;
    protected override void Start()
    {
        base.Start();

        if (Parent.IsInRage())
        {
            Invoke("Left2Attack", .2f);
            Invoke("RightAttack", .7f);

            Invoke("Left2Attack", .8f);
            Invoke("Right2Attack", 1.1f);

            Invoke("Left2Attack", 1.3f);
            Invoke("Right2Attack", 1.7f);
        }

        Invoke("AddLookAtPlayer", 0f);

        Invoke("LeftAttack", .4f);
        Invoke("FrontAttack", .5f);
        Invoke("RightAttack", .6f);

        Invoke("LeftAttack", .9f);
        Invoke("FrontAttack", 1f);
        Invoke("RightAttack", 1.1f);

        Invoke("LeftAttack", 1.4f);
        Invoke("FrontAttack", 1.5f);
        Invoke("RightAttack", 1.6f);

        Invoke("ClearLookAtPlayer", 1.5f);
        Invoke("DoRotateNomral", 2.5f);

        Invoke("Reset", 3.5f);
    }

    public override void OnBeHit()
    {
        CancelInvoke();
        Invoke("DoRotateNomral", 0);
        Invoke("Reset", 1);
    }

    void FrontAttack()
    {
        DoNormalAttack(1, 0);
    }
    void LeftAttack()
    {
        DoNormalAttack(1, 6f);
    }
    void RightAttack()
    {
        DoNormalAttack(1, -6f);
    }

    void Left2Attack()
    {
        DoNormalAttack(1, 12f);

    }

    void Right2Attack()
    {
        DoNormalAttack(1, -12f);
    }

    public void DoNormalAttack(float Scale, float angle)
    {
        GameObject SpawnedBullet = ResourcesSpawner.Spawn("Bullet", transform.position);
        SpawnedBullet.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 180 + angle);
        SpawnedBullet.transform.localScale = new Vector3(Scale, 1, Scale);
    }


    void AddLookAtPlayer()
    {
        LockAtPlayer = gameObject.AddComponent<LockAtPlayer>();
    }

    void ClearLookAtPlayer()
    {
        Destroy(LockAtPlayer);
    }
}