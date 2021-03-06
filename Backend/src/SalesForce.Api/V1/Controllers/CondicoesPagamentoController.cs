using AutoMapper;
using SalesForce.Api.Controllers;
using SalesForce.Application.ViewModels;
using SalesForce.Core.Notificacoes;
using SalesForce.Domain.Models;
using SalesForce.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SalesForce.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/condicoes-pagamento")]
    public class CondicoesPagamentoController : MainController
    {
        private readonly ICondicaoPagamentoService _condicaoPagamentoService;
        private readonly IMapper _mapper;

        public CondicoesPagamentoController(IMapper mapper,
                                      ICondicaoPagamentoService condicaoPagamentoService,
                                      INotificador notificador,
                                      IUser user) : base(notificador, user)
        {
            _mapper = mapper;
            _condicaoPagamentoService = condicaoPagamentoService;
        }

        [HttpGet]
        public async Task<IEnumerable<CondicaoPagamentoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CondicaoPagamentoViewModel>>(await _condicaoPagamentoService.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CondicaoPagamentoViewModel>> ObterPorId(Guid id)
        {
            var condicaoPagamento = await Obter(id);

            if (condicaoPagamento == null) return NotFound();

            return condicaoPagamento;
        }

        [HttpPost]
        public async Task<ActionResult<CondicaoPagamentoViewModel>> Adicionar(CondicaoPagamentoViewModel CondicaoPagamentoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _condicaoPagamentoService.Adicionar(_mapper.Map<CondicaoPagamento>(CondicaoPagamentoViewModel));

            return CustomResponse(CondicaoPagamentoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CondicaoPagamentoViewModel>> Atualizar(Guid id, CondicaoPagamentoViewModel CondicaoPagamentoViewModel)
        {
            if (id != CondicaoPagamentoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(CondicaoPagamentoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _condicaoPagamentoService.Atualizar(_mapper.Map<CondicaoPagamento>(CondicaoPagamentoViewModel));

            return CustomResponse(CondicaoPagamentoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CondicaoPagamentoViewModel>> Excluir(Guid id)
        {
            var CondicaoPagamentoViewModel = await Obter(id);

            if (CondicaoPagamentoViewModel == null) return NotFound();

            await _condicaoPagamentoService.Remover(id);

            return CustomResponse(CondicaoPagamentoViewModel);
        }

        private async Task<CondicaoPagamentoViewModel> Obter(Guid id)
        {
            return _mapper.Map<CondicaoPagamentoViewModel>(await _condicaoPagamentoService.Obter(id));
        }
    }
}
