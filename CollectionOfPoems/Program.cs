using System.Data;
using System.Text;

namespace CollectionOfPoems
{
    internal class Program
    {
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
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Невірний вибір");
                        break;
                }
            }
        }
    }
}
