using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMoveForward : MonoBehaviour
{
    public Boss Parent;
    void Start()
    {
        Parent = GetComponent<Boss>();
        Parent.KZ.SetActive(true);
        InvokeRepeating("DoShotGunAttack", 0.5f, 0.5f);
        Invoke("Reset", 2);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.up * Time.deltaTime * (Parent.IsInRage() ? 12 : 8);
    }

    public void DoShotGunAttack()
    {
        float[] angless = { -90f, 90f, -45f, 45f, -135f, 135f };

        if (Parent.IsInRage())
        {
            angless = new float[] { -90f, 90f, -112.5f, 112.5f, -45f, 45f, -67.5f, 67.5f, -135f, 135f, -157.5f, 157.5f };
        }

        foreach (var item in angless)
        {
            DoNormalAttack(1, item);
        }
    }

    public void DoNormalAttack(float Scale, float angle)
    {
        GameObject SpawnedBullet = ResourcesSpawner.Spawn("Bullet", transform.position);
        SpawnedBullet.transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 180 + angle);
        SpawnedBullet.transform.localScale = new Vector3(Scale, 1, Scale);
    }

    void Reset()
    {
        Parent.KZ.SetActive(false);
        Destroy(this);
        gameObject.AddComponent<BossReTurnToScene>();
    }
}
