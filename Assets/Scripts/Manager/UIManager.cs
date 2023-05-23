using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text sunNumText;
    public progresspanel progressPanel;

    private void Awake()
    {
        instance = this;
    }

    public void InitUI()
    {
        sunNumText.text = gameManager.instance.sunNum.ToString();
        progressPanel.gameObject.SetActive(false);
    }

    public void UpdateUI()
    {
        sunNumText.text = gameManager.instance.sunNum.ToString();
    }

    public void InitProgressPanel()
    {
        LevelInfoItem levelInfo = gameManager.instance.levelInfo.LevelInfoList[gameManager.instance.curLevelId];
        for (int i = 0; i < levelInfo.progressPercent.Length; i++)
        {
            // �õ����õ����ݣ�������ָ��λ����������
            float percent = levelInfo.progressPercent[i];
            if (percent == 1)
            {
                continue;
            }
            progressPanel.SetFlagPercent(percent);
        }
        // ��ʼ������Ϊ0
        progressPanel.SetPercent(0);
        progressPanel.gameObject.SetActive(true);
    }

    public void UpdateProgressPanel()
    {
        // todo: �õ���ǰ���εĽ�ʬ����
        int progressNum = 0;
        for (int i = 0; i < gameManager.instance.levelData.LevelDataList.Count; i++)
        {
            LevelItem levelItem = gameManager.instance.levelData.LevelDataList[i];
            if (levelItem.levelId == gameManager.instance.curLevelId && levelItem.progressId == gameManager.instance.curProgressId)
            {
                progressNum += 1;
            }
        }

        // ��ǰ����ʣ��Ľ�ʬ����
        int remainNum = gameManager.instance.curProgressZombie.Count;
        // ��ǰ���ν��е����ٰٷֱ�
        float percent = (float)(progressNum - remainNum) / progressNum;
        // ��ǰ���α�����ǰһ���α���
        LevelInfoItem levelInfoItem = gameManager.instance.levelInfo.LevelInfoList[gameManager.instance.curLevelId];
        float progressPercent = levelInfoItem.progressPercent[gameManager.instance.curProgressId - 1];
        float lastProgressPercent = 0;
        if (gameManager.instance.curProgressId > 1)
        {
            lastProgressPercent = levelInfoItem.progressPercent[gameManager.instance.curProgressId - 2];
        }
        // ���ձ��� = ��ǰ���ΰٷֱ� + ǰһ���ΰٷֱ�
        float finalPercent = percent * (progressPercent - lastProgressPercent) + lastProgressPercent;
        progressPanel.SetPercent(finalPercent);
    }
}
