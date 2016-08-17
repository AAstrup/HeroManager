using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardCreatorManager : MonoBehaviour {

    //Data structure
    CardBase cardBase;
    public GameObject container;
    CardTypeDropDown GeneralCardTypeDropdown;

    //Injected from unity.
    public InputField nameInputField;
    public InputField flavourInputField;
    public Dropdown CardTypeDropDown;
    public Dropdown CreatureTypeDropDown;
    public Dropdown Stat1TypeDropDown;
    public Dropdown Stat2TypeDropDown;

    void Start()
    {
        Activate();

        //Setting up name subscription
        var seName = new InputField.SubmitEvent();
        seName.AddListener(cardBase.SetName);
        nameInputField.onEndEdit = seName;

        //Setting up name subscription
        var seFlavour = new InputField.SubmitEvent();
        seFlavour.AddListener(cardBase.SetFlavourText);
        nameInputField.onEndEdit = seFlavour;

        //Setting up cardinfo (cardType,creatureType,attack,dmg)
        GeneralCardTypeDropdown = new CardTypeDropDown(CardTypeDropDown, CreatureTypeDropDown, Stat1TypeDropDown,Stat2TypeDropDown);

        CardTypeDropDown.onValueChanged.AddListener(delegate {
            cardBase.SetCardType(CardTypeDropDown);
        });
        CreatureTypeDropDown.onValueChanged.AddListener(delegate {
            cardBase.SetCreatureType(CreatureTypeDropDown);
        });
        Stat1TypeDropDown.onValueChanged.AddListener(delegate {
            cardBase.SetStat1(Stat1TypeDropDown);
        });
        Stat2TypeDropDown.onValueChanged.AddListener(delegate {
            cardBase.SetStat2(Stat2TypeDropDown);
        });


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

}
