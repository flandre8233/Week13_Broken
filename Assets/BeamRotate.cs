using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamRotate : MonoBehaviour
{
    [SerializeField] Transform TargetTrans;
    float CurrentSpeed = 0;
    private void Start()
    {
        TargetTrans = GameModel.instance.GetBoss().transform;

        Invoke("Close", 12f);
    }

    public void Close()
    {
        Destroy(this);
        GetComponent<BeamAttack>().Close();
        DoRotate();
    }

    void DoRotate()
    {
        BossRotate Rotate = TargetTrans.gameObject.AddComponent<BossRotate>();
        Rotate.WantedAngles = 0;
        Rotate.FinishSec = 1f;
    }

    void Update()
    {
        TargetTrans.Rotate(0, 0, CurrentSpeed);
        CurrentSpeed += Time.deltaTime * 0.5f;
    }
}
