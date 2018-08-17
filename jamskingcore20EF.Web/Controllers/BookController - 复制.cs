using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using jamskingcore20EF.Service.DBContexts;
using jamskingcore20EF.Service.PubJams;
using jamskingcore20EF.Model.ViewModel;
using jamskingcore20EF.Model.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;


namespace jamskingcore20EF.Web.Controllers
{
    public class BookController : Controller
    {
        static List<Book> BookList = new List<Book>();
        private JADbContext context;

        public BookController(JADbContext context)
        {
            this.context = context;
        }

        //需要加MODEL里面的东西，把例里的MODELS全部加到MODEL 里面，在共享文件夹里
        [HttpGet]
        public ActionResult Index()
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult GetDSAll(string name, string sortOrder = "desc", string sortName = "ID", int pageIndex = 1, int pageSize = 10)
        {
            var tempList = context.Set<Book>().ToList();
            if (sortOrder == "desc" && sortName == "ID")
            {
                tempList = tempList.OrderByDescending(b => b.Id).ToList();
            }
            else
            {
                tempList = tempList.OrderBy(b => b.Id).ToList();
            }
            if (!string.IsNullOrWhiteSpace(name))
            {
                tempList = tempList.Where(p => p.Name.Contains(name)).ToList();
            }
            var currentPersonList = tempList
                                              .Skip((pageIndex - 1) * pageSize)
                                              .Take(pageSize);

            
            
            var result = new Dictionary<string, object>();
            //var limit = Convert.ToInt32(Request.Form["limit"]);//每页的个数
            //var offset = Convert.ToInt32(Request.Form["offset"]);//分页时数据的偏移量
                                                                 //var order = Request.QueryString["order"].ToString();//排序 asc desc

            var msg = "加载成功";
            try
            {
                var total = tempList.Count();
                var rows = currentPersonList.Select(b => new { Id = b.Id, Name = b.Name });
                
                result.Add("rows", rows);
                result.Add("total", total);
                result.Add("IsOk", true);
                result.Add("msg", msg);
            }
            catch (Exception ex)
            {
                msg = "加载失败";
                result.Add("IsOk", false);
                result.Add("msg", msg);
            }
            return Json(result);
            
            
        }
        #region 修改
        /// <summary>
        /// 修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var book = context.Set<Book>().SingleOrDefault(b => b.Id == id);
            return View(book);
        }
        /// <summary>
        /// 修改提交
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(BookViewModel bookv,long? id)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("success", true);
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Book book = isNew ? new Book
                    {
                        AddedDate = DateTime.UtcNow
                    } : context.Set<Book>().SingleOrDefault(b => b.Id == id.Value);
                    book.Name = bookv.Name;
                    book.ISBN = bookv.ISBN;
                    book.Author = bookv.Author;
                    book.Publisher = bookv.Publisher;
                    book.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    book.ModifiedDate = DateTime.UtcNow;
                    if (isNew)
                    {
                        context.Add(book);
                    }
                    context.SaveChanges();
                    result["success"] = false;
                    result.Add("msg", "修改成功！");
                }
            }
            catch (Exception ex)
            {
                result["success"] = false;
                result.Add("msg", "修改失败！");
                throw ex;
            }
            
           
            return Json(result);
        }
        #endregion

        public ActionResult UpdateRow(long? id,BookViewModel model)
        {
            var result = new Dictionary<string, object>();
            var msg = "出现异常";
            var state = false;
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Book book = isNew ? new Book
                    {
                        AddedDate = DateTime.UtcNow
                    } : context.Set<Book>().SingleOrDefault(s => s.Id == id.Value);
                    book.Name = model.Name;
                    book.ISBN = model.ISBN;
                    book.Author = model.Author;
                    book.Publisher = model.Publisher;
                    book.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    book.ModifiedDate = DateTime.UtcNow;
                    if (isNew)
                    {
                        context.Add(book);
                    }
                    context.SaveChanges();
                    state = true;
                    msg = "修改成功";
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                state = false;
                msg = "修改失败"+ ex;
            }
           
            
            result.Add("state", state);
            result.Add("msg", msg);
            return Json(result);
        }
        public ActionResult DeleteRow(int id)
        {
            var result = new Dictionary<string, object>();
            var msg = "删除成功";
            var state = true;
            if (id == 0)
            {
                msg = "删除异常";
                state = false;
            }
            else
            {
                try
                {
                    Book book = context.Set<Book>().SingleOrDefault(c => c.Id == id);
                    context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    context.SaveChanges();
                    msg = "删除成功";
                    state = true;
                }
                catch (Exception ex)
                {
                    msg = "删除失败";
                    state = false;
                }
            }
            result.Add("state", state);
            result.Add("msg", msg);
            return Json(result);
        }
        VJson vj = new VJson();
        public ActionResult AddorEditi(int id)
        {
            var book = context.Set<Book>().SingleOrDefault(b => b.Id == id);
            return View(book);
        }
        [HttpPost]
        public ActionResult AddorEdit(BookViewModel model)
        {
            var result = new Dictionary<string, object>();
            var msg = "出现异常";
            var state = false;
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = false;
                    if (model.Id == 0)
                    {
                        isNew = true;
                    }
                    Book book = isNew ? new Book
                    {
                        AddedDate = DateTime.UtcNow
                    } : context.Set<Book>().SingleOrDefault(s => s.Id == model.Id);
                    book.Name = model.Name;
                    book.ISBN = model.ISBN;
                    book.Author = model.Author;
                    book.Publisher = model.Publisher;
                    book.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    book.ModifiedDate = DateTime.UtcNow;
                    if (isNew)
                    {
                        context.Add(book);
                        msg = "添加成功";
                    }
                    else
                    {
                        msg = "修改成功";
                    }
                    context.SaveChanges();
                    state = true;
                    
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                state = false;
                msg = "修改失败" + ex;
            }


            result.Add("state", state);
            result.Add("msg", msg);
            return Json(result);
        }

        [HttpGet]
        public IActionResult AddEditBook(long? id)
        {
            BookViewModel model = new BookViewModel();
            if (id.HasValue)
            {
                Book book = context.Set<Book>().SingleOrDefault(c => c.Id == id.Value);
                if (book != null)
                {
                    model.Id = book.Id;
                    model.Name = book.Name;
                    model.ISBN = book.ISBN;
                    model.Author = book.Author;
                    model.Publisher = book.Publisher;
                }
            }
            return PartialView("~/Views/Book/_AddEditBook.cshtml", model);
        }

        [HttpPost]
        public IActionResult AddEditBook(long? id, BookViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Book book = isNew ? new Book
                    {
                        AddedDate = DateTime.UtcNow
                    } : context.Set<Book>().SingleOrDefault(s => s.Id == id.Value);
                    book.Name = model.Name;
                    book.ISBN = model.ISBN;
                    book.Author = model.Author;
                    book.Publisher = model.Publisher;
                    book.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
                    book.ModifiedDate = DateTime.UtcNow;
                    if (isNew)
                    {
                        context.Add(book);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DeleteBook(long id)
        {
            Book book = context.Set<Book>().SingleOrDefault(c => c.Id == id);
            string bookName = book.Name;
            return PartialView("~/Views/Book/_DeleteBook.cshtml", model: bookName);
        }
        [HttpPost]
        public IActionResult DeleteBook(long id, IFormCollection form)
        {
            Book book = context.Set<Book>().SingleOrDefault(c => c.Id == id);
            context.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
