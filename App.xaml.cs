using HolaMundo.Services;
using HolaMundo.Utils;

namespace HolaMundo;

public partial class App : Application
{
    // Obtiene acceso StorageDirectory
    public static string StorageDirectory { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Photos");

    public App()
	{
		InitializeComponent();
        //Util._servicioApi=new ServicioApi();
        MainPage = new NavigationPage(new ContactosPage());
	}
}
