using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class PlayerContainerScript : MonoBehaviour {

    public Image img;
    public Text playerName;
    public Text playerPoints;

    public void SetValues(IPlayer player,UIManager manager)
    {
        playerName.text = player.GetName();
        playerPoints.text = player.GetPoints().ToString();
        img.sprite = manager.GetSprite(player);
    }
}
