using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToRed : MonoBehaviour
{
    Boss parent;
    float FinishTime = 3f;
    float CurTime;

    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponent<Boss>();
        Destroy(this, FinishTime);
    }

    // Update is called once per frame
    void Update()
    {
        CurTime += Time.deltaTime;
        parent.ViewRenderer.material.color = Color.Lerp(Color.white, Color.red, CurTime / FinishTime);
    }


}
