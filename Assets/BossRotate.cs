using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotate : MonoBehaviour
{
    float StartAngles;
    public float WantedAngles;
    public float FinishSec;
    float CurTime;

    private void Start()
    {
        WantedAngles += GetComponent<Boss>().IsUpper() ? 0 : 180;
        StartAngles = transform.localEulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        CurTime += Time.deltaTime;
        Quaternion WantedRotation = Quaternion.Euler(0, 0, WantedAngles);
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, StartAngles), WantedRotation, CurTime / FinishSec);
        if (CurTime >= FinishSec)
        {
            transform.rotation = WantedRotation;
            Destroy(this);
        }
    }
}
