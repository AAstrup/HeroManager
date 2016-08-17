using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class UIManager : MonoBehaviour {

    public UnityAdapter adapter;

    public Text headerText;
    public GameObject prefabPlayerContainer;
    public GameObject ContainerForAllPlayers;
    public List<GameObject> containers = new List<GameObject>();

    public Sprite humanSprite;
    public Sprite aiSprite;

    void Start() {
        adapter.Ref.leagueHandler.dayHandler.OnNewPlayerDay += ShowDivision;
        //DayHandler.OnNewPlayerDay += ShowDivision;
        //adapter.Ref.dayHandler.OnNewPlayerDay
    }

    public void ShowTournament(ITournament tournament)
    {
        throw new NotImplementedException();
    }

    public void ShowDivision(Division div)
    {
        headerText.text = "Division " + div.GetDivisionNr();

        var players = div.GetPlayers();

        foreach (var container in containers)
        {
            Destroy(container);
        }
        containers = new List<GameObject>();

        foreach (var player in players)
        {
            GameObject playerContainer = (GameObject)Instantiate(prefabPlayerContainer, transform.position, Quaternion.identity);
            playerContainer.transform.SetParent(ContainerForAllPlayers.transform,false);
            containers.Add(playerContainer);

            var script = playerContainer.GetComponent<PlayerContainerScript>();
            script.SetValues(player,this);
        }
    }

    internal Sprite GetSprite(IPlayer player)
    {
        if (player.IsHuman())
            return humanSprite;
        else
            return aiSprite;
    }
}
