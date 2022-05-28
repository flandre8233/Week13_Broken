using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSphereControll : MonoBehaviour
{
    [SerializeField] Shake SphereShake;
    [SerializeField] Boss parent;
    [SerializeField] MeshRenderer ViewRenderer;
    [SerializeField] Color OrlColor;
    // Start is called before the first frame update
    void Start()
    {
        OrlColor = ViewRenderer.material.color;
    }

    public void SetHitable(bool canbehit)
    {
        if (canbehit)
        {
            tag = "BossControll";
            ToNormalColor();
        }
        else
        {
            tag = "BossBody";
            ToRedColor();
        }
    }

    public void BeHit()
    {
        ResourcesSpawner.Spawn("Hit", 5f);
        parent.OnBeHit();
        SetHitable(false);
        SphereShake.StartShake(0.3f, 0.5f);
    }

    void ToNormalColor()
    {
        ViewRenderer.material.color = OrlColor;
    }

    void ToRedColor()
    {
        ViewRenderer.material.color = Color.red;
    }
}
