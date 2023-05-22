using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : plantBase
{
    float setBulletTime = 1f;//创建子弹的间隔
    float setBulletTimer = 0;//创建子弹的时间
    public GameObject bullet;//子弹预制体
    public Transform bulletPos;//子弹生成点

    protected override void Start()
    {
        base.Start();
        health= Utils.GetPlantData().peaShooter.health;
        currentHealth = health;
    }
    private void Update()
    {
        if (!isGrow) return;
        setBulletTimer += Time.deltaTime;
        if (setBulletTimer >= setBulletTime)
        {
            setBulletTimer = 0;
            Instantiate(bullet,bulletPos.position,Quaternion.identity);
        }
    }

}
