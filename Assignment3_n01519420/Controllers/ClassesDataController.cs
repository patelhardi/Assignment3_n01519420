using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment3_n01519420.Controllers
{
    public class ClassesDataController : ApiController
    {
        //query for insert teacher into class table
        // insert into classes(classcode, classname, finishdate, startdate, teacherid) values (@classcode, @classname, @finishdate, @startdate, @teacherid

        //query for remove teacher from class table
        // delete from classes where teacherid = @teacherid
    }
}
