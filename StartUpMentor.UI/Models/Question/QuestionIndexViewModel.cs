﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StartUpMentor.UI.Models.Question
{
    public class QuestionIndexViewModel
    {
        public Guid FieldId { get; set; }
        public PagedList.IPagedList<StartUpMentor.Model.Common.IQuestion> QuestionList { get; set; }
    }
}