using Applications.Model.Models.Cards;
using DesignPattern.Model.Models.Cards;
using Infrastructures.Share.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using System.Runtime.InteropServices;

namespace DesignPattern.Controllers.CreationalPatterns
{
    /// <summary>
    /// Prototype is a creational design pattern that lets you copy existing objects without making your code dependent on their classes.
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PrototypeController : ControllerBase
    {
        /// <summary>
        /// Pros:
        /// You can clone objects without coupling to their concrete classes.
        /// You can get rid of repeated initialization code in favor of cloning pre-built prototypes.
        /// You can produce complex objects more conveniently.
        /// You get an alternative to inheritance when dealing with configuration presets for complex objects.
        /// 
        /// Cons:
        /// Cloning complex objects that have circular references might be very tricky.
        /// 
        /// Reference:
        ///     https://refactoring.guru/design-patterns/prototype
        /// </summary>
        ///

        public readonly Dictionary<string, List<ClothesDTO>> ClothesDictionary;
        public static List<ClothesResponse> ClothesCard { get; set; } = new List<ClothesResponse>();

        public PrototypeController()
        {
            ClothesDictionary = new Dictionary<string, List<ClothesDTO>>
            {
                { "T-Shirt",    new List<ClothesDTO> {
                                    new ClothesDTO("RED", 39, "Short", "T-Shirt", 100),
                                    new ClothesDTO("RED", 40, "Short", "T-Shirt", 100),
                                    new ClothesDTO("RED", 41, "Short", "T-Shirt", 100),
                                    new ClothesDTO("RED", 42, "Short", "T-Shirt", 100),
                                    new ClothesDTO("YELLOW", 39, "Short", "T-Shirt", 100),
                                    new ClothesDTO("YELLOW", 40, "Short", "T-Shirt", 100),
                                    new ClothesDTO("YELLOW", 41, "Short", "T-Shirt", 100),
                                    new ClothesDTO("YELLOW", 42, "Short", "T-Shirt", 100),
                                }
                },
                { "Jean",    new List<ClothesDTO> {
                                    new ClothesDTO("BLACK", 39, "Long", "Jean", 100),
                                    new ClothesDTO("BLACK", 40, "Long", "Jean", 100),
                                    new ClothesDTO("BLACK", 41, "Long", "Jean", 100),
                                    new ClothesDTO("BLACK", 42, "Long", "Jean", 100),
                                    new ClothesDTO("BROWN", 39, "Long", "Jean", 100),
                                    new ClothesDTO("BROWN", 40, "Long", "Jean", 100),
                                    new ClothesDTO("BROWN", 41, "Long", "Jean", 100),
                                    new ClothesDTO("BROWN", 42, "Long", "Jean", 100),
                                }
                }
            };
        }

        [HttpGet]
        public IActionResult GetItems() => Ok(ClothesDictionary);

        [HttpGet]
        public IActionResult GetCards() => Ok(ClothesCard);

        [HttpPost]
        public IActionResult AddItemToCards(List<ClothesRequest> request)
        {
            var reduntItemList = new List<ClothesRequest>();

            request?.ToList().ForEach(item =>
            {
                if (ClothesDictionary.TryGetValue(item.Name, out var card))
                {
                    var itemToCard = card.FirstOrDefault(x => x.Color == item.Color && x.Size == item.Size);

                    if (itemToCard != null)
                    {
                        //// case 1 shallow copy
                        //var itemClone = itemToCard?.Clone(item.Count);

                        // case 2 deep copy
                        var itemClone = itemToCard?.Clone();
                        itemClone.Count = item.Count;

                        ClothesCard.Add(new ClothesResponse
                        {
                            Color = itemToCard.Color,
                            Count = itemToCard.Count,
                            Name = itemToCard.Name,
                            Size = itemToCard.Size,
                            Type = itemToCard.Type,
                        });
                    }
                    else
                    {
                        reduntItemList.Add(item);
                    }
                }
            });

            if (reduntItemList.Count > 0)
            {
                return BadRequest(reduntItemList);
            }

            return Ok(ClothesCard);
        }

        /// Actually
        /// When using Propertype Pattern, dev always converts to Json and then converts back to Object. (deep copy)
        ///     It accept system will provide new object with new instance of reference properties.
        ///     ==> Change reference properties will not affect another object.
        ///     
        /// In special cases, the new object uses the clone function manually. (shallow copy)
        ///     ==> Change reference properites will affect another object.
        ///     
        /// Example reference type: array, list
        ///
    }
}
