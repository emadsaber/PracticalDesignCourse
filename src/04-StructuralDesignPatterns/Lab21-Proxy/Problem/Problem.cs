using Lab21_Proxy.Shared;

namespace Lab21_Proxy.Problem;

public class Application
{
    public async Task Test()
    {
        var youtubeLib = new YoutubeLibrary();

        var idsList = await youtubeLib.ListVideosAsync();
        foreach (var id in idsList)
        {
            var info = await youtubeLib.GetVideoAsync(id);

            await youtubeLib.DownloadVideoAsync(info.Id);
        }
    }
}
