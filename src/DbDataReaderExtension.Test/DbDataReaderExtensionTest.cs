using System;
using Microsoft.Data.Sqlite;
using Xunit;

namespace DbDataReaderExtension.Test
{
    public class DbDataReaderExtensionTest
    {
        [Fact]
        public void IsDBNull()
        {
            using(var connection = new SqliteConnection("DataSource=:memory:"))
            {
                connection.Open();
                using(var command = connection.CreateCommand())
                {
                    command.CommandText = @"CREATE TABLE Foo (id NUMBER, label TEXT);";
                    command.ExecuteNonQuery();
                    command.CommandText = @"INSERT INTO Foo values (1, 'Not Null'), (2, NULL)";
                    command.ExecuteNonQuery();
                    command.CommandText = @"SELECT id, label from Foo";
                    using(var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        Assert.False(reader.IsDBNull("id"));
                        Assert.False(reader.IsDBNull("label"));
                        reader.Read();
                        Assert.False(reader.IsDBNull("id"));
                        Assert.True(reader.IsDBNull("label"));
                    }
                }
            }
        }

        [Fact]
        public void IsDBNullWithBadColumn()
        {
            using(var connection = new SqliteConnection("DataSource=:memory:"))
            {
                connection.Open();
                using(var command = connection.CreateCommand())
                {
                    command.CommandText = @"CREATE TABLE Foo (id NUMBER, label TEXT);";
                    command.ExecuteNonQuery();
                    command.CommandText = @"INSERT INTO Foo values (1, 'Not Null')";
                    command.ExecuteNonQuery();
                    command.CommandText = @"SELECT id, label from Foo";
                    using(var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        Assert.Throws<InvalidOperationException>(() => reader.IsDBNull("bad"));
                    }
                }
            }
        }
    }
}
