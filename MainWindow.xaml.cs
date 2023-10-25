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

namespace EersteWPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Application.Current.Resources.MergedDictionaries.Clear();
        }

        private char[] azertyCharacters = new char[]
        {
            '²', '&', 'é', '"', '\'', '(', '§', 'è', '!', 'ç', 'à', ')', '-',
            'a', 'z', '^', '$', 'µ',
            'q', 'm', 'ù',
            'w', ',', ';', ':', '='
        };
        private char[] qwertyCharacters = new char[]
        {
            '`', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '-', '=',
            'q', 'w', '[', ']', '\\',
            'a', ';', '\'',
            'z', 'm', ',', '.', '/'
        };

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            string inputStr = userInputText.Text;
            string outputStr = "";

            char[] inputCodeChars;
            char[] outputCodeChars;

            // de juiste arrays toekennen (azerty <-> qwerty omzetten))
            inputCodeChars = azertyCharacters;
            outputCodeChars = qwertyCharacters;

            // de invoer string per karakter overlopen en omzetten indien het kan
            for (int i = 0; i < inputStr.Length; i++)
            {
                if (inputCodeChars.Contains(inputStr[i]))
                {
                    outputStr += outputCodeChars[Array.IndexOf(inputCodeChars, inputStr[i])];
                }
                else
                {
                    outputStr += inputStr[i];
                }
            }

            outputConversionTBl.Text = outputStr;

        }

        private void DarkModeCB_Clicked(object sender, RoutedEventArgs e)
        {
            if (DarkModeCb.IsChecked is true)
            {
                this.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#222222");
                //Application.Current.Resources.MergedDictionaries.Source = new Uri("Themes/DarkTheme.xaml", UriKind.Relative);
                Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Themes/DarkTheme.xaml", UriKind.Relative) });

            }
            else
            {
                this.Background = Brushes.White;
                Application.Current.Resources.MergedDictionaries.Clear();
            }
        }

        private void darkMode_CB_Checked(object sender, RoutedEventArgs e)
        {
        }
    }
}
