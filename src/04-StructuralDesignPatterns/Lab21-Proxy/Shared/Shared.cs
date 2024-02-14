using System.Collections;

namespace Lab21_Proxy.Shared;

public class Video
{
    public string Id { get; set; }
    public string Url { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Base64Thumbnail { get; set; }
}

public interface IYoutubeLibrary
{
    Task<List<string>> ListVideosAsync();
    Task<Video> GetVideoAsync(string id);
    Task<byte[]> DownloadVideoAsync(string url);
}

public class YoutubeLibrary : IYoutubeLibrary
{
    private string _connection_identifier;

    private void Connect()
    {
        Console.WriteLine(">>> Opening connection to YouTube...");
        _connection_identifier = Guid.NewGuid().ToString().Substring(0, 8);
    }

    private void Disconnect()
    {
        Console.WriteLine(">>> Closing connection to YouTube...");
        _connection_identifier = null;
    }

    public Task<byte[]> DownloadVideoAsync(string url)
    {
        Connect();

        Console.WriteLine(
            $"connection: [{_connection_identifier}]: Downloading video with url {url}"
        );

        Disconnect();

        return Task.FromResult(ArrayList.Repeat((byte)0, 100).Cast<byte>().ToArray()); //Simulate video content downloaded from YouTube
    }

    public Task<Video> GetVideoAsync(string id)
    {
        Connect();

        Console.WriteLine(
            $"connection: [{_connection_identifier}]: Get video information from YouTube"
        );

        Disconnect();

        return Task.FromResult(
            new Video
            {
                Author = "Test Author",
                Id = id,
                Title = "Test Video Title",
                Url = $"https://youtub.com/video/{id}",
                Base64Thumbnail = "base64;DSASDSADSADASDSADAD##@$ADASDASDASDADASDARWERWEKRJLJRWELKJRW"
            }
        );
    }

    public Task<List<string>> ListVideosAsync()
    {
        Connect();

        Console.WriteLine(
            $"connection: [{_connection_identifier}]: Getting home page videos from YouTube"
        );

        var videosIds = new List<string>();
        for (int i = 1; i < 5; i++)
        {
            videosIds.Add(i.ToString());
        }

        Disconnect();

        return Task.FromResult(videosIds);
    }
}
