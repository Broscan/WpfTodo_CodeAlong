using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfTodo_CodeAlong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Loopa över alla enums
            cbPrios.Items.Add("-- Select Prio --");


            foreach (Priority priority in Enum.GetValues(typeof(Priority)))
            {
                // Lägg till i comboboxen
                //cbPrios.Items.Add(priority.ToString());

                ListViewItem item = new();

                item.Content = priority.ToString();
                item.Tag = priority;

                cbPrios.Items.Add(item);
            }

            cbPrios.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (txtTodo.Text == "")
            {
                //SoundPlayer soundPlayer = new SoundPlayer("tiktok aughhh sound effect (abnormally goofy ahh).WAV");
                //soundPlayer.Play();
                // Visa varning          
                MessageBox.Show("Please add a todo");
            }

            else if (cbPrios.SelectedIndex == 0)
            {
                MessageBox.Show("Please add a priority");
            }
            else
            {

                // Läs innehållet i textboxen
                string todo = txtTodo.Text;

                // Läs vad som är valt i comboboxen


                ListViewItem selectedItem = (ListViewItem)cbPrios.SelectedItem;


                // Skapa en todo
                Todo newTodo = new();
                newTodo.Name = todo;

                newTodo.Priority = (Priority)selectedItem.Tag;


                // Lägg till todon i listview:en

                // Skapa ett tomt ListViewItem

                ListViewItem item = new();

                // Sätt conten och tag på det nya LVI:et
                item.Content = newTodo.GetInfo();
                item.Tag = newTodo;

                // Lägg till item:et till listan
                lstTodos.Items.Add(item);


                //lstTodos.Items.Add(newTodo.GetInfo());



                // Rensa alla inputfält

                txtTodo.Text = "";
                cbPrios.SelectedIndex = 0;
            }

        }






        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            // Kolla vilket item som är selectat i listan
            ListViewItem selectedItem = (ListViewItem)lstTodos.SelectedItem;

            // Ta bort det itemet från listView:en
            lstTodos.Items.Remove(selectedItem);

        }

        private void lstTodos_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            ListViewItem selectedItem = (ListViewItem)lstTodos.SelectedItem;

            if (selectedItem != null)
            {

                Todo selectedTodo = (Todo)selectedItem.Tag;

                lblName.Content = selectedTodo.Name;
                lblPrio.Content = selectedTodo.Priority;
            }
        }
    }
}
