using Infrastructure.Entity;
using Infrastructure.Repository;
using Infrastructure.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Implement
{
    public class PriceService : IPriceService
    {
        private IRepositoryBase<GlassTypeEnt, int> _glassTypeRepo;
        private IRepositoryBase<FabricationCategoryEnt, int> _fabricationCategoryRepo;
        private IRepositoryBase<FabricationEnt, int> _fabricationRepo;
        private IRepositoryBase<Glass_FabricationEnt, int> _glass_FabricationRepo;
        private IRepositoryBase<GlassStrengthEnt, int> _glassStrengthRepo;
        private IRepositoryBase<GlassThicknesEnt, int> _glassThicknesRepo;
        private IRepositoryBase<GlassOptionEnt, int> _glassOptionRepo;
        private IRepositoryBase<GlassPriceEnt, int> _glassPriceRepo;
        private IRepositoryBase<FabricationPriceEnt, int> _FabricationPriceRepo;
        private IRepositoryBase<GlassExtraPriceEnt, int> _glassExtraPriceRepo;
        private IRepositoryBase<GlassType_OptionEnt, int> _glassType_OptionRepo;
        private IRepositoryBase<GlassType_StrengthEnt, int> _glassType_StrengthRepo;
        private IRepositoryBase<GlassType_ThicknesEnt, int> _glassType_ThicknesRepo;

        public PriceService(IRepositoryBase<GlassTypeEnt, int> _GlassTypeRepo,
            IRepositoryBase<Glass_FabricationEnt, int> _Glass_FabricationRepo,
            IRepositoryBase<FabricationCategoryEnt, int> _FabricationCategoryRepo,
            IRepositoryBase<FabricationEnt, int> _FabricationRepo,
               IRepositoryBase<GlassStrengthEnt, int> _GlassStrengthRepo,
               IRepositoryBase<GlassThicknesEnt, int> _GlassThicknesRepo,
               IRepositoryBase<GlassOptionEnt, int> _GlassOptionRepo,
               IRepositoryBase<GlassPriceEnt, int> _GlassPriceRepo,
               IRepositoryBase<FabricationPriceEnt, int> _FabricationPriceRepo,
               IRepositoryBase<GlassExtraPriceEnt, int> _glassExtraPriceRepo,
               IRepositoryBase<GlassType_OptionEnt, int> _GlassType_OptionRepo,
               IRepositoryBase<GlassType_StrengthEnt, int> _GlassType_StrengthRepo,
               IRepositoryBase<GlassType_ThicknesEnt, int> _GlassType_ThicknesRepo

            )
        {
            this._glassTypeRepo = _GlassTypeRepo;
            this._glassStrengthRepo = _GlassStrengthRepo;
            this._glassThicknesRepo = _GlassThicknesRepo;
            this._fabricationCategoryRepo = _FabricationCategoryRepo;
            this._glass_FabricationRepo = _Glass_FabricationRepo;
            this._fabricationRepo = _FabricationRepo;
            this._glassOptionRepo = _GlassOptionRepo;
            this._glassPriceRepo = _GlassPriceRepo;
            this._FabricationPriceRepo = _FabricationPriceRepo;
            this._glassExtraPriceRepo = _glassExtraPriceRepo;
            this._glassType_OptionRepo = _GlassType_OptionRepo;
            this._glassType_StrengthRepo = _GlassType_StrengthRepo;
            this._glassType_ThicknesRepo = _GlassType_ThicknesRepo;
        }

        public bool AddExtraPrice(GlassExtraPriceEnt model)
        {
            try
            {
                return _glassExtraPriceRepo.Insert(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddGlassType(GlassTypeEnt item)
        {
            try
            {
                return _glassTypeRepo.Insert(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddOrUpdate(int thicknesID, int strengthID, int optionID, int TypeID, double price)
        {
            try
            {
                var glassPrice = _glassPriceRepo.GetAll().FirstOrDefault(p => p.GlassOptionID == optionID & p.GlassStrengthID == strengthID & p.GlassTypeID == TypeID & p.GlassThicknesID == thicknesID);
                glassPrice = glassPrice ?? new GlassPriceEnt() { GlassOptionID = optionID, GlassStrengthID = strengthID, GlassThicknesID = thicknesID, GlassTypeID = TypeID };

                glassPrice.Price = price;

                if (glassPrice.ID != 0)
                    return _glassPriceRepo.Update(glassPrice);
                else
                    return _glassPriceRepo.Insert(glassPrice);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddOrUpdateFabricationPrice(FabricationPriceEnt model)
        {
            try
            {
                var FabPrice = new FabricationPriceEnt();
                if (model.GlassTypeID == 1)
                {
                    if (model.GlassThicknesID == 4 | model.GlassThicknesID == 1 | model.GlassThicknesID == 2 | model.GlassThicknesID == 3)//1/4 = 1/8 = 5/32 = 3/16
                        model.GlassThicknesID = 4;//1/4

                    if (model.GlassThicknesID == 5 | model.GlassThicknesID == 6)//3/8 - 5/16
                        model.GlassThicknesID = 6;//3/8
                }
                if (model.GlassTypeID == 3)
                {
                    if (model.GlassThicknesID == 4 | model.GlassThicknesID == 5)//1/4 = 5/16
                        model.GlassThicknesID = 4;//1/4

                    if (model.GlassThicknesID == 6 | model.GlassThicknesID == 7)//3/8 = 7/16
                        model.GlassThicknesID = 6;//3/8

                    if (model.GlassThicknesID == 8 | model.GlassThicknesID == 9)//1/2 - 9/16
                        model.GlassThicknesID = 8;//1/2

                    if (model.GlassThicknesID == 11 | model.GlassThicknesID == 12)//3/4 - 13/16
                        model.GlassThicknesID = 11;//1/2

                    if (model.GlassThicknesID == 14 | model.GlassThicknesID == 15)//1 - 1 1 / 16
                        model.GlassThicknesID = 14;//1/2

                    FabPrice = _FabricationPriceRepo.GetAll().FirstOrDefault(p => p.FabricationID == model.FabricationID & p.GlassThicknesID == model.GlassThicknesID & p.Sqf25 == model.Sqf25 & p.GlassStrengthID == model.GlassStrengthID);
                }
                else
                {
                    FabPrice = _FabricationPriceRepo.GetAll().FirstOrDefault(p => p.FabricationID == model.FabricationID & p.GlassThicknesID == model.GlassThicknesID & p.Sqf25 == model.Sqf25);
                }
                FabPrice = FabPrice ?? new FabricationPriceEnt()
                {
                    FabricationID = model.FabricationID,
                    GlassThicknesID = model.GlassThicknesID,
                    Price = model.Price,
                    Sqf25 = model.Sqf25,
                    GlassStrengthID = model.GlassStrengthID
                };

                FabPrice.Price = model.Price;

                if (FabPrice.ID != 0)
                    return _FabricationPriceRepo.Update(FabPrice);
                else
                    return _FabricationPriceRepo.Insert(FabPrice);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteExtraPrice(int id)
        {
            try
            {
                return _glassExtraPriceRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteGlassType(int id)
        {
            try
            {
                return _glassTypeRepo.Delete(id);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditExtraPrice(GlassExtraPriceEnt model)
        {
            try
            {
                return _glassExtraPriceRepo.Update(model);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool EditGlassType(GlassTypeEnt item)
        {
            try
            {
                return _glassTypeRepo.Update(item);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public GlassExtraPriceEnt ExtraPriceDetails(int id)
        {
            try
            {
                return _glassExtraPriceRepo.GetAll().FirstOrDefault(p => p.ID == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public FabricationPriceEnt FabricationPriceDetail(int fid, int thicknesID, byte Sqf25 = 0, int glassTypeID = 0, int StrengthID = 0)
        {
            try
            {
                if (glassTypeID == 1)
                {
                    if (thicknesID == 4 | thicknesID == 1 | thicknesID == 2 | thicknesID == 3)//1/4 = 1/8 = 5/32 = 3/16
                        thicknesID = 4;//1/4

                    if (thicknesID == 5 | thicknesID == 6)//3/8 - 5/16
                        thicknesID = 6;//3/8
                }

                if (glassTypeID == 3)
                {
                    if (thicknesID == 4 | thicknesID == 5)//1/4 = 5/16
                        thicknesID = 4;//1/4

                    if (thicknesID == 6 | thicknesID == 7)//3/8 = 7/16
                        thicknesID = 6;//3/8

                    if (thicknesID == 8 | thicknesID == 9)//1/2 - 9/16
                        thicknesID = 8;//1/2

                    if (thicknesID == 11 | thicknesID == 12)//3/4 - 13/16
                        thicknesID = 11;//1/2

                    if (thicknesID == 14 | thicknesID == 15)//1 - 1 1 / 16
                        thicknesID = 14;//1/2

                    return _FabricationPriceRepo.GetAll().FirstOrDefault(p => p.FabricationID == fid & p.GlassThicknesID == thicknesID & p.Sqf25 == Sqf25 & p.GlassStrengthID == StrengthID);
                }
                else
                {
                    return _FabricationPriceRepo.GetAll().FirstOrDefault(p => p.FabricationID == fid & p.GlassThicknesID == thicknesID & p.Sqf25 == Sqf25);
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public double FabricationPriceValue(int fid, int thicknesID, int Sqf25 = 0, int glassTypeID = 1, int StrengthID = 0)
        {
            try
            {
                if (glassTypeID == 1)
                {
                    if (thicknesID == 4 | thicknesID == 1 | thicknesID == 2 | thicknesID == 3)//1/4 = 1/8 = 5/32 = 3/16
                        thicknesID = 4;//1/4

                    if (thicknesID == 5 | thicknesID == 6)//3/8 - 5/16
                        thicknesID = 6;//3/8
                }
                if (glassTypeID == 3)
                {
                    if (thicknesID == 4 | thicknesID == 5)//1/4 = 5/16
                        thicknesID = 4;//1/4

                    if (thicknesID == 6 | thicknesID == 7)//3/8 = 7/16
                        thicknesID = 6;//3/8

                    if (thicknesID == 8 | thicknesID == 9)//1/2 - 9/16
                        thicknesID = 8;//1/2

                    if (thicknesID == 11 | thicknesID == 12)//3/4 - 13/16
                        thicknesID = 11;//1/2

                    if (thicknesID == 14 | thicknesID == 15)//1 - 1 1 / 16
                        thicknesID = 14;//1/2

                    return _FabricationPriceRepo.GetAll().FirstOrDefault(p => p.FabricationID == fid & p.GlassThicknesID == thicknesID & p.Sqf25 == Sqf25 & p.GlassStrengthID == StrengthID)?.Price ?? 0;
                }
                else
                {
                    return _FabricationPriceRepo.GetAll().FirstOrDefault(p => p.FabricationID == fid & p.GlassThicknesID == thicknesID & p.Sqf25 == Sqf25)?.Price ?? 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public double GetGlassPrice(int thiknessID, int strengthID, int optionID, int glassTypeID)
        {
            try
            {
                var price = _glassPriceRepo.GetAll().FirstOrDefault(p => p.GlassThicknesID == thiknessID & p.GlassStrengthID == strengthID & p.GlassOptionID == optionID & p.GlassTypeID == glassTypeID);
                if (price == null)
                    return -1;
                else
                    return price.Price;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public GlassTypeEnt GlassTypeDetails(int id)
        {
            try
            {
                return _glassTypeRepo.GetAll().Where(p => p.ID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool IFExistExtraPriceTitle(string title, int iD)
        {
            try
            {
                if (iD == 0)
                    return _glassExtraPriceRepo.GetAll().Any(p => p.Title == title);
                else
                    return _glassExtraPriceRepo.GetAll().Any(p => p.Title == title & p.ID != iD);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<FabricationEnt> ListAllFabrication()
        {
            try
            {
                return _fabricationRepo.GetAll().Include(p => p.FabricationCategory).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<GlassTypeEnt> ListAllGlassTypes()
        {
            try
            {
                return _glassTypeRepo.GetAll().OrderBy(p => p.Priority).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<GlassExtraPriceEnt> ListExtraPrice()
        {
            try
            {
                return _glassExtraPriceRepo.GetAll().ToList();
            }
            catch (Exception ex)
            {
                return new List<GlassExtraPriceEnt>();
            }
        }

        public List<Glass_FabricationEnt> ListGLassFabricationByTypeID(int id)
        {
            try
            {
                return _glass_FabricationRepo.GetAll().Where(p => p.GlassTypeID == id).ToList();
            }
            catch (Exception ex)
            {
                return new List<Glass_FabricationEnt>();
            }
        }

        public List<GlassOptionEnt> ListGlassOptionByTypeID(int id = 0)
        {
            try
            {
                if (id == 0)
                    return _glassOptionRepo.GetAll().ToList();
                else
                {
                    var result = (from option in _glassOptionRepo.GetAll()
                                  join glassoption in _glassType_OptionRepo.GetAll() on option.ID equals glassoption.GlassOptionID
                                  where glassoption.GlassTypeID == id
                                  select option).ToList();

                    return result;
                }
            }
            catch (Exception ex)
            {
                return new List<GlassOptionEnt>();
            }
        }

        public List<GlassStrengthEnt> ListGlassStrengthByTypeID(int id = 0)
        {
            try
            {
                if (id == 0)
                    return _glassStrengthRepo.GetAll().ToList();
                else
                {
                    var result = (from Strength in _glassStrengthRepo.GetAll().ToList()
                                  join glassStrength in _glassType_StrengthRepo.GetAll().ToList() on Strength.ID equals glassStrength.GlassStrengthID
                                  where glassStrength.GlassTypeID == id
                                  select Strength).ToList();

                    return result;
                }
            }
            catch (Exception ex)
            {
                return new List<GlassStrengthEnt>();
            }
        }

        public List<GlassThicknesEnt> ListGlassThicknesByTypeID(int id = 0)
        {
            try
            {
                if (id == 0)
                    return _glassThicknesRepo.GetAll().ToList();
                else
                {
                    var result = (from Thicknes in _glassThicknesRepo.GetAll()
                                  join glassThicknes in _glassType_ThicknesRepo.GetAll() on Thicknes.ID equals glassThicknes.GlassThicknesID
                                  where glassThicknes.GlassTypeID == id
                                  select Thicknes).ToList();

                    return result;
                }
            }
            catch (Exception ex)
            {
                return new List<GlassThicknesEnt>();
            }
        }
    }
}