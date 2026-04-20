using SchoolManagement.BusinessLogic.Dto;
using SchoolManagement.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.BusinessLogic.Mappers
{
    public static class MessageMapper
    {
        public static MessageDTO Map(Message message)
        {
            return new MessageDTO
            {
                MessageID = message.MessageID,
                AdvisorID = message.AdvisorID,
                StudentID = message.StudentID,
                ReceiverID = message.ReceiverID,
                MessageContent = message.MessageContent,
                SentDate = message.SentDate
            };
        }

        public static List<MessageDTO> Map(IEnumerable<Message> messages)
        {
            return messages.Select(Map).ToList();
        }
    }

}
