using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealthbar : MonoBehaviour
{
    public Healthbar bar;
    [SerializeField] Boss boss;

    float WantedRate = 1;
    float CurrentViewRate = 0;

    public void EnableBar(bool enable)
    {
        bar.gameObject.SetActive(enable);
        UpdateBar();
        CurrentViewRate = WantedRate;
    }

    public void UpdateBar()
    {
        WantedRate = boss.GetHPRate();
    }

    private void Update()
    {
        CurrentViewRate = Mathf.Lerp(CurrentViewRate, WantedRate, Time.deltaTime * 3);
        bar.SetHealth(CurrentViewRate * 100);
    }
}
