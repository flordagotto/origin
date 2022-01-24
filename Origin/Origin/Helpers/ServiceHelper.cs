using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Origin.Helpers
{
    public class ServiceHelper
    {
        public static List<T_out> Mapper<T_in, T_out>(IMapper _mapper, List<T_in> listaOrigen, T_out toMap)
        {
            var listaDestino = new List<T_out>();
            if (listaOrigen != null)
            {
                foreach (var elem in listaOrigen)
                {
                    var temp = _mapper.Map<T_out>(elem);

                    listaDestino.Add(temp);
                }

                return listaDestino;
            }
            return null;
        }
    }
}
