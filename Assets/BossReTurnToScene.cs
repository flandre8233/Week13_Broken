using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossReTurnToScene : MonoBehaviour
{
    Boss Parent;

    float FinishTime = 2f;
    float CurTime;

    Vector3 StartPoint;
    Vector3 EndPoint;


    // Start is called before the first frame update
    void Start()
    {
        Parent = GetComponent<Boss>();
        Parent.OnChangedPos();
        transform.eulerAngles = new Vector3(0, 0, Parent.IsUpper() ? 0 : 180);
        EndPoint = Screen.ToWorldPos(Parent.IsUpper() ? TopVP.Get() : BottomVP.Get());
        StartPoint = EndPoint + new Vector3(0, Parent.IsUpper() ? +3 : -3, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(StartPoint, EndPoint, CurTime / FinishTime);

        CurTime += Time.deltaTime;

        if (CurTime >= FinishTime)
        {
            transform.position = EndPoint;
            Close();
        }
    }
    void Close()
    {
        Parent.ResetToNormal();
        Destroy(this);
    }
}
