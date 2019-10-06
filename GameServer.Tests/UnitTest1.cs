using System;
using Xunit;
using GameServer.Models;

namespace GameServer.Tests
{
    public class GameBoardTest
    {
        [Fact]
        public void gameBoardUnitDimensions()
        {
            GameBoard<int> board = new GameBoard<int>(1,1);
            Assert.Equal(1, board.getArea());
            Assert.Equal(1, board.Width);
            Assert.Equal(1, board.Height);
        }

        [Fact]
        public void gameBoardNonTrivialDimensions()
        {
            GameBoard<int> board = new GameBoard<int>(2, 3);
            Assert.Equal(6, board.getArea());
            Assert.Equal(2, board.Width);
            Assert.Equal(3, board.Height);
        }

        [Fact]
        public void setItemInCell()
        {
            GameBoard<char> board = new GameBoard<char>(3, 4);
            board.set(1, 1, 'o');
            Assert.Equal('o', board.get(1, 1));
            board.set(0, 0, 'x');
            Assert.Equal('x', board.get(0, 0));
        }

        [Fact]
        public void setItemInCellOutOfRange()
        {
            GameBoard<char> board = new GameBoard<char>(3, 4);
            Assert.Throws<IndexOutOfRangeException>(() => board.set(-1, 0, 'f'));
            Assert.Throws<IndexOutOfRangeException>(() => board.set(3, 1, 'l'));
            Assert.Throws<IndexOutOfRangeException>(() => board.set(1, 4, 'l'));
            Assert.Throws<IndexOutOfRangeException>(() => board.set(1, -1, 'l'));
            board.set(2, 3, 'r');
        }

        [Fact]
        public void getBoardToString()
        {
            GameBoard<char> board = new GameBoard<char>(2, 2);
            Assert.Equal("[[\0,\0],[\0,\0]]", board.ToString());

            GameBoard<int> boardInt = new GameBoard<int>(2, 2);
            Assert.Equal("[[0,0],[0,0]]", boardInt.ToString());

            boardInt.set(1, 1, 9);
            boardInt.set(0, 0, 1);
            boardInt.set(0, 1, 2);
            boardInt.set(1, 0, 3);
            Assert.Equal("[[1,3],[2,9]]", boardInt.ToString());

            GameBoard<int> complexBoard = new GameBoard<int>(2, 5);
            complexBoard.set(0, 0, 1);
            complexBoard.set(0, 1, 2);
            complexBoard.set(1, 0, 3);
            complexBoard.set(1, 1, 4);
            complexBoard.set(1, 4, 587);
            
            Assert.Equal("[[1,3],[2,4],[0,0],[0,0],[0,587]]", complexBoard.ToString());

        }
    }
}
