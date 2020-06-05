﻿using HealthCareAppointment.HealthCare_BLL;
using HealthCareAppointment.HealthCare_BLL.Models;
using HealthCareAppointment.HealthCare_Common;
using HealthCareAppointment.HealthCare_DAL;
using System;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HealthCareAppointment.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AppointmentController : ApiController
    {
        log4net.ILog logger = log4net.LogManager.GetLogger(typeof(AppointmentController));
        //private readonly IUnitOfWork _unitOfWork;

        //public AppointmentController(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        private ApplicationDbContext _ApplicationDbContext;

        public AppointmentController()
        {
            _ApplicationDbContext = new ApplicationDbContext();
        }


        [Route("api/Appointment/Doctorsbyspecialization")]
        [HttpGet]
        [HealthCareAppointmentCaching_Filter(TimeDuration = 300)]
        public async Task<HttpResponseMessage> Doctorsbyspecialization()
        {
            try
            {
                var result = await _ApplicationDbContext.Doctors.ToListAsync();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, result);
                return response;
            }
            catch (Exception ex)
            {
                logger.Info("Register error : " + ex);
                logger.Debug(ex);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.BadRequest);
                return response;
            }
        }

        [DisableCors]
        //[OutputCache(Duration =100)]
        public IHttpActionResult Checkunittesting(int id)
        {
            if (id == 0)
                return NotFound();
            else
                return Ok();

        }
    }
}
