using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject EZ;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
        Invoke("SetEZShow", 0.2f);
        Invoke("SetEZOff", 0.25f);
    }

    void SetEZShow()
    {
        CameraShake.Shake(0.15f, 0.3f);
        EZ.SetActive(true);
    }
    void SetEZOff()
    {
        EZ.SetActive(false);
    }

}
