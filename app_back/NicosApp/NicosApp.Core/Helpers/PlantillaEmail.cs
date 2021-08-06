namespace NicosApp.Core.Helpers
{
    public class PlantillaEmail
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellidos"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string crearPlantilla(string nombre, string apellidos, string email, string password)
        {
            string htmlContent = $"<html>" +
                    "<head>" +
                    "<link rel='stylesheet' href='https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css' integrity='sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T' crossorigin='anonymous'>" +
                            "</head>" +
                    "<body>" +
                    "<div style='text-align:center;'>" +
                    " <div class='row'>" +
                    "<div class='col-md-4'>" +
                    "<img class='rounded float-left'  src='http://cdn.mcauto-images-production.sendgrid.net/b9133c3bbc6cced6/97606a57-4de8-40e3-af8d-a5367144b2e8/1500x1500.png' style='width:35%;height: auto;'>" +
                    //"<img class='img-responsive' src='http://cdn.mcauto-images-production.sendgrid.net/b9133c3bbc6cced6/ae2c75fc-1af0-4dcf-8e2a-d941acfdc6f8/287x287.png' style='float:left;width:23%;height:auto;'>" +
                    //"<img class='img-responsive' src='http://cdn.mcauto-images-production.sendgrid.net/b9133c3bbc6cced6/9abb229b-28ff-4977-8ccb-96cea1492944/1000x998.png' style='float:right;width:23%;height: auto;'>" +
                    "</div>" +
                    "</div>" +
                                //"<br>" +
                                // "<br>" +
                                $"<h1>Bienvenido(a) {nombre} {apellidos} </h1>" +
                                $"<h2>Tu registro en la plataforma ha sido exitoso</h2>" +
                                $"<h4>Tus credenciales para acceder a la plataforma son las siguientes</h4>" +
                                $"<p style='font-size:15px;'>usuario: {email} <br>password:  {password} </p>" +
                           "<h3><a href = ''> Accede a la plataforma </a></h3> " +
                     "</div>" +
                "</body>" +
                "</html>";
            return htmlContent;
        }
    }
}
