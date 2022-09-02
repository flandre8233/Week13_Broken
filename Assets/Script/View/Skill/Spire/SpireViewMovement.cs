using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpireViewMovement : MonoBehaviour
{
    [SerializeField] Transform FakeShadow;
    float CurTime = 0;
    // Update is called once per frame
    void Update()
    {
        CurTime += Time.deltaTime;
        transform.localPosition = Vector3.Lerp(new Vector3(0, 10, 0), new Vector3(), CurTime);
        FakeShadow.localScale = new Vector3(CurTime, CurTime, CurTime);
        if (CurTime >= 1)
        {
            Destroy(this);
        }
    }

}
