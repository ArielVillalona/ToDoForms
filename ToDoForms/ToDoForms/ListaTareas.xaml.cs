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
	public partial class ListaTareas : ContentPage
	{
		public ListaTareas ()
		{
			InitializeComponent ();

			var botonNuevo = new ToolbarItem()
			{
				Text = "+"
			};

			botonNuevo.Clicked += BotonNuevo_Clicked;
			ToolbarItems.Add(botonNuevo);
		}

		async private void BotonNuevo_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new NuevoItem());
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(App.RutaDB))
			{
				List<Tarea> listaTareas;
				listaTareas = sQLiteConnection.Table<Tarea>().ToList(); sQLiteConnection.Table<Tarea>().Where(t => t.Completada == false).ToList();

				ListaTareaListview.ItemsSource=listaTareas;
			}
		}
		private void MenuItem_Clicked(object sender, EventArgs e)
		{
			using (SQLite.SQLiteConnection sQLiteConnection = new SQLite.SQLiteConnection(App.RutaDB))
			{
				var tareaAcompletar = (sender as MenuItem).CommandParameter as Tarea;
				tareaAcompletar.Completada = true;
				sQLiteConnection.Update(tareaAcompletar);
				List<Tarea> listaTareasFiltradas;
				listaTareasFiltradas = sQLiteConnection.Table<Tarea>().Where(t => t.Completada == false).ToList();
				ListaTareaListview.ItemsSource = listaTareasFiltradas;
			}
		}
	}
}