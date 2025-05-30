// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Montanelli.Application.DTOs.ClienteDTOs;
// using Montanelli.Application.DTOs.EnderecoDTOs;
// using Montanelli.Domain.Entidades;

// namespace Montanelli.Application.Mappers;

// public static class ClienteMapper
// {
//     public static ClienteDTO? ToDto(this Cliente? entity)
//     {
//         if (entity == null) return null;
        
//         var clienteDto = new ClienteDTO
//         {
//             Id = entity.Id,
//             Nome = entity.Nome,
//             Email = entity.Email,
//             Telefone = entity.Telefone,
//             Cpf = entity.Cpf,
//             DataNascimento = entity.DataNascimento,
//             Ativo = entity.Ativo,
//             Observacoes = entity.Observacoes,
//             DataCadastro = entity.DataCadastro,
//             DataAtualizacao = entity.DataAtualizacao,
//             Enderecos = new List<EnderecoDTO>()
//         };
        
//         // Converter todos os endereços do relacionamento
//         if (entity.EnderecosClientes != null && entity.EnderecosClientes.Any())
//         {
//             foreach (var ec in entity.EnderecosClientes)
//             {
//                 if (ec.Endereco != null)
//                 {
//                     var enderecoDto = ec.Endereco.ParaEnderecoDTO();
//                     if (enderecoDto != null)
//                     {
//                         clienteDto.Enderecos.Add(enderecoDto);
//                     }
//                 }
//             }
//         }
        
//         return clienteDto;
//     }

//     public static Cliente? ToEntity(this AdicionarClienteDTO? dto)
//     {
//         if (dto == null) return null;
        
//         return new Cliente(
//             id: Guid.NewGuid(),
//             nome: dto.Nome,
//             email: dto.Email,
//             telefone: dto.Telefone,
//             cpf: dto.Cpf,
//             dataNascimento: dto.DataNascimento,
//             ativo: true,
//             observacoes: dto.Observacoes
//         );
//     }
    
//     public static void AtualizarEntidade(this AtualizarClienteDTO dto, Cliente entity)
//     {
//         if (dto == null || entity == null) return;
        
//         entity.Nome = dto.Nome;
//         entity.Email = dto.Email;
//         entity.Telefone = dto.Telefone;
//         entity.Cpf = dto.Cpf;
//         entity.DataNascimento = dto.DataNascimento;
//         entity.Ativo = dto.Ativo;
//         entity.Observacoes = dto.Observacoes;
//         entity.DataAtualizacao = DateTime.Now;
//     }
// }