﻿using Microsoft.Extensions.Logging;
using Plugin.Maui.Audio;

namespace BrainrotClicker
{
    public static class MauiProgram
    {

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });


            builder.Services.AddSingleton(AudioManager.Current);

            return builder.Build();
        }
    }
}