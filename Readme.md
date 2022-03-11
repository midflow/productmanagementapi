This is a simple api service to manage product that use .NET CORE 6.0 and EFCore 6.
default using inMemoryDatabase for testting but we can change the database to UseSqlServer by uncomment the line using UseSqlServer in program.cs and comment the line using InMemoryDatabase

//options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnectionString"));
options.UseInMemoryDatabase("ProductManagement");
    
    
    defaultConnectionString is in "appsettings.json"
