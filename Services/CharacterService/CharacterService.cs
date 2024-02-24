using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private static readonly List<Character> characters = new()
        {
            new (),
            new (){ Id = 1, Name = "Sam"},
        };
        public async Task<ServiceResponse<List<Character>>> AddCharacter(Character character)
        {
            var serviceResponse = new ServiceResponse<List<Character>>();
            characters.Add(character);
            serviceResponse.Data = characters;
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
        {
            var serviceResponse = new ServiceResponse<List<Character>>
            {
                Data = characters
            };
            return serviceResponse;
        }

        public async Task<ServiceResponse<Character>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<Character>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            if (character is not null)
            {
                serviceResponse.Data = character;
            }
            else
            {
                serviceResponse.Message = "Character does not exist";
            }
            return serviceResponse;
        }
    }
}