using System;
using System.Collections.Generic;

public class AbilityAction
{
    List<IActionProcess> processes;


    public AbilityAction(List<Cycle> cycles, CardBaseLibrary library)
    {
        IActionProcess process = new ActionProcess_DrawRandomCards(cycles,library);

    }

    public void Trigger(List<CardActive> cards, BoardState boardState)
    {


    }


}


/*class Cardinfo
{
    void GetDropdownList

}

class CardInfoInt : CardInfo
{
    List<CardInfoInt> property1Ints;
    int index;

    override void GetDropdownList
        return ints as List<string>;
    
    void SetIndex(int i){
        index = i
    }

}

*/
