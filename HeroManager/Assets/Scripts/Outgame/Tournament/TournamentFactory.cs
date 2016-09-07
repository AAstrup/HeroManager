using UnityEngine;
using System.Collections;

public class TournamentFactory {

	public ITournament CreateTournament(References references,Division info)
    {
        return new TreeTournament(references,info);
    }
}
