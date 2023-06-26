using HolaMundo.Models;
using HolaMundo.Services;
using HolaMundo.Utils;

namespace HolaMundo;

public partial class DetailsPage : ContentPage
{
    //readonly IServicioApi _servicioApi = new ServicioApi();
    private ContactosDb _contactosDb = new ContactosDb();

    public DetailsPage()
	{
		InitializeComponent();
       // _servicioApi = servicioApi;
    }

    protected override void OnAppearing()
    {
        //Write the code of your page here
        base.OnAppearing();
        Contacto contacto = BindingContext as Contacto;
        imagen.Source = contacto.imagen;
        nombre.Text = contacto.nombre;
        telefono.Text = contacto.telefono;
        direccion.Text = contacto.direccion;
        cedula.Text = contacto.cedula;
    }

    private async void onClickEliminarContacto(object sender, EventArgs e)
	{
        Contacto contacto = BindingContext as Contacto;
        await _contactosDb.DeleteContactoAsync(contacto);
        //await  _servicioApi.BorrarContacto(contacto.cedula);
        //Util.listContacto.Remove(contacto);
        await Navigation.PopAsync();
	}

	private async void onClickModificarContacto(Object sender, EventArgs e)
	{

		await Navigation.PushAsync(new NewContactPage()
		{
			BindingContext = BindingContext as Contacto,
		}) ;
    }
}