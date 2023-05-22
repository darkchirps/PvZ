using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : plantBase
{
    float setBulletTime = 1f;//�����ӵ��ļ��
    float setBulletTimer = 0;//�����ӵ���ʱ��
    public GameObject bullet;//�ӵ�Ԥ����
    public Transform bulletPos;//�ӵ����ɵ�

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
