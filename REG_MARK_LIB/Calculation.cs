using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace REG_MARK_LIB
{
    public class Calculation
    {
        public static bool CheckMark(string mark) // Проверяет правильность номерного знака 
        {
            Regex regex = new Regex("^[ABEKMHOPCTYX]{1}[0-9]{3}[ABEKMHOPCTYX]{2}[0-9]{3}");
            bool a = regex.IsMatch(mark);
            if(!a)
            {
                return false;
            }
            else
            {
                string kodRegion = mark.Substring(mark.Length - 3);
                if(kodRegion == "000")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        public static string GetNextMarkAfter(string mark) // Выдаёт следующий знак в данной серии или создает следующую серию
        {
            string nomer = mark.Substring(1, mark.Length - 3);
            if(nomer == "999")
            {

            }
            return "";
        }
        public static string GetNextMarkAfterInRange(string prevMark, string rangeStart, string rangeEnd) // Выдаёт следующий номер
        {

            return "";
        }
        public static int GetCombinationsCountInRange(string mark1, String mark2) // Расчёт оставшихся свободных номеров для региона
        {
            return 354;
        }
    }
}
