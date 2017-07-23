namespace StockManager.Automapper
{
    using AutoMapper;

    using StockManager.Common.Enums;
    using StockManager.Common.Models;
    using StockManager.DAL.Entities;

    /// <summary>
    /// Profile for automapper.
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class AutoMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoMapperProfile"/> class.
        /// </summary>
        public AutoMapperProfile()
        {
            this.CreateMap<EquityModel, Stock>().ForMember(x => x.StockType, opt => opt.UseValue(StockType.Equity));
            this.CreateMap<BondModel, Stock>().ForMember(x => x.StockType, opt => opt.UseValue(StockType.Bond));
            this.CreateMap<Stock, EquityModel>();
            this.CreateMap<Stock, BondModel>();
        }
    }
}
