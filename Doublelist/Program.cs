using Doublelist;

var list = new DoubleList<string>();
var option = string.Empty;
var value = string.Empty;

do
{
    option = Menu();
    switch (option)
    {
        case "1":
            Console.Write("Enter a value: ");
            value = Console.ReadLine() ?? string.Empty;
            list.Add(value);
            Console.WriteLine($"Value '{value}' was added to the list");
            break;

        case "2":
            Console.WriteLine(list.ToString());
            break;



        case "3":
            Console.WriteLine(list.ToStringReverse());
            break;

        case "4":
            list.Order();
            Console.WriteLine(list.ToString());

            break;

        case "5":

            var modes = list.ShowModes();

            if (modes.Count == 0)
            {
                Console.WriteLine("No hay modas");
            }
            else
            {
                Console.WriteLine("Moda(s):");
                foreach (var m in modes)
                {
                    Console.WriteLine(m);
                }
            }
            break;

        case "6":
            var chart = list.ShowChart();

            foreach (var item in chart)
            {
                Console.Write(item.value + " ");

                for (int i = 0; i < item.count; i++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }

            break;

        case "7":
            Console.Write("Enter a value: ");
            value = Console.ReadLine() ?? string.Empty;
            var exists = list.Contains(value);
            if (exists)
            {
                Console.WriteLine($"Value '{value}' found in the list.");
            }
            else
            {
                Console.WriteLine($"Value '{value}' not found in the list.");
            }
            break;


        case "8":
            Console.Write("Enter a value: ");
            value = Console.ReadLine() ?? string.Empty;
            if (list.Contains(value))
            {
                list.RemoveOccurrence(value);
                Console.WriteLine($"Value '{value}' was removed from the list");
            }
            else
            {
                Console.WriteLine($"Value '{value}' was not found in the list");
            }
            break;

        case "9":
            Console.Write("Enter a value to remove: ");
            value = Console.ReadLine() ?? string.Empty;
            if (list.Contains(value))
            {
                list.RemoveOccurrences(value);
                Console.WriteLine($"Value '{value}' was removed from the list");
            }
            else
            {
                Console.WriteLine($"Value '{value}' was not found in the list");
            }
            break;

        case "0":
            Console.WriteLine("Exiting...");
            break;

        default:
            Console.WriteLine("Invalid option. Please try again.");
            break;
    }
} while (option != "0");

string Menu()
{
    Console.WriteLine("1. Add");
    Console.WriteLine("2. Show forward");
    Console.WriteLine("3. Show backward");
    Console.WriteLine("4. Sort properly.");
    Console.WriteLine("5. Show mode(s)");
    Console.WriteLine("6. Show chart");
    Console.WriteLine("7. Exists");
    Console.WriteLine("8. Remove an occurrence.");
    Console.WriteLine("9. Remove all occurrences.");
    Console.WriteLine("0. Exit");
    Console.Write("Enter your option: ");
    return Console.ReadLine() ?? string.Empty;
}
