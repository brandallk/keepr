using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
    public class KeepsRepository : DbContext
    {
        public KeepsRepository(IDbConnection db) : base(db)
        {
        }

        public Keep CreateOne(Keep keep)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO keeps (Name, Description, UserId, ImageUrl, Link, Public, KeepCount, ShareCount, ViewCount)
            VALUES (@Name, @Description, @UserId, @ImageUrl, @Link, @Public, @KeepCount, @ShareCount, @ViewCount);
            SELECT id FROM keeps
            WHERE name=@Name AND description=@Description AND imageUrl=@ImageUrl AND link=@Link
            ", keep);

            keep.Id = id;
            return keep;
        }

        public List<Keep> GetPublicKeeps()
        {
            int isPublic = 1; // "Public" == 1 for public keeps
            return _db.Query<Keep>(@"
            SELECT * FROM keeps
            WHERE public=@Public
            ", new { Public = isPublic }).ToList();
        }
    }
}