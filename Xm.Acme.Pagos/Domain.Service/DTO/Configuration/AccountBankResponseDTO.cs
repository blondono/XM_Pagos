using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Service.DTO.Configuration
{
    public class AccountBankResponseDTO
    {
        public int cuentaBancariaId { get; set; }
        public int cuentaBancariaAgenteId { get; set; }
        public int cuentaBancariaEmpresaId { get; set; }
        public string nombreEntidadBancaria { get; set; }
        public string tipoCuenta { get; set; }
        public string claseCuenta { get; set; }
        public string numeroCuenta { get; set; }
        public string titularCuenta { get; set; }
        public string nit { get; set; }
        public int digitoVerificacion { get; set; }
        public string empresa { get; set; }
        public string agente { get; set; }
        public string estado { get; set; }
    }
}
