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
            try
            {
                Regex regex = new Regex("^[ABEKMHOPCTYX]{1}[0-9]{3}[ABEKMHOPCTYX]{2}[0-9]{3}");
                bool a = regex.IsMatch(mark);
                if (!a)
                {
                    return false;
                }
                else
                {
                    string nomer = mark.Substring(1, mark.Length - 6);
                    string kodRegion = mark.Substring(mark.Length - 3);
                    if (kodRegion == "000" || nomer == "000")
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        public static List<char> symbolsUsed = new List<char>() {'A', 'B', 'E', 'K', 'M', 'H', 'O', 'P', 'C', 'T', 'Y', 'X'};
        public static string GetNextMarkAfter(string mark) // Выдаёт следующий знак в данной серии или создает следующую серию
        {
            try
            {
                string nextMark = "";
                string nomer = mark.Substring(1, mark.Length - 6);
                if (nomer == "999")
                {
                    nomer = "001";
                    string seria = "" + mark[0] + mark[4] + mark[5];
                    if (seria[2] != symbolsUsed[symbolsUsed.Count - 1])
                    {
                        int indexSymbol = -1;
                        for (int i = 0; i < symbolsUsed.Count; i++)
                        {
                            if (symbolsUsed[i] == seria[2])
                            {
                                indexSymbol = i;
                            }
                        }
                        nextMark = "" + seria[2] + nomer + seria[1] + symbolsUsed[indexSymbol + 1] + mark[mark.Length - 3] + mark[mark.Length - 2] + mark[mark.Length - 1];
                    }
                    else
                    {
                        if (seria[0] != symbolsUsed[symbolsUsed.Count - 1])
                        {
                            int indexSymbol = -1;
                            for (int i = 0; i < symbolsUsed.Count; i++)
                            {
                                if (symbolsUsed[i] == seria[0])
                                {
                                    indexSymbol = i;
                                }
                            }
                            nextMark = "" + symbolsUsed[indexSymbol + 1] + nomer + seria[1] + symbolsUsed[0] + mark[mark.Length - 3] + mark[mark.Length - 2] + mark[mark.Length - 1];
                        }
                        else
                        {
                            if (seria[1] != symbolsUsed[symbolsUsed.Count - 1])
                            {
                                int indexSymbol = -1;
                                for (int i = 0; i < symbolsUsed.Count; i++)
                                {
                                    if (symbolsUsed[i] == seria[1])
                                    {
                                        indexSymbol = i;
                                    }
                                }
                                nextMark = "" + symbolsUsed[0] + nomer + symbolsUsed[indexSymbol + 1] + symbolsUsed[0] + mark[mark.Length - 3] + mark[mark.Length - 2] + mark[mark.Length - 1];
                            }
                            else
                            {
                                nextMark = "error";
                            }
                        }
                    }
                }
                else
                {
                    nomer = string.Format("{0:D3}", Convert.ToInt32(nomer) + 1);
                    int j = 0;
                    for (int i = 0; i < mark.Length; i++)
                    {
                        if (i == 1 || i == 2 || i == 3)
                        {
                            nextMark += nomer[j];
                            j++;
                        }
                        else
                        {
                            nextMark += mark[i];
                        }
                    }
                }
                return nextMark;
            }
            catch
            {
                return "error";
            }
        }
        public static string GetNextMarkAfterInRange(string prevMark, string rangeStart, string rangeEnd) // Выдаёт следующий номер
        {
            try
            {
                string kodRegion = prevMark.Substring(prevMark.Length - 3);
                string kodRegionStart = rangeStart.Substring(rangeStart.Length - 3);
                string kodRegionEnd = rangeEnd.Substring(rangeEnd.Length - 3);
                if (kodRegionStart != kodRegionEnd || kodRegionStart != kodRegion)
                {
                    return "out of stock";
                }
                bool a = false; // Входит ли данное число в диапозон
                string mark = rangeStart;
                while (mark != rangeEnd)
                {
                    if (mark == prevMark)
                    {
                        a = true;
                        break;
                    }
                    mark = GetNextMarkAfter(mark);
                }
                if (mark == prevMark)
                {
                    a = true;
                }
                string nextMark = prevMark;
                if (a == true)
                {
                    if (nextMark != rangeEnd)
                    {
                        nextMark = GetNextMarkAfter(nextMark);
                    }
                    else
                    {
                        return "out of stock";
                    }
                }
                else
                {
                    return "out of stock";
                }
                return nextMark;
            }
            catch
            {
                return "out of stock";
            }
        }
        public static int GetCombinationsCountInRange(string mark1, string mark2) // Расчёт оставшихся свободных номеров для региона
        {
            try
            {
                string kodRegion1 = mark1.Substring(mark1.Length - 3);
                string kodRegion2 = mark1.Substring(mark1.Length - 3);
                if (kodRegion1 != kodRegion2)
                {
                    return 0;
                }
                int count = 0;
                string nextMark = mark1;
                count++;
                while (nextMark != mark2)
                {
                    nextMark = GetNextMarkAfter(nextMark);
                    count++;
                }
                return count;
            }
            catch
            {
                return 0;
            }
        }
    }
}