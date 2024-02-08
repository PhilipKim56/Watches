using System.Collections;
using Watches.Models;

namespace Watches
{
    public interface IWatchRepo
    {
        public IEnumerable<watch> GetWatches();
        watch GetWatchById(int id); 
        
        void UpdateWatch(watch watch);
        public IEnumerable<watches> GetCategories();
        public watch AssignCategory();
        public void InsertWatch(watch watchToInsert);

        public void DeleteWatch(watch watchToDelete);


    }
}
