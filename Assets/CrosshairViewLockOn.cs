using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairViewLockOn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 wantedPos = Random.insideUnitCircle.normalized * 1.3f;
        wantedPos = new Vector2(Mathf.Abs(wantedPos.x),Mathf.Abs(wantedPos.y));
        wantedPos = Camera.main.ViewportToWorldPoint(wantedPos);
        transform.localPosition = new Vector3(wantedPos.x, wantedPos.y, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(), Time.deltaTime );
    }
}
