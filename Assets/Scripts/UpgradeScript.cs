using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class UpgradeScript : MonoBehaviour
{
    [Header("Upgrades")]
    public int originalUpgrade1Cost = 50;
    public float increasedUpgrade = 1f; //start with nothing
    public int currentOriginalCost;

    [SerializeField] TextMeshProUGUI upgradeText = new TextMeshProUGUI();

    [Header("Tower buy")]
    [SerializeField] Animator cameraAnimator;
    [SerializeField] GameObject[] towers;
    [SerializeField] Material[] materials;  
    [SerializeField] bool menuOpen;

    PauseGame pauseGame;

    // Start is called before the first frame update
    void Start()
    {
        pauseGame = FindObjectOfType<PauseGame>();
        currentOriginalCost = originalUpgrade1Cost;
    }

    // Update is called once per frame
    void Update()
    {
        TowerBuyMenu(0);
        if (upgradeText != null) { upgradeText.text = currentOriginalCost.ToString() + "$"; }
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
                tower.Guns[0].WavesPerCycle[0].Bullets[0].SizeFactor += 0.5f;
            }
        }
    }

    //Buy Towers

    public void OpenMenu(bool b)
    {
        cameraAnimator.SetBool("OpenBuyMenu", b);
        menuOpen = b;

        if (menuOpen) { pauseGame.Pause(true); }
        else { pauseGame.Pause(false); }
    }

    void TowerBuyMenu(int price)
    {
        if(price <= GameManager.GlobalGameManager.CurrentPlayerData.PlayerMoney)
        {
            GameManager.GlobalGameManager.CurrentPlayerData.PlayerMoney -= price;
        }

        foreach (GameObject tower in towers)
        {
            Renderer meshRenderer = tower.GetComponent<Renderer>();
            bool unlocked;

            if (tower.GetComponentInChildren<Light>() != isActiveAndEnabled)
            {
                unlocked = true;
            }
            else
            {
                unlocked = false;
            }

            //Enable Towers
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
}
