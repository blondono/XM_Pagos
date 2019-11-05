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

    public struct LoadFileType
    {
        public const string
            Head = "Encabezado",
            Detail = "Detalle";
    }

    public struct LoadFileOrigin
    {
        public const string
            Multicash = "Multicash",
            BankFile = "Archivo Banco";
    }
}
