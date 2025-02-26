using BusinessObject;
using DAL.DTOs.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mappers
{
    public static class TagMapper
    {
        public static TagResponseModel ToTagResponseModel(this Answer model)
        {
            return new TagResponseModel
            {
                Id = model.tag_id,
                Name = model.name,
            };
        }
    }
}
