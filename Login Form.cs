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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rb_Login.Checked = true;
            gb_Signup.Enabled = false;
            gb_Login.Enabled = true;
        }

        private void rb_Signup_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Signup.Checked)
            {
                gb_Signup.Enabled = true;
                gb_Login.Hide();
                gb_Signup.Show();
            }
        }

        private void rb_Login_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_Login.Checked)
            {
                gb_Login.Enabled = true;
                gb_Signup.Hide();
                gb_Login.Show();
            }
        }

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

    public static class AuthManager
    {
        public static User CurrentUser { get; private set; }

        public static bool Login(string username, string password)
        {
            CurrentUser = User.Login(username, password);
            return CurrentUser != null;
        }

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

        public static void Logout()
        {
            CurrentUser?.Logout();
            CurrentUser = null;
        }
    }

    public class User
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        private Portfolio _userPortfolio;

        public Portfolio UserPortfolio
        {
            get
            {
                if (_userPortfolio == null)
                    _userPortfolio = new Portfolio(this.UserName);
                return _userPortfolio;
            }
        }

        public User(string username, string email, string password)
        {
            UserName = username;
            Email = email;
            Password = (password);
        }

        private const string UserDatabase = "Clients.txt";
        private const string Separator = "#//#";


        public bool SignUp()
        {
            if (ValidationService.IsUserExists(UserName, Email))
                return false;

            string userRecord = $"{UserName}{Separator}{Email}{Separator}{Password}";
            File.AppendAllText(UserDatabase, userRecord + Environment.NewLine);
            return true;
        }

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

        public void Logout()
        {
            if (_userPortfolio != null)
            {
                UserPortfolio.SaveToFile();
                _userPortfolio = null;
            }
        }

    };

    class ValidationService
    {
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

    public class Portfolio
    {
        public string Owner { get; }
        public List<Asset> Assets { get; } = new List<Asset>();
        public decimal TotalValue => Assets.Sum(a => a.CurrentValue);
        public decimal TotalZakat => CalculateTotalZakat();

        public Portfolio(string owner)
        {
            Owner = owner;
        }

        public void AddAsset(Asset asset)
        {
            Assets.Add(asset);
            SaveToFile();
        }

        public void RemoveAsset(string assetId)
        {
            Assets.RemoveAll(a => a.Id == assetId);
            SaveToFile();
        }


        private decimal CalculateTotalZakat()
        {
                return Assets
                .Where(a => a.CurrentValue >= 450000)
                .Sum(a => a.ZakatAmount);
        }

        public void SaveToFile()
        {
            string fileName = $"{Owner}Portfolio.txt";
            var lines = Assets.Select(a =>
                $"{a.Id}|{a.Name}|{a.PurchasePrice}|{a.CurrentValue}|" +
                $"{a.AcquisitionDate:yyyy-MM-dd}|{a.Type.Name}|{a.Type.IsHalal}");

            File.WriteAllLines(fileName, lines);
        }

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

    public class Asset
    {
        public string Id { get; }
        public string Name { get; set; }
        public decimal PurchasePrice { get; private set; }
        public DateTime AcquisitionDate { get; private set; }
        public AssetType Type { get; private set; }
        public bool IsZakatApplicable => CurrentValue >= 450000;
        public decimal CurrentValue { get; set; }

        public decimal ZakatAmount => IsZakatApplicable ? CurrentValue * 0.025m : 0;

        public Asset(string name, decimal purchasePrice, AssetType type)
            : this(Guid.NewGuid().ToString(), name, purchasePrice, purchasePrice, DateTime.Now, type) { }

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

        public void UpdateValue(decimal newValue)
        {
            if (newValue < 0)
                throw new ArgumentException("Asset value cannot be negative");
            CurrentValue = newValue;
        }

        public void UpdateAsset(string name, decimal currentValue, bool isZakatApplicable)
        {
            Name = name;
            CurrentValue = currentValue;
        }
    }
    public class AssetType
    {
        public string Name { get; }
        public bool IsHalal { get; }
        public bool IsZakatEligible { get; }
        public int RiskRating { get; }

        public AssetType(string name, bool isHalal, bool isZakatEligible = true)
        {
            Name = name;
            IsHalal = isHalal;
            IsZakatEligible = isZakatEligible;
        }
    }   
}