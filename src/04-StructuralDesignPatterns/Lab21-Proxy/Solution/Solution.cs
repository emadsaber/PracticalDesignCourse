using Lab21_Proxy.Shared;

namespace Lab21_Proxy.Solution;

public class CachedYoutubeLibrary : IYoutubeLibrary
{
    private readonly YoutubeLibrary realService;
    private List<Video> cachedVideos = new List<Video>
    {
        new Video
        {
            Author = "Test Author 1",
            Title = "Test Video Title 1",
            Id = "1",
            Url = "https://youtub.com/video/1",
            Base64Thumbnail =
                "base64;QQWEQWWQEQPWOE{O{QWEOPEOP{OQWEQWEQWEEEQWWQASASDASDSADASDASCZXCCXZQQEWWEQqweeqASD}}}"
        },
        new Video
        {
            Author = "Test Author 2",
            Title = "Test Video Title 2",
            Id = "2",
            Url = "https://youtub.com/video/2",
            Base64Thumbnail = "base64;DSASDSADSADASDSADAD##@$ADASDASDASDADASDARWERWEKRJLJRWELKJRW"
        },
    };

    public CachedYoutubeLibrary(YoutubeLibrary realService)
    {
        this.realService = realService;
    }

    public bool HasAccess()
    {
        //check if the current logged in user has access to download videos

        return true;
    }

    public Task<byte[]> DownloadVideoAsync(string url)
    {
        if (!HasAccess())
            return Task.FromResult((byte[])null);

        //force use to download only between 12 AM and 4 AM
        if (DateTime.Now.Hour > 4)
        {
            Console.WriteLine("Downloading is only permitted between 12 AM and 4 AM");
            return Task.FromResult((byte[])null);
        }

        return realService.DownloadVideoAsync(url);
    }

    public Task<Video> GetVideoAsync(string id)
    {
        Console.WriteLine($"Getting video information for video id {id}");

        if (!HasAccess())
            return Task.FromResult((Video)null);

        if (cachedVideos.Any(x => x.Id == id))
        {
            Console.WriteLine($"Obtained video information for video id {id} from cache");
            return Task.FromResult(cachedVideos.First(x => x.Id == id));
        }

        return realService.GetVideoAsync(id);
    }

    public Task<List<string>> ListVideosAsync()
    {
        if (!HasAccess())
            return Task.FromResult((List<string>)null);

        return realService.ListVideosAsync();
    }
}

public class Application
{
    public async Task Test()
    {
        var cachedLib = new CachedYoutubeLibrary(new YoutubeLibrary());
        var idsList = await cachedLib.ListVideosAsync();
        foreach (var id in idsList)
        {
            var info = await cachedLib.GetVideoAsync(id);

            await cachedLib.DownloadVideoAsync(info.Id);
            Console.WriteLine("-------------------------------------------------");
        }
    }
}
