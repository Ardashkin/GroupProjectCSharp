using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DAL;
using Shop.DAL.Repository;
using Shop.Models;

namespace Shop.BLL
{
    public class ProductDomainModel : BaseDomainModel
    {
        public Models.Product GetLast()
        {
            using (var repository = new BaseRepository<DAL.Product, long>())
            {
                var list = repository.Query().Select(x => new Models.Product
                {
                    Artikul = x.Artikul,
                    Name = x.Name,
                    Mark = x.Mark,
                    Cost = x.Cost,
                    Sale = x.Sale,
                    Sale_cost = x.Sale_cost,
                    Amount_store = x.Amount_store,
                    Visible = x.Visible,
                    Popularity = x.Popularity
                }).ToList();
                var last = list.Last();
                return last;
            }
        }

        public Models.Product GetOne(Func<object, object> p)
        {
            throw new NotImplementedException();
        }

        public void Update(Models.ProductPageModel pr, int[] categories, string[] images)
        {
            DAL.Product dalPr = new DAL.Product();
            dalPr.Artikul = pr.Artikul;
            dalPr.Name = pr.Name;
            dalPr.Mark = pr.Mark;
            dalPr.Cost = pr.Cost;
            dalPr.Sale = pr.Sale;
            dalPr.Sale_cost = pr.Sale_cost;
            dalPr.Visible = pr.Visible;
            dalPr.Amount_store = pr.Amount_store;
            dalPr.Information = pr.Information;
            dalPr.Popularity = pr.Popularity;
            using (var repository = new BaseRepository<DAL.Product, long>())
            {
                repository.Update(dalPr);
            }
           
            using (var repository2 = new BaseRepository<DAL.ProductCategory, long>())
            {
                var cats = repository2.Query().Where(x=>x.Artikul==pr.Artikul).Select(x => new ProductCategoryModel
                {
                    Pr_cat_id = x.Pr_cat_id,
                    Category_id = x.Category_id,
                    Artikul = x.Artikul
                }).ToList();
                foreach (var v in cats)
                {
                    repository2.Delete(v.Pr_cat_id);
                }
                foreach (var v in categories)
                {
                    var cat = new ProductCategory();
                    cat.Artikul = dalPr.Artikul;
                    cat.Category_id = v;
                    repository2.Insert(cat);
                }
            }

        }
        //public void Delete(Models.Product pr)
        //{
        //    DAL.Product dalPr = new DAL.Product();
        //    dalPr.Artikul = pr.Artikul;
        //    dalPr.Name = pr.Name;
        //    dalPr.Mark = pr.Mark;
        //    dalPr.Cost = pr.Cost;
        //    dalPr.Sale = pr.Sale;
        //    dalPr.Sale_cost = pr.Sale_cost;
        //    dalPr.Visible = pr.Visible;
        //    dalPr.Amount_store = pr.Amount_store;
        //    dalPr.Popularity = pr.Popularity;
        //    using (var repository = new BaseRepository<DAL.Product, long>())
        //    {
        //        repository.Delete(dalPr.Artikul);
        //    }
        //    using (var repository1 = new BaseRepository<DAL.Image, long>())
        //    {
        //        var images = repository1.Query().Select(x => new Models.BannerModel
        //        {
        //            Artikul = pr.Artikul
        //        }).ToList();
        //        foreach (var im in images)
        //        {
        //            Image Im = new Image();
        //            Im.Artikul = im.Artikul;
        //            Im.Image_id = im.Image_id;
        //            Im.Image_path = im.Image_path;
        //            repository1.Delete(Im.Image_id);
        //        }
        //        //foreach (var pr in list)
        //        //{
        //        //    pr.Image_path = images.Where(c => c.Artikul == pr.Artikul)
        //        //       .Select(c => c.Image_path).FirstOrDefault();
        //        //}
        //    }
        //}

        public Models.Product GetOne(long pr)
        {
            using (var repository = new BaseRepository<DAL.Product, long>())
            {
                var list = repository.Query().Select(x => new Models.Product
                {
                    Artikul = x.Artikul,
                    Name = x.Name,
                    Mark = x.Mark,
                    Cost = x.Cost,
                    Sale = x.Sale,
                    Sale_cost = x.Sale_cost,
                    Amount_store = x.Amount_store,
                    Visible = x.Visible,
                    Popularity = x.Popularity
                }).ToList();

                var product = list.FirstOrDefault(g => g.Artikul == pr);
                return product;
            }
        }

        public void Create(Models.ProductPageModel pr, int[] categories)
        {
            DAL.Product dalPr = new DAL.Product();
            using (var repository = new BaseRepository<DAL.Product, long>())
            {
                dalPr.Name = pr.Name;
                dalPr.Mark = pr.Mark;
                dalPr.Cost = pr.Cost;
                dalPr.Sale = pr.Sale;
                dalPr.Sale_cost = pr.Sale_cost;
                dalPr.Visible = pr.Visible;
                dalPr.Amount_store = pr.Amount_store;
                dalPr.Information = pr.Information;
                dalPr.Popularity = pr.Popularity;
                var list = repository.Query().Select(x => new Models.Product
                {
                    Artikul = x.Artikul,
                    Name = x.Name,
                    Mark = x.Mark,
                    Cost = x.Cost,
                    Sale = x.Sale,
                    Sale_cost = x.Sale_cost,
                    Amount_store = x.Amount_store,
                    Visible = x.Visible,
                    Popularity = x.Popularity
                }).ToList();
                var last = list.Last();
                dalPr.Artikul = last.Artikul;
                repository.Insert(dalPr);
            }
                
            using (var repository2 = new BaseRepository<DAL.ProductCategory, long>())
            {
                foreach (var v in categories)
                {
                    //var cats = repository2.Query().Select(x => new DAL.ProductCategory
                    //{
                    //    Pr_cat_id = x.Pr_cat_id,
                    //    Category_id = x.Category_id,
                    //    Artikul = x.Artikul
                    //}).ToList();
                    var cat = new ProductCategory();
                    cat.Artikul = dalPr.Artikul;
                    cat.Category_id = v;
                    //cat.Pr_cat_id = cats.Last().Pr_cat_id;
                    repository2.Insert(cat);
                }
                //foreach (var pr in list)
                //{
                //    pr.Image_path = images.Where(c => c.Artikul == pr.Artikul)
                //       .Select(c => c.Image_path).FirstOrDefault();
                //}
            }
            // repository.Insert(new ProductTable { Name = "Test1" });
        }
        

        public IEnumerable<Models.Product> GetAll()
        {
            using (var repository = new BaseRepository<DAL.Product, long>())
            {
                var list = repository.Query().Select(x => new Models.Product
                {
                    Artikul = x.Artikul,
                    Name = x.Name,
                    Mark = x.Mark,
                    Cost = x.Cost,
                    Sale = x.Sale,
                    Sale_cost = x.Sale_cost,
                    Amount_store = x.Amount_store,
                    Visible = x.Visible,
                    Popularity = x.Popularity
                }).ToList();
                return list;
            }
        }

        // Take product description for Page "ProductsList" from 2 tables:
        // Image_path + all Product fields
        

        public Models.ProductPageModel ProductPage(long id)
        {
            ProductPageModel result = new ProductPageModel();
            using (var repository = new BaseRepository<DAL.Product, long>())
            {

                var product = repository.Query().Where(x => x.Artikul == id).Select(x => new Models.ProductPageModel
                {
                    Artikul = x.Artikul,
                    Name = x.Name,
                    Mark = x.Mark,
                    Cost = x.Cost,
                    Sale = x.Sale,
                    Sale_cost = x.Sale_cost,
                    Amount_store = x.Amount_store,
                    Visible = x.Visible,
                    Information = x.Information,
                    Popularity = x.Popularity
                }).FirstOrDefault();
                result = product;
            }                       
            return result;
        }
    }
}
