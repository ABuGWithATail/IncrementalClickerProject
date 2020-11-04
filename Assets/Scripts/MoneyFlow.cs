using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MoneyFlow : MonoBehaviour
{
    int money = 0;
    int incremented = 1;
    int investorIncome = 0;
    int efficiencyUpgradeCost = 100;
    int investorUpgradeCost = 75;
    int unlockCost = 300;
    public GameObject investorButton;

    float timer;
    int delayAmount = 1;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= delayAmount)
        {
            // the timer will constantly count, and will add investor income to the game, and once purchased and investor income becomes more then 0
            // this will become noticable.
            timer = 0f;
            Tick();
        }

        if (money >= unlockCost)
        {
            investorButton.SetActive(true);
        }
    }

    public void IncrementClick() // the code to allow for money to be added on clicking the clicky.
    {
        money += incremented;
    }

    public void EfficiencyUpgrade()
    {
        // efficiency adds to the amount you get per click
        if((money - efficiencyUpgradeCost) < 0) // ensure that amount of money won't go under 0
        {
            return;
        }
        else // raise the incremented amount, subtract from money, then raise the cost by double, prices eventually get crazy out of hand, but hey! Capitalism.
        {
            incremented++;
            money -= efficiencyUpgradeCost;
            efficiencyUpgradeCost *= 2;
        }
    }

    public void Tick() // this is the function called in update that allows for the investors to bring money in every second.
    {
        money += investorIncome;
    }

    public void InvestorUpgrade() // the investor upgrade button.
    {
        if ((money - investorUpgradeCost) < 0) // ensure that amount of money won't go under 0, the same as above.
        {
            return;
        }
        else // raise the amount investors pull in, subtract from the players money pool and double the cost.
        {
            investorIncome++;
            money -= investorUpgradeCost;
            investorUpgradeCost *= 2;
        }
    }

    private void OnGUI()
    {
        // label for how much money you have.
        GUI.Label(new Rect(Screen.width * 0.05f ,Screen.height * 0.6f, 150, 20),"current funds = " + money);


        if (investorButton.activeInHierarchy == true)
        {
            // label for the cost of the investor upgrade
            GUI.Label(new Rect(Screen.width * 0.43f, Screen.height * 0.25f, 150, 20), investorUpgradeCost.ToString());
        }
        // label for cost of the efficiency upgrade
        GUI.Label(new Rect(Screen.width * 0.425f, Screen.height * 0.1f, 150, 20), efficiencyUpgradeCost.ToString());

    }
}
