using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spire : MonoBehaviour
{
    [SerializeField] Shake shake;
    bool OnDead = false;
    public void Close()
    {
        if (OnDead)
        {
            return;
        }

        OnDead = true;
        shake.StartShake(1, 0.15f);
        Invoke("DelayDead", 1f);
    }

    void DelayDead()
    {
        SpawnExp();
        SpawnCrack();
        Destroy(gameObject);
    }

    public void SpawnExp()
    {
        ResourcesSpawner.Spawn("Explosion", transform.position);
    }

    public void SpawnCrack()
    {
        ResourcesSpawner.Spawn("Crack", transform.position);
    }
}
