using System;
using System.Collections.Generic;

namespace StartUpMentor.DAL.Models
{
    public partial class AnswerEntity
    {
        public Guid Id { get; set; }

        public string AnswerText { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }

        //FK for User
        public string UserId { get; set; }
        //One to many - One answer can be posted by a single user
        public virtual ApplicationUser User { get; set; }

        //FK for Question
        public Guid QuestionId { get; set; }
        //One Answer is related to one Question
        public virtual QuestionEntity Question { get; set; }
    }
}
