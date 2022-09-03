using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;

    public void SetData(Comic comic)
    {
        nameText.text = comic.Base.Name;
        levelText.text = "Lvl " + comic.Level;
        hpBar.SetHP((float) comic.HP / comic.MaxHp );
    }
}
