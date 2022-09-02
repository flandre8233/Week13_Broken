using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileViewAnimationEvent : MonoBehaviour
{
    [SerializeField] Missile Parent;
    public void OnFinish()
    {
        Parent.Close();
    }
}
