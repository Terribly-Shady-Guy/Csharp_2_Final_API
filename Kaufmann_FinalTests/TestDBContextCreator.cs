using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kaufmann_Final.Data;

namespace Kaufmann_FinalTests
{
    internal static class TestDBContextCreator
    {
        private const string connectionString = "Data Source=LAPTOP-05I8GA19;Initial Catalog=Kaufmann_FinalDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static Kaufmann_FinaldbContext CreateTestContext() => new(
            new DbContextOptionsBuilder<Kaufmann_FinaldbContext>()
            .UseSqlServer(connectionString)
            .Options);
    }
}
