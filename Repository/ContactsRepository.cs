using ContactsAdm.Data;
using ContactsAdm.Models;
using Dapper;

namespace ContactsAdm.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        private readonly ContactsDapperContext _contactContext;

        public ContactsRepository(ContactsDapperContext contactContext)
        {
            _contactContext = contactContext;
        }
            
        public async Task<IEnumerable<ContactModel>> ListAll() 
        {
            var sql = $@"SELECT [Id],
                               [Name],
                               [Email],
                               [CreatedDate]
                            FROM
                               [Contacts]";

            using var connection = _contactContext.CreateConnection();
            return await connection.QueryAsync<ContactModel>(sql);
        }

        public async Task<ContactModel> GetById(Guid id)
        {
            var sql = $@"SELECT [Id],
                               [Name],
                               [Email],
                               [CreatedDate]
                            FROM
                               [Contacts]
                            WHERE
                              [Id]=@id";

            using var connection = _contactContext.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<ContactModel>(sql, new { id });
        }

        public async Task<ContactModel> Create(ContactModel contact)
        {
            contact.Id = Guid.NewGuid();
            contact.CreatedDate = DateTime.Now;
            contact.UpdatedDate = DateTime.Now;
            var sql = $@"INSERT INTO [dbo].[Contacts]
                                ([Id],
                                 [Name],
                                 [Email],
                                 [CreatedDate],
                                 [UpdatedDate])
                                VALUES
                                (@Id,
                                 @Name,
                                 @Email,
                                 @CreatedDate,
                                 @UpdatedDate)";

            using var connection = _contactContext.CreateConnection();
            await connection.ExecuteAsync(sql, contact);
            return contact;
        }

        public async Task<ContactModel> Update(ContactModel contact)
        {
            contact.UpdatedDate = DateTime.Now;
            var sql = $@"UPDATE[dbo].[Contacts]
                           SET [Id] = @Id,
                               [Name] = @Name,
                               [Email] = @Email,
                               
                               [UpdatedDate] = @UpdatedDate
                          WHERE
                              Id=@Id";

            using var connection = _contactContext.CreateConnection();
            await connection.ExecuteAsync(sql, contact);
            return contact;
        }

        public async Task<ContactModel> Delete(ContactModel contact)
        {
            var sql = $@"
                        DELETE FROM
                            [dbo].[Contacts]
                        WHERE
                            [Id]=@Id";
            using var connection = _contactContext.CreateConnection();
            await connection.ExecuteAsync(sql, contact);
            return contact;
        }
    }
}
