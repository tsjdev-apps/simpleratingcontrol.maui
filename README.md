# Simple Rating Control for .NET MAUI

A Simple Rating Control for .NET MAUI using an icon font.


## Screenshots

### Android 

![Android Screenshot](https://github.com/tsjdev-apps/simpleratingcontrol.maui/raw/main/docs/sample-android.png)

### Windows 

![Windows Screenshot](https://github.com/tsjdev-apps/simpleratingcontrol.maui/raw/main/docs/sample-windows.png) 


## Setup

Available on NuGet: [SimpleRatingControl.MAUI](https://www.nuget.org/packages/SimpleRatingControl.MAUI)

[![NuGet](https://img.shields.io/nuget/v/SimpleRatingControl.MAUI.svg?label=NuGet&color=blue)](https://www.nuget.org/packages/SimpleRatingControl.MAUI)

Just add the package to your .NET MAUI application.


## API Usage

Initialize the package by calling `UseSimpleRatingControl()` on `MauiProgram`:
```CSHARP
var builder = MauiApp.CreateBuilder();

builder
	.UseMauiApp<App>()
	.UseSimpleRatingControl()

    // other configurations

return builder.Build();
```

You must add this namespace to your `xaml` files:

```XML
xmlns:controls="http://www.tsjdev-apps.de/maui/controls"
```

Now you can use the `SimpleRatingControl` from this namespace:
```XML
<controls:SimpleRatingControl Amount="5"
                              CurrentValue="1"
                              AccentColor="Black"
                              FontSize="36"
                              RatingType="Circle" />
```


## Available Properties

| Property       | Type          | Description                                              | Default Value |
|----------------|---------------|----------------------------------------------------------|---------------|
| `CurrentValue` | `double`      | Sets the value which should be used as the rating.       | `0`           |
| `Amount`       | `double`      | Sets the maximum amount                                  | `10`          |
| `FontSize`     | `double`      | Sets the size of each element.                           | `24`          |
| `AccentColor`  | `Color`       | Sets the color of the element.                           | `Red`         |
| `RatingType`   | `RatingType`  | Sets the type of the icon which should be used.          | `Star`        |