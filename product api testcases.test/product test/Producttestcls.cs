using Microsoft.EntityFrameworkCore;
using PRODUCT_API_APP.Controllers;
using PRODUCT_API_APP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace product_api_testcases.test.product_test
{
    public  class Producttestcls
    {
        public readonly DbContextOptions<productcls> _Options;
        public productcls db;
        public ProductController Controller;

        
        public Producttestcls()
        {
            _Options = new DbContextOptionsBuilder<productcls>().UseInMemoryDatabase(databaseName:"productestdb").Options;

            db=new productcls(_Options);
            Controller = new ProductController(db);

        }

        private static Products insertprd()
        {
            return new Products() 
            {
                id = 16,
                p_name = "Test",
                p_description = "Test2",
                p_price=1000,
            };

        }

        // --------------------------------------------------- Get Data --------------------------------------------
        [Fact]
        public void getprddata()
        {
            //setup
            var prdinsertdata = insertprd();
            db.Products.Add(prdinsertdata);
            db.SaveChanges();   

            //Exicute
            var res = Controller.Get(prdinsertdata.id);

            //Assert
            Assert.NotEmpty(res);
            Assert.Equal("Test", res.FirstOrDefault().p_name);
           

        }

        // -------------------------------------------------------- Insert Data -------------------------------------------
        [Fact]
        public void insertprddata() 
        {
            //setup
            var prdinsert = insertprd();

            //Exicute
            var res = Controller.Post(prdinsert);
            var result = db.Products.FirstOrDefault(x=> x.id == prdinsert.id);
            db.SaveChanges();

            //Assert
            Assert.NotNull(result);

        }

        // ------------------------------------------------------------ Update Data --------------------------------------------
        [Fact]
        public void prdupdate()
        {
            //setup
            var updateprd = insertprd();
            db.Products.Add(updateprd);
            db.SaveChanges();

            //Exicute
            var produpdate = new Products()
            {
                id= 16,
                p_name = "Bansil",
                p_description="Nariya",
                p_price=10000,
            };

            //Exicute
            var res = Controller.Put(produpdate.id, produpdate);
            var result = db.Products.FirstOrDefault();

            //Assert
            Assert.Equal("Bansil", result.p_name);
            Assert.NotNull (res);


        }

        // ----------------------------------------------------------------- Delete data ----------------------------------------------
        [Fact]
        public void deleteprddata()
        {
            //setup
            var deleproduct = insertprd();

            //Exicute
            var res = Controller.Delete(deleproduct.id);
            var result = db.Products.FirstOrDefault(x=> x.id ==deleproduct.id);


            //Assert
            Assert.Null(result);



        }

    }
}
