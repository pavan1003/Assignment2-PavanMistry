using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class J1Controller : ApiController
    {
        /// <summary>
        /// Each food item is selected by entering a digit choice. Based on the choices the program will compute the total calories of the meal.
        /// </summary>
        /// <param name="burger">Integer representing the choice of burger </param>
        /// <param name="drink">Integer representing the choice of drink </param>
        /// <param name="side">Integer representing the choice of side order </param>
        /// <param name="dessert">Integer representing the choice of dessert </param>
        /// <returns>String message with the total calories of the meal</returns>
        /// <example>
        ///     Get: /api/J1/Menu/4/4/4/ =>Your total calorie count is 0
        ///     GET: /api/J1/Menu/1/2/3/4 =>Your total calorie count is 691
        /// </example>

        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        [HttpGet]
        public string Menu(int burger, int drink, int side, int dessert)
        {
            List<int> burgerCalories = new List<int> { 461, 431, 420, 0 };
            List<int> drinkCalories = new List<int> { 130, 160, 118, 0 };
            List<int> sideCalories = new List<int> { 100, 57, 70, 0 };
            List<int> dessertCalories = new List<int> { 167, 266, 75, 0 };

            if (burger > 0 && burger < 5 && drink > 0 && drink < 5 && side > 0 && side < 5 && dessert > 0 && dessert < 5)
            {

                int totalcal = burgerCalories[burger - 1] + drinkCalories[drink - 1] + sideCalories[side - 1] + dessertCalories[dessert - 1];
                return "Your total calorie count is " + totalcal;
            }
            return "Kindly choose the correct menu items";
        }
    }
}
