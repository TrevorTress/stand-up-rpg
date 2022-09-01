using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comic
{
    ComicBase _base;
    int level;

    public Comic(ComicBase cBase, int cLevel)
    {
        _base = cBase;
        level = cLevel;

        _base.Name;
    }

    public int MaxHp {
        get { return Mathf.FloorToInt((_base.MaxHp * level) / 100f) + 10;}
    }

    public int Attack {
        get { return Mathf.FloorToInt((_base.Attack * level) / 100f) + 5;}
    }

    public int Defense {
        get { return Mathf.FloorToInt((_base.Defense * level) / 100f) + 5;}
    }

    public int Speed {
        get { return Mathf.FloorToInt((_base.Speed * level) / 100f) + 5;}
    }
}
