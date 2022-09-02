using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comic
{
    ComicBase _base;
    int level;

    public int HP {get; set; }

    public List<Move> Moves { get; set; }

    public Comic(ComicBase cBase, int cLevel)
    {
        _base = cBase;
        level = cLevel;
        HP = _base.MaxHp;

        Move = new List<Move>();
        foreach (var move in _base.LearnableMoves)
        {
            if (move.Level <= level)
                Moves.Add(new Move(move.Base));

            if (Moves.Count >= 4)
                break;
        }
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
