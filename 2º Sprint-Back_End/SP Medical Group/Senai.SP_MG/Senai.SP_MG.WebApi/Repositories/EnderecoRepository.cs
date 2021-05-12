﻿using Senai.SP_MG.WebApi.Contexts;
using Senai.SP_MG.WebApi.Domain;
using Senai.SP_MG.WebApi.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace Senai.SP_MG.WebApi.Repositories {
    public class EnderecoRepository : IStantardRepository<Endereco> {
        MedicalGroupContext ctx = new MedicalGroupContext();

        public void Delete(int id) {
            ctx.Enderecos.Remove(SearchById(id));
            ctx.SaveChanges();
        }

        public List<Endereco> ListAll() {
            return ctx.Enderecos.ToList();
        }

        public void Register(Endereco newEntity) {
            ctx.Enderecos.Add(newEntity);
            ctx.SaveChanges();
        }

        public Endereco SearchById(int id) {
            return ctx.Enderecos.FirstOrDefault(end => end.IdEndereco == id);
        }

        public void Update(int id, Endereco newEntity) {
            Endereco searchedAddress = ctx.Enderecos.Find(id);

            if(searchedAddress != null) {
                // UNDONE: searchedAddress != null
            }

            ctx.Enderecos.Update(searchedAddress);
            ctx.SaveChanges();
        }
    }
}
