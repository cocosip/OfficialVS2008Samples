//Copyright (C) Microsoft Corporation.  All rights reserved.

using ExpressionVisualizer;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace GuiHost
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void showVisualizerButton_Click(object sender, EventArgs e)
        {
            var user = new User()
            {
                UserId = 3
            };

            Expression<Func<Order, bool>> expr = o => o.OrderId == user.UserId;

            //Func<User, Dictionary<string, object>> f1 = x =>
            //{
            //    var dict=new Dictionary<string,object>();
            //    dict.Add("UserId",x.UserId);
            //    dict.Add("UserName",x.UserName);
            //    return dict;
            //};


            //Expression<Func<Order, User, Product, object>> expr = (x, y, z) => new
            //{
            //    OrderId1 = x.OrderId,
            //    Name = y.UserName,
            //    PName = z.ProductName
            //};
            VisualizerDevelopmentHost host = new VisualizerDevelopmentHost(expr,
                                                 typeof(ExpressionTreeVisualizer),
                                                 typeof(ExpressionTreeVisualizerObjectSource));
            host.ShowVisualizer(this);
        }
        public class Other
        {
            public int OId { get; set; }

            public string Name { get; set; }

            public string Code { get; set; }

            public Other()
            {

            }
            public Other(int oId, string name)
            {
                OId = oId;
                Name = name;
            }
        }

        public class Order
        {
            public int OrderId { get; set; }

            public string OrderCode { get; set; }
        }

        public class User
        {
            public int UserId { get; set; }

            public string UserName { get; set; }
        }

        public class Product
        {
            public int ProductId { get; set; }

            public string ProductName { get; set; }

            public string ProductCode { get; set; }
        }
        public class OrderItem
        {
            public int Id { get; set; }

            public int OrderId { get; set; }

            public string OrderCode { get; set; }
        }


    }
}