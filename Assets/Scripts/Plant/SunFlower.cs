using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : plantBase
{
    public GameObject sunPrefab;//̫��Ԥ����
    public float setSunTime;//����̫���ļ��
    public float setSunTimer;//����̫����ʱ��

    protected override void Start()
    {
        base.Start();
        health = Utils.GetPlantData().sunFlower.health;
        currentHealth = health;
    }

    private void Update()
    {
        if (!isGrow) return;
        setSunTimer += Time.deltaTime;
        if (setSunTimer >= setSunTime)
        {
            setSunTimer = 0;
            if (plantAni.GetBool("ready")) return;
            plantAni.SetBool("ready", true);
        }
    }
    //�����¼���ɺ�ص�
    public void flowerAniEnd()
    {
        BornSun();
        plantAni.Play("SunFlowerIdle");
        plantAni.SetBool("ready",false);
    }
    //��������
    private void BornSun()
    {
        GameObject sunObject = Instantiate(sunPrefab);
        int randomNum = Random.Range(0,2);
        int times = randomNum == 0 ? -1 : 1;
        float randomX = Random.Range(transform.position.x+0.2f * times, transform.position.x + 0.5f * times);
        float randomY = Random.Range(transform.position.y -0.2f, transform.position.y +0.2f);
        sunObject.transform.localPosition = new Vector2(randomX, randomY);
    }
}
