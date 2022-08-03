﻿namespace SimpleRatingControlMaui;

public static class AppHostBuilderExtensions
{
    public static MauiAppBuilder UseSimpleRatingControl(this MauiAppBuilder builder)
    {
        builder.ConfigureFonts(fonts =>
        {
            fonts.AddEmbeddedResourceFont(typeof(AppHostBuilderExtensions).Assembly, "materialdesignicons-webfont.ttf", "MDI");
        });

        return builder;
    }
}
