using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TreeTournament : TournamentAbstract,ITournament {

    int currentTournamentDay = 0;
    Block tree;

    public TreeTournament(Division div) : base(div)
    {
        tree = new Block(div.GetPlayers(),0,div);
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
        tree.Battle();
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
    class Block : IBlock
    {
        IBlock _left;
        IBlock _right;
        int _depth;
        IBlock winner;
        Division _div;

        public Block(List<IPlayer> blocks, int depth,Division div)
        {
            _div = div;
            _depth = depth;
            if (blocks.Count > 2)
            {
                _left = new Block(blocks.GetRange(0, blocks.Count / 2), depth++,div);
                _right = new Block(blocks.GetRange(blocks.Count / 2, blocks.Count / 2), depth++,div);
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
            IPlayer win = _div.FindWinner(_left.GetWinner(), _right.GetWinner());
            if (win == _left.GetWinner())
                winner = _left;
            else if (win == _right.GetWinner())
                winner = _right;
            else
                throw new Exception("Something went wrong, no winner found, bad checks");
            _div.Victory(win);
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
