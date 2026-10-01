using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionOfPoems
{
    internal class PoemCollection
    {
        public List<Poem> Poems { get; } = new List<Poem>();
        private const string FilePath = "poems.txt";

        public void AddPoem()
        {
            Console.Write("Введіть назву вірша: ");
            string title = Console.ReadLine() ?? string.Empty;
            Console.Write("Введіть автора вірша: ");
            string author = Console.ReadLine() ?? string.Empty;
            Console.Write("Введіть рік написання вірша: ");
            int year = int.TryParse(Console.ReadLine(), out int parsedYear) ? parsedYear : 0;
            Console.Write("Введіть тему вірша: ");
            string theme = Console.ReadLine() ?? string.Empty;
            Console.Write("Введіть текст вірша: ");
            string text = Console.ReadLine() ?? string.Empty;

            Poem poem = new Poem(title, author, year, theme, text);
            Poems.Add(poem);
        }

        public void DeletePoem()
        {
            Console.Write("Введіть назву вірша для видалення: ");
            string title = Console.ReadLine() ?? string.Empty;
            Poem poemToRemove = Poems.Find(p => p.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (poemToRemove != null)
            {
                Poems.Remove(poemToRemove);
                Console.WriteLine($"Вірш '{title}' видалено.");
            }
            else
                Console.WriteLine($"Вірш '{title}' не знайдено.");
        }

        public void EditPoem()
        {
            Console.Write("Введіть назву вірша для редагування: ");
            string title = Console.ReadLine() ?? string.Empty;
            Poem poemToEdit = Poems.Find(p => p.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (poemToEdit != null)
            {
                Console.Write("Введіть нову назву вірша: ");
                string newTitle = Console.ReadLine() ?? string.Empty;
                Console.Write("Введіть нового автора вірша: ");
                string newAuthor = Console.ReadLine() ?? string.Empty;
                Console.Write("Введіть новий рік написання вірша: ");
                int newYear = int.TryParse(Console.ReadLine(), out int parsedYear) ? parsedYear : 0;
                Console.Write("Введіть нову тему вірша: ");
                string newTheme = Console.ReadLine() ?? string.Empty;
                Console.Write("Введіть новий текст вірша: ");
                string newText = Console.ReadLine() ?? string.Empty;
                Poems.Remove(poemToEdit);
                Poem updatedPoem = new Poem(newTitle, newAuthor, newYear, newTheme, newText);
                Poems.Add(updatedPoem);
                Console.WriteLine($"Вірш '{title}' оновлено.");
            }
            else
                Console.WriteLine($"Вірш '{title}' не знайдено.");
        }

        public void DisplayPoems()
        {
            if (Poems.Count == 0)
            {
                Console.WriteLine("Колекція віршів порожня.");
                return;
            }
            Console.WriteLine("Колекція віршів:");
            foreach (var poem in Poems)
            {
                Console.WriteLine($"Назва: {poem.Title}, Автор: {poem.Author}, Рік: {poem.Year}, Тема: {poem.Theme}");
                Console.WriteLine($"Текст:\n{poem.Text}\n");
            }
        }

        public void FindPoems()
        {
            Console.Write("Введіть характеристику для пошуку (1: Назва, 2: Автор, 3: Рік, 4: Тема): ");
            int choice = int.TryParse(Console.ReadLine(), out int parsedChoice) ? parsedChoice : 0;

            List<Poem> foundPoems = new List<Poem>();

            switch (choice)
            {
                case 1:
                    Console.Write("Введіть назву вірша для пошуку: ");
                    string title = Console.ReadLine() ?? string.Empty;
                    foundPoems = Poems.FindAll(p => p.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
                    break;
                case 2:
                    Console.Write("Введіть автора вірша для пошуку: ");
                    string author = Console.ReadLine() ?? string.Empty;
                    foundPoems = Poems.FindAll(p => p.Author.Equals(author, StringComparison.OrdinalIgnoreCase));
                    break;
                case 3:
                    Console.Write("Введіть рік написання вірша для пошуку: ");
                    int year = int.TryParse(Console.ReadLine(), out int parsedYear) ? parsedYear : 0;
                    foundPoems = Poems.FindAll(p => p.Year == year);
                    break;
                case 4:
                    Console.Write("Введіть тему вірша для пошуку: ");
                    string theme = Console.ReadLine() ?? string.Empty;
                    foundPoems = Poems.FindAll(p => p.Theme.Equals(theme, StringComparison.OrdinalIgnoreCase));
                    break;
                default:
                    Console.WriteLine("Невірний вибір.");
                    return;
            }

            if (foundPoems.Count == 0)
            {
                Console.WriteLine("Вірші не знайдено.");
                return;
            }

            Console.WriteLine("Знайдені вірші:");
            foreach (var poem in foundPoems)
            {
                Console.WriteLine($"Назва: {poem.Title}, Автор: {poem.Author}, Рік: {poem.Year}, Тема: {poem.Theme}");
                Console.WriteLine($"Текст:\n{poem.Text}\n");
            }
        }

        public void SaveToFile()
        {
            using (var writer = new StreamWriter(FilePath))
            {
                writer.WriteLine(Poems.Count);

                foreach (var poem in Poems)
                    writer.WriteLine($"{poem.Title}|{poem.Author}|{poem.Year}|{poem.Theme}|{poem.Text}");
            }
            Console.WriteLine("Колекція віршів збережена у файл.");
        }

        public void LoadFromFile()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine("Файл з колекцією віршів не знайдено.");
                return;
            }
            using (var reader = new StreamReader(FilePath))
            {
                int count = int.TryParse(reader.ReadLine(), out int parsedCount) ? parsedCount : 0;
                Poems.Clear();
                for (int i = 0; i < count; i++)
                {
                    string line = reader.ReadLine() ?? string.Empty;
                    string[] parts = line.Split('|');
                    if (parts.Length == 5)
                    {
                        string title = parts[0];
                        string author = parts[1];
                        int year = int.TryParse(parts[2], out int parsedYear) ? parsedYear : 0;
                        string theme = parts[3];
                        string text = parts[4];
                        Poem poem = new Poem(title, author, year, theme, text);
                        Poems.Add(poem);
                    }
                }
            }
            Console.WriteLine("Колекція віршів завантажена з файлу.");
        }

        public string GenerateReportByTitle()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("Звіт за назвою віршів:");
            foreach (var poem in Poems)
                report.AppendLine($"Назва: {poem.Title}");
            return report.ToString();
        }

        public string GenerateReportByAuthor()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("Звіт за авторами віршів:");
            foreach (var poem in Poems)
                report.AppendLine($"Автор: {poem.Author}");
            return report.ToString();
        }

        public string GenerateReportByYear()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("Звіт за роками написання віршів:");
            foreach (var poem in Poems)
                report.AppendLine($"Рік: {poem.Year}");
            return report.ToString();
        }

        public string GenerateReportByTheme()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("Звіт за темами віршів:");
            foreach (var poem in Poems)
                report.AppendLine($"Тема: {poem.Theme}");
            return report.ToString();
        }

        public string GenerateReportByWordInText()
        {
            Console.Write("Введіть слово для пошуку у текстах віршів: ");
            string word = Console.ReadLine() ?? string.Empty;
            StringBuilder report = new StringBuilder();
            report.AppendLine($"Звіт за словом \"{word}\" у текстах віршів:");
            foreach (var poem in Poems)
            {
                if (poem.Text.Contains(word))
                    report.AppendLine($"Назва: {poem.Title}, Автор: {poem.Author}");
            }
            return report.ToString();
        }

        public string GenerateReportByLength()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine("Звіт за довжиною віршів:");
            foreach (var poem in Poems)
                report.AppendLine($"Назва: {poem.Title}, Довжина: {poem.Text.Length}");
            return report.ToString();
        }
    }
}
