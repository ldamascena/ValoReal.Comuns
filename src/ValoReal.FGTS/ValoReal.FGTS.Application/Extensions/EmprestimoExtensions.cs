using System;
using ValoReal.Comuns.Domain.Entities;
using ValoReal.FGTS.Application.DTOs.Emprestimos;

namespace ValoReal.FGTS.Application.Extensions;

public static class EmprestimoExtensions
{
    public static void InsertFromDTO(this Emprestimo emprestimo, SolicitaEmpDTO dto)
    {
        emprestimo.IdPessoa = dto.IdPessoa;
        emprestimo.CreatedAt = dto.CreatedAt ?? DateTime.UtcNow;
        emprestimo.UpdatedAt = DateTime.UtcNow;
        emprestimo.Ativo = dto.Ativo;
        emprestimo.IdEtapa = dto.IdEtapa;
        emprestimo.IdStatus = dto.IdStatus;
        emprestimo.IdBanco = dto.IdBanco;
        emprestimo.ValorBruto = dto.ValorBruto;
        emprestimo.ValorLiquido = dto.ValorLiquido;
        emprestimo.ValorParcela = dto.ValorParcela;
        emprestimo.ValorPrazo = dto.ValorPrazo;
    }
}
