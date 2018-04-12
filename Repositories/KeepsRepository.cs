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

        public List<Keep> GetByUserId(string id)
        {
            return _db.Query<Keep>(@"
            SELECT * FROM keeps
            WHERE userId=@Id
            ", new { Id = id }).ToList();
        }

        public List<Keep> GetByVaultId(string id)
        {
            return _db.Query<Keep>(@"
            SELECT * FROM vaultkeeps
            JOIN keeps ON keeps.id = vaultkeeps.keepId
            WHERE vaultId=@Id
            ", new { Id = id}).ToList();
        }

        public List<Keep> FindByQueryString(string query)
        {
            return _db.Query<Keep>(@"
            SELECT * FROM keeps
            WHERE name LIKE @Query
            OR description LIKE @Query
            OR imageUrl LIKE @Query
            OR link LIKE @Query
            ", new { Query = '%' + query + '%' }).ToList();
        }

        public List<Keep> FindByTagQuery(string query)
        {
            var rawResults = _db.Query<TagQueryResult>(@"
            SELECT * FROM keeps
            JOIN keeptags ON keeptags.keepId = keeps.id
            JOIN tags ON tags.id = keeptags.tagId
            WHERE tagname LIKE @Query
            ", new { Query = '%' + query + '%' }).ToList();

            List<Keep> keeps = new List<Keep>();

            foreach (TagQueryResult result in rawResults)
            {
                Keep keep = new Keep() {
                    Id = result.Id,
                    Name = result.Name,
                    Description = result.Description,
                    UserId = result.UserId,
                    ImageUrl = result.ImageUrl,
                    Link = result.Link,
                    Public = result.Public,
                    KeepCount = result.KeepCount,
                    ShareCount = result.ShareCount,
                    ViewCount = result.ViewCount
                };
                keeps.Add(keep);
            }

            return keeps;
        }

        public Keep FindOneAndUpdate(int id, Keep keep)
        {
            return _db.QueryFirstOrDefault<Keep>($@"
            UPDATE keeps SET
                Name=@Name,
                Description=@Description,
                ImageUrl=@ImageUrl,
                Link=@Link,
                Public=@Public,
                KeepCount=@KeepCount,
                ShareCount=@ShareCount,
                ViewCount=@ViewCount
            WHERE Id = {id};
            SELECT * FROM keeps WHERE Id = {id}
            ", keep);
        }

        public string DeleteOne(int id)
        {
            var rowsAffected = _db.Execute(@"
            DELETE FROM keeps
            WHERE id=@Id
            ", new { Id = id });

            if (rowsAffected > 0)
            {
                return "Successfully deleted keep";
            }
            else
            {
                return "Failed to delete keep";
            }
        }
    }
}