using App1.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    interface ISignUpApiService
    {
        [Get("/SignUp/Test")]
        Task<string> Test();
    }
}
