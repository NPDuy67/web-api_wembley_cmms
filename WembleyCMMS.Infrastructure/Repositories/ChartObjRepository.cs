//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WembleyCMMS.Domain.AggregateModels.ChartObjAggregate;
//using WembleyCMMS.Domain.AggregateModels.EquipmentAggregate;
//using WembleyCMMS.Domain.AggregateModels.MaintenanceResponseAggregate;

//namespace WembleyCMMS.Infrastructure.Repositories
//{
//    public class ChartObjRepository : BaseRepository, IChartObjRepository
//    {
//        public ChartObjRepository(ApplicationDbContext context) : base(context)
//        {
//        }

//        public ChartObj Add(ChartObj chartObj)
//        {
//            if (chartObj.IsTransient())
//            {
//                return _context.ChartObjs
//                    .Add(chartObj)
//                    .Entity;
//            }
//            else
//            {
//                return chartObj;
//            }
//        }

//        public ChartObj Update(ChartObj chartObj)
//        {
//            return _context.ChartObjs.Update(chartObj).Entity;
//        }

//        public async Task<ChartObj?> GetById(string chartObjId)
//        {
//            return await _context.ChartObjs
//                .FirstOrDefaultAsync(x => x.ChartObjId == chartObjId);
//        }
//    }
//}
