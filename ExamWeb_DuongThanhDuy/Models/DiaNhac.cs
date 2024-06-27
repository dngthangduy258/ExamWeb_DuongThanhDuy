using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamWeb_DuongThanhDuy.Models
{
    public class DiaNhac
    {
        public int Id { get; set; }
        [StringLength(250)]
        [Required(ErrorMessage ="Chưa nhập tên cd")]
        public string TuaCD { get; set; }
        [StringLength(50)]
        [Required(ErrorMessage = "Chưa nhập tên nghệ sĩ")]

        public string NgheSi { get; set; }
        public bool TrongNuoc { get; set; }
        [Range(1,1000,ErrorMessage ="Số lượng không hợp lệ")]
        public double GiaBan { get; set; }
        [Range(1, 1000, ErrorMessage = "Số lượng không hợp lệ")]

        public int SoLuong { get; set; }
    }
}
