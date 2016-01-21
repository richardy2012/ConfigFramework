﻿using ConfigFramework.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZF.Db.SqlHelper;
using System.Data.SqlClient;

namespace ConfigFramework.ConfigManger.Dal
{
    public class ConfigDal
    {
        /// <summary>
        /// 读取列表
        /// </summary>
        /// <returns></returns>
        public List<Config> GetList()
        {
            string conn = ConfigMangerHelper.Get<string>("ConfigManager");
            List<Config> list = new List<Config>();
            string sql = "SELECT Id,CategoryId,ConfigKey,ConfigValue,Remark,CreateTime FROM Config";
            DataTable dt = SqlServerHelper.Get(conn, sql);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Config category = new Config();
                    category = Config.CreateModel(dt.Rows[i]);
                    list.Add(category);
                }
            }
            return list;
        }

        public Config GetById(long id)
        {
            Config config = new Config();
            string conn = ConfigMangerHelper.Get<string>("ConfigManager");
            string sql = "SELECT Id,CategoryId,ConfigKey,ConfigValue,Remark,CreateTime FROM Config WHERE Id=@id";
            SqlParameter[] paramters = new SqlParameter[] { new SqlParameter("@id", id) };
            DataTable dt = SqlServerHelper.Get(conn, sql, paramters);
            if (dt.Rows.Count > 0)
            {
                config = Config.CreateModel(dt.Rows[0]);
            }
            return config;
        }

        public Config GetByCategoryId(long cid)
        {
            Config config = new Config();
            string conn = ConfigMangerHelper.Get<string>("ConfigManager");
            string sql = "SELECT Id,CategoryId,ConfigKey,ConfigValue,Remark,CreateTime FROM Config WHERE CategoryId=@cid";
            SqlParameter[] paramters = new SqlParameter[] { new SqlParameter("@cid", cid) };
            DataTable dt = SqlServerHelper.Get(conn, sql, paramters);
            if (dt.Rows.Count > 0)
            {
                config = Config.CreateModel(dt.Rows[0]);
            }
            return config;
        }
    }
}