using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using DataAccess;

namespace ApiEquity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        [HttpGet]
        [Route("ListarEmpresas")]
        public List<Empresa> Get()
        {
            List<Empresa> list = DBEmpresa.GetEmpresas();

            return list;
        }

        [HttpGet]
        [Route("EmpresasByID/{id}")]
        public Empresa GetEmpresa(int id)
        {
            Empresa empresa = DBEmpresa.GetEmpresa(id);

            return empresa;
        }

        [HttpPut]
        [Route("AlterarEmpresa")]
        public string AlterarEmpresa(Empresa empresa)
        {
            DBEmpresa.Alterar(empresa);

            return "Empresa alterada com sucesso!";
        }

        [HttpPost]
        [Route("CadastrarEmpresa")]
        public string CadastrarEmpresa(Empresa empresa)
        {
            DBEmpresa.Inserir(empresa);

            return "Empresa cadastrada com sucesso!";
        }

        [HttpDelete]
        [Route("ExcluirEmpresa/{id}")]
        public string ExcluirEmpresa(int id)
        {
            DBEmpresa.Excluir(id);

            return "Empresa excluída com sucesso!";
        }
    }
}
