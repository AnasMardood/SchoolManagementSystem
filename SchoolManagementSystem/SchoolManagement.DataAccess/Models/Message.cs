using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.DataAccess.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public int? AdvisorID { get; set; }
        public Advisor? Advisor { get; set; }
        public int? StudentID { get; set; }
        public Student? Student { get; set; }
        public int ReceiverID { get; set; }//Recipient ID (student or teacher)
        public string MessageContent { get; set; }
        public DateTime SentDate { get; set; }
    }
}