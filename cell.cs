using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DNA_Sequence_Alignment_Using_Dynamic_Programming_
{

    
    class Cell
    {
        private Cell Prevoius_Cell;
        private List<Cell> PreviousCells = new List<Cell>();
        private int row;
        private int Column;
        private int Score;
        private PrevcellType PCType;
        public Cell()
        {


        }
        public Cell(int row, int Col)
        {
            this.Column = Col;
            this.row = row;

        }
        public enum PrevcellType { Left, Above, Diagonal };
        public Cell(int row, int Col, int sco)
        {
            this.Column = Col;
            this.row = row;
            this.Score = sco;

        }
        public Cell(int row, int Col, int sco, Cell Prev)
        {
            this.Column = Col;
            this.row = row;
            this.Score = sco;
            this.Prevoius_Cell = Prev;

        }
        public Cell(int row, int Col, int sco, Cell Prev, PrevcellType PType)
        {
            this.Column = Col;
            this.row = row;
            this.Score = sco;
            this.Prevoius_Cell = Prev;
            this.PCType = PType;

        }
        public Cell CellPointer
        {
            set { this.Prevoius_Cell = value; }
            get { return this.Prevoius_Cell; }

        }
        public List<Cell> PrevCellPointer
        {
            set { this.PreviousCells = value; }
            get { return this.PreviousCells; }

        }
        public Cell this[int index]
        {
            set { this.PreviousCells[index] = value; }

            get { return this.PreviousCells[index]; }
        }
        public int CellScore
        {
            set { this.Score = value; }
            get { return this.Score; }

        }
        public int CellRow
        {
            set { this.row = value; }
            get { return this.row; }

        }
        public int CellColumn
        {
            set { this.Column = value; }
            get { return this.Column; }

        }
        public PrevcellType Type
        {
            set { this.PCType = value; }
            get { return this.PCType; }

        }
    }
}
