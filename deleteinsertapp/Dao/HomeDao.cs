using deleteinsertapp.DataModel;
using deleteinsertapp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace deleteinsertapp.Dao
{
    public class HomeDao
    {
        public List<HomeModel> getHomeList(DbAccess dbAccess, SqlCommand cmd)
        {
            cmd.CommandText = this.getHomeListSelectQuery();

            DataTable dt = new DataTable();
            dt = dbAccess.executeQuery(cmd);

            List<HomeModel> homeList = this.getHomeListBindDataTable(dt);

            return homeList;
        }


        public int deleteLicense(HomeViewModel vm, SqlCommand cmd, DbAccess dbAccess)
        {
            cmd.CommandText = this.getDeleteQuery(vm);

            return dbAccess.executeNonQuery(cmd);

        }

        public int insertLicense(HomeViewModel vm, SqlCommand cmd, DbAccess dbAccess)
        {
            cmd.CommandText = this.getInsertQuery(vm);

            // vmのデータをListに格納する
            List<HomeViewModel> listVm = transListVm(vm);

            int count = 0;
            foreach (var item in listVm)
            {
                cmd.Parameters.Clear();
                cmd.Parameters.Add(new SqlParameter("@LICENSE", item.License));
                cmd.Parameters.Add(new SqlParameter("@MM", int.Parse(item.MM)));
                int number = dbAccess.executeNonQuery(cmd);
                count = count + number;
            }

            return count;
        }

        private List<HomeViewModel> transListVm(HomeViewModel vm)
        {
            List<HomeViewModel> listVm = new List<HomeViewModel>();

            string[] license = { vm.LIC1, vm.LIC2, vm.LIC3, vm.LIC4 };
            string[] mm = { vm.MM1, vm.MM2, vm.MM3, vm.MM4 };
            for (int i = 0; i < 4; i++)
            {
                HomeViewModel homeViewModel = new HomeViewModel();
                if (!(license[i] == null))
                {
                    homeViewModel.License = license[i];
                    homeViewModel.MM = mm[i];
                    listVm.Add(homeViewModel);
                }
            }
            
            return listVm;
        }


        private string getHomeListSelectQuery()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT")
              .Append(" LICENSE,")
              .Append(" MM")
              .Append(" FROM")
              .Append(" LICENSE_TEST");

            return sb.ToString();
        }

        private List<HomeModel> getHomeListBindDataTable(DataTable dt)
        {
            List<HomeModel> homeList = new List<HomeModel>();


            foreach (DataRow dr in dt.Rows)
            {
                HomeModel homeModel = new HomeModel();

                if (!(dr["LICENSE"] is DBNull))
                {
                    homeModel.License = Convert.ToString(dr["LICENSE"]);
                }
                if (!(dr["MM"] is DBNull))
                {
                    homeModel.MM = Convert.ToString(dr["MM"]);
                }
                homeList.Add(homeModel);

            }

            return homeList;
        }


        private string getDeleteQuery(HomeViewModel vm)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" DELETE")
              .Append(" FROM")
              .Append(" LICENSE_TEST");

            return sb.ToString();
        }

        private string getInsertQuery(HomeViewModel vm)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" INSERT INTO")
              .Append(" LICENSE_TEST")
              .Append(" ( LICENSE")
              .Append(" , MM )")
              .Append(" VALUES")
              .Append(" ( @LICENSE")
              .Append(" , @MM )");

            return sb.ToString();
        }
    }
}