using Dapper;
using System.Data;
using Watches.Models;

namespace Watches
{
    public class WatchRepo : IWatchRepo
    {
        private readonly IDbConnection _conn;

        public WatchRepo(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<watch> GetWatches()
        {
            return _conn.Query<watch>("SELECT * FROM watch;");
        }

        public watch GetWatchById(int id)
        {
            return _conn.QuerySingle<watch>("SELECT * FROM watch WHERE watch_id = @id", new { id = id });
        }

       
        public void UpdateWatch(watch newwatch)
        {
            _conn.Execute("UPDATE watch SET description = @Description WHERE watch_id = @id",
             new { description = newwatch.description, id = newwatch.watch_id });
        }

        public void InsertWatch(watch watchToInsert)
        {
            _conn.Execute("INSERT INTO watch (model_name, manufacturer_name, Price) VALUES (@model_name, @manufacturer_name, @price);",
                new { model_name = watchToInsert.model_name, manufacturer_name = watchToInsert.manufacturer_name, price = watchToInsert.price });
        }

        public IEnumerable<watches> GetCategories()
        {
            return _conn.Query<watches>("SELECT * FROM watch;");
        }

        public watch AssignCategory()
        {
            var watchList = GetCategories();
            var watch = new watch();
            watch.Watches = watchList;
            return watch;
        }
        public void DeleteWatch(watch watchToDelete)
        {
            _conn.Execute("DELETE FROM watch WHERE watch_id = @id;", new { id = watchToDelete.watch_id });
        }

    }
}
