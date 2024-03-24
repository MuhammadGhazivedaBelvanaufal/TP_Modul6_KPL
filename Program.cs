internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Masukkan judul video: ");
        string judulVideo = Console.ReadLine();

        SayaTubeVideo video = new SayaTubeVideo(judulVideo);
        video.PrintVideoDetails();

        Console.Write("Masukkan jumlah penambahan play count: ");
        int tambahPlayCount = int.Parse(Console.ReadLine());

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

            playCount += count;
        }
        public void PrintVideoDetails()
        {
            Console.WriteLine("ID: " + id);
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Play Count: " + playCount);
        }
    }
}