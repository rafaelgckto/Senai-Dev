using Microsoft.EntityFrameworkCore;
using Senai.Hroads.WebApi.Contexts;
using Senai.Hroads.WebApi.Domains;
using Senai.Hroads.WebApi.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Senai.Hroads.WebApi.Repositories {
    public class PersonagemRepository : IPersonagemRepository {
        HroadsContext ctx = new HroadsContext();

        public void Delete(int id) {
            //Personagem soughtCharacter = ctx.Personagems.Find(id);
            ctx.Personagems.Remove(SearchById(id));
            ctx.SaveChanges();
        }

        public List<Personagem> ListAll() {
            return ctx.Personagems.Include(p => p.IdClasseNavigation).ToList();
        }

        public List<Personagem> ListCorresponding() {
            throw new System.NotImplementedException();
        }

        public List<Personagem> ListNotCorresponding() {
            throw new System.NotImplementedException();
        }

        public void Register(Personagem newEntity) {
            ctx.Personagems.Add(newEntity);
            ctx.SaveChanges();
        }

        public Personagem SearchById(int id) {
            return ctx.Personagems.FirstOrDefault(p => p.IdPersonagem == id);
        }

        public void Update(int id, Personagem newEntity) {
            //Personagem soughtCharacter = ctx.Personagems.Find(id);
            Personagem soughtCharacter = SearchById(id);

            if(soughtCharacter != null) {
                soughtCharacter.Nome = newEntity.Nome;
                soughtCharacter.IdClasse = newEntity.IdClasse;
                soughtCharacter.Vida = newEntity.Vida;
                soughtCharacter.Mana = newEntity.Mana;
                soughtCharacter.DtAtualizacao = newEntity.DtAtualizacao;
                soughtCharacter.DtCricao = newEntity.DtCricao;
            }

            ctx.Personagems.Update(soughtCharacter);
            ctx.SaveChanges();
        }
    }
}
