using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public GameObject bornParent;
    public GameObject zombiePrefab;
    public int sunNum;

    private int zOrderIndex=0;
    //HideInInspector��һ���������η�����������Inspector����е�ĳ���������ֶΡ���һ���������ֶα����ΪHideInInspectorʱ������������Inspector�������ʾ��������Ȼ�����ڽű���ʹ��
    [HideInInspector]
    public LevelData levelData;
    [HideInInspector]
    public LevelInfo levelInfo;
    public bool gameStart;
    public int curLevelId = 1;
    public int curProgressId = 1;
    public List<GameObject> curProgressZombie;
    private void Awake()
    {
        //����������
        instance = this;
    }
    private void Start()
    {
        //UIManager.instance.InitUI();
        //StartCoroutine(infiniteCreatZombie());
        //InvokeRepeating("sunMoveDown", 5, 5);
        //SoundManager.instance.PlayBGM(Globals.BGM1);
        ReadData();
    }
    private void GameStart()
    {
        UIManager.instance.InitUI();
        gameStart = true;
        CreateZombie();
        InvokeRepeating("sunMoveDown", 5, 5);
        //InvokeRepeating("CreateSunDown", 10, 10);
        // ����BGM
        SoundManager.instance.PlayBGM(Globals.BGM1);
    }
    void ReadData()
    {
        // StartCoroutine(LoadTable());
        LoadTableNew();
    }
    public void LoadTableNew()
    {
        levelData = Resources.Load<LevelData>("sheets/LevelData");
        levelInfo = Resources.Load<LevelInfo>("sheets/LevelInfo");
        //plantInfo = Resources.Load("TableData/plantInfo") as PlantInfo;
        GameStart();
    }
    public void ChangeSunNum(int changeNum)
    {
        sunNum += changeNum;
        if (sunNum <= 0)
        {
            sunNum = 0;
        }
        // �������������ı䣬֪ͨ��Ƭѹ�ڵ�...
        UIManager.instance.UpdateUI();

    }

    public void CreateZombie()
    {
        // StartCoroutine(DalayCreateZombie());
        curProgressZombie = new List<GameObject>();
        TableCreateZombie();
        // ���ó�ʼ���������ĺ���
        UIManager.instance.InitProgressPanel();
    }

    // ��񴴽���ʬ
    private void TableCreateZombie()
    {
        // todo ѡ��ؿ�
        bool canCreate = false;
        for (int i = 0; i < levelData.LevelDataList.Count; i++)
        {
            LevelItem levelItem = levelData.LevelDataList[i];
            if (levelItem.levelId == curLevelId && levelItem.progressId == curProgressId)
            {
                canCreate = true;
                StartCoroutine(ITableCreateZombie(levelItem));
            }
        }
        if (!canCreate)
        {
            StopAllCoroutines();
            curProgressZombie = new List<GameObject>();
            gameStart = false;
            GameWin();
        }
        else
        {
            SoundManager.instance.PlaySound(Globals.S_ZombieSound1);
        }
    }

    public void GameWin()
    {
        // todo: ���ʤ��֮���һЩ����
        SoundManager.instance.PlaySound(Globals.S_Winmusic);
    }

    IEnumerator ITableCreateZombie(LevelItem levelItem)
    {
        yield return new WaitForSeconds(levelItem.createTime);
        // ����
        // GameObject zombie = Instantiate(zombiePrefab);
        GameObject zombiePrefab = Resources.Load<GameObject>("Prefabs/Zombie/Zombie" + levelItem.zombieType.ToString());
        GameObject zombie = Instantiate(zombiePrefab);
        Transform zombieLine = bornParent.transform.Find("born" + levelItem.bornPos.ToString());
        zombie.transform.parent = zombieLine;
        zombie.transform.localPosition = Vector3.zero;
        zombie.GetComponent<SpriteRenderer>().sortingOrder = zOrderIndex;
        zOrderIndex += 1;
        curProgressZombie.Add(zombie);
    }

    public void ZombieDied(GameObject gameObject)
    {
        if (curProgressZombie.Contains(gameObject))
        {
            curProgressZombie.Remove(gameObject);
            UIManager.instance.UpdateProgressPanel();
        }
        // GameObject.Destroy(gameObject);
        if (curProgressZombie.Count == 0)
        {
            curProgressId++;
            TableCreateZombie();
        }
    }

    public int GetPlantLine(GameObject plant)
    {
        GameObject lineObject = plant.transform.parent.parent.gameObject;
        string lineStr = lineObject.name;
        int line = int.Parse(Split(lineStr, "line")[1]);
        return line;
    }

    public List<GameObject> GetLineZombies(int line)
    {
        string lineName = "born" + line.ToString();
        Transform bornObject = bornParent.transform.Find(lineName);
        List<GameObject> zombies = new List<GameObject>();
        for (int i = 0; i < bornObject.childCount; i++)
        {
            zombies.Add(bornObject.GetChild(i).gameObject);
        }
        return zombies;
    }
    public static string[] Split(string source, string str)
    {
        var list = new List<string>();
        while (true)
        {
            var index = source.IndexOf(str);
            if (index < 0) { list.Add(source); break; }
            var rs = source.Substring(0, index);
            list.Add(rs);
            source = source.Substring(index + str.Length);
        }
        return list.ToArray();
    }

    void sunMoveDown()
    {
        GameObject sunPrefab = Resources.Load("Prefabs/Bullet/Sun") as GameObject;
        float x = Random.Range(-4f, 2.25f);
        Vector3 spawnPosition = new Vector3(x, 4f, 0.0f);
        float y = Random.Range(-2.2f, -1.8f);
        GameObject sun = Instantiate(sunPrefab, spawnPosition, Quaternion.identity);
        sun.GetComponent<Sun>().SetTargetPos(new Vector3(x, y, 0));
    }
    public void changeSunNum(int changeNum)
    {
        sunNum += changeNum;
        if (sunNum <= 0)
        {
            sunNum = 0;
        }
        UIManager.instance.UpdateUI();
    }

    //�����ʬ
    IEnumerator infiniteCreatZombie()
    {
        while (true)
        {
            GameObject zombie = Instantiate(zombiePrefab);
            int index = Random.Range(0, 5);
            Transform zombieP = bornParent.transform.Find("born" + index.ToString());
            zombie.transform.parent = zombieP;
            zombie.transform.localPosition = Vector3.zero;
            zombie.GetComponent<SpriteRenderer>().sortingOrder = zOrderIndex;
            zOrderIndex += 1;
            yield return new WaitForSeconds(3);
        }
    }

}
