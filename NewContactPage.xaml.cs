namespace HolaMundo;
using HolaMundo.Utils;
using HolaMundo.Models;
using System.Collections.ObjectModel;
using HolaMundo.Services;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

public partial class NewContactPage : ContentPage
{
	Contacto contacto;
    private string fotoCapturada;


    //string imageString = (string)ImageSourceConverter.ConvertToInvariantString(fotoCapturada);

    private void CameraPage_PhotoCaptured(object sender, ImageSource photo)
    {
        fotoCapturada = (sender as CameraPage).CapturedImagePath;
        imagenCamara.Source = ImageSource.FromFile(fotoCapturada);
    }

    //readonly IServicioApi _servicioApi = new ServicioApi();
    private ContactosDb _contactosDb = new ContactosDb();
    public NewContactPage()
	{
		InitializeComponent();
		//_contactosDb = contactosDb;
       // _servicioApi = servicioApi;
    }

    protected override void OnAppearing()
    {
        //Write the code of your page here
        base.OnAppearing();
        contacto = BindingContext as Contacto;
        if (contacto != null)
        {	
            nombre.Text = contacto.nombre;
            direccion.Text = contacto.direccion;
            telefono.Text = contacto.telefono;
            cedula.Text = contacto.cedula;
			cedula.IsEnabled = false;
		}
		else
		{
            cedula.IsEnabled = true;
        }

    }

    private async void onClickGuardarContacto(object sender, EventArgs e)
	{
        //ImageSourceConverter converter = new ImageSourceConverter();
        if (contacto == null)
		{
			contacto = new Contacto()
			{
				nombre = nombre.Text,
				direccion = direccion.Text,
				telefono = telefono.Text,
				cedula = cedula.Text,
                //imagen = "imagen1.png"
                //imagen = fotoCapturada
                imagen = fotoCapturada != null? fotoCapturada : "imagen1.png"

            };
			await _contactosDb.SaveContactoAsync(contacto);
			//await _servicioApi.GuardarContacto(contacto);
			//Util.listContacto.Add(contacto);
			// var page = Navigation.NavigationStack.LastOrDefault();
			// await Navigation.PushAsync(new Contactos());
			//Navigation.RemovePage(page);
		}
		else
		{
			contacto.nombre= nombre.Text;
			contacto.direccion= direccion.Text;
			contacto.telefono= telefono.Text;
			contacto.cedula=cedula.Text;
            contacto.imagen = fotoCapturada;
            //await _servicioApi.EditarContacto(contacto.cedula, contacto);
            await _contactosDb.UpdateContactoAsync(contacto);
            BindingContext = contacto;
		}
        await Navigation.PopAsync();
    }

    //private async void onClickAbrirCamara(object sender, EventArgs e)
    //{
    //	await Navigation.PushAsync(new CameraPage());
    //}

    private async void onClickAbrirCamara(object sender, EventArgs e)
    {
        var cameraPage = new CameraPage();
        cameraPage.PhotoCaptured += CameraPage_PhotoCaptured;
        await Navigation.PushAsync(cameraPage);
    }
}