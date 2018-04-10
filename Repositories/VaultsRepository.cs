using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
    public class VaultsRepository : DbContext
    {
        public VaultsRepository(IDbConnection db) : base(db)
        {
        }

        public Vault CreateOne(Vault vault)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO vaults (Name, Description, UserId)
            VALUES (@Name, @Description, @UserId);
            SELECT id FROM vaults
            WHERE name=@Name AND description=@Description AND userId=@UserId
            ", vault);

            vault.Id = id;
            return vault;
        }

        public VaultKeep AssociateVaultAndKeep(VaultKeep vaultKeep)
        {
            int id = _db.ExecuteScalar<int>(@"
            INSERT INTO vaultkeeps (vaultId, keepId, userId)
            VALUES (@VaultId, @KeepId, @UserId);
            SELECT id FROM vaultkeeps
            WHERE vaultId=@VaultId AND keepId=@KeepId AND userId=@UserId
            ", vaultKeep);

            vaultKeep.Id = id;
            return vaultKeep;
        }
    }
}