using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamCombo : Combo
{
    protected override void Start()
    {
        base.Start();
        if (Parent.IsInRage())
        {
            Invoke("SpawnCrosshairLockOn", 1f);
            Invoke("SpawnCrosshairLockOn", 2.5f);
            Invoke("SpawnCrosshairLockOn", 4f);

            Invoke("DoShake", 5f);
            Invoke("DoRotate", 5f);

            Invoke("DoBeam", 9f);

            Invoke("Reset", 25f);
        }
        else
        {
            Invoke("SpawnCrosshairLockOn", .5f);
            Invoke("SpawnCrosshairLockOn", 1f);
            Invoke("SpawnCrosshairLockOn", 1.5f);
            Invoke("SpawnCrosshairLockOn", 2f);
            Invoke("SpawnCrosshairLockOn", 2.5f);
            Invoke("SpawnCrosshairLockOn", 3f);
            Invoke("Reset", 4f);
        }
    }
    public override void OnBeHit()
    {
        CancelInvoke();
        Invoke("DoRotateNomral", 0);
        Invoke("Reset", 1);
        Parent.BeamPart.SetActive(false);
    }
    void SpawnCrosshairLockOn()
    {
        Parent.shake.StartShake(0.15f, 0.2f);
        ResourcesSpawner.Spawn(Parent.IsInRage() ? "Crosshair" : "Small-Crosshair", transform.position);
    }

    void DoShake()
    {
        Parent.shake.StartShake(4f, 0.15f);
    }

    void DoRotate()
    {
        BossRotate Rotate = gameObject.AddComponent<BossRotate>();
        Rotate.WantedAngles = 285;
        Rotate.FinishSec = 4f;
    }
    void DoBeam()
    {
        Parent.BeamPart.SetActive(true);
    }
}
