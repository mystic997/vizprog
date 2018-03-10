using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YachtKlub.database;

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                /*// Set values into company model.  
                Members objMember = new Members();
                objMember.Email = "hello@hello.com";
                objMember.MemberId = 1;
                objMember.MemberName = "Valaki 2";*/

                // Create context object and then save company data.  
                //Members objMember = new Members();
                //Boats objBoat = new Boats();
                DatabaseContext objContext = new DatabaseContext();
                //objContext.Members.Add(objMember);
                //objContext.Boats.Add(objBoat);

                //objContext.Configuration.ValidateOnSaveEnabled = false;

                //objContext.Database.Create();
                //objContext.SaveChanges();


                //var data = from a in objContext.Members select a;
                //var data1 = objContext.Members.OrderBy(a => a.MemberName);
                //var data2 = objContext.Members.First();
                //var data3 = objContext.Members.ToList();


                // Query for all blogs with names starting with B 
                //var members = from b in objContext.Members
                //              where b.MemberId.Equals(0)
                //              select b;
                //var memberName = members.FirstOrDefault<Members>();

                ////Console.WriteLine(members.ToString() + " --- " + members.);

                //// Will hit the database 
                //var blog = objContext.Members.Find(0);

                //context.Blogs.Add(new Blog { Id = -1 });

                // Will find the new blog even though it does not exist in the database 
                /*var newBlog = context.Blogs.Find(-1);

                // Will find a User which has a string primary key 
                var user = context.Users.Find("johndoe1987");*/
            }
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
