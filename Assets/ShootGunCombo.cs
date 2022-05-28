using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGunCombo : Combo
{
    GameObject Steamsteam;
    GameObject SteamSound;
    LockAtPlayer LockAtPlayer;
    protected override void Start()
    {
        base.Start();
        if (Parent.IsInRage())
        {
            Invoke("SpawnCrosshairLockOn", 5);
            Invoke("SpawnCrosshairLockOn", 6);

            Invoke("SpawnCrosshairLockOn", 10);
            Invoke("SpawnCrosshairLockOn", 11);
            Invoke("SpawnCrosshairLockOn", 12);

            Invoke("SpawnCrosshairLockOn", 15);
            Invoke("SpawnCrosshairLockOn", 16);
            Invoke("SpawnCrosshairLockOn", 17);
            Invoke("SpawnCrosshairLockOn", 18);
        }

        DoShotGunAttackRepeatly(0f);

        Invoke("AddLookAtPlayer", 3f);

        DoShotGunAttackRepeatly(3f);
        Invoke("Do2ScaleBullet", 5f);

        DoShotGunAttackRepeatly(7f);
        Invoke("Do3ScaleBullet", 9f);

        DoShotGunAttackRepeatly(11f);
        Invoke("Do5ScaleBullet", 13f);

        Invoke("ClearLookAtPlayer", 13f);

        Invoke("DoRotateBack", 14f);

        Invoke("DoRotateNomral", 17f);

        Invoke("Reset", 18f);
    }

    protected override void Reset()
    {
        base.Reset();
        if (Steamsteam)
        {
            Destroy(Steamsteam);
        }
        if (SteamSound)
        {
            Destroy(SteamSound);
        }
    }

    public override void OnBeHit()
    {
        CancelInvoke();
        Invoke("DoRotateNomral", 0);
        Invoke("Reset", 1);


    }

    void AddLookAtPlayer()
    {
        LockAtPlayer = gameObject.AddComponent<LockAtPlayer>();
    }

    void ClearLookAtPlayer()
    {
        Destroy(LockAtPlayer);
    }

    void DoShotGunAttackRepeatly(float StartTime)
    {
        Invoke("DoShotGunAttack", StartTime + .5f);
        Invoke("DoShotGunAttack", StartTime + 1f);
        Invoke("DoShotGunAttack", StartTime + 1.5f);
        Invoke("DoShotGunAttack", StartTime + 2f);
        Invoke("DoShotGunAttack", StartTime + 2.5f);
    }

    public void DoShotGunAttack()
    {
        float[] angless = { -22.5f, 22.5f, -45f, 45f };

        if (Parent.IsInRage())
        {
            angless = new float[] { -22.5f, 22.5f, -45f, 45f, -67.5f, 67.5f, -90f, 90f };
        }

        foreach (var item in angless)
        {
            DoNormalAttack(1, item);
        }
    }

    void Do2ScaleBullet()
    {
        Parent.shake.StartShake(0.15f, 0.15f);
        DoNormalAttack(2, 0);
    }
    void Do3ScaleBullet()
    {
        Parent.shake.StartShake(0.15f * 2, 0.15f * 2);
        DoNormalAttack(3, 0);

    }
    void Do4ScaleBullet()
    {
        Parent.shake.StartShake(0.15f * 3, 0.15f * 3);
        DoNormalAttack(4, 0);

    }
    void Do5ScaleBullet()
    {
        Parent.shake.StartShake(0.15f * 4, 0.15f * 4);
        DoNormalAttack(5, 0);
    }

    public void DoNormalAttack(float Scale, float angle)
    {
        GameObject SpawnedBullet = ResourcesSpawner.Spawn("Bullet", transform.position);
        SpawnedBullet.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 180 + angle);
        SpawnedBullet.transform.localScale = new Vector3(Scale, 1, Scale);
    }

    void SpawnCrosshairLockOn()
    {
        Parent.shake.StartShake(0.15f, 0.2f);
        ResourcesSpawner.Spawn("Small-Crosshair", transform.position);
    }

    void DoRotateBack()
    {
        Steamsteam = ResourcesSpawner.Spawn("SteamSteamSteam", transform.position, 20f);
        Steamsteam.transform.position = new Vector3(Steamsteam.transform.position.x, Steamsteam.transform.position.y, -5);
        SteamSound = ResourcesSpawner.Spawn("Steam", 20f);
        BossRotate Rotate = gameObject.AddComponent<BossRotate>();
        Rotate.WantedAngles = 180;
        Rotate.FinishSec = 1f;
    }

}
