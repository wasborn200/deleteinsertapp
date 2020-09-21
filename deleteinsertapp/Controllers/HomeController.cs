using deleteinsertapp.Dao;
using deleteinsertapp.DataModel;
using deleteinsertapp.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace deleteinsertapp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            List<HomeModel> homeList = getHomeList();
            HomeViewModel vm = new HomeViewModel();

            vm.Count = 1;
            int cnt = 1;
            foreach (HomeModel a in homeList)
            {
                var lic = typeof(HomeViewModel).GetProperty("LIC" + cnt.ToString());
                lic.SetValue(vm, a.License);
                var mm = typeof(HomeViewModel).GetProperty("MM" + cnt.ToString());
                mm.SetValue(vm, a.MM);
                cnt++;
                vm.Count++;
            }

            ViewBag.SelectOptions = Util.DropDownList.getSelectListItem();

            // オートコンプリート入手
            //List<HomeViewModel> autocompleteViewList = new List<HomeViewModel>();
            //List<HomeModel> autocompleteList = getAutocompleteList();
            //foreach (var item in autocompleteList)
            //{
            //    HomeViewModel homeViewModel = new HomeViewModel();
            //    homeViewModel.Code = item.Code;
            //    homeViewModel.LicenseName = item.LicenseName;
            //    autocompleteViewList.Add(homeViewModel);
            //}
            //vm.AutocompleteList = autocompleteViewList;


            // オートコンプリート入手(パターン２)
            List<HomeModel> autocompleteList = getAutocompleteList();
            List<SelectListItem> selectoptions = new List<SelectListItem>();
            foreach (var item in autocompleteList)
            {
                selectoptions.Add(new SelectListItem() { Value = item.LicenseName });
            }
            ViewBag.AutocompleteOptions = selectoptions;




            return View(vm);

        }

        public ActionResult Edit(HomeViewModel vm)
        {

            try
            {
                editLicense(vm);
                TempData["message"] = "プロフィールが変更されました";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                throw;
                //this.ModelState.AddModelError(string.Empty, "プロフィールを変更することが出来ませんでした。");
            }
        }

        private List<HomeModel> getHomeList()
        {
            DbAccess dbAccess = new DbAccess();
            SqlCommand cmd = dbAccess.sqlCon.CreateCommand();
            try
            {
                HomeDao dao = new HomeDao();
                List<HomeModel> homeList = dao.getHomeList(dbAccess, cmd);

                dbAccess.close();
                return homeList;
            }
            catch (DbException)
            {
                dbAccess.close();
                throw;
            }
        }


        private static void editLicense(HomeViewModel vm)
        {
            //SQLServerの接続開始
            DbAccess dbAccess = new DbAccess();
            SqlCommand cmd = dbAccess.sqlCon.CreateCommand();

            dbAccess.beginTransaciton();
            try
            {
                HomeDao dao = new HomeDao();
                int deleteLicense = dao.deleteLicense(vm, cmd, dbAccess);

                int insertLicense = dao.insertLicense(vm, cmd, dbAccess);
                if ((deleteLicense > 0) && (insertLicense > 0))
                {
                    dbAccess.sqlTran.Commit();
                }
                else
                {
                    dbAccess.sqlTran.Rollback();
                }

                dbAccess.close();
            }
            catch (Exception)
            {
                dbAccess.close();
                throw;
            }

        }

        private List<HomeModel> getAutocompleteList()
        {
            DbAccess dbAccess = new DbAccess();
            SqlCommand cmd = dbAccess.sqlCon.CreateCommand();
            try
            {
                HomeDao dao = new HomeDao();
                List<HomeModel> autocompleteList = dao.getAutocompleteList(dbAccess, cmd);

                dbAccess.close();
                return autocompleteList;
            }
            catch (DbException)
            {
                dbAccess.close();
                throw;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}