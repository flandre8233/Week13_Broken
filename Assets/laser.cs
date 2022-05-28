using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField] LayerMask LayerMask;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(0, transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, 5000, LayerMask);
        if (hit)
        {
            Collider2D collider = hit.collider;
            if (collider)
            {
                lr.SetPosition(1, hit.point);
                if (collider.CompareTag("Player"))
                {
                    OnHitPlayer(collider.GetComponent<PlayerCollision>());
                }
                if (collider.CompareTag("Spire"))
                {
                    OnHitSpire(collider.GetComponent<SpireCollidison>());
                }
            }
        }
        else lr.SetPosition(1, transform.forward * 5000);
    }
    void OnHitPlayer(PlayerCollision collision)
    {
        collision.Close();
    }

    void OnHitSpire(SpireCollidison collision)
    {
        collision.OnHit();
    }
}
