using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject BGM;
    [SerializeField] GameObject GameoverCanvas;
    [SerializeField] BossSphereControll SphereControll;
    [SerializeField] GameObject BossExp;
    [SerializeField] BossHealthbar ViewBar;
    [SerializeField] BossHealthbar UpperViewBar;
    Combo CurrentCombo;
    public int MaxHp;
    public int CurrentHp;
    public Shake shake;
    public GameObject BeamPart;

    public GameObject KZ;
    public MeshRenderer ViewRenderer;

    bool DoesRage = false;
    bool DoesRageBeam = false;

    int DoesMiniCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHp = MaxHp;
    }

    public bool IsUpper()
    {
        return transform.position.y >= 0;
    }



    public void OnBeHit()
    {
        CameraShake.Shake(0.15f, 0.15f);

        if (CurrentHp == MaxHp)
        {
            OnFirstHit();
        }

        if (CurrentCombo)
        {
            CurrentCombo.OnBeHit();
        }
        CurrentHp -= 1;
        if (CurrentHp <= 0)
        {
            OnDead();
        }
        ViewBar.UpdateBar();
        UpperViewBar.UpdateBar();


    }

    void OnDead()
    {
        BossExp.SetActive(true);
        BossExp.transform.parent = null;
        if (CurrentCombo)
        {
            Destroy(CurrentCombo);
        }
        Destroy(gameObject, 1.5f);
        Timer.SetCount(false);
        GameoverCanvas.SetActive(true);

        Destroy(ViewBar, 3f);
        Destroy(UpperViewBar, 3f);


    }

    public void OnChangedPos()
    {
        ViewBar.EnableBar(IsUpper());
        UpperViewBar.EnableBar(!IsUpper());
    }

    void OnFirstHit()
    {
        CurrentCombo = gameObject.AddComponent<FirstShowUpCombo>();
        Timer.SetCount(true);
        BGM.SetActive(true);
    }

    public void DoRage()
    {
        DoesRage = true;
        gameObject.AddComponent<RageCombo>();
    }

    public void DoDown()
    {
        CurrentCombo = gameObject.AddComponent<DownCombo>();
    }

    public void DoMoveForwardCombo()
    {
        CurrentCombo = gameObject.AddComponent<MoveForwardCombo>();
    }

    public void DoShootGunCombo()
    {
        CurrentCombo = gameObject.AddComponent<ShootGunCombo>();
    }

    public void DoMiniGunCombo()
    {
        DoesMiniCount++;
        CurrentCombo = gameObject.AddComponent<MiniGunCombo>();
    }

    public void DoBeamCombo()
    {
        if (IsInRage())
        {
            DoesRageBeam = true;
        }
        CurrentCombo = gameObject.AddComponent<BeamCombo>();
    }

    public bool IsInRage()
    {
        return GetHPRate() <= 0.625f;
    }

    public float GetHPRate()
    {
        return ((float)CurrentHp / (float)(MaxHp - 1));
    }

    public void ResetToNormal()
    {
        SetBeHitable();
        print("ResetToNormal");
        NextMove();
    }

    public void SetBeHitable()
    {
        SphereControll.SetHitable(true);
    }

    void NextMove()
    {
        if (IsInRage() && !DoesRage)
        {
            if (!IsUpper())
            {
                DoMoveForwardCombo();
                return;
            }
            DoRage();
            return;
        }
        if (IsInRage() && !DoesRageBeam)
        {
            DoBeamCombo();
            return;
        }

        if (DoesMiniCount < 3)
        {
            DoMiniGunCombo();
            return;
        }
        RngDeside();

    }

    void RngDeside()
    {
        List<int> RNG = new List<int>();
        if (IsInRage())
        {
            Populate(RNG, 1, CurrentCombo.GetType() == typeof(MoveForwardCombo) ? 0 : 15);
            Populate(RNG, 2, CurrentCombo.GetType() == typeof(ShootGunCombo) ? 0 : 10);
            Populate(RNG, 3, CurrentCombo.GetType() == typeof(MiniGunCombo) ? 0 : 10);
            Populate(RNG, 4, CurrentCombo.GetType() == typeof(BeamCombo) ? 0 : 5);
        }
        else
        {
            Populate(RNG, 1, CurrentCombo.GetType() == typeof(MoveForwardCombo) ? 0 : 15);
            Populate(RNG, 2, CurrentCombo.GetType() == typeof(ShootGunCombo) ? 0 : 15);
            Populate(RNG, 3, CurrentCombo.GetType() == typeof(MiniGunCombo) ? 0 : 5);
            Populate(RNG, 4, CurrentCombo.GetType() == typeof(BeamCombo) ? 0 : 20);
        }
        int RNGResult = RNG[Random.Range(0, RNG.Count)];
        switch (RNGResult)
        {
            default:
                DoMoveForwardCombo();
                break;
            case 2:
                DoShootGunCombo();
                break;
            case 3:
                DoMiniGunCombo();
                break;
            case 4:
                if (IsInRage() && !IsUpper())
                {
                    RngDeside();
                    return;
                }
                DoBeamCombo();
                break;
        }
    }

    void Populate<T>(List<T> arr, T value, int Length)
    {
        for (int i = 0; i < Length; i++)
        {
            arr.Add(value);
        }
    }

    void Dead()
    {
        Destroy(this);
    }
}
