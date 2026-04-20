using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Dto
{
    public class MessageDTO
    {
        public int MessageID { get; set; }
        public int? AdvisorID { get; set; }
        public int? StudentID { get; set; }
        public int ReceiverID { get; set; }
        public string MessageContent { get; set; }
        public DateTime SentDate { get; set; }
    }
}
