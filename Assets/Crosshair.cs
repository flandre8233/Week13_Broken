using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
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
        SpawnSpire();
    }
    void Close()
    {
        Destroy(gameObject, 1);
    }

    void SpawnSpire()
    {
        ResourcesSpawner.Spawn("Spire", transform.position);
    }
}
