using TemplateApi.Domain.Interfaces;
using TemplateApi.Domain.Services;

namespace TemplateApi.Maui;

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
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddScoped<IPersonService, PersonService>();

		_ = builder.Services.AddHttpClient(nameof(PersonService), client =>
		{
            var url = DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:5000" : "http://localhost:5000";
            client.BaseAddress = new Uri($"{url}/api/Person");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
		});


		return builder.Build();
	}
}
