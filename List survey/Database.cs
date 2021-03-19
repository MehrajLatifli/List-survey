using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_survey
{
    [Serializable]
    public class Database
    {
        public Database(string name, string surname, string yourFatherName, string dateTime, string emailaddress, string phonenumber)
        {
            Name = name;
            Surname = surname;
            YourFatherName = yourFatherName;
            DateTime = dateTime;
            TelephoneNumber = phonenumber;
            EmailAddress = emailaddress;


            ID = DBID++;
        }

        public Database()
        {
            ID = DBID++;
        }

        public int ID { get; set; }
        public static int DBID { get; set; } = 1;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string YourFatherName { get; set; }
        public string DateTime { get; set; }
        public string TelephoneNumber { get; set; }
        public string EmailAddress { get; set; }


        public override string ToString()
        {
            return $" \n {ID.ToString()} \n {Name} \n {Surname} \n {YourFatherName} \n {TelephoneNumber} \n{EmailAddress} \n{DateTime} \n";
        }

        public void Show()
        {
         
        }
    }
}
