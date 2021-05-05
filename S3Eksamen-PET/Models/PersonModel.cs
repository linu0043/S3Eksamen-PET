using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Eksamen_PET.Models
{
    public enum Roles
    {
        Observant = 0,
        User = 1,
        Agent = 2,
        Leader = 3
    }

    public abstract class PersonModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Implementing INotifyPropertyChanged to help databind in WPF.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private int id;

        /// <summary>
        /// Gets or sets the ID of this person.
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("id"); }
        }

        private Roles role;

        /// <summary>
        /// Gets the role of this person.
        /// </summary>
        public abstract Roles Role { get; set; }

        private string name;

        /// <summary>
        /// Gets or sets the name of this person.
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("name"); }
        }

        private string address;

        /// <summary>
        /// Gets or sets the address for this person.
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged("address"); }
        }

        private string city;

        /// <summary>
        /// Gets or sets the city for this person.
        /// </summary>
        public string City
        {
            get { return city; }
            set { city = value; OnPropertyChanged("city"); }
        }

        private string postalCode;
        
        /// <summary>
        /// Gets or sets the postal code of the city for this person.
        /// </summary>
        public string PostalCode
        {
            get { return postalCode; }
            set { postalCode = value; OnPropertyChanged("postalCode"); }
        }

        private string phoneNo;

        /// <summary>
        /// Gets or sets the phone number for this person.
        /// </summary>
        public string PhoneNo
        {
            get { return phoneNo; }
            set { phoneNo = value; OnPropertyChanged("phoneNo"); }
        }

        private string email;

        /// <summary>
        /// Gets or sets the email of this person.
        /// </summary>
        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("email"); }
        }

        private RegionInfo nationality;

        /// <summary>
        /// Gets or sets the nationality of this person.
        /// </summary>
        public RegionInfo Nationality
        {
            get { return nationality; }
            set { nationality = value; OnPropertyChanged("nationality"); }
        }

        private string cpr;

        /// <summary>
        /// Gets or sets the CPR number for this person.
        /// </summary>
        public string CPR
        {
            get { return cpr; }
            set { cpr = value; OnPropertyChanged("cpr"); }
        }

        private int height;

        /// <summary>
        /// Gets or sets the height of this person in centimeters.
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; OnPropertyChanged("height"); }
        }

        private string eyeColor;

        /// <summary>
        /// Gets or sets the eye color of this person.
        /// </summary>
        public string EyeColor
        {
            get { return eyeColor; }
            set { eyeColor = value; OnPropertyChanged("eyeColor"); }
        }

        private string hairColor;

        /// <summary>
        /// Gets or sets the hair color of this person.
        /// </summary>
        public string HairColor
        {
            get { return hairColor; }
            set { hairColor = value; OnPropertyChanged("hairColor"); }
        }

        private byte[] photo;

        /// <summary>
        /// Gets or sets the photo for this person using a <c>byte[]</c>.
        /// </summary>
        public byte[] Photo
        {
            get { return photo; }
            set { photo = value; OnPropertyChanged("photo"); }
        }

        /// <summary>
        /// Verifies if the properties for this person are valid.
        /// </summary>
        /// <returns>True if valid, returns false if invalid.</returns>
        public virtual bool VerifyPerson()
        {
            // If all of this is invalid, return false (not verified), otherwise return true (is verified).
            if (string.IsNullOrWhiteSpace(name) &&
                string.IsNullOrWhiteSpace(address) &&
                string.IsNullOrWhiteSpace(city) &&
                string.IsNullOrWhiteSpace(postalCode) &&
                string.IsNullOrWhiteSpace(phoneNo) &&
                string.IsNullOrWhiteSpace(email) &&
                nationality == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
