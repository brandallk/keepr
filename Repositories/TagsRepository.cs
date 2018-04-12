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
            INSERT INTO tags (tagName)
            VALUES (@TagName);
            SELECT id FROM tags
            WHERE tagName=@TagName
            ", tag);

            tag.Id = id;
            return tag;
        }

        public Tag GetOneByName(string tagname)
        {
            return _db.QueryFirstOrDefault<Tag>(@"SELECT * FROM tags WHERE tagName=@TagName", new { TagName = tagname });
        }
    }
}