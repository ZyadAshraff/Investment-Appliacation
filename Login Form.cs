using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;

namespace InvestApp
{
    /// <summary>
    /// The main login/signup form for the InvestApp application
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Initializes a new instance of the login form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the form load event to set up initial state
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            rb_Login.Checked = true;
            gb_Signup.Enabled = false;
            gb_Login.Enabled = true;
        }

        /// <summary>
        /// Handles the signup radio button checked changed event
        /// </summary>
        private void rb_Signup_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Signup.Checked)
            {
                gb_Signup.Enabled = true;
                gb_Login.Hide();
                gb_Signup.Show();
            }
        }

        /// <summary>
        /// Handles the login radio button checked changed event
        /// </summary>
        private void rb_Login_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Login.Checked)
            {
                gb_Login.Enabled = true;
                gb_Signup.Hide();
                gb_Login.Show();
            }
        }

        /// <summary>
        /// Handles the login button click event
        /// </summary>
        private void bt_login_Click(object sender, EventArgs e)
        {
            string username = tb_Username_Login.Text;
            string password = tb_Password_Login.Text;

            if (AuthManager.Login(username, password))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
                tb_Password_Login.Clear();
                tb_Password_Login.Focus();
            }
        }

        /// <summary>
        /// Handles the signup button click event
        /// </summary>
        private void bt_Signup_Click(object sender, EventArgs e)
        {
            string username = tb_Username_Signup.Text;
            string email = tb_Email_Signup.Text;
            string password = tb_Password_Signup.Text;

            if (AuthManager.SignUp(username, email, password))
            {
                MessageBox.Show("Sign up successful! You can now login.");
                rb_Login.Checked = true;
            }
            else
            {
                MessageBox.Show("Username or email already exists");
            }
        }
    }

    /// <summary>
    /// Manages user authentication including login, signup and logout
    /// </summary>
    public static class AuthManager
    {
        /// <summary>
        /// Gets the currently logged in user
        /// </summary>
        public static User CurrentUser { get; private set; }

        /// <summary>
        /// Attempts to log in a user with the provided credentials
        /// </summary>
        /// <param name="username">The username to login with</param>
        /// <param name="password">The password to login with</param>
        /// <returns>True if login was successful, false otherwise</returns>
        public static bool Login(string username, string password)
        {
            CurrentUser = User.Login(username, password);
            return CurrentUser != null;
        }

        /// <summary>
        /// Attempts to create a new user account
        /// </summary>
        /// <param name="username">The desired username</param>
        /// <param name="email">The user's email address</param>
        /// <param name="password">The desired password</param>
        /// <returns>True if signup was successful, false otherwise</returns>
        public static bool SignUp(string username, string email, string password)
        {
            var newUser = new User(username, email, password);
            if (newUser.SignUp())
            {
                CurrentUser = newUser;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Logs out the current user and clears the session
        /// </summary>
        public static void Logout()
        {
            CurrentUser?.Logout();
            CurrentUser = null;
        }
    }

    /// <summary>
    /// Represents a user of the InvestApp system
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets the user's username
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Gets the user's password (stored in plain text - not secure!)
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Gets the user's email address
        /// </summary>
        public string Email { get; private set; }

        private Portfolio _userPortfolio;

        /// <summary>
        /// Gets the user's investment portfolio (lazy-loaded)
        /// </summary>
        public Portfolio UserPortfolio
        {
            get
            {
                if (_userPortfolio == null)
                    _userPortfolio = new Portfolio(this.UserName);
                return _userPortfolio;
            }
        }

        /// <summary>
        /// Creates a new User instance
        /// </summary>
        /// <param name="username">The user's username</param>
        /// <param name="email">The user's email</param>
        /// <param name="password">The user's password</param>
        public User(string username, string email, string password)
        {
            UserName = username;
            Email = email;
            Password = (password);
        }

        private const string UserDatabase = "Clients.txt";
        private const string Separator = "#//#";

        /// <summary>
        /// Signs up the user by saving their details to the database
        /// </summary>
        /// <returns>True if signup was successful, false if username/email already exists</returns>
        public bool SignUp()
        {
            if (ValidationService.IsUserExists(UserName, Email))
                return false;

            string userRecord = $"{UserName}{Separator}{Email}{Separator}{Password}";
            File.AppendAllText(UserDatabase, userRecord + Environment.NewLine);
            return true;
        }

        /// <summary>
        /// Attempts to log in a user with the provided credentials
        /// </summary>
        /// <param name="username">The username to login with</param>
        /// <param name="password">The password to login with</param>
        /// <returns>User object if login successful, null otherwise</returns>
        public static User Login(string username, string password)
        {
            if (!File.Exists(UserDatabase)) return null;

            foreach (string line in File.ReadLines(UserDatabase))
            {
                string[] parts = line.Split(new[] { Separator }, StringSplitOptions.None);
                if (parts.Length == 3 &&
                    parts[0] == username && parts[2] == password)
                {
                    var user = new User(parts[0], parts[1], parts[2]);
                    user.UserPortfolio.LoadFromFile();
                    return user;
                }
            }
            return null;
        }

        /// <summary>
        /// Logs out the user and saves their portfolio data
        /// </summary>
        public void Logout()
        {
            if (_userPortfolio != null)
            {
                UserPortfolio.SaveToFile();
                _userPortfolio = null;
            }
        }
    }

    /// <summary>
    /// Provides validation services for user data
    /// </summary>
    class ValidationService
    {
        /// <summary>
        /// Checks if a user with the given username or email already exists
        /// </summary>
        /// <param name="username">The username to check</param>
        /// <param name="email">The email to check</param>
        /// <returns>True if user exists, false otherwise</returns>
        public static bool IsUserExists(string username, string email)
        {
            if (!File.Exists("Clients.txt"))
                return false;

            string[] allLines = File.ReadAllLines("Clients.txt");

            foreach (string line in allLines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(new[] { "#//#" }, 3, StringSplitOptions.None);

                if (parts.Length >= 2)
                {
                    string existingUsername = parts[0].Trim();
                    string existingEmail = parts[1].Trim();

                    if (existingUsername.Equals(username, StringComparison.OrdinalIgnoreCase) ||
                        existingEmail.Equals(email, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Validates that an email address is in correct format
        /// </summary>
        /// <param name="email">The email address to validate</param>
        /// <returns>True if email is valid, false otherwise</returns>
        public static bool IsEmailValid(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

    /// <summary>
    /// Represents a user's investment portfolio containing assets
    /// </summary>
    public class Portfolio
    {
        /// <summary>
        /// Gets the owner's username
        /// </summary>
        public string Owner { get; }

        /// <summary>
        /// Gets the list of assets in the portfolio
        /// </summary>
        public List<Asset> Assets { get; } = new List<Asset>();

        /// <summary>
        /// Gets the total value of all assets in the portfolio
        /// </summary>
        public decimal TotalValue => Assets.Sum(a => a.CurrentValue);

        /// <summary>
        /// Gets the total zakat amount due for the portfolio
        /// </summary>
        public decimal TotalZakat => CalculateTotalZakat();

        /// <summary>
        /// Creates a new portfolio for the specified owner
        /// </summary>
        /// <param name="owner">The username of the portfolio owner</param>
        public Portfolio(string owner)
        {
            Owner = owner;
        }

        /// <summary>
        /// Adds an asset to the portfolio
        /// </summary>
        /// <param name="asset">The asset to add</param>
        public void AddAsset(Asset asset)
        {
            Assets.Add(asset);
            SaveToFile();
        }

        /// <summary>
        /// Removes an asset from the portfolio by its ID
        /// </summary>
        /// <param name="assetId">The ID of the asset to remove</param>
        public void RemoveAsset(string assetId)
        {
            Assets.RemoveAll(a => a.Id == assetId);
            SaveToFile();
        }

        /// <summary>
        /// Calculates the total zakat amount due for all eligible assets
        /// </summary>
        /// <returns>The total zakat amount</returns>
        private decimal CalculateTotalZakat()
        {
            return Assets
                .Where(a => a.CurrentValue >= 450000)
                .Sum(a => a.ZakatAmount);
        }

        /// <summary>
        /// Saves the portfolio data to a file
        /// </summary>
        public void SaveToFile()
        {
            string fileName = $"{Owner}Portfolio.txt";
            var lines = Assets.Select(a =>
                $"{a.Id}|{a.Name}|{a.PurchasePrice}|{a.CurrentValue}|" +
                $"{a.AcquisitionDate:yyyy-MM-dd}|{a.Type.Name}|{a.Type.IsHalal}");

            File.WriteAllLines(fileName, lines);
        }

        /// <summary>
        /// Loads the portfolio data from a file
        /// </summary>
        public void LoadFromFile()
        {
            string fileName = $"{Owner}Portfolio.txt";
            if (!File.Exists(fileName)) return;

            Assets.Clear();
            foreach (string line in File.ReadLines(fileName))
            {
                string[] parts = line.Split('|');
                if (parts.Length == 7)
                {
                    var assetType = new AssetType(
                        name: parts[5],
                        isHalal: bool.Parse(parts[6]));

                    Assets.Add(new Asset(
                        id: parts[0],
                        name: parts[1],
                        purchasePrice: decimal.Parse(parts[2]),
                        currentValue: decimal.Parse(parts[3]),
                        acquisitionDate: DateTime.Parse(parts[4]),
                        type: assetType));
                }
            }
        }
    }

    /// <summary>
    /// Represents an investment asset in a portfolio
    /// </summary>
    public class Asset
    {
        /// <summary>
        /// Gets the unique identifier for the asset
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets or sets the name of the asset
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets the original purchase price of the asset
        /// </summary>
        public decimal PurchasePrice { get; private set; }

        /// <summary>
        /// Gets the date the asset was acquired
        /// </summary>
        public DateTime AcquisitionDate { get; private set; }

        /// <summary>
        /// Gets the type of the asset
        /// </summary>
        public AssetType Type { get; private set; }

        /// <summary>
        /// Gets whether zakat is applicable to this asset (value ≥ 450,000)
        /// </summary>
        public bool IsZakatApplicable => CurrentValue >= 450000;

        /// <summary>
        /// Gets or sets the current value of the asset
        /// </summary>
        public decimal CurrentValue { get; set; }

        /// <summary>
        /// Gets the zakat amount due for this asset (2.5% of value if applicable)
        /// </summary>
        public decimal ZakatAmount => IsZakatApplicable ? CurrentValue * 0.025m : 0;

        /// <summary>
        /// Creates a new asset with auto-generated ID and current date
        /// </summary>
        /// <param name="name">The asset name</param>
        /// <param name="purchasePrice">The purchase price</param>
        /// <param name="type">The asset type</param>
        public Asset(string name, decimal purchasePrice, AssetType type)
            : this(Guid.NewGuid().ToString(), name, purchasePrice, purchasePrice, DateTime.Now, type) { }

        /// <summary>
        /// Creates a new asset with all specified properties
        /// </summary>
        /// <param name="id">The asset ID</param>
        /// <param name="name">The asset name</param>
        /// <param name="purchasePrice">The purchase price</param>
        /// <param name="currentValue">The current value</param>
        /// <param name="acquisitionDate">The acquisition date</param>
        /// <param name="type">The asset type</param>
        public Asset(string id, string name, decimal purchasePrice, decimal currentValue,
                    DateTime acquisitionDate, AssetType type)
        {
            Id = id;
            Name = name;
            PurchasePrice = purchasePrice;
            CurrentValue = currentValue;
            AcquisitionDate = acquisitionDate;
            Type = type;
        }

        /// <summary>
        /// Updates the current value of the asset
        /// </summary>
        /// <param name="newValue">The new value to set</param>
        /// <exception cref="ArgumentException">Thrown if newValue is negative</exception>
        public void UpdateValue(decimal newValue)
        {
            if (newValue < 0)
                throw new ArgumentException("Asset value cannot be negative");
            CurrentValue = newValue;
        }

        /// <summary>
        /// Updates multiple properties of the asset
        /// </summary>
        /// <param name="name">The new name</param>
        /// <param name="currentValue">The new current value</param>
        /// <param name="isZakatApplicable">Whether zakat is applicable</param>
        public void UpdateAsset(string name, decimal currentValue, bool isZakatApplicable)
        {
            Name = name;
            CurrentValue = currentValue;
        }
    }

    /// <summary>
    /// Represents a type/category of investment asset
    /// </summary>
    public class AssetType
    {
        /// <summary>
        /// Gets the name of the asset type
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets whether this asset type is considered halal
        /// </summary>
        public bool IsHalal { get; }

        /// <summary>
        /// Gets whether this asset type is eligible for zakat
        /// </summary>
        public bool IsZakatEligible { get; }

        /// <summary>
        /// Gets the risk rating for this asset type
        /// </summary>
        public int RiskRating { get; }

        /// <summary>
        /// Creates a new asset type
        /// </summary>
        /// <param name="name">The type name</param>
        /// <param name="isHalal">Whether the type is halal</param>
        /// <param name="isZakatEligible">Whether the type is zakat eligible (default true)</param>
        public AssetType(string name, bool isHalal, bool isZakatEligible = true)
        {
            Name = name;
            IsHalal = isHalal;
            IsZakatEligible = isZakatEligible;
        }
    }
}