# Store App Demo
This is a work in progress store application with admin dashboard.

<div>
<ul>
	<li>C#</li>
	<li>ASP.NET Core 5</li>
	<li>SQL database</li>
</ul>
</div>



> EntityFramework:
Scaffold-DbContext "Server=192.168.0.200;Database=StoreApp;User ID=superuser;Password=superuser;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Data/DatabaseModel" -f

<b>HOX! In Category model you must use [Key] -data-annotiation for CategoryId.</b>


## Sources

SQLQueries:
https://stackoverflow.com/questions/58347444/entity-framework-core-3-raw-sql-missing-methods

Admin Template:
https://startbootstrap.com/theme/sb-admin-2

Populating dropdownlist from db:
https://www.c-sharpcorner.com/article/set-default-value-to-dropdown-list-from-database-in-asp-net-mvc/

Static ImageDir:
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-5.0
Startup.cs------>
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), @"Content/ProductImages")),
                RequestPath = new PathString("/Content/ProductImages")
            });


Frontpage search:
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/search?view=aspnetcore-5.0

Frontpage pagination:
https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/sort-filter-page?view=aspnetcore-5.0

Session:
https://docs.microsoft.com/en-us/aspnet/core/fundamentals/app-state?view=aspnetcore-5.0
https://benjii.me/2016/07/using-sessions-and-httpcontext-in-aspnetcore-and-mvc-core/


## Screenshots

<a data-flickr-embed="true" href="https://www.flickr.com/photos/55156353@N07/51686986984/in/dateposted-public/" title="storeFront"><img src="https://live.staticflickr.com/65535/51686986984_69fb9b573f_w.jpg" width="600"  alt="storeFront"></a>
<br />
<a data-flickr-embed="true" href="https://www.flickr.com/photos/55156353@N07/51686578103/in/dateposted-public/" title="storeBasket"><img src="https://live.staticflickr.com/65535/51686578103_84c4d0b50c_w.jpg" width="600" alt="storeBasket"></a>
<br />
<a data-flickr-embed="true" href="https://www.flickr.com/photos/55156353@N07/51686302631/in/dateposted-public/" title="adminDash"><img src="https://live.staticflickr.com/65535/51686302631_5e2a48ed4e_w.jpg" width="600"  alt="adminDash"></a>
