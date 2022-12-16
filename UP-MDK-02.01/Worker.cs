using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UP_MDK_02._01
{
    internal class Worker
    {
        public int id { get; set; }
        public string ident { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string patronymic { get; set; }
        public string datebirth { get; set; }
        public string phone_number { get; set; }
        public string department { get; set; }

        public Worker() { }

        public Worker(string ident, string first_name, string last_name, string patronymic, string datebirth, string phone_number, string department)
        {
            this.ident = ident;
            this.first_name = first_name;
            this.last_name = last_name;
            this.patronymic = patronymic;
            this.datebirth = datebirth;
            this.phone_number = phone_number;
            this.department = department;
        }
    }
}
