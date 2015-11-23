﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Thepagedot.Tools
{
    public static class Randomizer
    {
        private static readonly Random Rand = new Random();

        /// <summary>
        /// Shuffles the entries of a list randomly.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">List to shuffle</param>
        public static void Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = Rand.Next(n + 1);
                T value = list[k];

                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
