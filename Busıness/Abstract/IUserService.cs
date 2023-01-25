﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busıness.Abstract
{
    public interface IUserService
    {
        List<OperatinClaims> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
    }
}
