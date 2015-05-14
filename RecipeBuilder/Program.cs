using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeBuilder
{
    public class Program
    {
        public static void Main()
        {
            //Create my ingredient
            Ingredient BrownSugar = new Ingredient();
            BrownSugar.Amount = 1.0;
            BrownSugar.Calories = 200;
            BrownSugar.Carbohydrates = 500;
            BrownSugar.Protein = 13;
            BrownSugar.Sodium = 500;
            BrownSugar.Type = "Brown Sugar";

            Ingredient Butter = new Ingredient();
            Butter.Amount = 2.0;
            Butter.Calories = 1000;
            Butter.Carbohydrates = 300;
            Butter.Protein = 26;
            Butter.Sodium = 10000;
            Butter.Type = "Lb of Butter";

            Ingredient ChocolateChips = new Ingredient();
            ChocolateChips.Amount = 3;
            ChocolateChips.Calories = 200;
            ChocolateChips.Carbohydrates = 600;
            ChocolateChips.Protein = 40;
            ChocolateChips.Sodium = 100000;
            ChocolateChips.Type = "Chocolate Chips";

            //Create a key-value storage device (in this case, a Dictionary)
            Dictionary<int, Ingredient> ingredients = new Dictionary<int, Ingredient>();

            //Add the ingredient, along with a key, to the Dictionary
            ingredients.Add(1, BrownSugar);
            ingredients.Add(2, Butter);
            ingredients.Add(3, ChocolateChips);

            //Create our recipe object and populate its properties
            Recipe ChocolateChipCookies = new Recipe();
            ChocolateChipCookies.Type = "Chocolate Chip Cookies!";
            ChocolateChipCookies.Ingredients = ingredients;
            ChocolateChipCookies.Rating = 8;
            Console.WriteLine(ChocolateChipCookies.ToString());

            Console.ReadLine();
        }
    }

    public class Recipe
    {
        public Dictionary<int, Ingredient> Ingredients { get; set; }
        public int Rating { get; set; }
        public string Type { get; set; }

        //Total the Nutritional info
        public string GetNutritionalInfo()
        {
            double caloriesTotal = 0, carbsTotal = 0, proteinTotal = 0;

            foreach (KeyValuePair<int, Ingredient> item in Ingredients)
            {
                caloriesTotal += item.Value.Calories;
                carbsTotal += item.Value.Carbohydrates;
                proteinTotal += item.Value.Protein;
            }

            string result = "\n\nCalories: " + caloriesTotal + "\nCarbs: " + carbsTotal + "\nProtein: " + proteinTotal;

            return result;
        }

        public override string ToString()
        {
            string returnVal = "Recipe for: " + Type + "\nRating: " + Rating + "\nIngredients:";

            foreach (KeyValuePair<int, Ingredient> item in Ingredients)
            {
                returnVal += "\n" + item.Value.Type + " - Amount: " + item.Value.Amount;
            }

            returnVal += GetNutritionalInfo();

            return returnVal;
        }
    }

    public class Ingredient
    {
        public double Amount { get; set; }
        public double Calories { get; set; }
        public double Carbohydrates { get; set; }
        public double Protein { get; set; }
        public double Sodium { get; set; }
        public double Sugar { get; set; }
        public string Type { get; set; }
    }
}

//1.Design and write a series of appropriate classes to model a recipe. The recipe should 
//include all ingredients needed for making the recipe, all amounts required, and basic nutritional 
//information such as calories, protein, fat, sugar, sodium. You do not have to make the nutritional 
//information accurate, you may enter your own values here. Allow the user to assign a rating to the recipe.
//2.Write a program that allows you to either create a new recipe or view existing recipes. 
//Make sure to encapsulate the appropriate functionality into functions for easy reuse, and to utilize 
//proper data types. Obviously, to view multiple recipes, you will need to store them in an array.
//3.(Bonus) Include functionality that allows the user to choose a recipe based on highest rating.