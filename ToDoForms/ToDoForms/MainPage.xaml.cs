using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ToDoForms
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		async private void Button_Clicked(object sender, EventArgs e)
		{
			if(string.IsNullOrEmpty(UsuarioEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))
			{
				resultadoLabel.Text = "Debe escribir Usuario y Contraseña";
			}
			else
			{
				resultadoLabel.Text = "Inicio de sesion exitoso";
				await Navigation.PushAsync(new ListaTareas());
			}
		}
	}
}
