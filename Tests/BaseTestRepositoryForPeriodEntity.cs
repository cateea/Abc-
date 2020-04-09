﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abc.Data.Common;
using Abc.Domain.Common;

namespace Abc.Tests
{
    internal abstract class BaseTestRepositoryForPeriodEntity<TObj, TData>
        where TObj : Entity<TData>
        where TData : PeriodData, new()
    {

        internal readonly List<TObj> list;
        public BaseTestRepositoryForPeriodEntity()
        {
            list = new List<TObj>();
        }
        public async Task<List<TObj>> Get()
        {
            await Task.CompletedTask;
            return list;
        }

        public async Task<TObj> Get(string id)
        {
            await Task.CompletedTask;
            return list.Find(x=> isThis(x, id));
        }

        protected abstract bool isThis(TObj entity, string id);

        public async Task Delete(string id)
        {
            await Task.CompletedTask;
            var obj = list.Find(x => isThis(x, id));
            list.Remove(obj);
        }

        public async Task Add(TObj obj)
        {
            await Task.CompletedTask;
            list.Add(obj);
        }

        public async Task Update(TObj obj)
        {
            await Delete(getId(obj));
            list.Add(obj);
        }

        protected abstract string getId(TObj entity);
        public string SortOrder { get; set; }
        public string SearchString { get; set; }
        public string FixedFilter { get; set; }
        public string FixedValue { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }
    }
}