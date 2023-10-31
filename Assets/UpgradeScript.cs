using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    public int originalUpgrade1Cost = 50;
    public float increasedUpgrade = 1f; //start with nothing
    private int currentOriginalCost;

    [Header("Tower buy")]
    [SerializeField] Animator cameraAnimator;

    // Start is called before the first frame update
    void Start()
    {
        currentOriginalCost = originalUpgrade1Cost;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Upgrade()
    {
        if (GameManager.GlobalGameManager.CurrentPlayerData.PlayerMoney >= currentOriginalCost)
        {
            GameManager.GlobalGameManager.CurrentPlayerData.PlayerMoney -= currentOriginalCost;
            currentOriginalCost = (int)(currentOriginalCost * increasedUpgrade);
            increasedUpgrade += 0.2f;
            
            foreach (TowerBase tower in GameManager.GlobalGameManager.AllTowers)
            {
                tower.Guns[0].WavesPerCycle[0].Bullets[0].SizeFactor = 1;
            }
        }
    }

    //Buy Towers
    void TowerBuyMenu()
    {

    }
}
