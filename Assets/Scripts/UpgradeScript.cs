using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeScript : MonoBehaviour
{
    [Header("Upgrades")]
    public int originalUpgrade1Cost = 50;
    public float increasedUpgrade = 1f; //start with nothing
    private int currentOriginalCost;

    [Header("Tower buy")]
    [SerializeField] Animator cameraAnimator;
    [SerializeField] GameObject[] towers;
    [SerializeField] GameObject[] unlockedTowers;
    [SerializeField] Material[] materials;
    [SerializeField] bool menuOpen;

    // Start is called before the first frame update
    void Start()
    {
        currentOriginalCost = originalUpgrade1Cost;
    }

    // Update is called once per frame
    void Update()
    {
        TowerBuyMenu();
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

    public void OpenMenu(bool b)
    {
        cameraAnimator.SetBool("Open Menu", b);
        menuOpen = b;

        //if (menuOpen) { Time.timeScale = 0f; }
        //else { Time.timeScale = 1f; }
    }

    void TowerBuyMenu()
    {
        bool unlocked = false;
        foreach (GameObject tower in towers)
        {
            Renderer meshRenderer = tower.GetComponent<Renderer>();
            if (unlocked)
            {
                tower.SetActive(true);
                meshRenderer.sharedMaterial = materials[0];
            }
            else if (!unlocked && menuOpen)
            {
                tower.SetActive(true);
                meshRenderer.sharedMaterial = materials[1];
            }
            else
            {
                tower.SetActive(false);
            }
        }
    }
    public void BuyTower(int tower)
    {
        Transform notUnlocked = towers[tower].GetComponentInChildren<Transform>();

        if(GameManager.GlobalGameManager.CurrentPlayerData.PlayerMoney >= 0)
        {
            Destroy(notUnlocked);
        }
    }
}
