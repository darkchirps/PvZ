using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlower : MonoBehaviour
{
    public GameObject sunPrefab;//̫��Ԥ����
    public float setSunTime;//����̫���ļ��
    public float setSunTimer;//����̫����ʱ��
    Animator flowerAni;//̫�����������

    private void Start()
    {
        flowerAni = GetComponent<Animator>();
    }
    private void Update()
    {
        setSunTimer += Time.deltaTime;
        if (setSunTimer >= setSunTime)
        {
            setSunTimer = 0;
            if (flowerAni.GetBool("ready")) return;
            flowerAni.SetBool("ready", true);
        }
    }
    //�����¼���ɺ�ص�
    public void flowerAniEnd()
    {
        BornSun();
        flowerAni.Play("SunFlowerIdle");
        flowerAni.SetBool("ready",false);
    }
    //��������
    private void BornSun()
    {
        GameObject sunObject = Instantiate(sunPrefab,transform);
        int randomNum = Random.Range(0,2);
        int times = randomNum == 0 ? -1 : 1;
        float randomX = Random.Range(0.2f * times, 0.5f * times);
        float randomY = Random.Range(-0.3f, 0.3f);
        sunObject.transform.localPosition = new Vector2(randomX, randomY);
    }
}
