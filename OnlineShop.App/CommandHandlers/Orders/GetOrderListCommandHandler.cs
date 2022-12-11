﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using OnlineShop.App.Options;
using OnlineShop.Domain.SalesOrderHeaders;
using OnlineShop.Domain.SalesOrderHeaders.Commands;
using OnlineShop.Domain.SalesOrderHeaders.Queries;
using OnlineShop.Persistence.Interfaces;

namespace OnlineShop.App.CommandHandlers.Orders
{
    public class GetOrderListCommandHandler : IRequestHandler<GetOrderListCommand, List<OrderListQueryResult>>
    {
        private readonly IRepository<SalesOrderHeader> _repository;
        private readonly IMapper _mapper;
        private readonly IOptions<PagingOptions> _options;

        public GetOrderListCommandHandler(IRepository<SalesOrderHeader> repository, IMapper mapper, IOptions<PagingOptions> options)
        {
            _repository = repository;
            _mapper = mapper;
            _options = options;
        }

        public async Task<List<OrderListQueryResult>> Handle(GetOrderListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _repository.GetByPagesAsync(request.Filter, request.Page, _options.Value.Count,
                    cancellationToken);

                var convert = _mapper.Map<List<OrderListQueryResult>>(result);
                return convert;
            }
            catch (Exception ex)
            {
                throw new Exception($"err {ex.Message}");
            }
        }
    }
}
