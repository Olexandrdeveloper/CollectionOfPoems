using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionOfPoems
{
    internal class Poem
    {
        public string Title { get; } = string.Empty;
        public string Author { get; } = string.Empty;
        public int Year { get; } = 0;
        public string Theme { get; } = string.Empty;
        public string Text { get; } = string.Empty;

        public Poem(string title, string author, int year, string theme, string text)
        {
            this.Title = title;
            this.Author = author;
            this.Year = year;
            this.Theme = theme;
            this.Text = text;
        }
    }
}
