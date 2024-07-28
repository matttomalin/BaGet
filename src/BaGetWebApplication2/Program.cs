using BaGet;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddBaGetWebApplication(app =>
{
    app.AddSqliteDatabase();
    app.AddFileStorage();
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

var baget = new BaGetEndpointBuilder();
baget.MapEndpoints(app);

app.Run();
