// SearchService.cs
using LibraryManagementSystem.Interfaces;
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Services
{
  
    public class SearchService<T> where T : IMedia
    {
        // items to search through.
        private List<T> items;

        
        public SearchService(List<T> items)
        {
            this.items = items; 
        }

        // search for items that match whatever
        public List<T> SearchBy(Func<T, bool> predicate)
        {
       
            List<T> results = new List<T>();

         
            foreach (var item in items)
            {
                // iff the item matches add to results.
                if (predicate(item))
                {
                    results.Add(item);
                }
            }

            
            return results;
        }
    }
}
