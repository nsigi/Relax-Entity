internal class Program
{
    private static void Main(string[] args)
    {
        // КОММЕНТИРУЙ ЭТУ СТРОЧКУ
        string dir = "C:\\Users\\_Asus_\\Documents\\Study\\ТСП\\RelaxEntity\\Relax-Entity\\RelaxEntityWeb\\wwwroot";

        Directory.SetCurrentDirectory(dir);
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
		builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession();

        var app = builder.Build();
		app.UseSession();
		// Configure the HTTP request pipeline.
		if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
		}
        //app.UseMvc();
		app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

		app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
		app.Run();
	}
}