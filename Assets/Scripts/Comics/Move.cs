using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// contains data of moves that changes during a battle
public class Move
{
    // create reference to MoveBase class
    public MoveBase Base { get; set; }
    public int PP { get; set; }

//initialize in constructor
    public Move(MoveBase cBase)
    {
        Base = cBase;
        PP = cBase.PP;
    }
}
