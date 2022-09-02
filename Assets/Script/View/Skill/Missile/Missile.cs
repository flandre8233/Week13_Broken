using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public void Close()
    {
        Invoke("SpawnExp" , 0.5f);
        Destroy(gameObject,1);
    }

    public void SpawnExp()
    {
        ResourcesSpawner.Spawn("Explosion", transform.position);
    }
}
