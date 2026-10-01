using System.Data;
using System.Text;

namespace CollectionOfPoems
{
    internal class Program
    {
        static string filePath = "report.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            PoemCollection poemCollection = new PoemCollection();

            while (true)
            {
                Console.Write(
                    "====== Меню ======\n" +
                    "1. Додати вірш\n" +
                    "2. Видалити вірш\n" +
                    "3. Показати всі вірші\n" +
                    "4. Знайти вірші за характеристикою\n" +
                    "5. Змінити вірш\n" +
                    "6. Зберегти колекцію віршів у файл\n" +
                    "7. Завантажити колекцію віршів з файлу\n" +
                    "8. Згенерувати звіт\n" +
                    "0. Вийти\n" +
                    "> ");

                int choice = int.TryParse(Console.ReadLine(), out int parsedChoice) ? parsedChoice : -1;
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        poemCollection.AddPoem();
                        break;
                    case 2:
                        poemCollection.DeletePoem();
                        break;
                    case 3:
                        poemCollection.DisplayPoems();
                        break;
                    case 4:
                        poemCollection.FindPoems();
                        break;
                    case 5:
                        poemCollection.EditPoem();
                        break;
                    case 6:
                        poemCollection.SaveToFile();
                        break;
                    case 7:
                        poemCollection.LoadFromFile();
                        break;
                    case 8:
                        ReportMenu(poemCollection);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Невірний вибір");
                        break;
                }
            }
        }

        static void ReportMenu(PoemCollection poemCollection)
        {
            Console.Write(
                "====== Звіт ======\n" +
                "1. За назвою\n" +
                "2. За автором\n" +
                "3. За роком\n" +
                "4. За темою\n" +
                "5. За словом у тексті\n" +
                "6. За довжиною\n" +
                "0. Назад\n" +
                "> ");
            string choice = Console.ReadLine() ?? string.Empty;

            switch (choice)
            {
                case "1":
                    string report = poemCollection.GenerateReportByTitle();
                    if (!string.IsNullOrEmpty(report))
                        SaveReportToFile(report);
                    else
                        Console.WriteLine("Вірші не знайдено.");
                    break;
                case "2":
                    string report2 = poemCollection.GenerateReportByAuthor();
                    if (!string.IsNullOrEmpty(report2))
                        SaveReportToFile(report2);
                    else
                        Console.WriteLine("Вірші не знайдено.");
                    break;
                case "3":
                    string report3 = poemCollection.GenerateReportByYear();
                    if (!string.IsNullOrEmpty(report3))
                        SaveReportToFile(report3);
                    else
                        Console.WriteLine("Вірші не знайдено.");
                    break;
                case "4":
                    string report4 = poemCollection.GenerateReportByTheme();
                    if (!string.IsNullOrEmpty(report4))
                        SaveReportToFile(report4);
                    else
                        Console.WriteLine("Вірші не знайдено.");
                    break;
                case "5":
                    string report5 = poemCollection.GenerateReportByWordInText();
                    if (!string.IsNullOrEmpty(report5))
                        SaveReportToFile(report5);
                    else
                        Console.WriteLine("Вірші не знайдено.");
                    break;
                case "6":
                    string report6 = poemCollection.GenerateReportByLength();
                    if (!string.IsNullOrEmpty(report6))
                        SaveReportToFile(report6);
                    else
                        Console.WriteLine("Вірші не знайдено.");
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Невірний вибір");
                    break;
            }
        }

        static void SaveReportToFile(string report)
        {
            Console.WriteLine(report);
            Console.WriteLine("Чи бажаєте зберигти звіт (+)?");
            string saveChoice = Console.ReadLine() ?? string.Empty;
            if (saveChoice == "+")
            {
                try
                {
                    File.WriteAllText(filePath, report);
                    Console.WriteLine($"Звіт збережено у файл: {filePath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка при збереженні звіту: {ex.Message}");
                }
            }
        }
    }
}
