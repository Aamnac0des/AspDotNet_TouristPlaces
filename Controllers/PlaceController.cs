using Aamnaa_proj.Models;
using Microsoft.AspNetCore.Mvc;
using static Aamnaa_proj.Models.Place;
using System.Data.SqlClient;

namespace Aamnas_project.Controllers
{
    public class PlaceController : Controller
    {
        public List<Place> listPlaces = new List<Place>();
        private readonly DatabaseContext _ctx;
        public PlaceController(DatabaseContext ctx)
        {
            _ctx = ctx;


        }
        public IActionResult Index()
        {

            try
            {
                String DefaultConnection = "Data Source=LAPTOP-P6E5307V\\SQLEXPRESS;Initial Catalog=MyPlaces;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(DefaultConnection))
                {
                    connection.Open();
                    String sql = "select * from places";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                Place placeInfo = new Place();
                                placeInfo.Id = reader.GetInt32(0);
                                placeInfo.Name = reader.GetString(1);
                                placeInfo.Incharge = reader.GetString(2);
                                placeInfo.ImgUrl = reader.GetString(3);
                                placeInfo.Established = reader.GetString(4);
                                placeInfo.Address = reader.GetString(5);
                                placeInfo.Area = reader.GetString(6);
                                placeInfo.Head = reader.GetString(7);

                                listPlaces.Add(placeInfo);

                            }
                        }


                    }
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return View(listPlaces);
        }

        public IActionResult Details(int Id)
        {

            try
            {
                String DefaultConnection = "Data Source=LAPTOP-P6E5307V\\SQLEXPRESS;Initial Catalog=MyPlaces;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(DefaultConnection))
                {
                    connection.Open();
                    String sql = $"select * from places where id = {Id}";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                var place = new Place();
                                place.Id = reader.GetInt32(0);
                                place.Name = reader.GetString(1);
                                place.Incharge = reader.GetString(2);
                                place.ImgUrl = reader.GetString(3);
                                place.Established = reader.GetString(4);
                                place.Address = reader.GetString(5);
                                place.Area = reader.GetString(6);
                                place.Head = reader.GetString(7);


                                return View(place);


                            }
                        }


                    }
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            return View();
        }
    }
}