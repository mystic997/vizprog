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
                AliveContext.Context = dbContext;

                if (dbContext.Database.Exists())
                {
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

                    BoatsDao boat = new BoatsDaoImpl();
                    List<BoatsEntity> boats = boat.GetTemplateBoats();
                    for (int i = 0; i < boats.Count; i++)
                    {
                        dbContext.Boats.Add(boats.SingleOrDefault(b => b.BoatId == i));
                    }
                    dbContext.SaveChanges();

                    TransportDevicesDao device = new TransportDevicesDaoImpl();
                    List<TransportDevicesEntity> devices = device.GetTemplateTransportDevices();
                    for (int i = 0; i < devices.Count; i++)
                    {
                        dbContext.TransportDevices.Add(devices.SingleOrDefault(d => d.TransportDeviceId == i));
                    }
                    dbContext.SaveChanges();

                    RentRequestsDao rent = new RentRequestsDaoImpl();
                    List<RentRequestsEntity> rents = rent.GetTemplateRentRequests();
                    for (int i = 0; i < rents.Count; i++)
                    {
                        dbContext.RentRequests.Add(rents[i]);
                    }
                    dbContext.SaveChanges();

                    BoatRentalsDao boatRent = new BoatRentalsDaoImpl();
                    List<BoatRentalsEntity> boatRents = boatRent.GetTemplateBoatRents();
                    for (int i = 0; i < boatRents.Count; i++)
                    {
                        dbContext.BoatRentals.Add(boatRents[i]);
                    }
                    dbContext.SaveChanges();
                }

                //AliveContext.Context = dbContext;
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
            catch (Exception ex)
            {
                new ExceptionToConsole(ex);
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

                // kivetelt dob, ha sikertelen a service, egyuttal ki is irja a hibauzeneteket VALTOZTATAS
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
            catch (Exception ex)
            {
                new ExceptionToConsole(ex);
            }
        }

        //private void btRegister_Click(object sender, RoutedEventArgs e)
        //{
        //    MemberRegisterWindow registerWindow = new MemberRegisterWindow();
        //    registerWindow.Show();
        //    this.Close();
        //}
    }
}
