using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PRODUCT_API_APP.Models;

namespace PRODUCT_API_APP.Controllers
{
    [Route("PRODUCT_DATA")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly productcls db;
        

        public ProductController(productcls context)
        {
            db = context;
        }



        //GET
        [HttpGet]
        public IEnumerable<Products> Get([FromQuery] int id)
        {
            
            var x= db.Products.Where(x => x.id == id);
            db.SaveChanges();
            return x;

        }


        //INSERT DATA
        [HttpPost]
        public IActionResult Post([FromBody] Products pdt)
        {
            if(pdt == null)
            {
                return Ok(ErrorCode.INVALID_DATA);

            }
            else
            {
                try
                {
                    db.Products.Add(pdt);
                    db.SaveChanges();
                    return Ok(ErrorCode.INSERT_DATA);

                }
                catch (Exception)
                {
                    return Ok(ErrorCode.ERROR);
                }
            }
            

        }


        //UPDATE DATA
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Products pdt)
        {
            if(pdt == null)
            {
                return Ok(ErrorCode.INVALID_DATA);
            }
            else
            {
                try
                {
                    var exite =db.Products.FirstOrDefault(x=> x.id == id);
                    exite.p_name=pdt.p_name;
                    exite.p_description=pdt.p_description;
                    exite.p_price=pdt.p_price;
                    db.Products.Update(exite);
                    db.SaveChanges(); 
                    return Ok(ErrorCode.UPDATE_DATA);


                }
                catch (Exception) 
                {
                    return Ok(ErrorCode.ERROR);

                }

            }
        }


        //DELETING DATA
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var deletedata = db.Products.Where(x => x.id == id).FirstOrDefault();

            if(deletedata == null)
            {
                return Ok(ErrorCode.INVALID_DATA);
            }
            else
            {
                try
                {
                    db.Products.Remove(deletedata);
                    db.SaveChanges();
                    return Ok(ErrorCode.DELETE_DATA);


                }
                catch (Exception)
                {
                    return Ok(ErrorCode.ERROR);

                }
            }
        }
    }
}
