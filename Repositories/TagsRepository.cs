using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
    public class TagsRepository : DbContext
    {
        public TagsRepository(IDbConnection db) : base(db)
        {
        }

        public Tag CreateOne(Tag tag)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO tags (Name)
            VALUES (@Name);
            SELECT id FROM tags
            WHERE name=@Name
            ", tag);

            tag.Id = id;
            return tag;
        }

        public Tag GetOneByName(string tagname)
        {
            return _db.QueryFirstOrDefault<Tag>(@"SELECT * FROM tags WHERE name=@Name", new { Name = tagname });
        }
    }
}