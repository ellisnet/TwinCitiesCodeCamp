using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Portable.Data.Sqlite;

using PatientCheckUp.Views;
using PatientCheckUp.Models;

namespace PatientCheckUp {
    public class App {

        private static readonly string _databaseName = "patientcheckup.sqlite";
        private static readonly string _databasePassword = "mySecretKey";

        private static IObjectCryptEngine _cryptEngine = null;
        public static IObjectCryptEngine CryptEngine {
            get {
                if (_cryptEngine == null) {
                    _cryptEngine = DependencyService.Get<IObjectCryptEngine>();
                    _cryptEngine.Initialize(new Dictionary<string, object>() { { "CryptoKey", _databasePassword } });
                }
                return _cryptEngine; 
            }
        }

        private static SqliteAdoConnection _databaseConnection = null;
        public static SqliteAdoConnection DatabaseConnection {
            get {
                if (_databaseConnection == null) {
                    string databasePath = DependencyService.Get<IDatabasePath>().GetPath(_databaseName);
                    _databaseConnection = new SqliteAdoConnection(new SQLitePCL.SQLiteConnection(databasePath), App.CryptEngine);
                }
                return _databaseConnection; 
            }
        }

        private static AppUser _user = null;
        public static AppUser User {
            get { return _user; }
            set { _user = value; }
        }

        private static void SetupDatabase(SqliteAdoConnection dbConnection) {
            //add patients if there aren't any
            var patientTable = new EncryptedTable<Patient>(App.CryptEngine, dbConnection);
            if (patientTable.GetItems(new TableSearch()).Count < 1) {
                patientTable.TempItems.Add(new Patient {
                    FirstName = "Joan",
                    LastName = "Smith",
                    Dob = new DateTime(1930, 12, 4),
                    Gender = 'F'
                });
                patientTable.TempItems.Add(new Patient {
                    FirstName = "Jon",
                    LastName = "Smith",
                    Dob = new DateTime(1940, 11, 29),
                    Gender = 'M'
                });
                patientTable.TempItems.Add(new Patient {
                    FirstName = "Abe",
                    LastName = "Henderson",
                    Dob = new DateTime(1953, 7, 4),
                    Gender = 'M'
                });
                patientTable.TempItems.Add(new Patient {
                    FirstName = "Ron",
                    LastName = "Anderson",
                    Dob = new DateTime(1976, 12, 12),
                    Gender = 'M'
                });
                patientTable.TempItems.Add(new Patient {
                    FirstName = "Samantha",
                    LastName = "Johnson",
                    Dob = new DateTime(1980, 1, 23),
                    Gender = 'F'
                });
                patientTable.TempItems.Add(new Patient {
                    FirstName = "Alan",
                    LastName = "Sams",
                    Dob = new DateTime(1962, 7, 9),
                    Gender = 'M'
                });
                patientTable.TempItems.Add(new Patient {
                    FirstName = "Randy",
                    LastName = "Gentry",
                    Dob = new DateTime(1952, 4, 8),
                    Gender = 'M'
                });
                patientTable.TempItems.Add(new Patient {
                    FirstName = "Alice",
                    LastName = "Sanderson",
                    Dob = new DateTime(1967, 10, 16),
                    Gender = 'F'
                });
                patientTable.TempItems.Add(new Patient {
                    FirstName = "Jim",
                    LastName = "Taylor",
                    Dob = new DateTime(1942, 8, 19),
                    Gender = 'M'
                });
                patientTable.TempItems.Add(new Patient {
                    FirstName = "Lando",
                    LastName = "Bespin",
                    Dob = new DateTime(1965, 8, 2),
                    Gender = 'M'
                });
                patientTable.TempItems.Add(new Patient {
                    FirstName = "Diane",
                    LastName = "Landis",
                    Dob = new DateTime(1930, 12, 9),
                    Gender = 'F'
                });
                patientTable.TempItems.Add(new Patient {
                    FirstName = "Jane",
                    LastName = "Allen",
                    Dob = new DateTime(1956, 3, 7),
                    Gender = 'F'
                });
                patientTable.TempItems.Add(new Patient {
                    FirstName = "Davis",
                    LastName = "Crawford",
                    Dob = new DateTime(1980, 5, 8),
                    Gender = 'M'
                });
                patientTable.TempItems.Add(new Patient {
                    FirstName = "Liam",
                    LastName = "Fredericks",
                    Dob = new DateTime(1934, 11, 5),
                    Gender = 'F'
                });
                patientTable.WriteChangesAndFlush();
            }
        }

        public static Page GetMainPage() {
            //New project code:
            //return new ContentPage {
            //    Content = new Label {
            //        Text = "Hello, Forms !",
            //        VerticalOptions = LayoutOptions.CenterAndExpand,
            //        HorizontalOptions = LayoutOptions.CenterAndExpand,
            //    },
            //};
            SetupDatabase(App.DatabaseConnection);
            var loginPage = new LoginPage();
            return new NavigationPage(loginPage);
        }
    }
}
