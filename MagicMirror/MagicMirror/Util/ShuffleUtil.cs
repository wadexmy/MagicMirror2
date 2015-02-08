using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicMirror.Util
{
    class ShuffleUtil
    {
        public static T[] Shuffle<T>(T[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                int idx = random.Next(i, array.Length);

                T tmp = array[i];
                array[i] = array[idx];
                array[idx] = tmp;
            }
            return array;
        }
    }
}
