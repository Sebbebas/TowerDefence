using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTowers : MonoBehaviour
{
    [SerializeField] int price = 0;

    public void BuyTower()
    {
        Light light = GetComponentInChildren<Light>();

        if (price <= GameManager.GlobalGameManager.CurrentPlayerData.PlayerMoney && gameObject.activeSelf == true)
        {
            GameManager.GlobalGameManager.CurrentPlayerData.PlayerMoney -= price;
            light.gameObject.SetActive(false);
        }
    }
}
