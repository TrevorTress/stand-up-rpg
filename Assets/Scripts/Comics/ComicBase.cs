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

    [SerializeField] List<LearnableMove> learnableMoves;

    public string Name {
        get {return name;}
    }

    public string Description {
        get {return description;}
    }

    public int MaxHp {
        get {return maxHp;}
    }

    public int Attack {
        get {return attack;}
    }

    public int Defense {
        get {return defense;}
    }

    public int Speed {
        get {return speed;}
    }
}

[System.Serializable]
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base {
        get { return moveBase;}
    }

    public int Level {
        get { return level;}
    }

    public List<LearnableMove> LearnableMoves {
        get { return LearnableMoves; }
    }
}

public enum ComicType
{
    Normal,
    Fire
}
