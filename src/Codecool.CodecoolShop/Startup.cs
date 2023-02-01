using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Data;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Codecool.CodecoolShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")

                ));
            //dao, AddScoped
            services.AddSingleton<Services.ICartManager, Services.CartManager>();
            
           
        }
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Product/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });

            SetupInMemoryDatabases();
        }

        private void SetupInMemoryDatabases()
        {
            IProductDao productDataStore = ProductDaoMemory.GetInstance();
            IProductCategoryDao productCategoryDataStore = ProductCategoryDaoMemory.GetInstance();
            ISupplierDao supplierDataStore = SupplierDaoMemory.GetInstance();

            Supplier amazon = new Supplier{Name = "Amazon", Description = "Digital content and services"};
            supplierDataStore.Add(amazon);
            Supplier lenovo = new Supplier{Name = "Lenovo", Description = "Computers"};
            supplierDataStore.Add(lenovo);
            Supplier asus = new Supplier{Name = "Asus", Description = "Computers"};
            supplierDataStore.Add(asus);
            Supplier acer = new Supplier{Name = "Acer", Description = "Computers"};
            supplierDataStore.Add(acer);
            Supplier samsung = new Supplier{Name = "Samsung", Description = "Computers"};
            supplierDataStore.Add(samsung);
            Supplier apple = new Supplier{Name = "Apple", Description = "Computers"};
            supplierDataStore.Add(apple);
            Supplier msi = new Supplier{Name = "Msi", Description = "Computers"};
            supplierDataStore.Add(msi);
            Supplier sony = new Supplier{Name = "Sony", Description = "Computers"};
            supplierDataStore.Add(sony);
            ProductCategory tablet = new ProductCategory {Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            ProductCategory laptop = new ProductCategory {Name = "Laptop", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            ProductCategory computer = new ProductCategory {Name = "Computer", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            ProductCategory desk = new ProductCategory {Name = "Desk", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            ProductCategory soundbar = new ProductCategory {Name = "Soundbar", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            ProductCategory accessories = new ProductCategory {Name = "Accessories", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            ProductCategory smartphone = new ProductCategory {Name = "smartphone", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            productCategoryDataStore.Add(tablet);
            productCategoryDataStore.Add(laptop);
            productCategoryDataStore.Add(computer);
            productCategoryDataStore.Add(desk);
            productCategoryDataStore.Add(soundbar);
            productCategoryDataStore.Add(accessories);
            productCategoryDataStore.Add(smartphone);
            productDataStore.Add(new Product { Name = "Amazon Fire", DefaultPrice = 49.9m, Currency = "USD", Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", ProductCategory = tablet, Supplier = amazon });
            productDataStore.Add(new Product { Name = "Lenovo IdeaPad Miix 700", DefaultPrice = 479.0m, Currency = "USD", Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", ProductCategory = tablet, Supplier = lenovo });
            productDataStore.Add(new Product { Name = "Amazon Fire HD 8", DefaultPrice = 89.0m, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategory = tablet, Supplier = amazon });
            productDataStore.Add(new Product { Name = "SonyXperia10", DefaultPrice = 189.0m, Currency = "USD", Description = "Xperia's latest smartphone", ProductCategory = smartphone, Supplier = sony });
            productDataStore.Add(new Product { Name = "ASUS X515JA-BQ2633W", DefaultPrice = 2499.99m, Currency = "USD", Description = "Surfing the web, office work, multimedia entertainment - ASUS X515JA is a laptop so versatile you can use it in many different ways.", ProductCategory = laptop, Supplier = asus });
            productDataStore.Add(new Product { Name = "Apple iPhone 14", DefaultPrice = 4499.99m, Currency = "USD", Description = "Meet the iPhone 14 and the much larger iPhone 14 Plus. They have casings in five beautiful colors. Accident detection. The most efficient batteries. And they take even more beautiful photos in low light.", ProductCategory = smartphone, Supplier = apple });
        }
    }
}
