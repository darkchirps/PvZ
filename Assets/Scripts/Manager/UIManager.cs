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
            // 拿到配置的数据，并且在指定位置生成旗子
            float percent = levelInfo.progressPercent[i];
            if (percent == 1)
            {
                continue;
            }
            progressPanel.SetFlagPercent(percent);
        }
        // 初始化进度为0
        progressPanel.SetPercent(0);
        progressPanel.gameObject.SetActive(true);
    }

    public void UpdateProgressPanel()
    {
        // todo: 拿到当前波次的僵尸总数
        int progressNum = 0;
        for (int i = 0; i < gameManager.instance.levelData.LevelDataList.Count; i++)
        {
            LevelItem levelItem = gameManager.instance.levelData.LevelDataList[i];
            if (levelItem.levelId == gameManager.instance.curLevelId && levelItem.progressId == gameManager.instance.curProgressId)
            {
                progressNum += 1;
            }
        }

        // 当前波次剩余的僵尸数量
        int remainNum = gameManager.instance.curProgressZombie.Count;
        // 当前波次进行到多少百分比
        float percent = (float)(progressNum - remainNum) / progressNum;
        // 当前波次比例，前一波次比例
        LevelInfoItem levelInfoItem = gameManager.instance.levelInfo.LevelInfoList[gameManager.instance.curLevelId];
        float progressPercent = levelInfoItem.progressPercent[gameManager.instance.curProgressId - 1];
        float lastProgressPercent = 0;
        if (gameManager.instance.curProgressId > 1)
        {
            lastProgressPercent = levelInfoItem.progressPercent[gameManager.instance.curProgressId - 2];
        }
        // 最终比例 = 当前波次百分比 + 前一波次百分比
        float finalPercent = percent * (progressPercent - lastProgressPercent) + lastProgressPercent;
        progressPanel.SetPercent(finalPercent);
    }
}
