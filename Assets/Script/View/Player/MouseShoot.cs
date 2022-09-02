using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseShoot : MonoBehaviour
{
    [SerializeField] GameObject CDReadyView;
    [SerializeField] float CD;
    [SerializeField] float CurrentCD;
    void Update()
    {
        if (CurrentCD <= 0)
        {

            if (!CDReadyView.activeSelf)
            {
                ResourcesSpawner.Spawn("1911" , 5f);
                CDReadyView.SetActive(true);
            }
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            }
        }
        CurrentCD -= Time.deltaTime;
    }

    void Fire()
    {
        CDReadyView.SetActive(false);
        CurrentCD = CD;
        ResourcesSpawner.Spawn("PlayerBullet", transform.position + (transform.up * 0.5f), transform.rotation);
    }

    float GetCDProgress()
    {
        return Mathf.Clamp(CurrentCD, 0, CD) / CD;
    }
}
