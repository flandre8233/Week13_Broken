using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageCombo : MonoBehaviour
{
    public Boss Parent;
    LockAtPlayer LockAtPlayer;
    void Start()
    {
        Parent = GetComponent<Boss>();
        ResourcesSpawner.Spawn("ofuscapreto", 5f);
        Invoke("DoShake", 0f);
        Invoke("TurnToRed", 0f);

        Invoke("Reset", 5f);
    }

    void DoShake()
    {
        Parent.shake.StartShake(3f, 0.25f);
    }
    void TurnToRed()
    {
        gameObject.AddComponent<TurnToRed>();
    }

    void Reset()
    {
        Destroy(this);
        Parent.ResetToNormal();
    }

}
