using System;
using System.Security.Cryptography;

namespace Minesweeper
{
    internal class KRandomNumber
    {
        /// <summary>
        /// Matthew Knox's random number class using the cryptography librarys.
        /// Generates proper random numbers as opposed to those unhunks of crap
        /// that microsoft provides by default.
        /// Copyright © Matthew Knox. All rights reserved.
        /// </summary>

        // Array to store the crypto numbers
        public byte[] RandomArray = { 0x0 };
        // Maximum and minimum numbers of generation
        private readonly int _maxnum, _minnum;
        // Required iteration variable to prevent number reuse
        private int _iterator;

        /// <summary>
        /// New Random Number Class
        /// Has a max value of 255 and min of 1
        /// </summary>
        public KRandomNumber()
        {
            _maxnum = 255;
            _minnum = 1;
            _iterator = RandomArray.Length;
        }

        /// <summary>
        /// New Random Number Class
        /// </summary>
        /// <param name="min">No less than 1</param>
        /// <param name="max">No more than 255</param>
        public KRandomNumber(int min, int max)
        {
            _maxnum = max;
            _minnum = min;
            _iterator = RandomArray.Length;
        }

        /// <summary>
        /// Generates a new random integer between the input bounds
        /// </summary>
        /// <returns>Random Int32</returns>
        public int Next()
        {
            int num; // result number storage variable
            do // do while as this allows checking post number generation
            {
                EndOfArray();
                num = Convert.ToInt32(RandomArray[_iterator]);
                _iterator++;
            } while (num > _maxnum || num < _minnum);
            return num;
        }

        /// <summary>
        /// Detects if a new array is required and takes appropriate action
        /// </summary>
        private void EndOfArray()
        {
            if (_iterator != RandomArray.Length) return;
            NewArray();
        }

        /// <summary>
        /// Generates a new array using the crypto classes
        /// </summary>
        public void NewArray()
        {
            _iterator = 0;
            RandomNumberGenerator.Create().GetNonZeroBytes(RandomArray);
        }
    }
}
