using AplicacaoCarrinho.GerenciaArquivos;
using AplicacaoCarrinho.Repository;
using AplicacaoCarrinho.Repository.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

// interface como serviço
builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = contet => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});


// corrigir problemas com TempData para aumentar o tempo de duração
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(900);
    options.Cookie.HttpOnly = true;
    // deixar informado para o navegador que a sessão é essencial
    options.Cookie.IsEssential = true;

});
builder.Services.AddMvc().AddSessionStateTempDataProvider();

builder.Services.AddMemoryCache();


// add gerenciador arquivo como serviços
builder.Services.AddScoped<GerenciadorArquivo>();
builder.Services.AddScoped<AplicacaoCarrinho.Cookie.Cookie>();
builder.Services.AddScoped<AplicacaoCarrinho.CarrinhoCompra.CookieCarrinhoCompra>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
