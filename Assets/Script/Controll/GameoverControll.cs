using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameoverControll : SingletonMonoBehavior<GameoverControll>
{
    [SerializeField]
    GameObject RestartAniObject;
    public void Gameover()
    {
        Invoke("DoAni", 1f);
        Invoke("ReloadScene", 2.5f);
    }

    void DoAni()
    {
        RestartAniObject.SetActive(true);

    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
