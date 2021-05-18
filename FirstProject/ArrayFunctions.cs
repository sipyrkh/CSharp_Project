using System;
namespace FirstProject
{
    public class ArrayFunctions
    {
        public static string[] GetUniqueArray(string[] firstMass, string[] secondMass)
        {
            string[] massResult = new string[firstMass.Length];
            int count = 0;
            for (int i = 0; i < firstMass.Length; i++)
            {
                bool flag = true;
                for (int j = 0; j < secondMass.Length; j++)
                {
                    if (firstMass[i].Equals(secondMass[j]))
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    massResult[count] = firstMass[i];
                    count++;
                }
            }

            if (count == firstMass.Length)
            {
                return massResult;
            }
            else
            {
                var newMassResult = new string[count];
                for (int i = 0; i < count; i++)
                {
                    newMassResult[i] = massResult[i];
                }
                return newMassResult;
            }
        }
    }
}
