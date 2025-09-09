using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

using System;

class RecipeApp
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Welcome to the Student Recipe Generator ===\n");

        // Step 1: Choose input method
        Console.WriteLine("How would you like to provide input?");
        Console.WriteLine("1. Type ingredients manually");
        Console.WriteLine("2. Send a picture of ingredients (simulate by typing ingredient names)");
        Console.WriteLine("3. Enter your budget to get recipe suggestions");
        Console.Write("Choose 1, 2, or 3: ");
        string choice = Console.ReadLine();

        string[] ingredients = null;
        decimal budget = 0;

        if (choice == "1" || choice == "2")
        {
            Console.WriteLine("\nEnter ingredients separated by commas:");
            string input = Console.ReadLine();
            ingredients = input.Split(',', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < ingredients.Length; i++)
            {
                ingredients[i] = ingredients[i].Trim();
            }

            DisplayRecipesFromIngredients(ingredients);
        }
        else if (choice == "3")
        {
            bool validBudget = false;
            while (!validBudget)
            {
                Console.Write("\nEnter your budget in $: ");
                string budgetInput = Console.ReadLine();
                if (decimal.TryParse(budgetInput, out budget) && budget >= 0)
                {
                    validBudget = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid positive number.");
                }
            }

            DisplayRecipesFromBudget(budget);
        }
        else
        {
            Console.WriteLine("Invalid choice. Exiting program.");
            return;
        }

        Console.WriteLine("\n=== Thank you for using the Student Recipe Generator! ===");
    }

    // Mock AI: generate multiple recipes based on ingredients
    static void DisplayRecipesFromIngredients(string[] ingredients)
    {
        Console.WriteLine("\nHere are some recipe options based on your ingredients:\n");

        for (int i = 1; i <= 3; i++)
        {
            string recipe = $"Recipe Option {i}:\n";
            recipe += "- Ingredients: " + string.Join(", ", ingredients) + "\n";
            recipe += "- Steps:\n";
            recipe += $"  1. Mix the ingredients creatively for option {i}.\n";
            recipe += $"  2. Cook as needed for option {i}.\n";
            recipe += $"  3. Serve and enjoy!\n";
            Console.WriteLine(recipe);
        }

        Console.Write("Pick a recipe number (1-3): ");
        string pick = Console.ReadLine();
        Console.WriteLine($"\nYou selected Recipe Option {pick}!");
    }

    // Mock AI: generate multiple recipes based on budget
    static void DisplayRecipesFromBudget(decimal budget)
    {
        Console.WriteLine($"\nHere are some recipes suitable for a budget of ${budget}:\n");

        for (int i = 1; i <= 3; i++)
        {
            string recipe = $"Recipe Option {i}:\n";
            recipe += "- Ingredients: Ingredient A, Ingredient B, Ingredient C\n";
            recipe += "- Estimated Cost: $" + (budget / 3 * i).ToString("0.00") + "\n";
            recipe += "- Steps:\n";
            recipe += $"  1. Prepare the ingredients for option {i}.\n";
            recipe += $"  2. Cook appropriately.\n";
            recipe += $"  3. Serve and enjoy!\n";
            Console.WriteLine(recipe);
        }

        Console.Write("Pick a recipe number (1-3): ");
        string pick = Console.ReadLine();
        Console.WriteLine($"\nYou selected Recipe Option {pick}!");
    }
}
