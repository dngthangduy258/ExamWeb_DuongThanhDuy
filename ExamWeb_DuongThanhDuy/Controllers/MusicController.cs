using ExamWeb_DuongThanhDuy.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamWeb_DuongThanhDuy.Controllers
{
    public class MusicController : Controller
    {
        private readonly ApplicationDbContext _db;
        public MusicController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var dsMusic = _db.DiaNhacs.ToList();
            var tongsoluong = _db.DiaNhacs.Sum(x => x.SoLuong);
            ViewBag.SUM = tongsoluong;
            return View(dsMusic);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(DiaNhac dianhac)
        {
            if (ModelState.IsValid)
            {
                _db.DiaNhacs.Add(dianhac);
                _db.SaveChanges();
                TempData["success"] = "Đã thêm 1 đĩa nhạc";
                return RedirectToAction("Index");
            }
            return View(dianhac);
        }

        public IActionResult Update(int id)
        {
            var diaNhac = _db.DiaNhacs.SingleOrDefault(x => x.Id == id);
            if (diaNhac != null)
                return View(diaNhac);

            return NotFound();
        }

        [HttpPost]
        public IActionResult Update(DiaNhac book)
        {
            if (ModelState.IsValid)
            {
                _db.DiaNhacs.Update(book);
                _db.SaveChanges();
                TempData["success"] = "Đã cập nhật 1 đĩa nhạc";
                return RedirectToAction("Index");
            }
            return View(book);
        }
        //Hiển thị form xác nhận xóa sản phẩm
        public IActionResult Delete(int id)
        {
            var product = _db.DiaNhacs.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        //Xử lý xóa sản phẩm
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _db.DiaNhacs.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            // xoá hình cũ của sản phẩm
           
            // xoa san pham khoi CSDL
            _db.DiaNhacs.Remove(product);
            _db.SaveChanges();
            TempData["success"] = "Product deleted success";
            //chuyen den action index
            return RedirectToAction("Index");
        }
    }
}
