using Microsoft.Win32;
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

namespace App_Lab_Interfaces.Lab_2
{
    public partial class MainWindow : Window
    {
        public static RoutedCommand ClearTextCommand = new RoutedCommand();

        public MainWindow()
        {
            InitializeComponent();

            CommandBinding saveCommand = new CommandBinding(ApplicationCommands.Save, execute_Save, canExecute_Save);
            CommandBindings.Add(saveCommand);

            CommandBinding clearTextCommand = new CommandBinding(ClearTextCommand, execute_ClearText, canExecute_ClearText);
            CommandBindings.Add(clearTextCommand);

            // Додайте обробник події для кнопки "Files"
            filesButton.Click += OpenFileButton_Click;
        }

        private void OpenFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                // Зчитуємо вміст файлу і встановлюємо його у текстове поле
                inputTextBox.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void canExecute_Save(object sender, CanExecuteRoutedEventArgs e)
        {
            if (inputTextBox.Text.Trim().Length > 0) e.CanExecute = true; else e.CanExecute = false;
        }

        private void execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            System.IO.File.WriteAllText("e:\\Учеба\\3 курс\\2\\Інтерфейси\\Lab\\myFile.txt", inputTextBox.Text);
            MessageBox.Show("The file was saved!");
        }

        private void canExecute_ClearText(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true; // Дозволяємо виконання команди
        }

        private void execute_ClearText(object sender, ExecutedRoutedEventArgs e)
        {
            inputTextBox.Text = string.Empty; // Очищаємо текстове поле
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
