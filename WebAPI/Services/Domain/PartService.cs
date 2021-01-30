using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Helpers;
using WebAPI.Models.Parts;

namespace WebAPI.Services
{
    public class PartService : IPartService
    {
        private DataContext _context;

        public PartService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<dynamic> GetPartList()
        {
            try
            {
                return (from part in _context.Parts
                        select new
                        {
                            id = part.Id,
                            hil_code = part.Hil_Code,
                            part_name = part.Part_Name,
                            part_no = part.Part_No,
                            material_code = part.Material_Code
                        }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<dynamic> GetPartSetSelection()
        {
            try
            {
                var query = (from partset in _context.PartSets                             
                             orderby partset.PartSet_Code
                             select new
                             {
                                 id = partset.Id,
                                 partset_code = partset.PartSet_Code
                             }).ToList();

                IList<PartSetsModel> partSets = new List<PartSetsModel>();
                foreach (var parent in query)
                {
                    PartSetsModel partSet = new PartSetsModel();
                    partSet.id = parent.id;
                    partSet.partset_code = parent.partset_code;
                 
                    var parts = (from part in _context.Parts
                                 join partset_details in _context.PartSet_Details on part.Id equals partset_details.Part_Id
                                 where partset_details.PartSet_Id == parent.id
                                 select new
                                 {
                                     id = part.Id,
                                     name = part.Part_Name
                                 }).ToList();
                    List<PartSet_Part> partParents = new List<PartSet_Part>();
                    foreach (var part in parts)
                    {
                        PartSet_Part partSingle = new PartSet_Part();
                        partSingle.id = part.id;
                        partSingle.name = part.name;
                        partParents.Add(partSingle);
                    }

                    partSet.parts = partParents;
                    partSets.Add(partSet);
                }
                return partSets;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public dynamic GetPartById(int id)
        {
            try
            {
                return (from part in _context.Parts
                        join customer in _context.Customers on part.Customer_Id equals customer.Id
                        where part.Id == id
                        select new
                        {
                            id = part.Id,
                            hil_code = part.Hil_Code,
                            part_name = part.Part_Name,
                            part_no = part.Part_No,
                            customer_id = customer.Id,
                            customer_name = customer.Customer_Name,
                            material_code = part.Material_Code,
                            material_description = part.Material_Description,
                            color = part.Colour,
                            back_code = part.Back_Code,
                            model = part.Model,
                            status = part.Status
                        }).First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EditPart(Part data)
        {
            try
            {
                Part part = _context.Parts.Where(x => x.Id == data.Id).First();
                part.Id = data.Id;
                part.Hil_Code = data.Hil_Code;
                part.Part_Name = data.Part_Name;
                part.Part_No = data.Part_No;
                part.Customer_Id = data.Customer_Id;
                part.Material_Code = data.Material_Code;
                part.Material_Description = data.Material_Description;
                part.Colour = data.Colour;
                part.Back_Code = data.Back_Code;
                part.Model = data.Model;
                int num = _context.SaveChanges();
                if (num > 0)
                {
                    return data.Id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data.Id;
        }

        public int AddPart(Part data)
        {
            try
            {
                _context.Parts.Add(data);
                int num = _context.SaveChanges();
                if (num > 0)
                {
                    return data.Id;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return data.Id;
        }

        //public IEnumerable<dynamic> GetPartModelSelection()
        //{
        //    try
        //    {
        //        return (from pm in _context.part_model
        //                orderby pm.name
        //                select new
        //                {
        //                    id = pm.id,
        //                    part_model = string.Concat(string.Concat(string.Concat(pm.name + " / ", pm.model_name), " / "), pm.code)
        //                }).ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
