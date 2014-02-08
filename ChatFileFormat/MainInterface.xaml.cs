using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Data;
using System.Text.RegularExpressions;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainInterface : Window
    {
        public string textForFile;
        public DataTable personTable = new DataTable();
        OpenFileDialog openFileControl = new OpenFileDialog();
        public MainInterface()
        {
            InitializeComponent();

            dateBox.Text = DateTime.Now.AddDays(-1).ToShortDateString();
        }

        public Dictionary<int, string> GetChoices()
        {
            Dictionary<int, string> choices = new Dictionary<int, string>();
            choices.Add(1, "KaiTukov: ##110481|");
            choices.Add(2, "YaraSherred:  ##666666| ");
            choices.Add(3, "Guylian:  ##208020| ");
            choices.Add(4, "DamianStark:  ##800000| ");
            choices.Add(5, "BlackSmith:  ##800000| ");
            choices.Add(6, "KT4313ST:  ##103010| ");
            choices.Add(7, "NivoseST:  ##555555| ");
            return choices;
        }

        private void OpenDialog(object sender, RoutedEventArgs e)
        {
            // Create an instance of the open file dialog box.
            
            
            // Set filter options and filter index.
            openFileControl.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
            openFileControl.FilterIndex = 1;

            openFileControl.Multiselect = false;

            

            // Call the ShowDialog method to show the dialog box.
            bool? userClickedOK = openFileControl.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == true)
            {
                ManipulateText(openFileControl);
            }
            
        }

        private void ManipulateText(OpenFileDialog openFileControl)
        {
            
            LoadFromForm();
            fileNameBox.Text = openFileControl.FileName.ToString();
            
            StringBuilder sb = ComposeText(openFileControl);
            TempStorage.fileTextContents.Clear();
            TempStorage.fileTextContents.Append(sb.ToString());
        }

        private StringBuilder ComposeText(OpenFileDialog openFileControl)
        {
            //Need to do the name swap HERE, with line start.
            
            StringBuilder sb = new StringBuilder();

            string regexPattern = @"^[0-9]:[0-9][0-9]";
            Regex regexerPassOne = new Regex(regexPattern);
            regexPattern = @"^[0-9][0-9]:[0-9][0-9]\s";
            Regex regexerPassTwo = new Regex(regexPattern);
            regexPattern = @"\*\s([A-z]*)";
            Regex regexerPassThree = new Regex(regexPattern);
            regexPattern = @"[\+]";
            Regex regexerPassFour = new Regex(regexPattern);
            using (StreamReader sr = new StreamReader(openFileControl.FileName.ToString()))
            {

                while (sr.Peek() >= 0)
                {
                    string tempString = string.Empty;
                    tempString += (sr.ReadLine()).ToString();
                    //sb.Append(sr.ReadLine());
                    tempString = (regexerPassOne.Replace(tempString, "00:00"));
                    tempString = (regexerPassTwo.Replace(tempString, string.Empty));
                    if (regexerPassThree.IsMatch(tempString) || regexerPassFour.IsMatch(tempString))
                    {
                        tempString = string.Empty;
                    }

                    
                    //Method Call
                    tempString = TextTranformation.PersonReplace(tempString);

                    if (tempString.Trim() != string.Empty)
                    {
                        sb.Append(tempString + (" ## \r\n"));
                    }
                }

            }
            return sb;
        }

        private StringBuilder ComposeHeader(StringBuilder sbHeader)
        {

            //Pull stuff from item lists
            for (int i = 0; i < npcListBox.Items.Count; i++)
            {
                TempStorage.npcList.Add(npcListBox.Items[i].ToString());
            }

            for (int i = 0; i < MainLocationListBox.Items.Count; i++)
            {
                TempStorage.mainLocations.Add(MainLocationListBox.Items[i].ToString());
            }

            for (int i = 0; i < SublocationListBox.Items.Count; i++)
            {
                TempStorage.subLocations.Add(SublocationListBox.Items[i].ToString());
            }
            //Add Header

            sbHeader.Append("++ Type \r\n");
            sbHeader.Append(typeBox.Text + "\r\n\r\n");
            sbHeader.Append("++ Date \r\n");
            sbHeader.Append(dateBox.Text + "\r\n\r\n");
            if (TempStorage.mainLocations.Count > 0)
            {
                sbHeader.Append("++ Main Locations \r\n");
                for (int i = 0; i < TempStorage.mainLocations.Count; i++)
                {
                    sbHeader.Append("* " + TempStorage.mainLocations[i].ToString() + "\r\n");
                }
                sbHeader.Append("\r\n");
            }
            if (TempStorage.subLocations.Count > 0)
            {
                sbHeader.Append("++ Sublocations \r\n");
                for (int i = 0; i < TempStorage.subLocations.Count; i++)
                {
                    sbHeader.Append("* " + TempStorage.subLocations[i].ToString() + "\r\n");
                }
                sbHeader.Append("\r\n");
            }
            if (TempStorage.npcList.Count > 0)
            {
                sbHeader.Append("++ NPCs Involved \r\n");
                for (int i = 0; i < TempStorage.npcList.Count; i++)
                {
                    sbHeader.Append("* " + TempStorage.npcList[i].ToString() + "\r\n");
                }
                sbHeader.Append("\r\n");
            }
            return sbHeader;
        }

        private void LoadFromForm()
        {
            TempStorage.enteredNameOne = personOne.Text;
            TempStorage.enteredNameTwo = personTwo.Text;
            TempStorage.enteredNameThree = personThree.Text;
            TempStorage.enteredNameFour = personFour.Text;
            TempStorage.storyTellerCheckOne = STOne.IsChecked;
            TempStorage.storyTellerCheckTwo = STTwo.IsChecked;
            TempStorage.storyTellerCheckThree = STThree.IsChecked;
            TempStorage.storyTellerCheckFour = STFour.IsChecked;
        }

        private void richTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if (personOne.Text != string.Empty || personTwo.Text != string.Empty || personThree.Text != string.Empty || personFour.Text != string.Empty)
            {
                SaveFileDialog saveFileControl = new SaveFileDialog();
                saveFileControl.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
                saveFileControl.FilterIndex = 1;

                saveFileControl.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileControl.FileName != "")
                {
                    File.WriteAllText(saveFileControl.FileName, textForFile.ToString());
                }
            }
            else
            {
                MessageBox.Show("Notice", "Please enter at least one character.");
            }
            
        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void STAll_Checked(object sender, RoutedEventArgs e)
        {
            if (STOne.IsChecked == true)
            {
                personOne.Text = "ST4313";
            }
            else
            {
                personOne.Text = "Kai_Tukov";
            }
            if (STTwo.IsChecked == true)
            {
                personTwo.Text = "YaraST";
            }
            else
            {
                personTwo.Text = "YaraSherred";
            }
            if (STThree.IsChecked == true)
            {
                personThree.Text = "BlackSmith";
            }
            else
            {
                personThree.Text = "DamianStark";
            }
        }



        private void button2_Click(object sender, RoutedEventArgs e)
        {
            MainLocationListBox.Items.Add(mainLocationsBox.Text);
            mainLocationsBox.Clear();
        }

        private void button2_Click_1(object sender, RoutedEventArgs e)
        {
            SublocationListBox.Items.Add(subLocationBox.Text);
            subLocationBox.Clear();
        }


        private void npcAdd_Click(object sender, RoutedEventArgs e)
        {
            npcListBox.Items.Add(npcBox.Text);
            npcBox.Clear();
        }

        private void personOne_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UpdateText_Click(object sender, RoutedEventArgs e)
        {
            string holder;
            ClearCollections();
            StringBuilder sbHeader = new StringBuilder();
            sbHeader = ComposeHeader(sbHeader);
            holder = TempStorage.fileTextContents.ToString();//TextTranformation.PersonReplace(TempStorage.fileTextContents.ToString());
            mainTextBox.Text = textForFile = sbHeader.ToString() + holder;
        }

        private void ClearText_Click(object sender, RoutedEventArgs e)
        {
            textForFile = string.Empty;
            mainTextBox.Text = string.Empty;
            ClearCollections();
        }

        private static void ClearCollections()
        {
            TempStorage.npcList.Clear();
            TempStorage.mainLocations.Clear();
            TempStorage.subLocations.Clear();
        }



    }
}
