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
using System.Windows.Shapes;
using YachtKlub.dao;
using YachtKlub.entity;
using YachtKlub.service;
using YachtKlub.validator;

namespace YachtKlub
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            try
            {
                // set up the active database
                DatabaseContext dbContext = new DatabaseContext();
                if (dbContext.Database.Exists())
                    dbContext.Database.Delete();
                dbContext.Database.Create();

                // fill the database with temporarily data
                MembersDao mem = new MembersDaoImpl();
                List<MembersEntity> mems = mem.GetTemplateMembers();
                for (int i = 0; i < mems.Count; i++)
                {
                    dbContext.Members.Add(mems[i]);
                }
                dbContext.SaveChanges();

                // example to get data from database
                //var datas = mem.getAllMembers();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void btLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string email = tbEmailLogin.Text;
                string password = tbPasswordLogin.Text;

                Validator loginValidator = new Validator();
                loginValidator.ValidationComponents.Add(new EmptyFieldValidator(email, "e-mail cím"));
                loginValidator.ValidationComponents.Add(new EmailFormatValidator(email));
                loginValidator.ValidationComponents.Add(new EmptyFieldValidator(password, "jelszó"));
                // kivetelt dob, ha a validalas hibara fut, egyuttal ki is irja a hibauzeneteket
                loginValidator.ValidateElements();

                // kivetelt dob, ha sikertelen a service, egyuttal ki is irja a hibauzeneteket
                LoginService loginService = new LoginService(email, password);

                if (loginService.ResponseMessage["permission"].Equals("admin"))
                {
                    PersonalAdminWindow PersonalAdmintoWindow = new PersonalAdminWindow(tbEmailLogin.Text);
                    PersonalAdmintoWindow.Show();
                    Close();
                }
                else
                {
                    PersonalWindow PersonalWindow = new PersonalWindow(tbEmailLogin.Text);
                    PersonalWindow.Show();
                    Close();
                }
            }
            catch (Exception ex) { }
        }

        private void btRegister_Click(object sender, RoutedEventArgs e)
        {
            MemberRegisterWindow registerWindow = new MemberRegisterWindow();
            registerWindow.Show();
            this.Close();
        }
    }
}
