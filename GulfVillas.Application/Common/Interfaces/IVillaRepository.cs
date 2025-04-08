using GulfVillas.Domain.Entites;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GulfVillas.Application.Common.Interfaces
{
    public interface IVillaRepository : IRepository<Villa> 
    {
        //IEnumerable<Villa> GetAll(Expression<Func<Villa,bool>>? filter = null, string? includeProperties= null);
        //explain the above line of code :
        // IEnumerable<Villa>:

        //        Think of this as a list or a bag that will hold the toy houses you pick out.
        //Villa means each item in the bag is a toy house.
        //IEnumerable just means you can look through the items in the bag one by one.
        //GetAll:

        //This is the name of the tool.It's like saying "Get all the toy houses".
        //Expression<Func<Villa, bool>>? filter = null:

        //This is like a special instruction you can give the tool.
        //filter: this is the name of the instruction.
        //Func<Villa, bool>: this is the instruction itself.
        //Imagine you have a checklist.This checklist lets you check each toy house.
        //For each house, the checklist tells you "yes" (keep it) or "no" (leave it).
        //For example, the checklist could say "Is the house red?" or "Does the house have a pool?"
        //Expression: This is a way of storing that checklist so the computer can understand it and use it to look through your box of toy villas.
        //? filter = null:
        //This means you don't have to give the tool a checklist.
        //If you don't give it a checklist (filter = null), it will just give you all the toy houses.


       
        void Update(Villa entity);
      

        void Save();


    }
}
