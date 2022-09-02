using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combo : MonoBehaviour
{
    public Boss Parent;
    protected virtual void Start()
    {
        Parent = GetComponent<Boss>();
    }

    public abstract void OnBeHit();

    protected virtual void Reset()
    {
        Destroy(this);
        Parent.ResetToNormal();
    }

    protected virtual void DoRotateNomral()
    {
        BossRotate Rotate = gameObject.AddComponent<BossRotate>();
        Rotate.WantedAngles = 0;
        Rotate.FinishSec = 1f;
    }
}
