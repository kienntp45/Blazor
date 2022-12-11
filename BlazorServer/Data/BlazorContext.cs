namespace BlazorServer.Data
{
    public class BlazorContext : DbContext
    {
        public BlazorContext(DbContextOptions<BlazorContext> options) : base(options)
        {

        }

        public DbSet<Marks>    Marks { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Subjects> Subjects { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Students>(stu =>
            {
                stu.ToTable("tbl_student");
                stu.HasKey(p => p.ID);
                stu.Property(p => p.Name).HasMaxLength(250);
                stu.Property(p => p.Gender).HasDefaultValue(0);
                stu.Property(p => p.Status).HasDefaultValue(true);


            });
            modelBuilder.Entity<Subjects>(sub =>
            {
                sub.ToTable("tbl_subject");
                sub.HasKey(p => p.ID);
                sub.Property(p => p.Name).HasMaxLength(200);
                sub.Property(p => p.Status).HasDefaultValue(true);
            });
            modelBuilder.Entity<Marks>(mar =>
            {
                mar.ToTable("tbl_mark");
                mar.HasKey(p => new { p.SubjectId, p.StudentId });
                mar.Property(p => p.Scores).HasDefaultValue(0);
                mar.HasOne<Subjects>(p => p.Subject).WithMany(c => c.Marks).HasForeignKey(p => p.SubjectId);
                mar.HasOne<Students>(p => p.Student).WithMany(c => c.Marks).HasForeignKey(p => p.StudentId).IsRequired().OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
