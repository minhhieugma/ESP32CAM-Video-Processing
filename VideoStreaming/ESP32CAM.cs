using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Net.Http.Headers;

namespace VideoStreaming;

public class ESP32CAM
{
    private readonly string _url;
    private readonly string _boundary;

    public ESP32CAM(string url, string boundary)
    {
        _url = url;
        _boundary = boundary;
    }

    public async IAsyncEnumerable<byte[]> ReadVideoStreamAsync()
    {
        using HttpClient client = new();
        using HttpResponseMessage response = await client.GetAsync(_url, HttpCompletionOption.ResponseHeadersRead);
        Stream stream = await response.Content.ReadAsStreamAsync();
        MultipartReader multipartReader = new(_boundary, stream);

        while (await multipartReader.ReadNextSectionAsync() is { } section)
        {
            // Make sure we have a content-type for the section
            if (!MediaTypeHeaderValue.TryParse(section.ContentType, out MediaTypeHeaderValue? sectionType))
            {
                throw new ("Missing content-type");
            }

            using MemoryStream ms = new();
            await section.Body.CopyToAsync(ms);
            byte[] binaryData = ms.ToArray();

            yield return binaryData;
        }
    }
}