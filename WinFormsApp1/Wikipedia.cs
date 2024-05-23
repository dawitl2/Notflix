using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WinFormsApp1
{
    internal class Wikipedia
    {
        private string movieTitle;
        private string url;
        private List<string> castNames;

        public Wikipedia(string title)
        {
            movieTitle = title;
            url = $"https://en.wikipedia.org/wiki/{movieTitle.Replace(" ", "_")}";
            castNames = new List<string>();
            scrape(movieTitle, url);
        }

        void scrape(string movieTitle, string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);

                var castNodes = doc.DocumentNode.SelectNodes("//table[contains(@class, 'infobox')]//th[text()='Starring']/following-sibling::td//a");

                if (castNodes != null && castNodes.Any())
                {
                    foreach (var node in castNodes.Take(10))
                    {
                        castNames.Add(node.InnerText);
                    }
                }
                else
                {
                    castNames.Add("Cast information not found.");
                }
            }
            catch (Exception ex)
            {
                castNames.Add($"An error occurred: {ex.Message}");
            }
        }

        public string[] GetCastNames()
        {
            return castNames.ToArray();
        }
    }
}
