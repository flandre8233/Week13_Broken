using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpireKillZone : MonoBehaviour
{
    [SerializeField] Transform KillZone;
    // Start is called before the first frame update
    void Start()
    {
        Close();
        Invoke("Show", 0.95f);
        Invoke("Close", 1.05f);
    }

    void Show()
    {
        KillZone.gameObject.SetActive(true);
    }
    void Close()
    {
        KillZone.gameObject.SetActive(false);
    }
}
