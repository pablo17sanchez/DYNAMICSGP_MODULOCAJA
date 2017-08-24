using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SITCASH_EXE_PS.MODEL;

namespace SITCASH_EXE_PS.CONTROLLER
{
    class ControllerDynamicsConfig
    {
        DYNAMICSEntities entidaddynamics = new DYNAMICSEntities();

        public String GetuserLocation(String vendedor) {

            var resultado = (from userinfo in entidaddynamics.SY01400
                            where
                                userinfo.USERID.Trim() == vendedor.Trim()
                            select new 
                            {
                              Localidad=  userinfo.Internet_Address_Name
                            }).Single();

            String resultados = resultado.Localidad.ToString().Trim();

            return resultados;

        
        
        }





    }
}
