using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardCombo : Combo
{
    LockAtPlayer LockAtPlayer;
    BossMoveForward BossMoveForward;

    protected override void Start()
    {
        base.Start();
        if (Parent.IsInRage())
        {
            ResourcesSpawner.Spawn("ofuscapreto", 2f);
            Invoke("AddLookAtPlayer", 0);
            Invoke("DoShake", 0);
            Invoke("ClearLookAtPlayer", 2f);

            Invoke("DoMoveForward", 2.5f);
        }
        else
        {
            ResourcesSpawner.Spawn("ofuscapreto", 2.5f);
            Invoke("DoShake", 0);
            Invoke("DoMoveForward", 2.5f);
        }
        Destroy(this, 10f);
    }

    public override void OnBeHit()
    {
        print("OnBeHit");
        CancelInvoke();
        Parent.DoDown();
        Destroy(BossMoveForward);
        Destroy(this);
    }

    void DoShake()
    {
        Parent.shake.StartShake(2f, 0.3f);
    }

    void DoMoveForward()
    {
        BossMoveForward = gameObject.AddComponent<BossMoveForward>();
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
