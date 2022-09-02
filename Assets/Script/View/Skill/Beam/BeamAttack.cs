using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamAttack : MonoBehaviour
{
    private void OnEnable() {
        Invoke("StartRotate", 2.5f);
    }

    void StartRotate()
    {
        gameObject.AddComponent<BeamRotate>();
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
