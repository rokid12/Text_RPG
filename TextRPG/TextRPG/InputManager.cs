using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    internal class InputManager
    {
        public static int PickNumber(int max, int min) // max와 min에 정수 범위를 넣어주세요.
        {

            while (true)
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int selectNumber))
                {
                    if (selectNumber <= max && selectNumber >= min)
                    {
                        return selectNumber;
                    }
                }
                Console.WriteLine("\n잘못된 입력입니다.");
            }
        }
    }
}
