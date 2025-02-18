# Raygun4Net.NetCore iOS example

This project contains a .Net for iOS example app integrating Raygun4Net.

Created from scratch using `dotnet new ios`.

## Setup

Replace `YOUR_API_KEY` in `AppDelegate.cs` with your Raygun application key.

This example needs a complete iOS app development setup (including SDK).

## Running

With a connected device or iOS simulator, run with:

```
dotnet run
```

## Usage

Tap on the button to crash the app. The exception should be captured by Raygun
and appear in your dashboard shortly after.
