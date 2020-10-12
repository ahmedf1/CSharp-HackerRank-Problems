using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class Movie
{
    public string title { get; set; }
    public string year { get; set; }
    public string imdbID { get; set; }
}

public class MoviesResult
{
    public int page { get; set; }
    public int per_page { get; set; }
    public int total { get; set; }
    public int total_pages { get; set; }
    public List<Movie> data { get; set; }
}
class Solution
{
    /*
     * Complete the function below. 
     * Base url: https://jsonmock.hackerrank.com/api/movies/search/?Title=
     */
    public static MoviesResult result;

    /// <summary>
    /// the function below is designed to download json data from the mock json data set after searching,
    /// using a term supplied by the user, it sifts through the pages of the search results and prints
    /// the titles of the found movies
    /// </summary>
    /// <param name="substr"></param>
    /// <returns></returns>
    public static string[] getMovieTitles(string substr)
    {
        string url = "https://jsonmock.hackerrank.com/api/movies/search/?Title=" + substr;
        string[] movies = { };
        using (var w = new WebClient())
        {
            var jsonData = string.Empty;
            try
            {
                
                jsonData = w.DownloadString(url);
                result = JsonConvert.DeserializeObject<MoviesResult>(jsonData); // to get pageNumbers
                int numPages = result.total_pages;

                int total_Results = 0;
                for (int i = 1; i <= numPages; i++)
                {
                    jsonData = w.DownloadString(url + "&page=" + i);
                    result = JsonConvert.DeserializeObject<MoviesResult>(jsonData);
                    Console.WriteLine("Printing All Search Results for: " + substr);
                    foreach (Movie m in result.data)
                    {
                        Console.WriteLine(m.title);
                        total_Results++;
                    }
                }
                Console.WriteLine(total_Results+" Results Found.");

            }
            catch (Exception ex)
            {
                Console.WriteLine("failed to load movies, " + ex);
            }
        }
        return movies;
    }
    static void Main(String[] args)
    {
        Console.WriteLine("Enter Movie Name: ");
        string s = Console.ReadLine();

        string fileName = "C:\\Users\\Farhad Vantage\\Desktop\\out.txt";
        TextWriter fileOut = new StreamWriter(@fileName, true);

        string[] res = getMovieTitles(s);
        for (int res_i = 0; res_i < res.Length; res_i++)
        {
            fileOut.WriteLine(res[res_i]);
        }

        fileOut.Flush();
        fileOut.Close();
    }
}