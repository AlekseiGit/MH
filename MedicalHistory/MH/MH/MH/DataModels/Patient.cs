using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH.DataModels
{
    class Patient
    {
        public Guid ID { get; set; }
        public string MedicalCardNumber { get; set; }
        public string SName { get; set; }
        public string FName { get; set; }
        public string MName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string AgeCategory { get; set; }
        public int Sex { get; set; }
        public int Weight { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Organization { get; set; }
        public string Profession { get; set; }
        public string Position { get; set; }
    }
}