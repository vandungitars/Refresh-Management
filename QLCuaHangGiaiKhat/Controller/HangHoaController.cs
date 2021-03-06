﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QLCuaHangGiaiKhat.Model;
using QLCuaHangGiaiKhat.Object;

namespace QLCuaHangGiaiKhat.Controller
{
    class HangHoaController
    {
        HangHoaModel hhMod = new HangHoaModel();
        public DataTable GetData()
        {
            return hhMod.GetData();
        }
        public DataTable GetData(string dieukien)
        {
            return hhMod.GetData(dieukien);
        }
        public bool AddData(HangHoaObj hhObj)
        {
            return hhMod.AddData(hhObj);
        }
        public bool UpdData(HangHoaObj hhObj)
        {
            return hhMod.UpdData(hhObj);
        }
        public bool UpdSL(DataTable dt)
        {
            DataTable dthh = new DataTable();
            dthh = hhMod.GetData();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dthh.Rows.Count; j++)
                {
                    if (dt.Rows[i][1].ToString() == dthh.Rows[j][0].ToString())
                    {
                        int SLcu = int.Parse(dthh.Rows[j][3].ToString());
                        int SLmoi = int.Parse(dthh.Rows[j][3].ToString()) - int.Parse(dt.Rows[i][3].ToString());
                        if (!hhMod.UpdSL(dthh.Rows[j][0].ToString(), SLmoi))
                            return false;
                        break;
                    }
                }

            }
            return true;
        }
        public bool DelData(string ma)
        {
            return hhMod.DelData(ma);
        }
    }
}
