using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monogamer.classes
{
    public class functions
    {

        public T[] AddElementToArray<T>(T[] originalArray, T newElement)
        {
            T[] newArray = new T[originalArray.Length + 1];
            for (int i = 0; i < originalArray.Length; i++)
            {
                newArray[i] = originalArray[i];
            }
            newArray[originalArray.Length] = newElement;
            return newArray;
        }


    }
}
