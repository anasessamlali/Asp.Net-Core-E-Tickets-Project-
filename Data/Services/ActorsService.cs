﻿using E_Tickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Linq;     
using System.Threading.Tasks;

namespace E_Tickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;
        public ActorsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Actor actor)
        {
             await _context.Actors.AddAsync(actor);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);
            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();
            

        }

        public async Task<IEnumerable<Actor>> GetAllAsync()   //Avoir ensemble des acteurs.
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetByIdAsync(int id)    //Avoir ensemble des acteurs selon leurs identificateur(id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n=>n.Id ==id);
            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)  
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }

        Task IActorsService.AddAsync(Actor actor)
        {
            throw new System.NotImplementedException();
        }
    }
}
