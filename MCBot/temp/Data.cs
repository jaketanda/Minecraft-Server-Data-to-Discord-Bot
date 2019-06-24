using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MCBot.Resources.Database;

namespace MCBot.Core.Data
{
    public static class Data
    {
        public static int GetStones(ulong UserId)
        {
            using (var DbContext = new SqliteDbContext())
            {
                if (DbContext.Stones.Where(x => x.UserId == UserId).Count() < 1)
                {
                    return 0;
                }
                return DbContext.Stones.Where(x => x.UserId == UserId).Select(x => x.Amount).FirstOrDefault();
            }
        }

        public static async Task SaveStones(ulong UserId, int Amount)
        {
            // open and close database
            using (var DbContext = new SqliteDbContext())
            {
                if (DbContext.Stones.Where(x => x.UserId == UserId).Count() < 1)
                {
                    // The user doesnt have a row yet, create one for him
                    DbContext.Stones.Add(new Stone
                    {
                        UserId = UserId,
                        Amount = Amount
                    }) ;
                }
                else
                {
                    Stone Current = DbContext.Stones.Where(x => x.UserId == UserId).FirstOrDefault();
                    Current.Amount += Amount;
                    DbContext.Stones.Update(Current);
                }
                await DbContext.SaveChangesAsync();
            }
        }
    }
}
