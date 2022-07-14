using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class BookappointmentController : ApiController
    {
        EmployeesEntities db = new EmployeesEntities();

        [Route("api/Bookappointment/AddBookAppointment")]
        [HttpPost]
        public BookappointmentResponse AddBookAppointment(BookappointmentModel bookappointmentModel)
        {
            BookappointmentResponse bookappointmentResponse = new BookappointmentResponse();
            BookAppointmnet BookAppointmnet = new BookAppointmnet();
            BookAppointmnet.AppointmentId = bookappointmentModel.AppointmentId;
            BookAppointmnet.Patientname = bookappointmentModel.Patientname;
            BookAppointmnet.Specialization = bookappointmentModel.Specialization;
            BookAppointmnet.ConsultingDoctor = bookappointmentModel.ConsultingDoctor;
            BookAppointmnet.AppointmentDate = bookappointmentModel.AppointmentDate;
            BookAppointmnet.AppointmentTime = bookappointmentModel.AppointmentTime;
            BookAppointmnet.PatientId = bookappointmentModel.PatientId;
            BookAppointmnet.DoctorId= bookappointmentModel.DoctorId;
            if (bookappointmentModel.Type == "Add")
            {

                if (BookAppointmnet != null)
                {
                    db.BookAppointmnets.Add(BookAppointmnet);
                    db.SaveChanges();
                    bookappointmentResponse.ResponseCode = "200";
                    bookappointmentResponse.ResponseMessage = "Booked";

                }
                else
                {
                    bookappointmentResponse.ResponseCode = "100";
                    bookappointmentResponse.ResponseMessage = "Some error occured";

                }

            }
            if (bookappointmentModel.Type == "Update")
            {

                if (BookAppointmnet != null)
                {
                    db.Entry(BookAppointmnet).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    bookappointmentResponse.ResponseCode = "200";
                    bookappointmentResponse.ResponseMessage = "Doctor Updated";

                }
                else
                {
                    bookappointmentResponse.ResponseCode = "100";
                    bookappointmentResponse.ResponseMessage = "Some error occured";

                }

            }
            if (bookappointmentModel.Type == "Delete")
            {

                if (BookAppointmnet != null)
                {
                    db.Entry(BookAppointmnet).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                    bookappointmentResponse.ResponseCode = "200";
                    bookappointmentResponse.ResponseMessage = "Doctor Deleted";

                }
                else
                {
                    bookappointmentResponse.ResponseCode = "100";
                    bookappointmentResponse.ResponseMessage = "Some error occured";

                }

            }
            return bookappointmentResponse;

        }

        [Route("api/Bookappointment/GetBookAppointmnet")]
        [HttpGet]
        public BookappointmentResponse GetBookAppointmnet()
        {
            BookappointmentResponse bookappointmentResponse = new BookappointmentResponse();
            List<BookAppointmnet> lstBookAppointmnets = new List<BookAppointmnet>();
            lstBookAppointmnets = db.BookAppointmnets.ToList();
            bookappointmentResponse.ResponseCode = "200";
            bookappointmentResponse.ResponseMessage = "Data feteched";
            bookappointmentResponse.lstBookAppointmnets = lstBookAppointmnets;

            return bookappointmentResponse;

        }

        [Route("api/Bookappointment/BookAppointmnetByAppointmentId")]
        [HttpPost]
        public BookappointmentResponse BookAppointmnetByAppointmentId(BookappointmentModel bookappointmentModel)
        {
            BookappointmentResponse bookappointmentResponse = new BookappointmentResponse();
            BookAppointmnet BookAppointmnet = new BookAppointmnet();
            if (bookappointmentModel != null && bookappointmentModel.AppointmentId> 0)
            {
                BookAppointmnet = db.BookAppointmnets.FirstOrDefault(x => x.AppointmentId== bookappointmentModel.AppointmentId);
                bookappointmentResponse.BookAppointmnet = BookAppointmnet;

            }
            return bookappointmentResponse;
        }

    }
}
