using System;
using System.Collections.Generic;
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
            List<Article> articles = new List<Article>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Article article = new Article();
                string[] arr = Console.ReadLine().Split(", ").ToArray();

                article.Titel = arr[0];
                article.Content = arr[1];
                article.Author = arr[2];

                articles.Add(article);
            }



            foreach (Article article in articles)
            {
                Console.WriteLine(article.ToString(article.Titel, article.Content, article.Author));
            }
        }
    }
    class Article
    {
        public string Titel { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article()
        {
            ToString(Titel, Content, Author);
        }
        public string ToString(string title, string content, string author)
        {
            return ($"{title} - {content}: {author}");
        }
    }
}
