using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpireCollidison : MonoBehaviour
{
    [SerializeField]
    Spire Parent;

    private void Start()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        Invoke("StartListen" , 1);
    }

    void StartListen()
    {
        GetComponent<CircleCollider2D>().enabled = true;
    }

    public void OnHit()
    {
        Parent.Close();
    }
}
