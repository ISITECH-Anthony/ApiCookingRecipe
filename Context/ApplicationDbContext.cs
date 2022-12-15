namespace ApiScrabble.Context;

using Microsoft.EntityFrameworkCore;
using ApiScrabble.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<ApiScrabble.Entities.User> users { get; set; }
    public DbSet<ApiScrabble.Entities.Recipe> recipes { get; set; }
    public DbSet<ApiScrabble.Entities.RecipeStep> recipeSteps { get; set; }
    public DbSet<ApiScrabble.Entities.RecipeStepFood> recipeStepFoods { get; set; }
    public DbSet<ApiScrabble.Entities.Food> foods { get; set; }
    public DbSet<ApiScrabble.Entities.UnitMeasure> unitMeasures { get; set; }
    public DbSet<ApiScrabble.Entities.Opinion> opinions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // create primary keys
        modelBuilder.Entity<RecipeStepFood>()
            .HasKey(rsf => new { rsf.recipe_step_id, rsf.food_id });


        // create reationships
        modelBuilder.Entity<RecipeStepFood>()
            .HasOne(rsf => rsf.recipe_step)
            .WithMany(rs => rs.recipeStepFoods)
            .HasForeignKey(rsf => rsf.recipe_step_id);

        modelBuilder.Entity<RecipeStepFood>()
            .HasOne(rsf => rsf.food)
            .WithMany(f => f.recipeStepFoods)
            .HasForeignKey(rsf => rsf.food_id);

        modelBuilder.Entity<RecipeStepFood>()
            .HasOne(rsf => rsf.unit_measure)
            .WithMany(um => um.recipeStepFoods)
            .HasForeignKey(rsf => rsf.unit_measure_id);

        modelBuilder.Entity<Recipe>()
            .HasOne(r => r.user)
            .WithMany(u => u.recipes)
            .HasForeignKey(r => r.user_id);

        modelBuilder.Entity<RecipeStep>()
            .HasOne(rs => rs.recipe)
            .WithMany(r => r.recipeSteps)
            .HasForeignKey(rs => rs.recipe_id);

        modelBuilder.Entity<Opinion>()
            .HasOne(o => o.recipe)
            .WithMany(r => r.opinions)
            .HasForeignKey(o => o.recipe_id);
    }

    // override SaveChanges to set created_at and updated_at automatically
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e.Entity is BaseEntity && ( e.State == EntityState.Added || e.State == EntityState.Modified));

        var now = DateTime.Now;

        foreach (var entityEntry in entries)
        {

            if (entityEntry.State == EntityState.Added)
            {
                ((BaseEntity)entityEntry.Entity).created_at = now;
            }

            ((BaseEntity)entityEntry.Entity).updated_at = now;
        }
        int result = await base.SaveChangesAsync();

        return  result;
    }
}