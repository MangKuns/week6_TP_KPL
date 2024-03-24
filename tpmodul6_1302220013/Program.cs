// See https://aka.ms/new-console-template for more information

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(String title)
    {
        id = GenerateRandomId();
        this.title = title;
        playCount = 0;
    }

    private int GenerateRandomId()
    {
        Random randomID = new Random();
        return randomID.Next(10000, 99999);
    }
    public void increasePLayCount(int count)
    {
        playCount =+ count;
    }

    public void PrintVideoDetails()
    {
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Play Count: {playCount}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        
        string namaPraktikan = "Rizky Kusuma Nugraha";
        string judulVideo = $"Tutorial Design By Contract - {namaPraktikan}";

        SayaTubeVideo video = new SayaTubeVideo(judulVideo);

        video.PrintVideoDetails();

        video.increasePLayCount(5);

        video.PrintVideoDetails();
    }
}