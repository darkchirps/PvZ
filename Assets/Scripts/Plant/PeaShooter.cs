using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : healthBase
{
    float setBulletTime = 2f;//创建子弹的间隔
    float setBulletTimer = 0;//创建子弹的时间
    public GameObject bullet;//子弹预制体
    public Transform bulletPos;//子弹生成点

    private void Start()
    {
        base.health= Utils.GetPlantData().peaShooter.health;
    }
    private void Update()
    {
        setBulletTimer += Time.deltaTime;
        if (setBulletTimer >= setBulletTime)
        {
            setBulletTimer = 0;
            Instantiate(bullet,bulletPos.position,Quaternion.identity);
        }
        if (base.health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
