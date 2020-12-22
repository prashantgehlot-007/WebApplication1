using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly PaymentDetailContext db;

        public EmployeeController(PaymentDetailContext context)
        {
            db = context;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult GetEmployee()
        {
            List<Employee> userData = db.Employees.ToList();
            List<Employee> data = new List<Employee>();

            try
            {
                if (userData != null)
                {
                    if (userData.Count > 0)
                    {
                        foreach (var item in userData)
                        {
                            Employee employee = new Employee();
                            employee.Id = item.Id;
                            employee.SId = item.SId;
                            employee.StudentName = item.StudentName;
                            employee.StudentNumber = item.StudentNumber;
                            employee.AdmissionDate = item.AdmissionDate;
                            employee.SchoolCode = item.SchoolCode;
                            employee.AcedmicDay = item.AcedmicDay;
                            employee.Class = item.Class;
                            employee.Comment = item.Comment;
                            employee.Address = item.Address;
                            employee.Mobile = item.Mobile;
                            employee.SchoolTime = item.SchoolTime;
                            employee.Email = item.Email;

                            data.Add(employee);
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

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public IActionResult GetEmpById(int id) 
        {
            try
            {
                Employee employee = new Employee();
                Base response = new Base();
                var p1 = db.Employees.Where(x => x.Id == id).FirstOrDefault();
                if (p1 == null)
                {
                    response.Message = "Record Not Found";
                    response.StatusReason = false;
                    return Ok(response);
                }

                employee.Id = p1.Id;
                employee.SId = p1.SId;
                employee.StudentName = p1.StudentName;
                employee.StudentNumber = p1.StudentNumber;
                employee.AdmissionDate = p1.AdmissionDate;
                employee.SchoolCode = p1.SchoolCode;
                employee.AcedmicDay = p1.AcedmicDay;
                employee.Class = p1.Class;
                employee.Comment = p1.Comment;
                employee.Address = p1.Address;
                employee.Mobile = p1.Mobile;
                employee.SchoolTime = p1.SchoolTime;
                employee.Email = p1.Email;
                //response.Message = "Record Found";
                //response.StatusReason = true;

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult PostEmp(Employee p1)   
        {
            try
            {
                Employee employee = new Employee();

                employee.Id = p1.Id;
                employee.SId = p1.SId;
                employee.StudentName = p1.StudentName;
                employee.StudentNumber = p1.StudentNumber;
                employee.AdmissionDate = p1.AdmissionDate;
                employee.SchoolCode = p1.SchoolCode;
                employee.AcedmicDay = p1.AcedmicDay;
                employee.Class = p1.Class;
                employee.Comment = p1.Comment;
                employee.Address = p1.Address;
                employee.Mobile = p1.Mobile;
                employee.SchoolTime = p1.SchoolTime;
                employee.Email = p1.Email;

                db.Employees.Add(employee);
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

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public IActionResult UpdateEmp(Employee p1) 
        {
            try
            {
                var EmoliyeeD = db.Employees.Where(x => x.Id == p1.Id).FirstOrDefault();

                EmoliyeeD.SId = p1.SId;
                EmoliyeeD.StudentName = p1.StudentName;
                EmoliyeeD.StudentNumber = p1.StudentNumber;
                EmoliyeeD.AdmissionDate = p1.AdmissionDate;
                EmoliyeeD.SchoolCode = p1.SchoolCode;
                EmoliyeeD.AcedmicDay = p1.AcedmicDay;
                EmoliyeeD.Class = p1.Class;
                EmoliyeeD.Comment = p1.Comment;
                EmoliyeeD.Address = p1.Address;
                EmoliyeeD.Mobile = p1.Mobile;
                EmoliyeeD.SchoolTime = p1.SchoolTime;
                EmoliyeeD.Email = p1.Email;

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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteEmp(int id)  
        {
            try
            {
                Base response = new Base();
                if (id <= 0)
                    return BadRequest("Not a valid Id");

                var data = db.Employees.Where(x => x.Id == id).FirstOrDefault();
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
