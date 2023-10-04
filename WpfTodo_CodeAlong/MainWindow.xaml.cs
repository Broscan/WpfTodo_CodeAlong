using System;
using System.Media;
using System.Windows;

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
                cbPrios.Items.Add(priority.ToString());
            }
            cbPrios.SelectedIndex = 0;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

            if (txtTodo.Text == "")
            {
                SoundPlayer soundPlayer = new SoundPlayer("tiktok aughhh sound effect (abnormally goofy ahh).WAV");
                soundPlayer.Play();
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


                // Annat sätt att göra det på
                string priority = (string)cbPrios.SelectedItem;

                // Skapa en todo
                Todo newTodo = new();
                newTodo.Name = todo;
                // Hur man konverterar från en enum till en sträng
                newTodo.Priority = (Priority)Enum.Parse(typeof(Priority), priority);


                // Lägg till todon i listview:en

                lstTodos.Items.Add(newTodo.GetInfo());
                // Rensa alla inputfält

                txtTodo.Text = "";
                cbPrios.SelectedIndex = 0;
            }

        }

        private void cbPrios_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}
