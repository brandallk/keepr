using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
    public class VaultKeepsRepository : DbContext
    {
        public VaultKeepsRepository(IDbConnection db) : base(db)
        {
        }

        public VaultKeep CreateOne(VaultKeep vaultKeep)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO vaultkeeps (VaultId, KeepId, UserId)
            VALUES (@VaultId, @KeepId, @UserId);
            SELECT id FROM vaultkeeps
            WHERE vaultId=@VaultId AND keepId=@KeepId AND userId=@UserId
            ", vaultKeep);

            vaultKeep.Id = id;
            return vaultKeep;
        }
    }
}