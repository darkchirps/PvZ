using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// DataObj�ű� ö�����
/// </summary>
public class DataObj 
{
    [System.Serializable]
    public class plantList//ֲ�������
    {
        public plantType peaShooter;
        public plantType sunFlower; 
        public plantType wallNut; 
    }
    [System.Serializable]
    public class plantType//ֲ������
    {
        public string name;
        public int health;
        public int attack;
        //public List<int> grades;
    }
    [System.Serializable]
    public class zombieList//��ʬ������
    {
        public zombieType general;
        public zombieType sunFlower;
    }
    [System.Serializable]
    public class zombieType//��ʬ����
    {
        public string name;
        public int health;
        public int lostHeadHealth;
        public int attack;
        //public List<int> grades;
    }
    /// <summary>
    /// JsonData ����json������õ�����
    /// </summary>
    public class JsonData
    {
        //Data���������������JSON�ļ��еļ�����ͬ�����������ʧ�ܡ�
        public int sfan;
    }

    /// <summary>
    /// ö��                      
    /// </summary>
    enum Direction { North, East, South, West };
    /// <summary>
    /// ���� ��Ӳ ����
    /// </summary>
    public enum boxType { broken, solid, rare };
    /// <summary>
    /// ��� ��ֵ ��� �ӵ�
    /// </summary>
    public enum fruitType { gold,health,apple,banana };

}
