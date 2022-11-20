﻿using NDDTraining.Domain.DTOS;
using NDDTraining.Domain.Models;

namespace NDDTraining.Domain.Interfaces.Services
{
    public interface IUserService
    {
        User GetUser(string token);
        void InsertUser(UserDTO newUser);
        void Update(UserDTO changedUser, int id);
        String VerifyLogin (LoginDTO loginDTO);
        string Reset(string email);
        string VerifyToken(ResetDTO resetDTO);
    }
}
