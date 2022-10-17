﻿using Gomoku.Domain.Chains;
using System.Collections.Generic;

namespace Gomoku.Domain.Players
{
    public interface IPlayer1 : IPlayer { }
    public class Player1 : IPlayer1
    {
        public IList<IChain> Placements { get; }

        public Player1(IHorizontalChain horizontal, IVerticalChain vertical
            , IForwardDiagonalChain forwardDiagonal, IBackwardDiagonalChain backwardDiagonal)
        {
            Placements = new List<IChain>
            {
                horizontal,
                vertical,
                forwardDiagonal,
                backwardDiagonal
            };
        }

        public void Clear()
        {
            foreach (var chain in Placements)  chain.Clear();
        }
    }
}