using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J2Controller : ApiController
    {
        /// <summary>
        /// Receives two input m and n representing sides of 2 dice to determine number of ways to obtain the value 10 by rolling the dices.
        /// </summary>
        /// <param name="m">Integer representing the number of sides on the first die</param>
        /// <param name="n">Integer representing the number of sides on the second die</param>
        /// <returns>String message with the total number of ways the sum 10 can be obtained when both the dice are rolled</returns>
        /// <example>
        ///     GET : /api/J2/DiceGame/6/8 => There are 5 total ways to get the sum 10.
        ///     GET : /api/J2/DiceGame/12/4 => There are 4 ways to get the sum 10.
        ///     GET : /api/J2/DiceGame/3/3 => There are 0 ways to get the sum 10.
        ///     GET : /api/J2/Dicegame/5/5 => There is 1 way to get the sum 10.
        /// </example>
        [Route("api/J2/DiceGame/{m}/{n}")]
        [HttpGet]
        public string DiceGame(int m, int n)
        {
            int value = 10;
            int count = 0;
            //nested loop to go through all values of dice
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if ((i + j) == value)
                    {
                        count++;
                    }
                }
            }
            if (count == 1)
            {
                return "There is " + count + " way to get the sum " + value + ".";
            }
            else
            {
                return "There are " + count + " ways to get the sum " + value + ".";
            }
        }
    }
}
