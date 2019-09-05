using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoForms.Clases;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoForms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NuevoItem : ContentPage
	{
		public NuevoItem ()
		{
			InitializeComponent ();
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			Tarea tarea = new Tarea()
			{
				Nombre = nombreEntry.Text,
				Fecha = fechaLimiteDatePicker.Date,
				Hora = horaLimiteTimePicker.Time,
				Completada=false
			};
			using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(App.RutaDB))
			{
				sQLiteConnection.CreateTable<Tarea>();
				var resultado = sQLiteConnection.Insert(tarea);

				if (resultado > 0)
					DisplayAlert("Exito", "el elemento se guardo", "ok");
				else
					DisplayAlert("Error", "Intenta de nuevo", "ok");
			}
		}
	}
}