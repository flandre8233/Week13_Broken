using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKeepRotate : MonoBehaviour
{
    float Speed = 720;
    private void Start()
    {
        ResourcesSpawner.Spawn("CarCrash", 5f);
    }
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * Speed));
        Speed = Mathf.Lerp(Speed, 0, Time.deltaTime * 0.5f);
    }
}
