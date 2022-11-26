﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using week05.MnbServiceReference;

namespace week05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            MNBArfolyamServiceSoapClient mnbService = new MNBArfolyamServiceSoapClient();
            GetExchangeRatesRequestBody request = new GetExchangeRatesRequestBody()
            {
                currencyNames ="EUR",
                startDate = "2020-01-01",
                endDate = "2020-06-30"
            };

            GetExchangeRatesResponseBody response = mnbService.GetExchangeRates(request);
            string result = response.GetExchangeRatesResult;
            MessageBox.Show(result);
        }
    }
}
