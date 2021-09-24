using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    interface IAlertService
    {
        Task Alert(string title, string message, string cancel);
    }
}