using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_013_ToDoApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> items = new List<string>();
        List<Task> tasks = new List<Task>();

        Task task = new Task();
        List<Category> categories = new List<Category>();

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        void Initialise()
        {
            using (var db = new TasksDBEntities())
            {
                tasks = db.Tasks.ToList();
                categories = db.Categories.ToList();
            }
            ListBoxTasks.ItemsSource = tasks;
            ListBoxTasks.DisplayMemberPath = "Description";
            ComboBoxCategory.ItemsSource = categories;
            ComboBoxCategory.DisplayMemberPath = "CategoryName";
        }

        //void InitialiseListBox()
        //{
        //    ListBoxTasks.ItemsSource = items;
        //    using (var db = new TasksDBEntities())
        //    {
        //        tasks = db.Tasks.ToList();
        //    }
        //    //Get description and add to list
        //    foreach (var item in tasks)
        //    {
        //        items.Add($"{item.TaskID,-5}{item.Description,-40}{item.Done,-40}{item.DateCompleted,-40}");
        //    }
        //}

        private void ListBoxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            //print out details of selected item
            //instance = (convert to task) the item selected in listbox by user
            task = (Task)ListBoxTasks.SelectedItem;
            if (task != null)
            {
                TextboxId.Text = task.TaskID.ToString();
                TextboxDescription.Text = task.Description.ToString();
                TextboxCategoryId.Text = task.CategoryID.ToString();
                TextboxId.IsReadOnly = true;
                TextboxDescription.IsReadOnly = true;
                TextboxCategoryId.IsReadOnly = true;
                ButtonEdit.IsEnabled = true;
                if (task.CategoryID != null)
                {
                    ComboBoxCategory.SelectedIndex = (int)task.CategoryID;
                }   
            }
            
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonEdit.Content.ToString() == "Edit")
            {
                TextboxId.IsReadOnly = true;
                TextboxDescription.IsReadOnly = false;
                TextboxCategoryId.IsReadOnly = false;
                ButtonEdit.IsEnabled = true;
                ButtonEdit.Content = "Save";
                var brush = new BrushConverter();
                TextboxDescription.Background = (Brush)brush.ConvertFrom("#0A84FF");
            }
            else
            {
                using (var db = new TasksDBEntities())
                {
                    //update description and category id
                    var taskToEdit = db.Tasks.Find(task.TaskID);
                    taskToEdit.Description = TextboxDescription.Text;
                    //convert category id to integer from textbox
                    //try parse safe way to do converstion, null if fails
                    int.TryParse(TextboxCategoryId.Text, out int categoryId);
                    taskToEdit.CategoryID = categoryId;
                    //update record in database
                    db.SaveChanges();
                    //update list box
                    ListBoxTasks.ItemsSource = null; //reset listbox
                    tasks = db.Tasks.ToList(); // 
                    ListBoxTasks.ItemsSource = tasks;
                }
                TextboxId.IsReadOnly = true;
                TextboxDescription.IsReadOnly = true;
                TextboxCategoryId.IsReadOnly = true;
                ButtonEdit.Content = "Edit";
                ButtonEdit.IsEnabled = false;
                var brush = new BrushConverter();
                TextboxDescription.Background = (Brush)brush.ConvertFrom("#0A84FF");
            }
            
        }

        private void ListBoxTasks_DoubleClick (object sender, MouseButtonEventArgs e)
        {
            task = (Task)ListBoxTasks.SelectedItem;
            if (task != null)
            {
                // set the boxes for edit conditions
                TextboxId.Text = task.TaskID.ToString();
                TextboxDescription.Text = task.Description.ToString();
                TextboxCategoryId.Text = task.CategoryID.ToString();
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonDelete.Content.ToString() == "Delete")
            {

                ButtonDelete.Content = "Confirm";
                TextboxDescription.Background = Brushes.White;
                TextboxCategoryId.Background = Brushes.White;
                TextboxDescription.IsReadOnly = false;
                TextboxCategoryId.IsReadOnly = false;
            }
            else
            {

                using (var db = new TasksDBEntities())
                {
                    var taskToDelete = db.Tasks.Find(task.TaskID);
                    db.Tasks.Remove(taskToDelete);
                    db.SaveChanges();
                    ListBoxTasks.ItemsSource = null; //  reset list box
                    tasks = db.Tasks.ToList();       // get fresh link
                    ListBoxTasks.ItemsSource = tasks; // re-link 
                }
                ButtonDelete.Content = "Delete";
                ButtonDelete.IsEnabled = false;
                TextboxId.Text = " ";
                TextboxDescription.Text = " ";
                TextboxCategoryId.Text = " ";
            }



        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            
            if (ButtonAdd.Content.ToString() == "Add")
            {
                ButtonAdd.IsEnabled = true;
                ButtonAdd.Content = "Confirm";
                // set boxes to editable
                TextboxDescription.Background = Brushes.Blue;
                TextboxCategoryId.Background = Brushes.Blue;
                TextboxDescription.IsReadOnly = false;
                TextboxCategoryId.IsReadOnly = false;
                //clear out boxes
                TextboxId.Text = "";
                TextboxDescription.Text = "";
                TextboxCategoryId.Text = "";
            }
            else
            {
                ButtonAdd.Content = "Add";
                TextboxDescription.IsReadOnly = true;
                TextboxCategoryId.IsReadOnly = true;
                
                var brush = new BrushConverter();
                TextboxDescription.Background = (Brush)brush.ConvertFrom("#0A84FF");

                int.TryParse(TextboxCategoryId.Text, out int categoryId);

                var taskToAdd = new Task()
                {
                    Description = TextboxDescription.Text,
                    CategoryID = categoryId
                };
                using (var db = new TasksDBEntities())
                {
                    db.Tasks.Add(taskToAdd);
                }
            }
        }
    }
}
