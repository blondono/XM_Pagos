using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Constant
{
    public struct State
    {
        public const string
            Successfull = "Exitosa",
            Pending = "Pendiente",
            Error = "Error";
    }
    public struct AgentValidation
    {
        public const string
            Successfull = "Cruce creado. El cruce ingresado estará sujeto a la disponibilidad que se posea de cubrimiento del beneficio asociado al vencimiento.",
            Uniqueness = "Ya existe un cruce con la misma empresa, negocio y tipo de cruce",
            CeatedInvalid = "No se puede crear un cruce con fecha posterior a la fecha inicial del vencimiento seleccionado",
            IsNotBeneficiary = "El agente {0} no figura como posee veneficio para el vencimiento {1} del negocio {2}";
    }
}
