﻿using ApplicationCore.Entities;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
	public interface IAccountServiceAsync
	{
        Task<int> AddAccountAsync(RegisterModel user);
        Task<int> UpdateAccountAsync(User user, int id);
        Task<int> DeleteAccountAsync(int id);
        Task<IEnumerable<User>> GetAllAccountsAsync();
        Task<User> GetAccountByIdAsync(int id);
    }
}
