using FluxoDeCaixa.Application.Common.Interfaces;
using FluxoDeCaixa.Application.Common.Interfaces.Persistence;
using FluxoDeCaixa.Application.Features.FluxoDeCaixa.Commands.Transacao;
using FluxoDeCaixa.Domain.Common.Errors;
using FluxoDeCaixa.Domain.Entities;
using Moq;

namespace FluxoDeCaixa.Tests
{
    public class TransacaoCommandHandlerTests
    {
        [Fact]
        public async Task Handle_DeveRetornarErroParaValorNegativo()
        {
            // Arrange
            var mockFluxoDeCaixaRepository = new Mock<IFluxoDeCaixaRepository>();
            var mockDbContext = new Mock<IFluxoDeCaixaDbContext>();
            var handler = new TransacaoCommandHandler(mockFluxoDeCaixaRepository.Object, mockDbContext.Object);

            var command = new TransacaoCommand(-50, true);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(Errors.Transacao.InvalidValue, result.FirstError);
        }

        [Fact]
        public async Task Handle_DeveAdicionarTransacaoAoFluxoDeCaixaExistente()
        {
            // Arrange
            var mockFluxoDeCaixaRepository = new Mock<IFluxoDeCaixaRepository>();
            var mockDbContext = new Mock<IFluxoDeCaixaDbContext>();
            var handler = new TransacaoCommandHandler(mockFluxoDeCaixaRepository.Object, mockDbContext.Object);

            var fluxoDeCaixa = new Domain.Aggregate_Root.FluxoDeCaixa(new List<Transacao>(), DateTime.Now);
            mockFluxoDeCaixaRepository.Setup(repo => repo.ObterFluxoDeCaixaPorData(It.IsAny<DateTime>()))
                .ReturnsAsync(fluxoDeCaixa);

            var command = new TransacaoCommand(100, true);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.Value);
            Assert.Single(fluxoDeCaixa.Transacoes);
            // Verifique outros aspectos da transação adicionada
        }
    }
}

