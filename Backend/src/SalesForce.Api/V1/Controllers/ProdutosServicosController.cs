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
    [Route("api/v{version:apiVersion}/produtos-servicos")]
    public class ProdutosServicosController : MainController
    {
        private readonly IProdutoServicoService _produtoServicoService;
        private readonly IMapper _mapper;

        public ProdutosServicosController(IMapper mapper,
                                      IProdutoServicoService produtoServicoService,
                                      INotificador notificador,
                                      IUser user) : base(notificador, user)
        {
            _mapper = mapper;
            _produtoServicoService = produtoServicoService;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoServicoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoServicoViewModel>>(await _produtoServicoService.RecuperarTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoServicoViewModel>> ObterPorId(Guid id)
        {
            var produtoServico = await Obter(id);

            if (produtoServico == null) return NotFound();

            return _mapper.Map<ProdutoServicoViewModel>(produtoServico);
        }

        [HttpGet("recuperar-quantidade")]
        public async Task<ActionResult<int>> RecuperarQuantidade()
        {
            return await _produtoServicoService.RecuperarQuantidade();
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoServicoViewModel>> Adicionar(ProdutoServicoViewModel produtoServicoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoServicoService.Adicionar(_mapper.Map<ProdutoServico>(produtoServicoViewModel));

            return CustomResponse(produtoServicoViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProdutoServicoViewModel>> Atualizar(Guid id, ProdutoServicoViewModel produtoServicoViewModel)
        {
            if (id != produtoServicoViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(produtoServicoViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _produtoServicoService.Atualizar(_mapper.Map<ProdutoServico>(produtoServicoViewModel));

            return CustomResponse(produtoServicoViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoServicoViewModel>> Excluir(Guid id)
        {
            var produtoServicoViewModel = await Obter(id);

            if (produtoServicoViewModel == null) return NotFound();

            await _produtoServicoService.Remover(id);

            return CustomResponse(produtoServicoViewModel);
        }

        private async Task<ProdutoServicoViewModel> Obter(Guid id)
        {
            return _mapper.Map<ProdutoServicoViewModel>(await _produtoServicoService.Obter(id));
        }

       
    }
}
