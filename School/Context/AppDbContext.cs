using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Context
{
    public class AppDbContext :DbContext
    {
       public DbSet<Department> Departments {  get; set; }
      public DbSet<Teacher> Teachers { get; set; }
      public DbSet<ClassRoom> classRooms { get; set; }
      public DbSet<Student> students { get; set; }
      public DbSet<Subject> subjects { get; set; }
      public DbSet<Enrollment> enrollments { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasMany(t => t.Teachers).WithOne(d => d.department).HasForeignKey(f => f.TeacheriD);
            modelBuilder.Entity<Teacher>().HasOne(d => d.department).WithMany(t => t.Teachers).HasForeignKey(f => f.DepartmentId);
            modelBuilder.Entity<Teacher>().Property(t => t.Email).HasAnnotation("EmailAdress", true);

            modelBuilder.Entity<ClassRoom>()
               .HasMany(c => c.Students)
               .WithOne(s => s.ClassRoom)
               .HasForeignKey(s => s.ClassRoomId);


            modelBuilder.Entity<Student>()
                .HasMany(s => s.Enrollments)
                .WithOne(e => e.Student)
                .HasForeignKey(s => s.StudentId);



            modelBuilder.Entity<Subject>()
                .HasMany(s => s.Enrollments)
                .WithOne(e => e.Subject)
                .HasForeignKey(s => s.SubjectId);


            modelBuilder.Entity<Student>()
                .HasIndex(s => s.Email)
                .IsUnique();




            modelBuilder.Entity<Enrollment>()
           .HasIndex(e => new { e.StudentId, e.SubjectId })
           .IsUnique();



            modelBuilder.Entity<Department>().HasData( new Department 
            {
                Id=1,
                Name="science",
                Description="asdfg"
            });
            modelBuilder.Entity<Teacher>().HasData( new Teacher 
            {
                TeacheriD=1,
                FirstName="lujain",
                LastName="mohamed",
                PhoneNumber="011234567",
                salary=12,
                Email="llll@345",
                DepartmentId=1,
            });



            
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\SchoolServer;Initial Catalog=SchoolDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }

        //u
    }
}
