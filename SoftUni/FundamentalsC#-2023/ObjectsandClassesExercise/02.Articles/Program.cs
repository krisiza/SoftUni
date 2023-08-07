using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;

namespace _02.Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Article article= new Article();

            string[] arr = Console.ReadLine().Split(", ").ToArray();
            article.Titel = arr[0];
            article.Content= arr[1];
            article.Author= arr[2];

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ").ToArray();

                switch (command[0]) 
                {
                    case "Edit":
                        article.Edit(command[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(command[1]);
                        break;
                    case "Rename":
                        article.Rename(command[1]);
                        break;
                }
            }
            Console.WriteLine(article.ToString(article.Titel,article.Content,article.Author));
        }
    }
    class Article
    {
        public string Titel { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article()
        {
            Edit(Content);
            ChangeAuthor(Author);
            Rename(Titel);
            ToString(Titel, Content, Author);
        }
        public void Edit(string content)
        {
            Content= content;
        }
        public void ChangeAuthor(string authot)
        {
            Author = authot;
        }
        public void Rename(string title)
        {
            Titel= title;
        }
        public string ToString(string title, string content, string author)
        {
            return ($"{title} - {content}: {author}");
        }
    }
}
