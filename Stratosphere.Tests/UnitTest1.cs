using Npgsql;
using Dapper;

namespace Stratosphere.Tests;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public async Task TestMethod1()
    {
        var connString = "Host=localhost;Port=5432;User Id=postgres;Password=postgres;Database=postgres";

        var conn = new NpgsqlConnection(connString);

        var sql = "select * from maintenancemode.group";

        var res = await conn.QueryAsync(sql);

        Assert.IsNotNull(res);
        Assert.IsTrue(res.Any());
    }
}