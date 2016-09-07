using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TreeTournament : TournamentAbstract,ITournament
{

    private References _references;
    int currentTournamentDay = 0;
    Block tree;

    public List<BattleInfo> battleInfo;
    int currentBattle; 

    public TreeTournament(References references,Division div) : base(div)
    {
        _references = references;
        battleInfo = new List<BattleInfo>();
        tree = new Block(_references, div.GetPlayers(), 0, div, this);
    }

    public int GetCurrentDay()
    {
        return currentTournamentDay;
    }

    public bool IsDone()
    {
        return tree.HasBattled();
    }

    public void IncreaseDay()
    {
        currentTournamentDay++;
        battleInfo = new List<BattleInfo>();
        currentBattle = 0;
        tree.Battle();
        Battle();
    }

    public void BattleFinished()
    {
        currentBattle++;
        Battle();
    }
    public void Battle()
    {
        if(battleInfo.Count > currentBattle)
        {
            battleInfo[currentBattle].battle.FindWinner(battleInfo[currentBattle]);
        }
    }

    public int GetTotalDays()
    {
        return _div.GetPlayersInDivision() / 2;
    }

    interface IBlock
    {
        void Battle();
        bool HasBattled();
        IPlayer GetWinner();
    }
    public class Block : IBlock
    {
        private References _references;
        IBlock _left;
        IBlock _right;
        int _depth;
        IBlock winner;
        Division _div;
        TreeTournament _tournament;

        public Block(References references,List<IPlayer> blocks, int depth,Division div, TreeTournament tournament)
        {
            _references = references;
            _tournament = tournament;
            _div = div;
            _depth = depth;
            if (blocks.Count > 2)
            {
                _left = new Block(_references,blocks.GetRange(0, blocks.Count / 2), depth++, div, _tournament);
                _right = new Block(_references,blocks.GetRange(blocks.Count / 2, blocks.Count / 2), depth++, div, _tournament);
            }
            else if (blocks.Count == 2)
            {
                _left = new Leaf(blocks[0]);
                _right = new Leaf(blocks[1]);
            }
            else
                throw new Exception("Amount of players not dividable with 2");
        }

        public void Battle()
        {
            if (!_left.HasBattled())
            {
                _left.Battle();
                _right.Battle();
            }
            else
                FindWinner();
        }

        void FindWinner()
        {
            _tournament.battleInfo.Add(new BattleInfo(_references,_left.GetWinner(), _right.GetWinner(), this, _div.FindBattleType()));
        }

        public void WinnerFound(IPlayer win)
        {
            if (win == _left.GetWinner())
                winner = _left;
            else if (win == _right.GetWinner())
                winner = _right;
            else
                throw new Exception("Something went wrong, no winner found, bad checks");
            _div.Victory(win);
            _tournament.BattleFinished();
        }

        public bool HasBattled()
        {
            return winner != null;
        }

        public IPlayer GetWinner()
        {
            return winner.GetWinner();
        }
    }

    class Leaf : IBlock
    {
        IPlayer _player;
        public Leaf (IPlayer player)
        {
            _player = player;
        }

        public void Battle()
        {
            throw new NotSupportedException("This should never have been called!");
        }

        public IPlayer GetWinner()
        {
            return _player;
        }

        public bool HasBattled()
        {
            return true;
        }
    }
}
