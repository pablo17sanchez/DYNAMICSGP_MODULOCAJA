using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;





namespace SITCASH_EXE_PS
{
    class GPdataaccess
    {
        //CONEXION AL SQL DE GPHN 10.0.0.86
        public string GPCONECTIONS()
        {

            string StringDeConexiongp = "";
            try
            {

                StringDeConexiongp = ConfigurationManager.ConnectionStrings["GPCONECT"].ConnectionString;
            }
            catch (ConfigurationException Configurationex)
            {
                Console.Write("Error con el String de conexion: " + Configurationex.ToString());
            }

            StringDeConexiongp = "Data Source=GEA-SRVDATA\\SQLSERVER2008;Initial Catalog=GPHN;User ID=sa;Password=taramaca01$";
            return StringDeConexiongp;
        }

        //CONEXION AL SQL DE PALCOMSYNC 10.0.0.86
        public string PAMLCONECTIONS()
        {
            string StringDeConexionPAML = "";
            try
            {
                StringDeConexionPAML = ConfigurationManager.ConnectionStrings["PALMCONECT"].ConnectionString;
            }
            catch (ConfigurationException ConfigurationexPaml)
            {

                Console.Write("Error con el String de conexion: " + ConfigurationexPaml.ToString());
            }

            StringDeConexionPAML = "Data Source=GEA-SRVDATA\\SQLSERVER2008;Initial Catalog=PalmComSync;User ID=sa;Password=taramaca01$";
            return StringDeConexionPAML;

        }


        //CONEXION AL SQL DE SITINTEGRATION 10.0.0.86
        public string SITINTEGRATION()
        {
            string StringDeConexionSITINTEGRATION = "";


            try
            {
                StringDeConexionSITINTEGRATION = ConfigurationManager.ConnectionStrings["SITDB"].ConnectionString;
            }
            catch (ConfigurationException ConfigurationexPaml)
            {

                Console.Write("Error con el String de conexion: " + ConfigurationexPaml.ToString());
            }
            StringDeConexionSITINTEGRATION = "Data Source=GEA-SRVDATA\\SQLSERVER2008;Initial Catalog=SITGPIntegration;User ID=sa;Password=taramaca01$";

            return StringDeConexionSITINTEGRATION;

        }


        //CONEXION DE SQL_DE_PRUEBA   10.0.0.26
        public string GPHNCARGAR()
        {
            string StringDeConexionSITINTEGRATION = "";


            try
            {
                StringDeConexionSITINTEGRATION = ConfigurationManager.ConnectionStrings["SITDB"].ConnectionString;
            }
            catch (ConfigurationException ConfigurationexPaml)
            {

                Console.Write("Error con el String de conexion: " + ConfigurationexPaml.ToString());
            }
            StringDeConexionSITINTEGRATION = "Data Source=GEA-SRVDATA\\SQLSERVER2008;Initial Catalog=GPHN;Persist Security Info=True;User ID=sa;Password=taramaca01$";

            return StringDeConexionSITINTEGRATION;

        }




        public string DYNAMICDB()
        {
            string StringDeConexionSITINTEGRATION = "";


            try
            {
                StringDeConexionSITINTEGRATION = ConfigurationManager.ConnectionStrings["SITDB"].ConnectionString;
            }
            catch (ConfigurationException ConfigurationexPaml)
            {

                Console.Write("Error con el String de conexion: " + ConfigurationexPaml.ToString());
            }
            StringDeConexionSITINTEGRATION = " Data Source=GEA-SRVDATA\\SQLSERVER2008;Initial Catalog=DYNAMICS;Persist Security Info=True;User ID=sa;Password=taramaca01$";

            return StringDeConexionSITINTEGRATION;

        }




    }
}
