// See https://aka.ms/new-console-template for more information

using VideoStreaming;


string boundary = "123456789000000000000987654321";
ESP32CAM esp32cam = new("http://192.168.0.160:81/stream", boundary);

await foreach (byte[] binaryData in esp32cam.ReadVideoStreamAsync())
{
    await File.WriteAllBytesAsync("file.jpg", binaryData);
}