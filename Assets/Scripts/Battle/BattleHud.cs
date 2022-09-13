using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHud : MonoBehaviour
{
    [SerializeField] Text nameText;
    [SerializeField] Text levelText;
    [SerializeField] HPBar hpBar;

    Comic _comic;

    public void SetData(Comic comic)
    {
        _comic = comic;

        nameText.text = comic.Base.Name;
        levelText.text = "Lvl " + comic.Level;
        hpBar.SetHP((float) comic.HP / comic.MaxHp );
    }

    public IEnumerator UpdateHP()
    {
        yield return hpBar.SetHPSmooth((float)_comic.HP / _comic.MaxHp );
    }
}
