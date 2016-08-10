using UnityEngine;
using System.Collections;

public interface IBattle
{
    IPlayer FindWinner(IPlayer player1, IPlayer player2);
}
