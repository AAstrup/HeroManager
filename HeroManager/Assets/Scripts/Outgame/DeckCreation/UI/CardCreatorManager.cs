using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class CardCreatorManager : MonoBehaviour {
    
    //Data structure
    CardBase cardBase;
    public GameObject container;
    CardTypeDropDown GeneralCardTypeDropdown;
    CardBaseVisualizer cardVisualizer;
    ManaDropDownsHandler manaDropDownsHandler;
    CardSaveLoader cardSaveLoader;
    CardBalancer cardBalancer;

    //Injected
    UnityAdapter _adapter;

    //Injected from unity.
    public GameObject CardPrefab;
    public InputField nameInputField;
    public InputField flavourInputField;
    public Dropdown CardTypeDropDown;
    public Dropdown CreatureTypeDropDown;
    public Dropdown Stat1TypeDropDown;
    public Dropdown Stat2TypeDropDown;

    public Dropdown[] crystalsDropDowns;

    public void Initialize(UnityAdapter adapter)
    {
        _adapter = adapter;
        Activate();
        SetupCardPrefab();
        cardSaveLoader = new CardSaveLoader();
        cardBalancer = new CardBalancer();

        //Setting up name subscription
        nameInputField.onValueChanged.AddListener(delegate { cardBase.SetName(nameInputField.text); });
        nameInputField.onValueChanged.AddListener(delegate { cardVisualizer.SetTitle(nameInputField.text); });

        //Setting up name subscription
        flavourInputField.onValueChanged.AddListener(delegate { cardBase.SetFlavourText(nameInputField.text); });

        //Setting up cardinfo (cardType,creatureType,attack,dmg)
        GeneralCardTypeDropdown = new CardTypeDropDown(CardTypeDropDown, CreatureTypeDropDown, Stat1TypeDropDown,Stat2TypeDropDown);

        CardTypeDropDown.onValueChanged.AddListener(delegate {
            cardBase.SetCardType(CardTypeDropDown);
            cardBalancer.BalanceCard(cardBase);
            cardVisualizer.Visualize(cardBase, true);
        });
        CreatureTypeDropDown.onValueChanged.AddListener(delegate {
            cardBase.SetCreatureType(CreatureTypeDropDown);
            cardBalancer.BalanceCard(cardBase);
            cardVisualizer.SetType(CreatureTypeDropDown.options[CreatureTypeDropDown.value].text.ToString());
            cardVisualizer.Visualize(cardBase, true);
        });
        Stat1TypeDropDown.onValueChanged.AddListener(delegate {
            cardBase.SetStat1(Stat1TypeDropDown);
            cardBalancer.BalanceCard(cardBase);
            cardVisualizer.SetStat1Text(Stat1TypeDropDown.options[Stat1TypeDropDown.value].text.ToString());
            cardVisualizer.Visualize(cardBase, true);
        });
        Stat2TypeDropDown.onValueChanged.AddListener(delegate {
            cardBase.SetStat2(Stat2TypeDropDown);
            cardBalancer.BalanceCard(cardBase);
            cardVisualizer.SetStat2Text(Stat2TypeDropDown.options[Stat2TypeDropDown.value].text.ToString());
            cardVisualizer.Visualize(cardBase, true);
        });

        //Setting up mana crystals
        manaDropDownsHandler = new ManaDropDownsHandler(crystalsDropDowns);

        for (int i = 0; i < 3; i++)
        {
            int nr = i;
            var CrystalType = crystalsDropDowns[i * 2];
            CrystalType.onValueChanged.AddListener(delegate {
                cardBase.SetCrystalType(nr, CrystalType);
                cardBalancer.BalanceCard(cardBase);
                cardVisualizer.Visualize(cardBase, true);
                manaDropDownsHandler.GetCrystalHandler(nr).dropType.SelectValue(CrystalType.value);
            });

            int inputAmount = (i * 2) + 1;
            var CrystalAmount = crystalsDropDowns[i * 2 + 1];
            CrystalAmount.onValueChanged.AddListener(delegate {
                cardBase.SetCrystalAmount(nr, CrystalAmount);
                cardBalancer.BalanceCard(cardBase);
                cardVisualizer.Visualize(cardBase, true);
                manaDropDownsHandler.GetCrystalHandler(nr).dropAmount.SelectValue(CrystalAmount.value);
            });
        }

        //At the end
        cardVisualizer.Visualize(cardBase,true);
    }

    private void SetupCardPrefab()
    {
        cardVisualizer = new CardBaseVisualizer(_adapter.Ref.librariesContainer, CardPrefab);
    }

    public void Activate()
    {
        container.SetActive(true);
        cardBase = new CardBase();

    }

    public void End()
    {
        container.SetActive(false);
    }

    public void SaveCard()
    {
        cardSaveLoader.Save(cardBase);
        //Restart();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
