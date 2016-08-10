using UnityEngine;
using System.Collections;

public interface IBoardCondition  {

    bool Legal(BoardState boardState);
}
