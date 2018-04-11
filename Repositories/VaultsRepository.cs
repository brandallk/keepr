using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public string DissociateVaultAndKeep(VaultKeep vaultKeep)
        {
            var rowsAffected = _db.Execute(@"
            DELETE FROM vaultkeeps
            WHERE vaultId=@VaultId AND keepId=@KeepId AND userId=@UserId
            ", vaultKeep);

            if (rowsAffected > 0)
            {
                return "Successfully dissociated keep from vault";
            }
            else
            {
                return "Failed to dissociate keep from vault";
            }
        }

        public List<Vault> GetByUserId(string id)
        {
            return _db.Query<Vault>(@"
            SELECT * FROM vaults
            WHERE userId=@Id
            ", new { Id = id }).ToList();
        }

        public Vault FindOneAndUpdate(int id, Vault vault)
        {
            return _db.QueryFirstOrDefault<Vault>($@"
            UPDATE vaults SET
                Name=@Name,
                Description=@Description,
                UserId=@UserId
            WHERE Id = {id};
            SELECT * FROM vaults WHERE Id = {id}
            ", vault);
        }

        public string DeleteOne(int id)
        {
            var rowsAffected = _db.Execute(@"
            DELETE FROM vaults
            WHERE id=@Id
            ", new { Id = id });

            if (rowsAffected > 0)
            {
                return "Successfully deleted vault";
            }
            else
            {
                return "Failed to delete vault";
            }
        }
    }
}