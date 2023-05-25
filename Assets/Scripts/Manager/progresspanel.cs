using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progresspanel : MonoBehaviour
{
    private GameObject Progress;
    private GameObject Head;
    private GameObject LevelText;
    private GameObject Bg;
    private GameObject Flag;
    private GameObject FlagPrefab;

    private void Awake()
    {
        Progress = transform.Find("Progress").gameObject;
        Head = transform.Find("Head").gameObject;
        LevelText = transform.Find("LevelText").gameObject;
        Bg = transform.Find("Bg").gameObject;
        Flag = transform.Find("Flag").gameObject;
        // ��Resources�м���Ԥ�Ƽ�
        FlagPrefab = Resources.Load<GameObject>("Prefabs/page/Flag");
    }

    public void SetPercent(float per)
    {
        //ͼƬ������
        Progress.GetComponent<Image>().fillAmount = per;
        // ���������ұߵ�λ�ã���ʼλ�ã�TransformPoint
        float originPosX = Bg.transform.TransformPoint(Vector3.zero).x + Bg.GetComponent<RectTransform>().sizeDelta.x / 2;
        // ���������
        float width = Bg.GetComponent<RectTransform>().sizeDelta.x;
        // ������Զ��������������ƫ�ƣ��������Լ���Ϊ���ʵ�λ��
        float offset = 5;
        // ����ͷ��x��λ�ã����ұߵ�λ�� - ��������ȵ�һ�� + �Զ����ƫ��
        Head.GetComponent<RectTransform>().position = new Vector2(originPosX - per * width + offset, Head.GetComponent<RectTransform>().position.y);
    }

    public void SetFlagPercent(float per)
    {
        Flag.SetActive(false);
        // ���������ұߵ�λ�ã���ʼλ�ã�
        float originPosX = Bg.transform.TransformPoint(Vector3.zero).x + Bg.GetComponent<RectTransform>().sizeDelta.x / 2;
        // ���������
        float width = Bg.GetComponent<RectTransform>().sizeDelta.x;
        // ������Զ��������������ƫ�ƣ��������Լ���Ϊ���ʵ�λ��
        // �����µ�����
        GameObject newFlag = Instantiate(FlagPrefab);
        newFlag.transform.SetParent(gameObject.transform, false);
        newFlag.GetComponent<RectTransform>().position = Flag.GetComponent<RectTransform>().position;
        // ������Զ��������������ƫ�ƣ��������Լ���Ϊ���ʵ�λ��
        float offset = 5;
        // ����λ��
        newFlag.GetComponent<RectTransform>().position = new Vector2(originPosX- width* per+offset, newFlag.GetComponent<RectTransform>().position.y);
        //newFlag.GetComponent<RectTransform>().position = new Vector2(originPosX - per * width + offset, newFlag.GetComponent<RectTransform>().position.y);
        Head.transform.SetAsLastSibling();
    }
}
