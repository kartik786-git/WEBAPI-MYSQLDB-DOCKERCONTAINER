using StuendetMS.Entity;

namespace StuendetMS.Data
{
    public static class DBInitializerSeedData
    {
        public static void InitializeDatabase(StudentDbContext studentDbContext)
        {
            if (studentDbContext.Students.Any())
                return;

            var studentOne = new Student
            {
                Name = "kartik",
                Class = "first",
                Section = "A",

            };
            var studentTwo = new Student
            {
                Name = "kkp",
                Class = "second",
                Section = "A",

            };
            var studentThree = new Student
            {
                Name = "john",
                Class = "thrid",
                Section = "A",

            };
            studentDbContext.Students.Add(studentOne);
            studentDbContext.Students.Add(studentTwo);
            studentDbContext.Students.Add(studentThree);

            studentDbContext.SaveChanges();
        }
    }
}
