using QLNhaTro_API.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace QLNhaTro_API.APIController
{
    public class PHONGController : ApiController
    {
        private DBQLNhaTro db = new DBQLNhaTro();
        // GET: api/PHONG
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(db.Phongs.ToList());
        }

        // GET: api/PHONG/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Phong phong = db.Phongs.SingleOrDefault(p => p.IdPhong == id);
            if (phong == null)
            {
                return NotFound();
            }
            
            // Return
            return Ok(phong);
        }

        // POST: api/PHONG
        [HttpPost]
        public IHttpActionResult Post(Phong phong)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Thêm phòng không thành công. Vui lòng thử lại"));
                }
                phong.TrangThai = 0;
                db.Phongs.Add(phong);
                db.SaveChanges();

                //Return
                return Ok(new Message(1, "Thêm phòng thành công"));
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Thêm phòng không thành công. Vui lòng thử lại"));
            }
        }

        // PUT: api/PHONG/5
        [HttpPut]
        public IHttpActionResult Put(int id, Phong newPhong)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Thay đổi thông tin thất bại. Vui lòng kiểm tra và thử lại"));
                }
                var phong = db.Phongs.Find(id);
                if (phong == null)
                {
                    return Ok(new Message(2, "Không tìm thấy phòng cần thay đổi thông tin. Vui lòng kiểm tra và thử lại"));
                }
                phong.TenPhong = newPhong.TenPhong;
                phong.TrangThai = newPhong.TrangThai;
                db.SaveChanges();

                // Return
                return Ok(new Message(1, "Thay đổi thông tin thành công"));
            }
            catch (Exception )
            {
                return Ok(new Message(0, "Thay đổi thông tin thất bại. Vui lòng kiểm tra và thử lại"));
            }
        }

        // DELETE: api/PHONG/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Ok(new Message(0, "Xoá thất bại. Vui lòng kiểm tra và thử lại"));
                }
                Phong phong = db.Phongs.Find(id);
                if (phong == null)
                {
                    return Ok(new Message(2, "Không tìm thấy phòng cần xoá. Vui lòng kiểm tra và thử lại"));
                }
                db.Phongs.Remove(phong);
                db.SaveChanges();

                //Return
                return Ok(new Message(1, "Xoá thành công"));
            }
            catch (Exception)
            {
                return Ok(new Message(0, "Xoá thất bại. Vui lòng kiểm tra và thử lại"));
            }
        }

        //public IHttpActionResult test(int id)
        //{
        //    try
        //    {
        //        // Begin transaction
        //        db.Connection.Open();
        //        System.Data.Common.DbTransaction trans = db.Connection.BeginTransaction();
        //        db.Transaction = trans;
        //        // Processing
        //        if (!ModelState.IsValid)
        //        {
        //            return Ok(new Message(0, "Xoá thất bại. Vui lòng kiểm tra và thử lại"));
        //        }
        //        Phong phong = db.Phongs.Find(id);
        //        if (phong == null)
        //        {
        //            return Ok(new Message(2, "Không tìm thấy phòng cần xoá. Vui lòng kiểm tra và thử lại"));
        //        }
        //        db.Phongs.Remove(phong);
        //        db.SaveChanges();
        //        // Commit data
        //        trans.Commit();
        //        // Return
        //        return Ok(new Message(1, "Xoá thành công"));
        //    }
        //    catch (Exception ex)
        //    {
        //        // Case: Error, then rollback database
        //        if (trans != null)
        //            trans.Rollback();
        //        return Ok(new Message(0, "Xóa phòng không thành công. Vui lòng thử lại"));
        //    }
        //}
    }
}
