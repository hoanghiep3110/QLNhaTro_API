using System;
using System.Linq;
using System.Web.Http;
using QLNhaTro_API.Models;

namespace QLNhaTro_API.APIController
{
    public class DICHVUController : ApiController
    {
        private DBQLNhaTro db = new DBQLNhaTro();
        // GET: api/DICHVU
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(db.DichVus.ToList());
        }

        // GET: api/DICHVU/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            DichVu dichVu = db.DichVus.SingleOrDefault(p => p.IdDichVu == id);
            if (dichVu == null)
            {
                return NotFound();
            }
            return Ok(dichVu);
        }

        // POST: api/DICHVU
        [HttpPost]
        public IHttpActionResult Post(DichVu dichVu)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Thêm dịch vụ không thành công. Vui lòng thử lại"));
                }
                db.DichVus.Add(dichVu);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Thêm dịch vụ không thành công. Vui lòng thử lại"));
            }
            return Ok(new Message(1, "Thêm dịch vụ thành công"));
        }

        // PUT: api/DICHVU/5
        [HttpPut]
        public IHttpActionResult Put(int id, DichVu newDichVu)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Thay đổi thông tin thất bại. Vui lòng kiểm tra và thử lại"));
                }
                var dichvu = db.DichVus.Find(id);
                if (dichvu == null)
                {
                    return Ok(new Message(2, "Không tìm thấy dịch vụ cần thay đổi thông tin. Vui lòng kiểm tra và thử lại"));
                }
                dichvu.TenDichVu = newDichVu.TenDichVu;
                dichvu.DonGia = newDichVu.DonGia;
                db.SaveChanges();

                //Return
                return Ok(new Message(1, "Thay đổi thông tin thành công"));
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Thay đổi thông tin thất bại. Vui lòng kiểm tra và thử lại"));
            }

        }

        // DELETE: api/DICHVU/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Xoá thất bại. Vui lòng kiểm tra và thử lại"));
                }
                DichVu dichVu = db.DichVus.Find(id);
                if (dichVu == null)
                {
                    return Ok(new Message(2, "Không tìm thấy dịch vụ cần xoá. Vui lòng kiểm tra và thử lại"));
                }
                db.DichVus.Remove(dichVu);
                db.SaveChanges();
                return Ok(new Message(1, "Xoá thành công"));
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Xoá thất bại. Vui lòng kiểm tra và thử lại"));
            }
        }
    }
}
