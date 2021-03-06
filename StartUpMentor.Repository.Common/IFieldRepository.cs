﻿using StartUpMentor.Common.Filters;
using StartUpMentor.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpMentor.Repository.Common
{
    public interface IFieldRepository
    {
        Task<IField> GetAsync(Guid id);
        Task<IEnumerable<IField>> GetRangeAsync(GenericFilter filter);

        Task<int> AddAsync(IField field);
        Task<int> UpdateAsync(IField field);
        Task<int> DeleteAsync(IField field);
        Task<int> DeleteAsync(Guid id);
    }
}
