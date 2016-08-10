﻿using UnityEngine;
using System.Collections.Generic;

public interface IReferences
{
    void EndSeason();
    void Initialize();
    List<Division> GetDivisions();
    IPlayer GetHumanPlayer();
    void Print(string v);
}
