/**000905815 Omar Zahraoui certify that this material is my original work.  No other person's work has been used without due acknowledgement **/
using System;
using System.IO;
using System.Linq;

namespace Lab_Assignment_3
{
    // Book class implementing Media and IEncryptable
    public class Book : Media, IEncryptable
    {
        public string Author { get; set; }
        public string Summary { get; set; }

        public Book(string title, int year, string author, string summary)
            : base(title, year)
        {
            Author = author;
            Summary = summary;
        }

        public string Encrypt()
        {
            return Rot13(Summary);
        }

        public string Decrypt()
        {
            return Rot13(Summary);
        }

        private string Rot13(string input)
        {
            return new string(input.Select(c =>
                char.IsLetter(c) ? (char)((c & 223) + 13 - 26 * ((c & 223) > 'M' ? 1 : 0)) : c).ToArray());
        }
    }

    // movie class implementing Media and IEncryptable
    public class Movie : Media, IEncryptable
    {
        public string Director { get; set; }
        public string Summary { get; set; }

        public Movie(string title, int year, string director, string summary)
            : base(title, year)
        {
            Director = director;
            Summary = summary;
        }

        public string Encrypt()
        {
            return Rot13(Summary);
        }

        public string Decrypt()
        {
            return Rot13(Summary);
        }

        private string Rot13(string input)
        {
            return new string(input.Select(c =>
                char.IsLetter(c) ? (char)((c & 223) + 13 - 26 * ((c & 223) > 'M' ? 1 : 0)) : c).ToArray());
        }
    }

    // song class implementing media
    public class Song : Media
    {
        public string Album { get; set; }
        public string Artist { get; set; }

        public Song(string title, int year, string album, string artist)
            : base(title, year)
        {
            Album = album;
            Artist = artist;
        }
    }

    // Main Program
    internal class Program
    {
       
        /// Main entry point of the program
        private static void Main(string[] args)
        {
            Media[] mediaArray = new Media[100];
            ReadData(mediaArray);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. List Books");
                Console.WriteLine("2. List Movies");
                Console.WriteLine("3. List Songs");
                Console.WriteLine("4. List All Media");
                Console.WriteLine("5. Search Media by Title");
                Console.WriteLine("6. Exit Program");
                Console.Write("Enter your choice (1-6): ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ListBooks(mediaArray);
                            break;
                        case 2:
                            ListMovies(mediaArray);
                            break;
                        case 3:
                            ListSongs(mediaArray);
                            break;
                        case 4:
                            ListAllMedia(mediaArray);
                            break;
                        case 5:
                            SearchMediaByTitle(mediaArray);
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }


        /// Reads data from the Data.txt file and populates the mediaArray.
        static void ReadData(Media[] mediaArray)
        {
            try
            {
                using (StreamReader reader = new StreamReader("Data.txt"))
                {
                    string line;
                    int count = 0;
                    while ((line = reader.ReadLine()) != null && count < 100)
                    {
                        string[] parts = line.Split('|');
                        if (parts.Length >= 4)
                        {
                            string type = parts[0];
                            string title = parts[1];
                            int year = int.Parse(parts[2]);
                            string third = parts[3];
                            string fourth = parts.Length > 4 ? parts[4] : "";

                            switch (type)
                            {
                                case "BOOK":
                                    mediaArray[count] = new Book(title, year, third, fourth);
                                    break;
                                case "MOVIE":
                                    mediaArray[count] = new Movie(title, year, third, fourth);
                                    break;
                                case "SONG":
                                    mediaArray[count] = new Song(title, year, third, fourth);
                                    break;
                            }

                            count++;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error reading data: " + e.Message);
            }
        }


        /// Lists all books in the mediaArray.
        static void ListBooks(Media[] mediaArray)
        {
            Console.WriteLine("List of Books:");
            foreach (var media in mediaArray)
            {
                if (media is Book book)
                {
                    Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
                }
            }
        }

        /// Lists all movies in the mediaArray.
        static void ListMovies(Media[] mediaArray)
        {
            Console.WriteLine("List of Movies:");
            foreach (var media in mediaArray)
            {
                if (media is Movie movie)
                {
                    Console.WriteLine($"Title: {movie.Title}, Director: {movie.Director}");
                }
            }
        }
         /// Lists all songs in the mediaArray.

        static void ListSongs(Media[] mediaArray)
        {
            Console.WriteLine("List of Songs:");
            foreach (var media in mediaArray)
            {
                if (media is Song song)
                {
                    Console.WriteLine($"Title: {song.Title}, Artist: {song.Artist}");
                }
            }
        }

        /// Lists all media in the mediaArray.

        static void ListAllMedia(Media[] mediaArray)
        {
            Console.WriteLine("List of All Media:");
            foreach (var media in mediaArray)
            {
                if (media is Book book)
                {
                    Console.WriteLine($"Book: {book.Title}, Author: {book.Author}");
                }
                else if (media is Movie movie)
                {
                    Console.WriteLine($"Movie: {movie.Title}, Director: {movie.Director}");
                }
                else if (media is Song song)
                {
                    Console.WriteLine($"Song: {song.Title}, Artist: {song.Artist}");
                }
            }
        }

        /// Searches media by title and displays matching media.

        static void SearchMediaByTitle(Media[] mediaArray)
        {
            Console.Write("Enter the title to search: ");
            string searchTitle = Console.ReadLine();

            Console.WriteLine("Search Results:");
            foreach (var media in mediaArray)
            {
                if (media != null && media.Search(searchTitle))
                {
                    Console.WriteLine($"Title: {media.Title}, Year: {media.Year}");
                    if (media is IEncryptable encryptable)
                    {
                        Console.WriteLine($"Summary: {encryptable.Decrypt()}");
                    }
                }
            }
        }
    }
}
