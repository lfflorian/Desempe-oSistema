using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Document
    {
        public string Uuid { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; } 
        public int Month { get; set; }
        public int Year { get; set; }
        public ulong Number { get; set; }
        public string Phone { get; set; }

        public Document(string uuid, int id, DateTime date, ulong number, string phone)
        {
            Uuid = uuid;
            Id = id;
            Date = date;
            Month = Date.Month;
            Year = Date.Year;
            Number = number;
            Phone = phone;
        }
    }
}
