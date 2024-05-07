﻿using ProjectStructure.Domain;
using ProjectStructure.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStructure.Repository.IRepository
{
    public interface IPersonRepository
    {
        List<Person> GetPeople();
    }
}