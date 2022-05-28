using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockOnPlayer : MonoBehaviour
{
    [SerializeField] Transform Target;

    void SetTarget()
    {
        Player player = GameModel.instance.GetPlayer();
        if (player)
        {
            Target = GameModel.instance.GetPlayer().transform;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (Target != null)
        {
            transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * 2);
        }
    }
}
