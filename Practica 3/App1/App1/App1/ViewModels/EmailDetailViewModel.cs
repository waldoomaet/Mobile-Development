using App1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.ViewModels
{
    class EmailDetailViewModel
    {
        public Email Email { get; set; }
        public EmailDetailViewModel(Email email)
        {
            Email = email;
        }
    }
}
