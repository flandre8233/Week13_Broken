using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
[SerializeField] float Speed;
    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * Time.deltaTime * Speed;
    }
}
