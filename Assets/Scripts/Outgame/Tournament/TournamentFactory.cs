using UnityEngine;
using System.Collections;

public class TournamentFactory {

	public ITournament CreateTournament(Division info)
    {
        return new TreeTournament(info);
    }
}
