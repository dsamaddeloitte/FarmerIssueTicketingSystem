namespace Farmer_Issues.Models
{
    public class DataSeeder
    {
        public static async Task SeedAsync(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if(context.Users.Any())
            {
                return;
            }
            var farmer = new User
            {
                Username = "farmer1",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("farmerpassword"),
                Role = "Farmer"
            };
            var fertilzer = new User
            {
                Username = "fertilizer1",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("fertilizerpassword"),
                Role = "Fertilizer"
            };
            context.Users.Add(farmer);
            context.Users.Add(fertilzer);
            await context.SaveChangesAsync();

        }
        

    }
}
