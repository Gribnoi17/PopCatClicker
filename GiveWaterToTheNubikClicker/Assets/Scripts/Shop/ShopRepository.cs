using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopRepository : Repository
{
    private const string KEY_COST = "SHOP_COST";
    private const string KEY_LEVEL = "SHOP_LEVEL";
    private const string KEY_CLICK = "SHOP_CLICK";

    public int CostBonus { get; set; }
    public int LevelBonus { get; set; }
    public int ClickPowerBonus { get; set; }
    public override void Initialize()
    {
        CostBonus = PlayerPrefs.GetInt(KEY_COST, 20);
        LevelBonus = PlayerPrefs.GetInt(KEY_LEVEL, 0);
        ClickPowerBonus = PlayerPrefs.GetInt(KEY_CLICK, 1);
    }

    public override void Save()
    {
        PlayerPrefs.SetInt(KEY_COST, this.CostBonus);
        PlayerPrefs.SetInt(KEY_LEVEL, this.LevelBonus);
        PlayerPrefs.SetInt(KEY_CLICK, this.ClickPowerBonus);
    }
}
