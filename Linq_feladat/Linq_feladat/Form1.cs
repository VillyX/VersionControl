﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linq_feladat
{
    public partial class Form1 : Form
    {
        List<Country> countries = new List<Country>();
        List<Ramen> ramens = new List<Ramen>();
        List<Brand> brands = new List<Brand>();
        public Form1()
        {
            InitializeComponent();
            LoadData("ramen.csv");
        }

        void LoadData(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);
            sr.ReadLine(); //átugrik az első soron, mert az a fejléc
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                string orszag = sor[2];
                string marka = sor[0];

                Country aktorszag = AddCountry(orszag); //akrualis orszag
                Brand aktmarka = AddBrand(marka);
                Ramen r = new Ramen
                { //mapping
                    ID = ramens.Count + 1,
                    CountryFK = aktorszag.ID,
                    Country = aktorszag,
                    Rating = Convert.ToDouble(sor[3]),
                    Name = aktorszag.Name,
                    Brand = aktmarka
                };
                ramens.Add(r);
            }
            sr.Close();

            Brand AddBrand(string marka)
            {
                //var ered = countries.Where(i => i.Name.Equals(orszag)).FirstOrDefault(); //LINQ lekérdezés a köv sor ugyanez másképpen felírva:
                var ered = (from c in brands where c.Name.Equals(marka) select c).FirstOrDefault();

                if (ered == null) //ha nincs ilyen ország a listában
                {
                    ered = new Brand
                    {
                        ID = brands.Count,
                        Name = marka
                    };
                    brands.Add(ered);
                }
                return ered;
            }


            Country AddCountry(string orszag)
            {
                //var ered = countries.Where(i => i.Name.Equals(orszag)).FirstOrDefault(); //LINQ lekérdezés a köv sor ugyanez másképpen felírva:
                var ered = (from c in countries where c.Name.Equals(orszag) select c).FirstOrDefault();

                if (ered == null) //ha nincs ilyen ország a listában
                {
                    ered = new Country
                    {
                        ID = countries.Count,
                        Name = orszag
                    };
                    countries.Add(ered);
                }
                return ered;
            }
        }

    }
}
