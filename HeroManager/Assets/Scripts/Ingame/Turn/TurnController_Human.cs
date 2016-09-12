using System.Linq;
using UnityEngine;
using System.Collections;

public class TurnController_Human : TurnController {

    public override void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Decide(0, 0);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            EndTurn();
        }
        base.Update();
    }
}
