using System;

class SayaTubeVideo
{
    private int id;
    private string title;
    private int playCount;

    public SayaTubeVideo(string title)
    {
 
        if (string.IsNullOrEmpty(title) || title.Length > 100)
        {
            throw new ArgumentException("Judul video harus memiliki panjang maksimal 100 karakter dan tidak null.");
        }

        id = GenerateRandomId();
        this.title = title;
        playCount = 0;
    }

    private int GenerateRandomId()
    {
        Random random = new Random();
        return random.Next(10000, 99999); 
    }

    public void IncreasePlayCount(int count)
    {
        if (count < 0 || count > 10000000)
        {
            throw new ArgumentOutOfRangeException("count", "Input penambahan play count harus antara 0 hingga 10,000,000.");
        }

        try
        {
            checked
            {
                playCount += count;
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Overflow terjadi dalam penambahan play count.");
        }
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
        try
        {
           
            SayaTubeVideo video = new SayaTubeVideo(null); 
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ArgumentException: {ex.Message}");
        }

        try
        {
            
            SayaTubeVideo video = new SayaTubeVideo("Video dengan judul panjang melebihi 100 karakter ini akan menyebabkan pengecualian ArgumentException.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"ArgumentException: {ex.Message}");
        }

        try
        {
            
            SayaTubeVideo video = new SayaTubeVideo("Video 1");

            video.IncreasePlayCount(20000000); 

            for (int i = 0; i < 5; i++)
            {
                video.IncreasePlayCount(2000000); 
            }
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"ArgumentOutOfRangeException: {ex.Message}");
        }

        SayaTubeVideo video1 = new SayaTubeVideo("Video 1");
        video1.PrintVideoDetails();  
        video1.IncreasePlayCount(5); 
        video1.PrintVideoDetails();  
    }
}
