using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestAPI.Services.LuhnAlgorithm
{
    public class checkDigit
    {
        public static int CalLuhnCheckDigit(string imei)
        {
            int checkDigit = 0;
            int addValue = 0;
            for (int i = 0; i < imei.Length; i++)
            {
                if (i % 2 == 0)
                {
                    int result = Convert.ToInt32(imei[imei.Length - i - 1].ToString()) * 2;
                    if (result > 9)
                    {
                        addValue += (result - 9);
                    }
                    else
                    {
                        addValue += result;
                    }
                }
                else
                {
                    addValue += Convert.ToInt32(imei[imei.Length - i - 1].ToString());
                }
            }

            if (addValue % 10 == 0)
            {
                checkDigit = 0;
            }
            else
            {
                checkDigit = 10 - addValue % 10;
            }
            return checkDigit;
        }
    }
}