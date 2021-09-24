using App1.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    interface ISignUpApiService
    {
        Task<string> Test();
        Task<SignUpApiResponse> Create(User newUser);
    }
}
