using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnit : MonoBehaviour
{
    [SerializeField] ComicBase _base;
    [SerializeField] int level;

    [SerializeField] bool isPlayerUnit;

    public Comic Comic { get; set; }

    public void Setup()
    {
        Comic = new Comic(_base, level);
        if (isPlayerUnit)
            GetComponent<Image>().sprite = Comic.Base.Sprite;
    }
}
