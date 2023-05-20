using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaShooter : healthBase
{
    float setBulletTime = 2f;//�����ӵ��ļ��
    float setBulletTimer = 0;//�����ӵ���ʱ��
    public GameObject bullet;//�ӵ�Ԥ����
    public Transform bulletPos;//�ӵ����ɵ�

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
