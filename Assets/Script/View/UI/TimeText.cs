using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeText : CommonUIText
{
    protected override void Start()
    {
        base.Start();
        UpdateText();
    }

    public override void UpdateText()
    {
        text.text = "Time : " + Timer.instance.GetTime();
    }
}
