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
    public class CandidatoController : ControllerBase
    {
        [HttpGet]
        [Route("ListarCandidatos")]
        public List<Candidato> Get()
        {
            List<Candidato> list = DBCandidato.GetCandidatos();

            return list;
        }

        [HttpGet]
        [Route("CandidatosByID/{id}")]
        public Candidato GetCandidato(int id)
        {
            Candidato candidato = DBCandidato.GetCandidato(id);

            return candidato;
        }

        [HttpPut]
        [Route("AlterarCandidato")]
        public string AlterarEmpresa(Candidato candidato)
        {
            DBCandidato.Alterar(candidato);

            return "Candidato alterado com sucesso!";
        }

        [HttpPost]
        [Route("CadastrarCandidato")]
        public string CadastrarCandidato(Candidato candidato)
        {
            DBCandidato.Inserir(candidato);

            return "Candidato cadastrado com sucesso!";
        }

        [HttpDelete]
        [Route("ExcluirCandidato/{id}")]
        public string ExcluirCandidato(int id)
        {
            DBCandidato.Excluir(id);

            return "Candidato excluído com sucesso!";
        }
    }
}
