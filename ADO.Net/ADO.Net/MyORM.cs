using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.Net
{
    public class MyORM<T> where T : IEntity
    {
        private SqlConnection _connection;
        public MyORM(SqlConnection connection)
        {
            _connection = connection;

        }
        public MyORM(string connectionString) 
            : this(new SqlConnection(connectionString))
        {

        }
        public void Insert(T item)
        {
            Type type = item.GetType();
            var properties = type.GetProperties();
            
            var sql = new StringBuilder();
            sql.Append($"insert into {type.Name} (");

            foreach (var property in properties)
            {
                if (property.GetValue(item) != null)
                {
                    sql.Append(property.Name);
                }
                if (property != properties.Last()) sql.Append(", ");
            }
            sql.Append(") Values (");

            foreach (var property in properties)
            {
                if (property.GetValue(item) != null)
                {
                    sql.Append($"@{property.Name}");
                }
                if (property != properties.Last()) sql.Append(", ");
            }
            sql.Append(')');
            var query = sql.ToString();

            Console.WriteLine(query);

            using(var command = new SqlCommand(query, _connection))
            {
                foreach (var property in properties)
                {
                    if (property.GetValue(item) != null)
                    {
                        command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(item));
                    }
                    
                }
                command.ExecuteNonQuery();
            }
        }
        /*
        public void InsertWithNested(T item)
        {
            Type type = item.GetType();
            var properties = type.GetProperties();

            var sql = new StringBuilder();
            sql.Append($"insert into {type.Name} (");

            foreach (var property in properties)
            {
                if (property.PropertyType.IsClass && !property.PropertyType.FullName.Equals("System.String"))
                {
                    var prop = (Type)property.GetValue(item, null);
                   
                    var entity = (T)Activator.CreateInstance(prop);
                    InsertWithNested(entity);
                }
                if (property.GetValue(item) != null)
                {
                    sql.Append(property.Name);
                }
                if (property != properties.Last()) sql.Append(", ");
            }
            sql.Append(") Values (");

            foreach (var property in properties)
            {
                if (property.GetValue(item) != null)
                {
                    sql.Append($"@{property.Name}");
                }
                if (property != properties.Last()) sql.Append(", ");
            }
            sql.Append(')');
            var query = sql.ToString();

            Console.WriteLine(query);

            using (var command = new SqlCommand(query, _connection))
            {
                foreach (var property in properties)
                {
                    if (property.GetValue(item) != null)
                    {
                        command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(item));
                    }

                }
                command.ExecuteNonQuery();
            }
        }
        */
        public void Update(T item)
        {
            Type type = item.GetType();
            var properties = type.GetProperties();

            var sql = new StringBuilder();
            sql.Append($"Update {type.Name} Set ");

            foreach (var property in properties)
            {
                if (property == properties.First())
                {
                    continue;
                }
                sql.Append($"{property.Name} = '{property.GetValue(item)}'");
                if (property != properties.Last())
                {
                    sql.Append(", ");
                }
            }
            sql.Append($" where {properties.First().Name} = {properties.First().GetValue(item)}");
            var query = sql.ToString();

            Console.WriteLine(query);

            using (var command = new SqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }


        }
        public void Delete(T item)
        {
            var type = item.GetType();
            var sql = new StringBuilder();
            sql.Append($"Delete from {type.Name} where Id = {type.GetProperties().First().GetValue(item)}");
            var query = sql.ToString();
            using (var command = new SqlCommand(query, _connection))
            {
                command.ExecuteNonQuery();
            }

        }
        public T GetbyId(int id)
        {
            var type = typeof(T);
            var obj = (T)Activator.CreateInstance(type);

            var sql = new StringBuilder();
            sql.Append($"Select * from {type.Name} Where Id = @Id");
            var query = sql.ToString();

            //Console.WriteLine(query);

            var command = new SqlCommand(query, _connection);
            command.Parameters.AddWithValue("Id", id);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                foreach (var property in type.GetProperties())
                {
                    property.SetValue(obj, reader[property.Name]);
                }
            }
            return obj;
            
        }

        
        public IList<T> GetAll()
        {
            var type = typeof(T);
            var listType = typeof(List<>).MakeGenericType(type);
            var entityList = (IList<T>)Activator.CreateInstance(listType);

            var sql = new StringBuilder();
            sql.Append($"Select * from {type.Name}");
            var query = sql.ToString();

            var command = new SqlCommand(query, _connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var entity = (T)Activator.CreateInstance(type);

                foreach (var prop in type.GetProperties())
                {
   
                    prop.SetValue(entity, reader[prop.Name]);
                }
                entityList.Add(entity);
            }
            return entityList;
        }

    }
}
