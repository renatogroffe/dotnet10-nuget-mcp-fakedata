using Bogus;
using FakeDataMcpServer.Models;
using FakeDataMcpServer.Validators;
using ModelContextProtocol.Server;
using System.ComponentModel;

namespace FakeDataMcpServer.Tools;

/// <summary>
/// MCP Tool para geracao de dados fake de mensagens baseadas em Lorem Ipsum.
/// </summary>
internal class MensagensFakeDataTool
{
    [McpServerTool]
    [Description("Gera uma lista de mensagens fake baseadas em Lorem Ipsum.")]
    public async Task<Result<Mensagem>> GerarMensagensFake(
        [Description("Quantidade de registros")] int numberOfRecords)
    {
        try
        {
            var result = NumberOfRecordsValidator<Mensagem>.Validate(numberOfRecords)!;
            if (result.IsSuccess!.Value)
            {
                var random = new Random();
                var fakeMensagens = new Faker<Mensagem>("pt_BR").StrictMode(false)
                    .RuleFor(e => e.Texto, f => f.Lorem.Sentence())
                    .RuleFor(e => e.AnoCitacao, f => random.Next(2016, DateTime.Now.Year))
                    .Generate(numberOfRecords);
                result.Data = fakeMensagens;
                result.Message = $"{numberOfRecords} mensagem(ns) fake gerada(s) com sucesso!";
            }
            return await Task.FromResult(result);
        }
        catch (Exception ex)
        {
            return new Result<Mensagem>
            {
                IsSuccess = false,
                Message = $"Erro ao gerar dados fake de mensagens: {ex.Message}"
            };
        }
    }
}