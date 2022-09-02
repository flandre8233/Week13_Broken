using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCrosshair : MonoBehaviour
{
    LockOnPlayer LockOnPlayer;
    // Start is called before the first frame update
    void Start()
    {
        LockOnPlayer = gameObject.AddComponent<LockOnPlayer>();
        Invoke("CloseLockOn", 3);
        Invoke("Fire", 5);
    }


    void CloseLockOn()
    {
        Destroy(LockOnPlayer);
    }

    void Fire()
    {
        Close();
        SpawnMissile();
    }
    void Close()
    {
        Destroy(gameObject, 1);
    }

    void SpawnMissile()
    {
        ResourcesSpawner.Spawn("Missile", transform.position);
    }
}
