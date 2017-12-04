using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningGame
{
    class Map
    {
        #region Const
        private const int SmallRockNumber = 1;

        private const int EarthNumber = 0;
        #endregion

        #region Map size
        /// <summary>
        /// Map Width 
        /// </summary>
        public const int Width = 30;
        /// <summary>
        /// Map Height
        /// </summary>
        public const int Height = 6;
        #endregion

        #region Public properties
        /// <summary>
        /// Map view
        /// </summary>
        public char[,] View { get; set; }
        /// <summary>
        /// Viewable patterns
        /// </summary>
        public List<char[,]> Patterns { get; set; }

        #region Char Constant
        /// <summary>
        /// Earth symbol
        /// </summary>
        public char[,] Earth = { { ' ' }, { ' ' }, { ' ' }, { ' ' }, { ' ' }, { '#' } };
        /// <summary>
        /// Rock view
        /// </summary>
        public char[,] SmallRock = { { ' ' }, { ' ' }, { ' ' }, { ' ' }, { '#' }, { '#' } };
        #endregion

        #endregion

        #region Default constructor
        public Map()
        {
            Patterns = new List<char[,]> { Earth, SmallRock };
            View = new char[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {

                    View[i, j] = Earth[i, 0];  
                }
            }
        }
        #endregion
        private bool canPutRock;
        private Random r = new Random();
        public void Generate()
        {
            var newView = new char[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width - 1; j++)
                {
                    newView[i, j] = View[i, j + 1];
                }                                
            }
            var randomValue = r.Next() % Patterns.Count;
            if (randomValue == SmallRockNumber)
            {
                if (!canPutRock)
                {
                    randomValue = EarthNumber;
                    canPutRock = true;
                }
                else
                {
                    canPutRock = false;
                }
            }
            

            for (int i = 0; i < Height; i++)
            {
                newView[i, Width - 1] = Patterns[randomValue][i, 0];
            }
            View = newView;
        }

    }
}
