# Stopwatch WPF App

Dark theme, Windows 11 Fluent Design, Always on Top.

## Yêu cầu
- .NET 8 SDK: https://dotnet.microsoft.com/download/dotnet/8.0
- Windows 10/11

## Build & chạy

```bash
# Clone hoặc copy folder vào máy, mở terminal tại thư mục Stopwatch/

# Chạy thử
dotnet run

# Build ra file .exe (single file, không cần cài .NET)
dotnet publish -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true

# File .exe xuất hiện tại:
# bin/Release/net8.0-windows/win-x64/publish/Stopwatch.exe
```

## Upload GitHub

```bash
git init
git add .
git commit -m "Stopwatch WPF app"
git remote add origin https://github.com/YOUR_USERNAME/stopwatch-wpf.git
git push -u origin main
```

## Tính năng
- Hiển thị HH : MM : SS font Inter SemiBold 68px
- Nút Start / Pause
- Nút Reset
- Lưu 1 kết quả gần nhất khi nhấn Pause
- Always On Top - kéo thả tự do
- Nút X để đóng app
