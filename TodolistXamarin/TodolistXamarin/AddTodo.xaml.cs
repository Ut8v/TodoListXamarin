using Xamarin.Forms;
using TodolistXamarin.Data;
using System;
using SQLite;
using System.Globalization;

namespace TodolistXamarin
{
    public partial class AddTodo : ContentPage
    {
        public AddTodo()
        {
             InitializeComponent();
        }

        private async void AddTask_Clicked(object sender, EventArgs e)
        {
            string titletxt = titleEntry.Text;
            string task = taskEntry.Text;
            string descriptiontxt = descriptionEditor.Text;
            bool done = doneSwitch.IsToggled;

            iTodo todo = DependencyService.Get<iTodo>();
            var todoItem = new Todo
            {
                task = task,
                title = titletxt,
                description = descriptiontxt,
                done = done
            };

            await todo.AddTodo(todoItem);

           await Navigation.PushAsync(new MainPage());
            
        }
    }
}
