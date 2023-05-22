using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DataObj脚本 枚举相关
/// </summary>
public class DataObj 
{
    [System.Serializable]
    public class plantList//植物的配置
    {
        public plantType peaShooter;
        public plantType sunFlower; 
        public plantType wallNut; 
    }
    [System.Serializable]
    public class plantType//植物属性
    {
        public string name;
        public int health;
        public int attack;
        //public List<int> grades;
    }
    [System.Serializable]
    public class zombieList//僵尸的配置
    {
        public zombieType general;
        public zombieType sunFlower;
    }
    [System.Serializable]
    public class zombieType//僵尸属性
    {
        public string name;
        public int health;
        public int lostHeadHealth;
        public int attack;
        //public List<int> grades;
    }
    /// <summary>
    /// JsonData 解析json输出所用到的类
    /// </summary>
    public class JsonData
    {
        //Data类的属性名必须与JSON文件中的键名相同，否则解析将失败。
        public int sfan;
    }

    /// <summary>
    /// 枚举                      
    /// </summary>
    enum Direction { North, East, South, West };
    /// <summary>
    /// 可碎 坚硬 特殊
    /// </summary>
    public enum boxType { broken, solid, rare };
    /// <summary>
    /// 金币 心值 变大 子弹
    /// </summary>
    public enum fruitType { gold,health,apple,banana };

}
