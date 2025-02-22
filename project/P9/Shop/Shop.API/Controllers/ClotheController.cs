using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shop.Core;

namespace Shop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // api/Clothe // api/esm class bedoone controller // dakhele[] re az esm class bar midare
    public class ClotheController : Controller
    {
        public static List<Clothe> Clothes = new List<Clothe>
        {
            new Clothe(){Name = "hat" , Color = "Red" , Id = 1 , Price = 1000},
            new Clothe(){Name = "Shirt" , Color = "Blue" , Id = 2 , Price = 2000},
            new Clothe(){Name = "Pants" , Color = "Purple" , Id = 3 , Price = 3000}
        };

        // 1
        [HttpGet] // --> attribute
        [Route("getAllClothes")] // api/Clothe/getAllClothes
        // 2
        // [HttpGet("getAllClothes")] // api/Clothe/getAllClothes
        public List<Clothe> GetAllClothes() => ClotheController.Clothes;

        [HttpGet("getClothById/{id}")] // api/Clothe/getClotheById/2
        public Clothe GetClothById(int id )
        {
            return ClotheController.Clothes.Where(cloth => cloth.Id == id).FirstOrDefault();
        }

        [HttpPost]
        [Route("addNewCloth")]
        public Clothe AddNewCloth(Clothe cloth) // api/Clothe/AddNewCloth   postman --> body  
        {
            var newId = ClotheController.Clothes.Last().Id + 1;
            var newCloth = new Clothe() { Name = cloth.Name, Color = cloth.Color, Id = newId, Price = cloth.Price };
            ClotheController.Clothes.Add(newCloth);
            return newCloth;
        }

        [HttpDelete]
        [Route("removeClothes")] // api/Clothe/RemoveClothes    postman --> body --> raw --> Json --> array:mesl list python (Json int va string va array ro mishnase vali object ro na)
        public List<Clothe> RemoveCloth(int[] ids)
        {
            Clothes = Clothes.Where(c => !ids.Contains(c.Id)).ToList();
            return Clothes;
        }

        [HttpPut("updateClothName")]
        // [Route("updateClothName")]
        // [HttpPut("updateClothName/{id}/{name}")]    rahe digare anjame in kar
        public Clothe UpdateClothName(int id , string name) // api/Clothe/updateClothName postman --> put -->  Params -> Key : id - Value :5 -. Key : newName - Value : Gloves
        {
            var clothe = Clothes.Where(cloth => cloth.Id == id).FirstOrDefault();
            var idx = Clothes.IndexOf(clothe);
            clothe.Name = name;
            Clothes[idx] = clothe;
            return Clothes[idx];
        }

        [HttpPut]
        [Route("updateCloth")]
        public Clothe UpdateCloth(Clothe newClothe)
        {
            var Clothe = Clothes.Where(c => c.Id == newClothe.Id).FirstOrDefault();
            // // Clothe = newClothe;
            // Clothe.SetValue(newClothe);
            var idx = Clothes.IndexOf(Clothe);
            Clothes[idx] = newClothe;
            return Clothes[idx];
        }



        // use interface
        // private readonly ClotheRepository _provider;
        // public ClotheController(ClotheRepository provider)
        // {
        //     this._provider = provider;
        // }
        // [HttpPost]
        // [Route("addClothToDb")]
        // public Clothe AddClothToDb(Clothe clothe)
        // {
        //     this._provider.AddCloth(clothe);
        //     return clothe;
        // }   
        // [HttpPost] // create
        // [Route("addClothToDb")] // api/Clothe/addClothToDb
        // public async Task<Clothe> AddClothToDb(Clothe cloth)
        // {
        //     await this._provider.AddCloth(cloth);
        //     return cloth;
        // }  
        
    //     // [HttpPost]
    //     // [Route("getAllClothesFromDb")]
    //     // public async Task<List<Cloth>> GetAllClothesFromDb()
    //     // {
    //     //     List<Cloth> Clothes = await this._provider.GetAllClothes();
    //     //     return Clothes;
    //     // }

    //     // [HttpPost] // read
    //     // [Route("getAllClothesFromDb")]
    //     // public List<Cloth> GetAllClothesFromDb()
    //     // {
    //     //     List<Cloth> Clothes = this._provider.GetAllClothes();
    //     //     return Clothes;
    //     // }

    //     [HttpGet] // read
    //     [Route("getAllClothesFromDb")] // api/Clothe/getAllClothesFromDb
    //     public List<Clothe> GetAllClothesFromDb()
    //     {
    //         List<Clothe> Clothes = this._provider.GetAllClothes();
    //         return Clothes;
    //     }

    //     [HttpGet("getClothByIdFromDb/{id}")] // api/Clothe/getClothByIdFromDb/2
    //     public Clothe GetClothByIdFromDb(int id )
    //     {
    //         return this._provider.GetClothById(id);
            
    //     }

    //     [HttpPut("UpdateClothNameInDb/{Id}/{NewName}")] // update
    //     public Cloth UpdateClothNameInDb(int Id , string NewName)
    //     {
    //         var Clothe = this._provider.UpdateClotheName(Id,NewName);
    //         return Clothe;
    //     }

    //     [HttpPut("UpdateClothInDb")] // update
    //     public Clothe UpdateClothInDb(Clothe newClothe)
    //     {
    //         var Clothe = this._provider.UpdateClothe(newClothe);
    //         return Clothe;
    //     }

    //     [HttpDelete("DeleteClothFromDbByIds")] // delete or remove
    //     public List<Clothe> DeleteClothFromDbByIds(int[] ids)
    //     {
    //         return _provider.DeleteClothByIds(ids);
    //     }

    //     [HttpDelete("DeleteClothFromDb")]
    //     public List<Clothe> DeleteClothFromDb(Clothe clothe)
    //     {
    //         return _provider.DeleteCloth(clothe);
    //     }
    }
}
