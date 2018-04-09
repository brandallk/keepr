using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
    public class KeeptagsRepository : DbContext
    {
        public KeeptagsRepository(IDbConnection db) : base(db)
        {
        }

        public KeepTag CreateOne(KeepTag keeptag)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO keeptags (KeepId, TagId)
            VALUES (@KeepId, @TagId);
            SELECT id FROM keeptags
            WHERE keepId=@KeepId AND tagId=@TagId
            ", keeptag);

            keeptag.Id = id;
            return keeptag;
        }
    }
}