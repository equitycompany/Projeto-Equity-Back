using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Model;
using DataAccess;

namespace ApiEquity.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        [EnableCors("AllowAll")]
        [HttpGet]
        [Route("ListarCandidatos")]
        public List<Candidato> Get()
        {
            List<Candidato> list = DBCandidato.GetCandidatos();

            return list;
        }

        [EnableCors("AllowAll")]
        [HttpGet]
        [Route("CandidatosByID/{id}")]
        public Candidato GetCandidato(int id)
        {
            Candidato candidato = DBCandidato.GetCandidato(id);

            return candidato;
        }

        [EnableCors("AllowAll")]
        [HttpPut]
        [Route("AlterarCandidato")]
        public string AlterarEmpresa(Candidato candidato)
        {
            DBCandidato.Alterar(candidato);

            return "Candidato alterado com sucesso!";
        }

        [EnableCors("AllowAll")]
        [HttpPost]
        [Route("CadastrarCandidato")]
        public string CadastrarCandidato(Candidato candidato)
        {
            DBCandidato.Inserir(candidato);

            return "Candidato cadastrado com sucesso!";
        }

        [EnableCors("AllowAll")]
        [HttpDelete]
        [Route("ExcluirCandidato/{id}")]
        public string ExcluirCandidato(int id)
        {
            DBCandidato.Excluir(id);

            return "Candidato excluído com sucesso!";
        }

        [EnableCors("AllowAll")]
        [HttpGet]
        [Route("CheckarLogin/{login}&{senha}")]
        public bool CheckLogin(string login, string senha)
        {
            bool lOk;

            lOk = DBCandidato.CheckLogin(login, senha);

            return lOk;
        }
    }
}
