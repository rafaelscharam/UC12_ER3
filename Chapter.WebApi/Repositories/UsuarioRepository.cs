﻿using Chapter.WebApi.Contexts;
using Chapter.WebApi.Interfaces;
using Chapter.WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace Chapter.WebApi.Repositories

{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ChapterContext _context;

        public UsuarioRepository(ChapterContext context)
        {
            _context = context;
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public void Cadastrar(Usuario u)
        {
            _context.Usuarios.Add(u);

            _context.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
           return _context.Usuarios.Find(id);
        }

        public void Atualizar(int id, Usuario u)
        {
            Usuario usuarioEncontrado = _context.Usuarios.Find(id);

            if (usuarioEncontrado != null)
            { 
                usuarioEncontrado.Email = u.Email;
                usuarioEncontrado.Senha = u.Senha;
                usuarioEncontrado.Tipo = u.Tipo;

            }
            
            _context.Usuarios.Update(usuarioEncontrado);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioEncontrado = _context.Usuarios.Find(id);

            _context.Usuarios.Remove(usuarioEncontrado);

            _context.SaveChanges();
        }

        public Usuario Login(string Email, string Senha)
        { 
            return _context.Usuarios.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);
        }
    }
}
