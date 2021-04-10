﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TurnierverwaltungService.Models;
using TurnierverwaltungService.Controllers;

namespace TurnierverwaltungService.Views
{
    public partial class Turnierverwaltung : System.Web.UI.Page
    {
        private controller _Verwalter;

        public controller Verwalter { get => _Verwalter; set => _Verwalter = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!this.IsCallback)
            {
                Verwalter = new controller();
                LoadUI();
            }
        }

        public void LoadUI(int sTID = 1)
        {
            tblSpiele.Rows.Clear();
            TblMS.Rows.Clear();
            List<Turnier> TLIST = Verwalter.GetTurniere();
            if(!(DDTurnier.SelectedItem is null))
            {
                string[] vsplit = DDTurnier.SelectedItem.Text.Split('-');
                int vPID = Convert.ToInt32(vsplit[0].Trim());
                sTID = vPID;
            }
            else
            {

            }
            if(DDTurnier.Items.Count == 0)
            {
                foreach (var e in TLIST)
                {
                    DDTurnier.Items.Add(e.TID + " - " + e.TNAME);
                }
            }
            List<Mannschaft> MSLIST = new List<Mannschaft>();
            foreach(var e in TLIST)
            {
                if (e.TID == sTID)
                {
                    foreach (var x in e.ListTeilnehmer)
                    {
                        MSLIST.Add(x);
                    }
                }
                else
                {

                }
            }

            List<spiele> SpielList = new List<spiele>();
            foreach (var e in TLIST)
            {
                if (e.TID == sTID)
                {
                    foreach (var x in e.ListSpiele)
                    {
                        SpielList.Add(x);
                    }
                }
                else
                {

                }
            }

            TableRow tr = new TableRow();
            TableCell tc = new TableCell();
            tc.Text = "Mannschaft-ID";
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "Mannschaft-Name";
            tr.Cells.Add(tc);
            TblMS.Rows.Add(tr);

            foreach (var e in MSLIST)
            {
                tr = new TableRow();
                tc = new TableCell();
                tc.Text = e.MID.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = e.MNAME;
                tr.Cells.Add(tc);
                TblMS.Rows.Add(tr);
            }

            tr = new TableRow();
            tc = new TableCell();
            tc.Text = "Spiel-ID";
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "MS1";
            tr.Cells.Add(tc);
            tc = new TableCell();
            tc.Text = "MS2";
            tr.Cells.Add(tc);
            tblSpiele.Rows.Add(tr);

            foreach (var e in SpielList)
            {
                tr = new TableRow();
                tc = new TableCell();
                tc.Text = e.SpielID.ToString();
                tr.Cells.Add(tc);
                tc = new TableCell();
                tc.Text = e.MS1.ToString();
                tr.Cells.Add(tc);
                tblSpiele.Rows.Add(tr);
            }
        }

        protected void DDTurnier_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUI();
        }
    }
}