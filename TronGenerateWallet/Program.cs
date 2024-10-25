using TronGenerateWallet.Services;
using TronNet;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddTronNet(x =>
{
    x.Network = TronNetwork.MainNet;
    x.Channel = new GrpcChannelOption { Host = "grpc.nile.trongrid.io", Port = 50051 };
    x.SolidityChannel = new GrpcChannelOption { Host = "grpc.nile.trongrid.io", Port = 50052 };
    x.ApiKey = "TRON GRÝD APÝKEY";
});

builder.Services.AddScoped<TronWalletGenerateService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
