using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject BGM;
    [SerializeField] Animator DeadAni;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Close()
    {
        Destroy(gameObject);
        GameModel.instance.player = null;
        GameoverControll.instance.Gameover();
        ResourcesSpawner.Spawn("Gameover", 5f);
        BGM.SetActive(false);

    }

    public void PlayerDeadByFall()
    {
        print("PlayerDeadByFall");
        DeadAni.enabled = true;
        Destroy(gameObject, 1f);
        GameModel.instance.player = null;
        GameoverControll.instance.Gameover();
        ResourcesSpawner.Spawn("Gameover", 5f);

        BGM.SetActive(false);

    }

    public void PlayerDeadByExp()
    {
        CameraShake.Shake(0.3f, .3f);

        print("PlayerDeadByExp");
        Destroy(gameObject);
        GameModel.instance.player = null;
        GameoverControll.instance.Gameover();
        ResourcesSpawner.Spawn("Gameover", 5f);

        BGM.SetActive(false);

    }
    public void PlayerDeadByBullet()
    {
        CameraShake.Shake(0.3f, .15f);

        print("PlayerDeadByBullet");
        Destroy(gameObject);
        GameModel.instance.player = null;
        GameoverControll.instance.Gameover();
        ResourcesSpawner.Spawn("Gameover", 5f);
        BGM.SetActive(false);

    }

}
