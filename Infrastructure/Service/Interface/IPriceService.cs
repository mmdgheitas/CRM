using Infrastructure.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service.Interface
{
    public interface IPriceService
    {
        List<GlassTypeEnt> ListAllGlassTypes();
        bool DeleteGlassType(int id);
        GlassTypeEnt GlassTypeDetails(int id);
        bool AddGlassType(GlassTypeEnt item);
        bool EditGlassType(GlassTypeEnt item);
        List<GlassOptionEnt> ListGlassOptionByTypeID(int id = 0);
        List<GlassThicknesEnt> ListGlassThicknesByTypeID(int id = 0);
        List<GlassStrengthEnt> ListGlassStrengthByTypeID(int id = 0);
        List<FabricationEnt> ListAllFabrication();
        double GetGlassPrice(int thiknessID, int strengthID, int optionID,int glassTypeId);
        bool AddOrUpdate(int thicknesID, int strengthID, int optionID,int TypeID, double price);
        FabricationPriceEnt FabricationPriceDetail(int fid, int thicknesID,byte Sqf25 = 0,int glassTypeID = 0,int StrengthID = 0);
        bool AddOrUpdateFabricationPrice(FabricationPriceEnt model);
        double FabricationPriceValue(int fid, int thicknesID,int Sqf25 = 0,int glassTypeID = 0,int StrengthID = 0);
        List<Glass_FabricationEnt> ListGLassFabricationByTypeID(int id);
        List<GlassExtraPriceEnt> ListExtraPrice();
        bool DeleteExtraPrice(int id);
        GlassExtraPriceEnt ExtraPriceDetails(int id);
        bool IFExistExtraPriceTitle(string title, int iD);
        bool AddExtraPrice(GlassExtraPriceEnt model);
        bool EditExtraPrice(GlassExtraPriceEnt model);
    }
}
