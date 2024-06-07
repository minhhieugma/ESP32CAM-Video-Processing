
# Video Streaming with ESP32CAM

This project is a simple implementation of a video streaming client for the ESP32CAM module. It connects to the video stream provided by the ESP32CAM and saves the video frames as JPEG files.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- .NET 5.0 or later
- An ESP32CAM module set up to stream video over HTTP

### Installing

1. Clone the repository
2. Open the solution in JetBrains Rider 2024.1.2
3. Build the solution

### Usage

Update the `boundary` and `url` in `Program.cs` to match your ESP32CAM settings:

```csharp
string boundary = "123456789000000000000987654321";
ESP32CAM esp32cam = new("http://192.168.0.160:81/stream", boundary);
```

Run the program. It will connect to the video stream and save the video frames as JPEG files.

## Built With

- [.NET 5.0](https://dotnet.microsoft.com/download/dotnet/5.0)
- [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-5.0)

## Authors

- [minhhieugma](https://github.com/minhhieugma)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Acknowledgments

- [Reading JSON and binary data from multipart form data sections in ASP.NET Core](https://andrewlock.net/reading-json-and-binary-data-from-multipart-form-data-sections-in-aspnetcore/#manually-reading-multipart-form-data-with-multipartreader)
