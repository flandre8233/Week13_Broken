using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen
{
    public static Vector3 ToWorldPos(Vector2 ViewPort)
    {
        Vector2 WantedWorldPos = Camera.main.ViewportToWorldPoint(ViewPort);
        return new Vector3(WantedWorldPos.x, WantedWorldPos.y, 0);
    }
}

public class TopLeftVP
{
    public static Vector2 Get()
    {
        return new Vector2(0.25f, 1);
    }
}

public class TopRightVP
{
    public static Vector2 Get()
    {
        return new Vector2(0.75f, 1);
    }
}

public class BottomLeftVP
{
    public static Vector2 Get()
    {
        return new Vector2(0.25f, 0);
    }
}

public class BottomRightVP
{
    public static Vector2 Get()
    {
        return new Vector2(0.75f, 0);
    }
}

public class TopVP
{
    public static Vector2 Get()
    {
        return new Vector2(0.5f, 1);
    }
}

public class BottomVP
{
    public static Vector2 Get()
    {
        return new Vector2(0.5f, 0);
    }
}

public class LeftVP
{
    public static Vector2 Get()
    {
        return new Vector2(0, 0.5f);
    }
}

public class RightVP
{
    public static Vector2 Get()
    {
        return new Vector2(1, 0.5f);
    }
}
