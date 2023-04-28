
using System;

class PROG_ASSIGNMENT
{
    private string[] ingredients;
    private double[] quantities;
    private int[] units;
    private string[] steps;

    public PROG_ASSIGNMENT()
    {

        ingredients = new string[0];
        quantities = new double[0];
        units = new int[0];
        steps = new string[0];
    }
    public void Enter_details()
    {
        //Add ingredient number.
        int ingredient_num;
        do
        {
            Console.Write("Enter the ingredient number: \n");
            if (int.TryParse(Console.ReadLine(), out ingredient_num))
            {
                break;
            }
            Console.Write("Invalid, please try again");
        }
        while (true);

        //Arrays for ingredient num..
        ingredients = new string[ingredient_num];
        quantities = new double[ingredient_num];
        units = new int[ingredient_num];

        // allow ingredint number.....
        for (int i = 0; i < ingredients.Length; i++)
        {
            Console.WriteLine($"Enter the ingredients #{i + 1}: ");

            //ingredient name...
            do
            {
                Console.WriteLine("Enter ingredient name:");
                ingredients[i] = Console.ReadLine();
                break;
            }
            while (true);

            //if empty
            if (ingredients[i].Length == 0)
            {
                Console.WriteLine("cannot be empty");
                ingredients[i] = Console.ReadLine();
                return;
            }

            // quanity
            quantities[i] = 0;
            bool values = false;

            while (!values)
            {
                Console.WriteLine("Enter the Quantity:");
                string Invalue = Console.ReadLine();
                if (double.TryParse(Invalue, out quantities[i]) == false)
                {
                    Console.WriteLine("the quantity must be double, try again");
                    Console.WriteLine("Enter the Quantity again");

                }
                else if (quantities[i] < 0)
                {
                    Console.WriteLine("the quantity must be double, try again");
                    Console.WriteLine("Enter the Quantity again");
                }

                else
                {
                    values = true;
                }
            }

            //meausremt
            units[i] = 0;
            do
            {
                Console.Write("Enter the measurement unit: ");
                if (int.TryParse(Console.ReadLine(), out units[i]))
                {
                    break;
                }
                Console.WriteLine("enter the correct measurement: ");

            }
            while (true);
        }

        //steps
        int steps_number;
        do
        {
            Console.WriteLine("Enter the number of steps");
            if (int.TryParse(Console.ReadLine(), out steps_number))
            {
                break;
            }
            Console.WriteLine("eNTER THE CORRECT STEP NUMBER");
        }

        while (true);

        //array for steps..
        steps = new string[steps_number];

        // allow...
        for (int a = 0; a < steps_number; a++)
        {

            Console.WriteLine($"Add the step descriptions: #{a + 1}: ");
            steps[a] = Console.ReadLine();
        }


    }
    public void DisplayRecipe()
    {
        //display the ingredient and quantities..
        Console.WriteLine("Ingredients:");
        for (int i = 0; i < ingredients.Length; i++)
        {
            Console.WriteLine($"- {"Quanties: " + quantities[i] + ","} {"Measurement Units: " + units[i]} of {"The Name: " + ingredients[i]}");

        }
        //display the stes..
        Console.WriteLine("\nSteps:");
        for (int i = 0; i < steps.Length; i++)
        {
            Console.WriteLine($"- {steps[i]}");
        }
    }

    public void ScaleRecipe(double factor)
    {
        // Multiply all the quantities by the scaling factor
        for (int i = 0; i < quantities.Length; i++)
        {
            quantities[i] *= factor;
        }
    }

    public void resetquantities()
    {
        //reset all the quanties to the their oroginal values
        for (int i = 0; i < quantities.Length; i++)
        {
            quantities[i] /= 2;
        }
    }

    public void clearRecipe()
    {
        //reset all the arrays to empty
        ingredients = new string[0];
        quantities = new double[0];
        units = new int[0];
        steps = new string[0];
    }


    public static void Main(string[] args)
    {
        PROG_ASSIGNMENT RECIPES = new PROG_ASSIGNMENT();


        while (true)
        {
            //Display options and get user input
            Console.WriteLine("********************************");
            Console.WriteLine("Select Recipe Option:");
            Console.WriteLine("********************************");
            Console.WriteLine("1. Add ingredient");
            Console.WriteLine("2. Scale recipe");
            Console.WriteLine("3. Reset quantities");
            Console.WriteLine("4. Clear recipe");
            Console.WriteLine("5. Display recipe");
            Console.WriteLine("6. Exit program");
            Console.Write("Enter option number: ");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    RECIPES.Enter_details();

                    break;

                case "2":
                    //Scale recipe

                    double factor;
                    Console.Write("Enter scale factor (0.5, 2 or 3):");
                    string factorString = Console.ReadLine();


                    if (double.TryParse(factorString, out factor) && (factor == 0.5 || factor == 2 || factor == 3))
                    {
                        RECIPES.ScaleRecipe(factor);

                        Console.WriteLine("Recipe scaled by factor of {factor}.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid factor entered.");
                    }
                    break;
                case "3":
                    //Reset quantities
                    RECIPES.resetquantities();

                    break;
                case "4":
                    //Clear recipe
                    RECIPES.clearRecipe();

                    break;
                case "5":
                    //Display recipe
                    RECIPES.DisplayRecipe();
                    break;
                case "6":
                    //Exit program
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        }
    }
}
