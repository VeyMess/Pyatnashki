using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnashki
{
    class Memo
    {
        static private int[] numbers;
        static private int turns;
        static private DateTime NowTime = new DateTime(0, 0);
        static private bool Invert = false;

        static public bool GetInvert()
        {
            return Invert;
        }

        static public void InvertChage(bool condition)
        {
            if (condition)
                Invert = true;
            if (!condition)
                Invert = false;
        }

        static public void ResetTime()
        {
            DateTime Reset = new DateTime(0, 0);
            NowTime = Reset;
        }

        static public void ResetTurns()
        {
            turns = 0;
        }

        static public void TimerTick()
        {
            NowTime = NowTime.AddSeconds(1);
        }

        static public string GetTime()
        {
            return NowTime.ToString("mm:ss");
        }

        static public void randMem()
        {
            Randomish.RandomNotRepeat ran2 = new Randomish.RandomNotRepeat(0, 16);
            numbers = new int[16];
            for (int i = 0; i < 16; i++)
            {
                numbers[i] = ran2.Next();
            }
        }

        static public int GetTurns()
        {
            return turns;
        }

        static public void IntTurns()
        {
            turns++;
        }

        static public int GetNumber(int index)
        {
            return numbers[index];
        }

        static public void SetNumber(int index, int newNumber)
        {
            numbers[index] = newNumber;
        }

        static public int[] GetNumbersArr()
        {
            return numbers;
        }

        static public void SetNumbersArr(int[] NewNumbersArr)
        {
            NewNumbersArr.CopyTo(numbers, 0);
        }

    }
}
