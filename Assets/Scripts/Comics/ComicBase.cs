using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Comic", menuName = "Comic/Create new comic")]

public class ComicBase : ScriptableObject
{
    [SerializeField] string name;
    [TextArea] 
    [SerializeField] string description;
    [SerializeField] Sprite sprite;
    [SerializeField] ComicType type;

    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;

    public string Name {
        get {return name;}
    }

    public string Description {
        get {return descriptiod;}
    }

    public string MaxHp {
        get {return maxHp;}
    }

    public string Attack {
        get {return attack;}
    }

    public string Defense {
        get {return defense;}
    }

    public string Speed {
        get {return speed;}
    }
}

public enum ComicType
{
    Normal,
    Fire
}
