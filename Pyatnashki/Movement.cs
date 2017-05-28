using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnashki
{
    class Movement
    {
        static public void KeyUp(int index)
        {
                int temp = Memo.GetNumber(index - 4);
                Memo.SetNumber(index - 4, Memo.GetNumber(index));
                Memo.SetNumber(index, temp);
                Memo.IntTurns();
        }

        static public void KeyDown(int index)
        {
                int temp = Memo.GetNumber(index + 4);
                Memo.SetNumber(index + 4, Memo.GetNumber(index));
                Memo.SetNumber(index, temp);
                Memo.IntTurns();
        }

        static public void KeyLeft(int index)
        {
                int temp = Memo.GetNumber(index - 1);
                Memo.SetNumber(index - 1, Memo.GetNumber(index));
                Memo.SetNumber(index, temp);
                Memo.IntTurns();
        }

        static public void KeyRight(int index)
        {
                int temp = Memo.GetNumber(index + 1);
                Memo.SetNumber(index + 1, Memo.GetNumber(index));
                Memo.SetNumber(index, temp);
                Memo.IntTurns();
        }

        static public void Check_Up()
        {
            int index = Array.IndexOf(Memo.GetNumbersArr(), 0);
            if (index > 3)
            {
                KeyUp(index);
            }
        }

        static public void Check_Down()
        {
            int index = Array.IndexOf(Memo.GetNumbersArr(), 0);
            if (index < 12)
            {
                KeyDown(index);
            }
        }

        static public void Check_Left()
        {
            int index = Array.IndexOf(Memo.GetNumbersArr(), 0);
            if (index != 0 &&
                index != 4 &&
                index != 8 &&
                index != 12)
            {
                KeyLeft(index);
            }
        }

        static public void Check_right()
        {
            int index = Array.IndexOf(Memo.GetNumbersArr(), 0);
            if (index != 3 &&
                index != 7 &&
                index != 11 &&
                index != 15)
            {
                KeyRight(index);
            }
        }
    }
}
