using SQLite;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Vacation_App_3.Features
{
    public class TodoDBAsyncWrapper
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInit = new Lazy<SQLiteAsyncConnection>(() => { return new SQLiteAsyncConnection(Consts.DBPath, Consts.flags); });

     
        static SQLiteAsyncConnection database = lazyInit.Value;
        static bool IsInit = false; //싱글톤 패턴을 위해

        public TodoDBAsyncWrapper()
        {
            InitAsync().SafeFireAndForget(false);
        }
        async Task InitAsync()
        {
            if (!IsInit)
            {
                if(!database.TableMappings.Any(m => m.MappedType.Name == typeof(TODODataFormat).Name))
                {
                    await database.CreateTablesAsync(CreateFlags.None, typeof(TODODataFormat)).ConfigureAwait(false);
                    IsInit = true;
                }
            }
        }

        public Task<List<TODODataFormat>> GetItemsAsync()
        {
            return database.Table<TODODataFormat>().ToListAsync();
        }

        //public Task<List<TODODataFormat>> GetItemsNotDoneAsync()
        //{
        //    return database.QueryAsync<TODODataFormat>("SELECT * FROM [TODODataFormat] WHERE [Done] = 0");

        //}

        public Task<TODODataFormat> GetItemAsync(int _id)
        {
            return database.Table<TODODataFormat>().Where(i => i.ID == _id).FirstOrDefaultAsync();
        }
        public Task<int> SaveItemAsync(TODODataFormat _item)
        {
            if(_item.ID != 0)
            {
                return database.UpdateAsync(_item);
            }
            else
            {
                return database.InsertAsync(_item);
            }
        }

        public Task<int> DeleteItemAsync(TODODataFormat _item)
        {
            return database.DeleteAsync(_item);
        }

    }
}
