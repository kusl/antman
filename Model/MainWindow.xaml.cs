/*  Wet Kitty Video Talent Information Sheet
 *  Written by: Antonio Piazza
 *  Trinacria Media Productions LLC.
 *  For https://wetkittyvideo.com
 *  
 * This program is for use on the wetkittyvideo.com website.
 * It allows the user to enter information and upload pics which are then
 * saved to themySQL database table.
 * 
*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace TalentInfoSheet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int i = -1;
        string[] imageFileNameArray = new string[10];
        string[] imageFileSafeNameArray = new string[10];
        List<byte[]> listOfbyteArrays = new List<byte[]>();
        byte[] imageFileArray = null;
        String sexString, firstNameString, lastNameString, stageNameString, ageString, heightString, weightString,
            chestString, waistString, hipsString, dressString, shirtString, pantsString, shoeString, phoneString,
            emailString, cityString, stateString, experienceString, soloString, bgString, ggString, bbgString, ggbString,
            groupString, analString, dpString, swallowString, squirtString, bjString, creamPieString, fetishString,
            bondageString, interRacialString;
        String errorMessageString;
        Regex regAlpha = new Regex("^[a-zA-Z]+$");
        Regex regNumbers = new Regex("^[0-9]+$");
        Regex regHeight = new Regex("^[0-9]\'[0-9]+\"$");
        Regex regAlphSpace = new Regex("^[a-zA-Z ]+$");
        Regex regChestFem = new Regex("^[0-9]{1,2}[a-zA-Z]+$");
        Regex regShoe = new Regex("^[1-9]{1,2}.{0,1}[0-9]{0,1}$");
        Regex regNumsSpace = new Regex("^[0-9 ]+$");
        Regex regEmail = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
            + "@"
            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");

        private void uploadCancelButtonClick(object sender, RoutedEventArgs e)
        {
            chosenFileTextBox.Text = "";
            i = -1;
            imageFileArray = null;
            uploadedFilesListBox.Items.Clear();
        }

        private void uploadButtonClick(object sender, RoutedEventArgs e)
        {
            if (i < 2)
            {
                try
                {
                    FileStream fs = new FileStream(imageFileNameArray[i], FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    imageFileArray = br.ReadBytes((int)fs.Length);
                    listOfbyteArrays.Add(imageFileArray);
                    if (chosenFileTextBox.Text != "")
                    {
                        uploadedFilesListBox.Items.Add(imageFileSafeNameArray[i].ToString() + "\n");
                    }
                    chosenFileTextBox.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Conact Administrator: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Only 2 images can be uploaded.");
            }
        }

        private void chooseFileButtonClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                i++;
                string imageFileName = dlg.FileName;
                imageFileSafeNameArray[i] = dlg.SafeFileName;
                imageFileNameArray[i] = dlg.FileName.ToString();
                chosenFileTextBox.Text = imageFileSafeNameArray[i] + "\n";
            }

        }

        private void clearButtonClick(object sender, RoutedEventArgs e)
        {
            firstNameTextBox.Text = String.Empty;
            lastNameTextBox.Text = String.Empty;
            stageNameTextBox.Text = String.Empty;
            ageTextBox.Text = String.Empty;
            heightTextBox.Text = String.Empty;
            weightTextBox.Text = String.Empty;
            chestTextBox.Text = String.Empty;
            waistTextBox.Text = String.Empty;
            hipsTextBox.Text = String.Empty;
            dressTextBox.Text = String.Empty;
            shirtTextBox.Text = String.Empty;
            pantsTextBox.Text = String.Empty;
            shoeTextBox.Text = String.Empty;
            phoneTextBox.Text = String.Empty;
            emailTextBox.Text = String.Empty;
            cityTextBox.Text = String.Empty;
            experienceTextBox.Text = String.Empty;
            uploadedFilesListBox.Items.Clear();
            chosenFileTextBox.Text = "";
            stateComboBox.SelectedIndex = -1;
            maleRadio.IsChecked = false;
            femaleRadio.IsChecked = false;
            soloCheckBox.IsChecked = false;
            bgCheckBox.IsChecked = false;
            ggCheckBox.IsChecked = false;
            bbgCheckBox.IsChecked = false;
            ggbCheckBox.IsChecked = false;
            groupCheckBox.IsChecked = false;
            analCheckBox.IsChecked = false;
            dpCheckBox.IsChecked = false;
            swallowCheckBox.IsChecked = false;
            squirtCheckBox.IsChecked = false;
            bjCheckBox.IsChecked = false;
            creamPieCheckBox.IsChecked = false;
            fetishCheckBox.IsChecked = false;
            bondageCheckBox.IsChecked = false;
            interRacialCheckBox.IsChecked = false;
            imageFileArray = null;
            i = -1;
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            GetErrorMessageString();

            if (errorMessageString == null)
            {
                DBConnect openConnection = new DBConnect(sexString, firstNameString, lastNameString, stageNameString, ageString, heightString, weightString,
                    chestString, waistString, hipsString, dressString, shirtString, pantsString, shoeString, phoneString,
                    emailString, cityString, stateString, experienceString, soloString, bgString, ggString, bbgString, ggbString,
                    groupString, analString, dpString, swallowString, squirtString, bjString, creamPieString, fetishString, bondageString, interRacialString, listOfbyteArrays);
                MessageBox.Show("Thank you for your submission!  If we decide that you are a fit for an upcoming production we will contact you." +
                    " If you have any questions email us at admin@wetkittyvideo.com");
                Application curApp = Application.Current;
                curApp.Shutdown();
            }
        }

        private void cancelButtonClick(object sender, RoutedEventArgs e)
        {
            Application curApp = Application.Current;
            curApp.Shutdown();
        }

        public string GetErrorMessageString()
        {
            String sexErrorString, firstNameErrorString, lastNameErrorString, stageNameErrorString, ageErrorString, heightErrorString, weightErrorString,
                waistErrorString, hipsErrorString, dressErrorString, shirtErrorString, pantsErrorString, shoeErrorString, phoneErrorString,
                emailErrorString, cityErrorString, stateErrorString, experienceErrorString, checkBoxErrorString, imageCountErrorString;
            String errorMessageString;
            String chestErrorString = null;

            Boolean errorMessage = false;

            if (maleRadio.IsChecked.Equals(true))
            {
                sexString = "Male";
                sexErrorString = null;
            }
            else if (femaleRadio.IsChecked.Equals(true))
            {
                sexString = "Female";
                sexErrorString = null;
            }
            else
            {
                sexString = null;
                sexErrorString = "Check either 'Male' or 'Female' radio button\n\n";
                errorMessage = true;
            }

            if (firstNameTextBox.Text == "" || firstNameTextBox.Text.Length > 25 ||
                !regAlpha.IsMatch(firstNameTextBox.Text))
            {
                firstNameErrorString = "First Name: Type your first name.  Must be less than 25 characters long with no spaces, numbers, or special " +
                    "characters\n\n";
                firstNameString = null;
                errorMessage = true;
            }
            else
            {
                firstNameErrorString = null;
                firstNameString = firstNameTextBox.Text;
            }

            if (lastNameTextBox.Text == "" || lastNameTextBox.Text.Length > 25 ||
                !regAlpha.IsMatch(lastNameTextBox.Text))
            {
                lastNameErrorString = "Last Name: Type your last name.  Must be less than 25 characters long with no spaces, numbers, or special " +
                "characters.\n\n";
                lastNameString = null;
                errorMessage = true;
            }
            else
            {
                lastNameErrorString = null;
                lastNameString = lastNameTextBox.Text;
            }

            if (stageNameTextBox.Text.Length > 55 || !regAlphSpace.IsMatch(stageNameTextBox.Text))
            {
                stageNameErrorString = "Stage Name: Stage Name must be 55 charcters or less with no special characters.\n\n";
                stageNameString = null;
                errorMessage = true;
            }
            else
            {
                stageNameString = stageNameTextBox.Text;
                stageNameErrorString = null;
            }

            if (ageTextBox.Text.Length > 3 || ageTextBox.Text == "" || !regNumbers.IsMatch(ageTextBox.Text) ||
                Convert.ToInt32(ageTextBox.Text) < 18)
            {
                ageErrorString = "Age: Enter Age.  Must be numbers only and no more than 3 characters long.\n\n";
                ageString = null;
                errorMessage = true;
            }
            else
            {
                ageString = ageTextBox.Text;
                ageErrorString = null;
            }

            if (heightTextBox.Text == "" || heightTextBox.Text.Length > 5 ||
                !regHeight.IsMatch(heightTextBox.Text))
            {
                heightErrorString = "Height: Enter height in feet and whole inches with no spaces rounding inches up i.e., 5\''10\".\n\n";
                heightString = null;
                errorMessage = true;
            }
            else
            {
                heightString = heightTextBox.Text;
                heightErrorString = null;
            }

            if (weightTextBox.Text == "" || weightTextBox.Text.Length > 3 ||
                !regNumbers.IsMatch(weightTextBox.Text))
            {
                weightErrorString = "Weight: Enter weight in pounds, in whole numbers only, no spaces, no special characters and " +
                    "no more than 3 characters long\n\n";
                weightString = null;
                errorMessage = true;
            }
            else
            {
                weightString = weightTextBox.Text;
                weightErrorString = null;
            }
            if (femaleRadio.IsChecked.Equals(true))
            {
                if (chestTextBox.Text == "" || chestTextBox.Text.Length > 4 ||
                    !regChestFem.IsMatch(chestTextBox.Text))
                {
                    chestErrorString = "Chest:  Enter chest size in inches and cup size with no spaces or special characters no more than 4 " +
                    "characters long i.e. 34DD.\n\n";
                    chestString = null;
                    errorMessage = true;
                }
                else
                {
                    chestString = chestTextBox.Text;
                    chestErrorString = null;
                }
            }
            else if (maleRadio.IsChecked.Equals(true))
            {
                if (chestTextBox.Text == "" || chestTextBox.Text.Length > 2 ||
                    !regNumbers.IsMatch(chestTextBox.Text))
                {
                    chestErrorString = "Chest:  Enter chest size in inches with no spaces or special characters no more than 2 " +
                    "characters long i.e., 34.\n\n";
                    chestString = null;
                    errorMessage = true;
                }
                else
                {
                    chestString = chestTextBox.Text;
                    chestErrorString = null;
                }
            }


            if (waistTextBox.Text == "" || waistTextBox.Text.Length > 2 || !regNumbers.IsMatch(waistTextBox.Text))
            {
                waistErrorString = "Waist:  Enter waist size in inches with no special characters or spaces and no more than 2 characters in length.\n\n";
                waistString = null;
                errorMessage = true;
            }
            else
            {
                waistString = waistTextBox.Text;
                waistErrorString = null;
            }

            if (hipsTextBox.Text == "" || hipsTextBox.Text.Length > 2 || !regNumbers.IsMatch(hipsTextBox.Text))
            {
                hipsErrorString = "Hips:  Enter hips size in inches with numbers only, no spaces or special characters and no more than 2 " +
                    "characters long.\n\n";
                hipsString = null;
                errorMessage = true;
            }
            else
            {
                hipsString = hipsTextBox.Text;
                hipsErrorString = null;
            }

            if (dressTextBox.IsEnabled.Equals(true))
            {
                if (dressTextBox.Text == "" || dressTextBox.Text.Length > 2 || !regNumbers.IsMatch(dressTextBox.Text))
                {
                    dressErrorString = "Dress:  Enter dress size in numbers only, no more than 2 characters long.\n\n";
                    dressString = null;
                    errorMessage = true;
                }
                else
                {
                    dressString = dressTextBox.Text;
                    dressErrorString = null;
                }
            }
            else
            {
                dressString = null;
                dressErrorString = null;
            }

            if (pantsTextBox.Text == "" || pantsTextBox.Text.Length > 5 || !regNumsSpace.IsMatch(pantsTextBox.Text))
            {
                pantsErrorString = "Pants:  Enter pants size in numbers only.  Men add a space between waist and length.  No more than 5 characters.\n\n";
                pantsString = null;
                errorMessage = true;
            }
            else
            {
                pantsString = pantsTextBox.Text;
                pantsErrorString = null;
            }

            if (shirtTextBox.Text == "" || shirtTextBox.Text.Length > 4 || !regAlpha.IsMatch(shirtTextBox.Text))
            {
                shirtErrorString = "Shirt:  Enter shirt size using letters only, no numbers, spaces or special characters i.e., XL.\n\n";
                shirtString = null;
                errorMessage = true;
            }
            else
            {
                shirtString = shirtTextBox.Text;
                shirtErrorString = null;
            }

            if (shoeTextBox.Text == "" || shoeTextBox.Text.Length > 4 || !regShoe.IsMatch(shoeTextBox.Text))
            {
                shoeErrorString = "Shoe:  Enter shoe size.  No letters or spaces and no more than 4 characters i.e., 10.5.\n\n";
                shoeString = null;
                errorMessage = true;
            }
            else
            {
                shoeString = shoeTextBox.Text;
                shoeErrorString = null;
            }

            if (phoneTextBox.Text == "" || phoneTextBox.Text.Length > 10 ||
                !regNumbers.IsMatch(phoneTextBox.Text))
            {
                phoneErrorString = "Phone: Enter phone number using numbers only, no spaces or special characters and no more than 10 characters, " +
                    "area code first i.e., 5551115555.\n\n";
                phoneString = null;
                errorMessage = true;
            }
            else
            {
                phoneString = phoneTextBox.Text;
                phoneErrorString = null;
            }

            if (emailTextBox.Text == "" || emailTextBox.Text.Length > 100 ||
                !regEmail.IsMatch(emailTextBox.Text))
            {
                emailErrorString = "Email: Enter a valid email address.  No more than 100 characters.\n\n";
                emailString = null;
                errorMessage = true;
            }
            else
            {
                emailString = emailTextBox.Text;
                emailErrorString = null;
            }

            if (cityTextBox.Text == "" || cityTextBox.Text.Length > 50 ||
                !regAlphSpace.IsMatch(cityTextBox.Text))
            {
                cityErrorString = "City:  Enter the city you live in using no special characters.  No more than 50 characters long.\n\n";
                cityString = null;
                errorMessage = true;
            }
            else
            {
                cityString = cityTextBox.Text;
                cityErrorString = null;
            }

            if (stateComboBox.SelectedItem == null)
            {
                stateErrorString = "State:  Select the state that you live in.\n\n";
                stateString = null;
                errorMessage = true;
            }
            else
            {
                stateString = stateComboBox.Text;
                stateErrorString = null;
            }

            if (experienceTextBox.Text.Length > 500)
            {
                experienceErrorString = "Experience:  Enter no more than 500 characters.\n\n";
                experienceString = null;
                errorMessage = true;
            }
            else
            {
                experienceString = experienceTextBox.Text;
                experienceErrorString = null;
            }

            if (i < 1 || i > 3)
            {
                errorMessage = true;
                imageCountErrorString = "Images:  You must upload at least 2 images and no more than 3.";
            }
            else
            {
                imageCountErrorString = null;
            }

            if (soloCheckBox.IsChecked == true)
            {
                soloString = "Yes";
            }
            else
            {
                soloString = "No";
            }

            if (bgCheckBox.IsChecked == true)
            {
                bgString = "Yes";
            }
            else
            {
                bgString = "No";
            }

            if (ggCheckBox.IsChecked == true)
            {
                ggString = "Yes";
            }
            else
            {
                ggString = "No";
            }

            if (bbgCheckBox.IsChecked == true)
            {
                bbgString = "Yes";
            }
            else
            {
                bbgString = "No";
            }

            if (ggbCheckBox.IsChecked == true)
            {
                ggbString = "Yes";
            }
            else
            {
                ggbString = "No";
            }

            if (groupCheckBox.IsChecked == true)
            {
                groupString = "Yes";
            }
            else
            {
                groupString = "No";
            }

            if (analCheckBox.IsChecked == true)
            {
                analString = "Yes";
            }
            else
            {
                analString = "No";
            }

            if (dpCheckBox.IsChecked == true)
            {
                dpString = "Yes";
            }
            else
            {
                dpString = "No";
            }

            if (swallowCheckBox.IsChecked == true)
            {
                swallowString = "Yes";
            }
            else
            {
                swallowString = "No";
            }

            if (squirtCheckBox.IsChecked == true)
            {
                squirtString = "Yes";
            }
            else
            {
                squirtString = "No";
            }

            if (bjCheckBox.IsChecked == true)
            {
                bjString = "Yes";
            }
            else
            {
                bjString = "No";
            }

            if (creamPieCheckBox.IsChecked == true)
            {
                creamPieString = "Yes";
            }
            else
            {
                creamPieString = "No";
            }

            if (fetishCheckBox.IsChecked == true)
            {
                fetishString = "Yes";
            }
            else
            {
                fetishString = "No";
            }

            if (bondageCheckBox.IsChecked == true)
            {
                bondageString = "Yes";
            }
            else
            {
                bondageString = "No";
            }

            if (interRacialCheckBox.IsChecked == true)
            {
                interRacialString = "Yes";
            }
            else
            {
                interRacialString = "No";
            }

            if (soloCheckBox.IsChecked.Equals(false) && bgCheckBox.IsChecked.Equals(false) &&
                ggCheckBox.IsChecked.Equals(false) && bbgCheckBox.IsChecked.Equals(false) &&
                ggbCheckBox.IsChecked.Equals(false) && groupCheckBox.IsChecked.Equals(false) &&
                analCheckBox.IsChecked.Equals(false) && dpCheckBox.IsChecked.Equals(false) &&
                swallowCheckBox.IsChecked.Equals(false) && squirtCheckBox.IsChecked.Equals(false) &&
                bjCheckBox.IsChecked.Equals(false) && creamPieCheckBox.IsChecked.Equals(false) &&
                fetishCheckBox.IsChecked.Equals(false) && bondageCheckBox.IsChecked.Equals(false) &&
                interRacialCheckBox.IsChecked.Equals(false))
            {
                errorMessage = true;
                checkBoxErrorString = "Availability:  Check one or more boxes that apply\n\n";
            }
            else
            {
                checkBoxErrorString = null;
            }

            if (errorMessage == true)
            {
                errorMessageString = "Fix the following errors: \n\n";
                if (sexErrorString != null)
                {
                    errorMessageString += sexErrorString;
                }
                if (firstNameErrorString != null)
                {
                    errorMessageString += firstNameErrorString;
                }
                if (lastNameErrorString != null)
                {
                    errorMessageString += lastNameErrorString;
                }
                if (stageNameErrorString != null)
                {
                    errorMessageString += stageNameErrorString;
                }
                if (ageErrorString != null)
                {
                    errorMessageString += ageErrorString;
                }
                if (heightErrorString != null)
                {
                    errorMessageString += heightErrorString;
                }
                if (weightErrorString != null)
                {
                    errorMessageString += weightErrorString;
                }
                if (chestErrorString != null)
                {
                    errorMessageString += chestErrorString;
                }
                if (waistErrorString != null)
                {
                    errorMessageString += waistErrorString;
                }
                if (hipsErrorString != null)
                {
                    errorMessageString += hipsErrorString;
                }
                if (dressErrorString != null)
                {
                    errorMessageString += dressErrorString;
                }
                if (shirtErrorString != null)
                {
                    errorMessageString += shirtErrorString;
                }
                if (pantsErrorString != null)
                {
                    errorMessageString += pantsErrorString;
                }
                if (shoeErrorString != null)
                {
                    errorMessageString += shoeErrorString;
                }
                if (phoneErrorString != null)
                {
                    errorMessageString += phoneErrorString;
                }
                if (emailErrorString != null)
                {
                    errorMessageString += emailErrorString;
                }
                if (cityErrorString != null)
                {
                    errorMessageString += cityErrorString;
                }
                if (stateErrorString != null)
                {
                    errorMessageString += stateErrorString;
                }
                if (experienceErrorString != null)
                {
                    errorMessageString += experienceErrorString;
                }
                if (checkBoxErrorString != null)
                {
                    errorMessageString += checkBoxErrorString;
                }
                if (imageCountErrorString != null)
                {
                    errorMessageString += imageCountErrorString;
                }

                MessageBox.Show(errorMessageString);
            }
            else
            {
                errorMessageString = "";
            }

            return errorMessageString;
            return sexString;
            return firstNameString;
            return lastNameString;
            return stageNameString;
            return ageString;
            return heightString;
            return weightString;
            return chestString;
            return waistString;
            return hipsString;
            return dressString;
            return shirtString;
            return pantsString;
            return shoeString;
            return phoneString;
            return emailString;
            return cityString;
            return stateString;
            return experienceString;
            return soloString;
            return bgString;
            return ggString;
            return bbgString;
            return ggbString;
            return groupString;
            return analString;
            return dpString;
            return swallowString;
            return squirtString;
            return bjString;
            return creamPieString;
            return fetishString;
            return bondageString;
            return interRacialString;
        }

        private void experienceTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            int remainingCharsInt = experienceTextBox.MaxLength - experienceTextBox.Text.Length;
            String remainingCharsString = remainingCharsInt.ToString();
            remainingCharsLabel.Content = "Remaining: " + remainingCharsString;
        }
    }
}

class DBConnect : IDisposable
{
    //private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    public void Dispose()
    {
        //if (connection != null)
        //{
        //    connection.Dispose(); connection = null;
        //}
    }

    //Constructor
    public DBConnect(String sexString, String firstNameString, String lastNameString,
        String stageNameString, String ageString, String heightString, String weightString,
        String chestString, String waistString, String hipsString, String dressString,
        String shirtString, String pantsString, String shoeString, String phoneString,
        String emailString, String cityString, String stateString, String experienceString,
        String soloString, String bgString, String ggString, String bbgString, String ggbString,
        String groupString, String analString, String dpString, String swallowString, String squirtString,
        String bjString, String creamPieString, String fetishString, String bondageString, String interRacialString, List<byte[]> listOfbyteArrays)
    {

        Initialize();
        Insert(sexString, firstNameString, lastNameString, stageNameString, ageString, heightString, weightString,
        chestString, waistString, hipsString, dressString, shirtString, pantsString, shoeString, phoneString,
        emailString, cityString, stateString, experienceString, soloString, bgString, ggString, bbgString, ggbString,
        groupString, analString, dpString, swallowString, squirtString, bjString, creamPieString, fetishString, bondageString, interRacialString, listOfbyteArrays);
    }

    //Initialize values
    private void Initialize()
    {
        server = "localhost";
        database = "infosheet";
        uid = "user";
        password = "password";

        string connectionString;
        connectionString = "server=" + server + ";" + "uid=" + uid + ";" + "pwd=" + password + ";" + "database=" +
        database + ";";

        //connection = new MySqlConnection(connectionString);
    }

    //open connection to database
    private bool OpenConnection()
    {
        try
        {
            //connection.Open();
            return true;
        }
        catch (Exception ex)
        {
            //When handling errors, you can your application's response based 
            //on the error number.
            //The two most common error numbers when connecting are as follows:
            //0: Cannot connect to server.
            //1045: Invalid user name and/or password.

            //MessageBox.Show(ex.Number + " Connection Error.  Contact Amdinistrator");
            return false;
        }
    }

    //Close connection
    private bool CloseConnection()
    {
        try
        {
            //connection.Close();
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Contact Administrator: " + ex.Message);
            return false;
        }
    }

    //Insert statement
    public void Insert(String sexString, String firstNameString, String lastNameString,
        String stageNameString, String ageString, String heightString, String weightString,
        String chestString, String waistString, String hipsString, String dressString,
        String shirtString, String pantsString, String shoeString, String phoneString,
        String emailString, String cityString, String stateString, String experienceString,
        String soloString, String bgString, String ggString, String bbgString, String ggbString,
        String groupString, String analString, String dpString, String swallowString, String squirtString,
        String bjString, String creamPieString, String fetishString, String bondageString,
        String interRacialString, List<byte[]> listOfbyteArrays)
    {
        String dateString = DateTime.Today.ToString();
        string query = "INSERT INTO talentinfotable(_Date, Sex, FirstName, LastName, StageName, " +
            "Age, Height, Weight, Chest, Waist, Hips, Dress, Shirt, Pants, Shoe, Phone, " +
            "Email, City, _State, Experience, Solo, BG, GG, BBG, GGB, _Group, Anal, DP, Swallow, " +
            "Squirt, BJ, CreamPie, Fetish, Bondage, InterRacial, Image1, Image2) VALUES(?_Date, ?Sex, ?FirstName, ?LastName, " +
            "?StageName, ?Age, ?Height, ?Weight, ?Chest, ?Waist, ?Hips, ?Dress, ?Shirt, ?Pants, ?Shoe, " +
            "?Phone, ?Email, ?City, ?_State, ?Experience, ?Solo, ?BG, ?GG, ?BBG, ?GGB, ?_Group, ?Anal, " +
            "?DP, ?Swallow, ?Squirt, ?BJ, ?CreamPie, ?Fetish, ?Bondage, ?InterRacial, ?Image1, ?Image2)";

        //open connection
        if (this.OpenConnection() == true)
        {
            //create command and assign the query and connection from the constructor
            try
            {
                //MySqlCommand cmd = new MySqlCommand(query, connection);
                //cmd.Parameters.Add("?_Date", MySqlDbType.VarChar).Value = dateString;
                //cmd.Parameters.Add("?Sex", MySqlDbType.Text).Value = sexString;
                //cmd.Parameters.Add("?FirstName", MySqlDbType.Text).Value = firstNameString;
                //cmd.Parameters.Add("?LastName", MySqlDbType.Text).Value = lastNameString;
                //cmd.Parameters.Add("?StageName", MySqlDbType.VarChar).Value = stageNameString;
                //cmd.Parameters.Add("?Age", MySqlDbType.Text).Value = ageString;
                //cmd.Parameters.Add("?Height", MySqlDbType.VarChar).Value = heightString;
                //cmd.Parameters.Add("?weight", MySqlDbType.Text).Value = weightString;
                //cmd.Parameters.Add("?Chest", MySqlDbType.Text).Value = chestString;
                //cmd.Parameters.Add("?Waist", MySqlDbType.Text).Value = waistString;
                //cmd.Parameters.Add("?Hips", MySqlDbType.Text).Value = hipsString;
                //cmd.Parameters.Add("?Dress", MySqlDbType.Text).Value = dressString;
                //cmd.Parameters.Add("?Shirt", MySqlDbType.Text).Value = shirtString;
                //cmd.Parameters.Add("?Pants", MySqlDbType.VarChar).Value = pantsString;
                //cmd.Parameters.Add("?Shoe", MySqlDbType.VarChar).Value = shoeString;
                //cmd.Parameters.Add("?Email", MySqlDbType.VarChar).Value = emailString;
                //cmd.Parameters.Add("?Phone", MySqlDbType.VarChar).Value = phoneString;
                //cmd.Parameters.Add("?City", MySqlDbType.Text).Value = cityString;
                //cmd.Parameters.Add("?_State", MySqlDbType.Text).Value = stateString;
                //cmd.Parameters.Add("?Experience", MySqlDbType.VarChar).Value = experienceString;
                //cmd.Parameters.Add("?Solo", MySqlDbType.Text).Value = soloString;
                //cmd.Parameters.Add("?BG", MySqlDbType.Text).Value = bgString;
                //cmd.Parameters.Add("?GG", MySqlDbType.Text).Value = ggString;
                //cmd.Parameters.Add("?BBG", MySqlDbType.Text).Value = bbgString;
                //cmd.Parameters.Add("?GGB", MySqlDbType.Text).Value = ggbString;
                //cmd.Parameters.Add("?_Group", MySqlDbType.Text).Value = groupString;
                //cmd.Parameters.Add("?Anal", MySqlDbType.Text).Value = analString;
                //cmd.Parameters.Add("?DP", MySqlDbType.Text).Value = dpString;
                //cmd.Parameters.Add("?Swallow", MySqlDbType.Text).Value = swallowString;
                //cmd.Parameters.Add("?Squirt", MySqlDbType.Text).Value = squirtString;
                //cmd.Parameters.Add("?BJ", MySqlDbType.Text).Value = bjString;
                //cmd.Parameters.Add("?CreamPie", MySqlDbType.Text).Value = creamPieString;
                //cmd.Parameters.Add("?Fetish", MySqlDbType.Text).Value = fetishString;
                //cmd.Parameters.Add("?Bondage", MySqlDbType.Text).Value = bondageString;
                //cmd.Parameters.Add("?InterRacial", MySqlDbType.Text).Value = interRacialString;
                //cmd.Parameters.Add("?Image1", MySqlDbType.Blob).Value = listOfbyteArrays[0];
                //cmd.Parameters.Add("?Image2", MySqlDbType.Blob).Value = listOfbyteArrays[1];

                ////Execute command
                //cmd.ExecuteNonQuery();

                ////close connection
                //this.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Contact Administrator: " + ex.Message);
            }
        }
    }

}

