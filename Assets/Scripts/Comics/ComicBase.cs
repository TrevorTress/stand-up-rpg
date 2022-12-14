using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Comic", menuName = "Comic/Create new comic")]

public class ComicBase : ScriptableObject
{
    // initialize basic comic info
    [SerializeField] string name;
    [TextArea] 
    [SerializeField] string description;
    [SerializeField] Sprite sprite;
    [SerializeField] ComicType type;

    // initialize comic stats
    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int speed;

    // initialize list of learnable moves
    [SerializeField] List<LearnableMove> learnableMoves;

    // create links to comic details with public data
    public string Name {
        get {return name;}
    }

    public string Description {
        get {return description;}
    }

    public Sprite Sprite{
        get { return sprite;}
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

    public List<LearnableMove> LearnableMoves {
        get { return learnableMoves; }
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
}

public enum ComicType
{
    Normal,
    Fire
}
