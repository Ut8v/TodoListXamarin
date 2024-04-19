using System;
using System.Collections.ObjectModel;
using TodolistXamarin.Data;
using Xamarin.Forms;

namespace TodolistXamarin
{
    public partial class MainPage : ContentPage
    {
        private readonly iTodo todo;

        public ObservableCollection<Todo> TodoItems { get; set; }

        public MainPage()
        {
            InitializeComponent();
            TodoItems = new ObservableCollection<Todo>();
            BindingContext = this;
            todo = DependencyService.Get<iTodo>();
            LoadTodoItems();
           
        }

        private async void LoadTodoItems()
        {
            try
            {
               
                var items = await todo.GetTodo();

                foreach (var item in items)
                {
                    //TodoItems.Add(item);

                    AddTodoItemView(item);

                }

                Console.WriteLine(TodoItems);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading TODO items: " + ex.Message);
            }
        }
        private void AddTodoItemView(Todo todoItem)
        {
            var todoItemView = new StackLayout
            {
                Padding = new Thickness(10),
                BackgroundColor = Color.FromHex("#F0F0F0"),
                Margin = new Thickness(0, 5, 0, 5)
            };

            todoItemView.Children.Add(new Label
            {
                Text = todoItem.title,
                FontAttributes = FontAttributes.Bold,
                FontSize = 18
            });

            todoItemView.Children.Add(new Label
            {
                Text = todoItem.task,
                FontSize = 16
            });

            todoItemView.Children.Add(new Label
            {
                Text = todoItem.description,
                FontSize = 14,
                TextColor = Color.FromHex("#666666")
            });

            todoItemView.Children.Add(new Switch
            {
                IsToggled = todoItem.done,
                IsEnabled = true
            });

            todoItemsStack.Children.Add(todoItemView);
        }

        async void AddTodo_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTodo());
        }
    }
}

