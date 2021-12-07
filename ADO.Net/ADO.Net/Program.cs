using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ADO.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "Server=RAIZOR\\SQLEXPRESS;Database = StudentDB;Trusted_Connection=True;";
            connection.Open();

            //SqlCommand command = new SqlCommand();
            //command.CommandText = "insert into Student (Name, Department) values ('Pintu', 'BIO')";
            //command.Connection = connection;
            //command.ExecuteNonQuery();
            /*
            string sql = "select * from Student";
            var students = ReadOperation(sql, connection);

            foreach (var item in students)
            {
                Console.WriteLine($"Name: {item.Name}, Id : {item.Id}, Department: {item.Department}");
            }
            */

            var student = new Student()
            {
                Id = 100,
                Name = "Mukhdo",
                Department = "SWE",
            };

            var coures = new Course()
            {
                 Id = 344, Name = "AOL"
                //new Course{ Id = 311, Name = "ML"},
                //new Course{ Id = 302, Name = "AI"},
                //new Course{ Id = 399, Name = "OOD"},
            };
            //student.Coures = coures;
            var orm = new MyORM<Student>(connection);
            //orm.Insert(student);

            orm.Update(student);

            //orm.Delete(student);

            //var entity = orm.GetbyId(5);
            //foreach (var prop in typeof(Student).GetProperties())
            //{
            //    Console.WriteLine(prop.GetValue(entity));
            //}

            //var entityList = orm.GetAll();
            //foreach (var item in entityList)
            //{
            //    Console.WriteLine($"{item.Id} {item.Name} {item.Department}");
            //}
            //orm.InsertWithNested(student);
            // Dispose
        }
            
        static IList<Student> ReadOperation(string sql, SqlConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }

            using var command = new SqlCommand(sql, connection);
            var reader = command.ExecuteReader();

            var students = new List<Student>();

            while(reader.Read())
            {
                var student = new Student();
                student.Id = (int)reader["Id"];
                student.Name = (string)reader["Name"];
                student.Department = (string)reader["Department"];
                students.Add(student);

            }
            return students;

        }
    }

    public class Student : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        //public Course Coures { get; set; }
    }

    public class Course : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
