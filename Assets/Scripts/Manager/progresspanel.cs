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
        //图片进度条
        progress.GetComponent<Image>().fillAmount = per;
        //进度条最右边的位置（初始位置）
        float originPosX = bg.GetComponent<RectTransform>().position.x + bg.GetComponent<RectTransform>().sizeDelta.x / 2;
        //进度条宽度
        float width = bg.GetComponent<RectTransform>().sizeDelta.x;
        //自定义参数，用来做偏移，调整到自己认为合适的位置
        float offset = 10;
        //设置头的x位置：最右边的位置-进度条宽度的一半+自定义的偏移
        head.GetComponent<RectTransform>().position = new Vector2(originPosX-per*width+offset,head.GetComponent<RectTransform>().position.y);
    }

    public void SetFlagPercent(float per)
    {
        flag.SetActive(false);
        //进度条最右边的位置（初始位置）
        float originPosX = bg.GetComponent<RectTransform>().position.x + bg.GetComponent<RectTransform>().sizeDelta.x / 2;
        //进度条宽度
        float width = bg.GetComponent<RectTransform>().sizeDelta.x;
        //自定义参数，用来做偏移，调整到自己认为合适的位置
        float offset = 10;
        //创建新的旗子
        GameObject newFlag = Instantiate(flagPrefab);
        newFlag.transform.SetParent(gameObject.transform, false);
        newFlag.GetComponent<RectTransform>().position = flag.GetComponent<RectTransform>().position;
        //设置位置
        newFlag.GetComponent<RectTransform>().position = new Vector2(originPosX-per*width+offset, newFlag.GetComponent<RectTransform>().position.y);
        head.transform.SetAsFirstSibling();
    }
}
