using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progresspanel : MonoBehaviour
{
    private GameObject progress;
    private GameObject head;
    private GameObject levelText;
    private GameObject bg;
    private GameObject flag;
    private GameObject flagPrefab;

    private void Start()
    {
        progress = transform.Find("progress").gameObject;
        head = transform.Find("head").gameObject;
        levelText = transform.Find("level").gameObject;
        bg = transform.Find("bg").gameObject;
        flag = transform.Find("flag").gameObject;
        flagPrefab = Resources.Load("Prefabs/page/flag") as GameObject;
        SetPercent(0.6f);
        SetFlagPercent(0.6f);
    }

    public void SetPercent(float per)
    {
        //ͼƬ������
        progress.GetComponent<Image>().fillAmount = per;
        //���������ұߵ�λ�ã���ʼλ�ã�
        float originPosX = bg.GetComponent<RectTransform>().position.x + bg.GetComponent<RectTransform>().sizeDelta.x / 2;
        //���������
        float width = bg.GetComponent<RectTransform>().sizeDelta.x;
        //�Զ��������������ƫ�ƣ��������Լ���Ϊ���ʵ�λ��
        float offset = 10;
        //����ͷ��xλ�ã����ұߵ�λ��-��������ȵ�һ��+�Զ����ƫ��
        head.GetComponent<RectTransform>().position = new Vector2(originPosX-per*width+offset,head.GetComponent<RectTransform>().position.y);
    }

    public void SetFlagPercent(float per)
    {
        flag.SetActive(false);
        //���������ұߵ�λ�ã���ʼλ�ã�
        float originPosX = bg.GetComponent<RectTransform>().position.x + bg.GetComponent<RectTransform>().sizeDelta.x / 2;
        //���������
        float width = bg.GetComponent<RectTransform>().sizeDelta.x;
        //�Զ��������������ƫ�ƣ��������Լ���Ϊ���ʵ�λ��
        float offset = 10;
        //�����µ�����
        GameObject newFlag = Instantiate(flagPrefab);
        newFlag.transform.SetParent(gameObject.transform, false);
        newFlag.GetComponent<RectTransform>().position = flag.GetComponent<RectTransform>().position;
        //����λ��
        newFlag.GetComponent<RectTransform>().position = new Vector2(originPosX-per*width+offset, newFlag.GetComponent<RectTransform>().position.y);
        head.transform.SetAsFirstSibling();
    }
}
