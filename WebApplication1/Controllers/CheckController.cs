using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckController : ControllerBase
    {
        
        private readonly PaymentDetailContext db;

        public CheckController(PaymentDetailContext context)
        {
            db = context;
        }
        // GET: api/Check
        [HttpGet]
        public IActionResult Get()
        {
            List<FireAlarm> userData = db.fireAlarms.ToList();
            List<FireAlarm> data = new List<FireAlarm>();

            try
            {
                if (userData != null)
                {
                    if (userData.Count > 0)
                    {
                        foreach (var item in userData)
                        {
                            FireAlarm fireAlarm = new FireAlarm();
                            fireAlarm.id = item.id;
                            fireAlarm.Myid = item.Myid;
                            fireAlarm.Name = item.Name;
                            fireAlarm.Address = item.Address;
                            fireAlarm.Email = item.Email;
                            data.Add(fireAlarm);
                        }
                    }
                }
                return Ok(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
            //return new string[] { "value1", "value2" };
        

        // GET: api/Check/5
        [HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    var res = from k in db.PaymentDetails
        //              where k.PaymentDetailId == id
        //              select k;

        //    PaymentDetail t = (PaymentDetail)res.FirstOrDefault();
        //    return Ok(t);
        //}

        // GetBy method 2
        public IActionResult GetPaymentById(int id)
        {
            try
            {                
                PaymentDetail paymentDetail = new PaymentDetail();
                Base response = new Base();
                var p1 = db.PaymentDetails.Where(x => x.PaymentDetailId == id).FirstOrDefault();
                if (p1 == null)
                {
                    response.Message = "Record Not Found";
                    response.StatusReason = false;
                    return Ok(response);
                }

                paymentDetail.PaymentDetailId = p1.PaymentDetailId;
                paymentDetail.CardOwnerName = p1.CardOwnerName;
                paymentDetail.CardNumber = p1.CardNumber;
                paymentDetail.ExpirationDate = p1.ExpirationDate;
                paymentDetail.SecurityCode = p1.SecurityCode;
                //response.Message = "Record Found";
                //response.StatusReason = true;
                
                return Ok(paymentDetail);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Check
        
        [HttpPost]
        public IActionResult Post(FireAlarm p1)
        {
            try
            {
                FireAlarm fireAlarm = new FireAlarm();
                //fireAlarm.id = p1.id;
                fireAlarm.Myid = p1.Myid;
                fireAlarm.Name = p1.Name;
                fireAlarm.Address = p1.Address;
                fireAlarm.Email = p1.Email;
                db.fireAlarms.Add(fireAlarm);
                db.SaveChanges();
                Base response = new Base();
                response.Message = "Added Successfully";
                response.StatusReason = true;
                return Ok(response);

            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // PUT: api/Check/5
        [HttpPut("{id}")]        
        public IActionResult UpdatePayment(PaymentDetail p1)
        {
            try
            {
                var paymentD = db.PaymentDetails.Where(x => x.PaymentDetailId == p1.PaymentDetailId).FirstOrDefault();

                //paymentD.PaymentDetailId = p1.PaymentDetailId;
                paymentD.CardOwnerName = p1.CardOwnerName;
                paymentD.CardNumber = p1.CardNumber;
                paymentD.ExpirationDate = p1.ExpirationDate;
                paymentD.SecurityCode = p1.SecurityCode;
                
                db.SaveChanges();
                Base response = new Base();
                response.Message = "Updated Successfully";
                response.StatusReason = true;
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePayment(int id)
        {
            try
            {
                Base response = new Base();
                if (id <= 0)
                    return BadRequest("Not a valid Id");

                var data = db.fireAlarms.Where(x => x.Myid == id).FirstOrDefault();
                if (data != null)
                {
                    db.Remove(data);
                    db.SaveChanges();
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
