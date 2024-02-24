using Gadget.Data;
using Gadget.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gadget.Controllers
{
    public class GadgetController : Controller
    {
        // GET: Gadget
        public ActionResult Index()
        {
            // generate some fake data and send it to a view
            List<GadgetModel> gadgets = new List<GadgetModel>();

            GadgetDAO gadgetDAO = new GadgetDAO();
            gadgets = gadgetDAO.FetchAll();


            return View("index", gadgets);
        }

        public ActionResult Details(int id)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            GadgetModel gadget = gadgetDAO.FetchOne(id);

            return View("Details", gadget);
        }

        public ActionResult Create()
        {
            return View("Create");
        }

        public ActionResult ProsesCreate(GadgetModel gadgetModel)
        {
            //save to the db
            GadgetDAO gadgetDAO = new GadgetDAO();
            gadgetDAO.CreateOrUpdate(gadgetModel);
            return View("Details", gadgetModel);
        }

        public ActionResult Edit(int id)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            GadgetModel gadget = gadgetDAO.FetchOne(id);
            return View("Create", gadget);
        }

        public ActionResult Delete(int id)
        {
            GadgetDAO gadgetDAO = new GadgetDAO();
            gadgetDAO.Delete(id);

            List<GadgetModel> gadgets = gadgetDAO.FetchAll();

            return View("Index", gadgets);
        }
    }
}