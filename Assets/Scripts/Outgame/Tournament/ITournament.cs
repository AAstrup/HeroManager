using UnityEngine;
using System.Collections;

public interface ITournament
{
    bool IsDone();
    int GetTotalDays();
    int GetCurrentDay();
    void IncreaseDay();
}
