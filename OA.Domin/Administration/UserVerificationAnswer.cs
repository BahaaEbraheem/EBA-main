using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace OA.Domin.Administration
{
    public class UserVerificationAnswer : BaseEntity
    {
        public UserVerificationAnswer()
        {
        }

        private ILazyLoader LazyLoader;
        public UserVerificationAnswer(ILazyLoader lazyLoader)
        {
            LazyLoader = lazyLoader;
        }

        public string UserId { get; set; }

        public int VerificationQuestionId { get; set; }

        private VerificationQuestion _VerificationQuestion;

        public VerificationQuestion VerificationQuestion 
        { 
            get => LazyLoader.Load(this, ref _VerificationQuestion);
            set => _VerificationQuestion = value; 
        }

        public string Answer { get; set; }

    }
}
