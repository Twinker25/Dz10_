namespace Dz10_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.Write("\nEnter task (1 - 6): ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Func<string, int[]> RainbowColor = (colorName) =>
                        {
                            switch (colorName.ToLower())
                            {
                                case "red":
                                    return new int[] { 255, 0, 0 };
                                case "orange":
                                    return new int[] { 255, 165, 0 };
                                case "yellow":
                                    return new int[] { 255, 255, 0 };
                                case "green":
                                    return new int[] { 0, 255, 0 };
                                case "blue":
                                    return new int[] { 0, 0, 255 };
                                case "indigo":
                                    return new int[] { 75, 0, 130 };
                                case "purple":
                                    return new int[] { 238, 130, 238 };
                                default:
                                    throw new Exception("Invalid rainbow color name");
                            }
                        };
                        Console.Write("\nEnter color: ");
                        string Сolor = Console.ReadLine();
                        try
                        {
                            int[] rgb = RainbowColor(Сolor);
                            Console.WriteLine($"RGB value for {Сolor}: ({rgb[0]}, {rgb[1]}, {rgb[2]})");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 2:
                        Console.Write("\nEnter the color of the backpack: ");
                        string color = Console.ReadLine();
                        Console.Write("Enter the brand and manufacturer of the backpack: ");
                        string brand = Console.ReadLine();
                        Console.Write("Enter backpack fabric: ");
                        string fabric = Console.ReadLine();
                        Console.Write("Enter the weight of the backpack: ");
                        double weight = double.Parse(Console.ReadLine());
                        Console.Write("Enter the volume of the backpack: ");
                        double volume = double.Parse(Console.ReadLine());

                        Backpack myBackpack = new Backpack(color, brand, fabric, weight, volume);
                        myBackpack.ItemAdded += (sender, e) =>
                        {
                            Console.WriteLine($"Added item '{e.Item.Name}' to backpack.");
                        };
                        try
                        {
                            Console.Write("Enter the subject name: ");
                            string itemName = Console.ReadLine();
                            Console.Write("Enter the volume of the item: ");
                            double itemVolume = double.Parse(Console.ReadLine());
                            myBackpack.AddItem(new Item(itemName, itemVolume));
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case 3:
                        Random random1 = new Random();
                        Console.Write("\nEnter size of array: ");
                        int size1 = int.Parse(Console.ReadLine());
                        int[] arr1 = new int[size1];
                        Console.Write("Array: ");
                        for (int i = 0; i < size1; i++)
                        {
                            arr1[i] = random1.Next(1, 100);
                            Console.Write(arr1[i] + " ");
                        }
                        int k1 = arr1.Count(x => x % 7 == 0);
                        Console.WriteLine($"\nThe number of numbers in the array that are multiples of 7: {k1}");
                        break;
                    case 4:
                        Random random2 = new Random();
                        Console.Write("\nEnter size of array: ");
                        int size2 = int.Parse(Console.ReadLine());
                        int[] arr2 = new int[size2];
                        Console.Write("Array: ");
                        for (int i = 0; i < size2; i++)
                        {
                            arr2[i] = random2.Next(-100, 100);
                            Console.Write(arr2[i] + " ");
                        }
                        int k2 = arr2.Count(x => x > 0);
                        Console.WriteLine($"\nThe number of positive numbers in the array: {k2}");
                        break;
                    case 5:
                        Random random3 = new Random();
                        Console.Write("\nEnter size of array: ");
                        int size3 = int.Parse(Console.ReadLine());
                        int[] arr3 = new int[size3];
                        Console.Write("Array: ");
                        for (int i = 0; i < size3; i++)
                        {
                            arr3[i] = random3.Next(-100, 100);
                            Console.Write(arr3[i] + " ");
                        }
                        var numbers = arr3.Where(x => x < 0).Distinct();
                        Console.Write("\nUnique and negative numbers: ");
                        foreach (var rezult in numbers)
                        {
                            Console.Write(rezult + " ");
                        }
                        break;
                    case 6:
                        Console.Write("\nEnter text: ");
                        string text = Console.ReadLine();
                        Console.Write("Enter word: ");
                        string word = Console.ReadLine();
                        Func<string, string, bool> checkWord = (t, w) => t.Contains(w);
                        bool containsWord = checkWord(text, word);
                        if (containsWord)
                        {
                            Console.WriteLine($"The text contains the word '{word}'");
                        }
                        else
                        {
                            Console.WriteLine($"The text does not contain the word '{word}'");
                        }
                        break;
                    default:
                        Console.WriteLine("Error! Try again!");
                        break;
                }
            } while (choice > 1 || choice < 6);
        }
    }
}