using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Masukkan judul video: ");
        string judulVideo = Console.ReadLine();

        SayaTubeVideo video;
        try
        {
            video = new SayaTubeVideo(judulVideo);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return;
        }

        video.PrintVideoDetails();

        bool isValidInput;
        int tambahPlayCount;
        do
        {
            Console.Write("Masukkan jumlah penambahan play count (maksimal 10.000.000): ");
            isValidInput = int.TryParse(Console.ReadLine(), out tambahPlayCount) && tambahPlayCount <= 10000000;

            if (!isValidInput)
            {
                Console.WriteLine("Input jumlah penambahan play count tidak valid!");
            }
        } while (!isValidInput);

        try
        {
            video.IncreasePlayCount(tambahPlayCount);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        video.PrintVideoDetails();
    }
    public class SayaTubeVideo
    {
        public int id;
        public string title;
        public int playCount;

        private static Random random = new Random();

        public SayaTubeVideo(string title)
        {
            if (title == null || title.Length > 100)
                throw new Exception("Judul video tidak valid");

            this.id = random.Next(10000, 99999);
            this.title = title;
            this.playCount = 0;
        }

        public void IncreasePlayCount(int count)
        {
            if (count > 10000000)
                throw new Exception("Penambahan play count melebihi batas");
            try
            {
                checked
                {
                    playCount += count;
                }
            }
            catch (OverflowException)
            {
                Console.WriteLine("Play count melebihi batas tertinggi integer");
            }
        }
        public void PrintVideoDetails()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Play Count: " + playCount);
        }
    }
}