using Microsoft.Extensions.Logging;
using Degree.Repositories;
using SQLitePCL;
using Degree.MVVM.Models;
using Degree.MVVM.Services;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace Degree
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>().UseSkiaSharp()               .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<BaseRepository<User>>();
            builder.Services.AddSingleton<BaseRepository<Order>>();
            builder.Services.AddSingleton<BaseRepository<Product>>();
            builder.Services.AddSingleton<BaseRepository<OrderItem>>();
            builder.Services.AddSingleton<BaseRepository<Inventory>>();
            builder.Services.AddSingleton<BaseRepository<InventoryChangeLogs>>();

            return builder.Build();
        }
    }
}
