# Raygun4Net.NetCore Android example

This project contains a .Net for Android example app integrating Raygun4Net.

## Setup

Replace `YOUR_API_KEY` in `MainActivity.cs` with your Raygun application key.

This example needs a complete Android app development setup (including SDK).

## Running

With a connected device or emulator, run with:

```
dotnet run
```

## Usage

Tap on the button to crash the app. The exception should be captured by Raygun
and appear in your dashboard shortly after.
