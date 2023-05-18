using TreeApp.Data;

namespace TreeApp
{
    public static class DataSeeder
    {
        public static void Seed(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<BranchDataContext>();
            context.Database.EnsureCreated();
            AddBranches(context);
        }
        private static void AddBranches(BranchDataContext context)
        {
            var branch = context.Branches.FirstOrDefault();
            if (branch != null) return;

            context.Branches.Add(new Branch
            {
                Id = 1,
                Name = "Branch",
                ParentId = 0
            });
            context.Branches.Add(new Branch
            {
                Id = 2,
                Name = "Branch",
                ParentId = 1
            });
            context.Branches.Add(new Branch
            {
                Id = 3,
                Name = "Branch",
                ParentId = 1
            });
            context.Branches.Add(new Branch
            {
                Id = 4,
                Name = "Branch",
                ParentId = 2
            });
            context.Branches.Add(new Branch
            {
                Id = 5,
                Name = "Branch",
                ParentId = 3
            });
            context.Branches.Add(new Branch
            {
                Id = 6,
                Name = "Branch",
                ParentId = 3
            });
            context.Branches.Add(new Branch
            {
                Id = 7,
                Name = "Branch",
                ParentId = 3
            });
            context.SaveChanges();
        }
    }
}
