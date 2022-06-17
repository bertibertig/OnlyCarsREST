using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OnlyCarsREST.Models;
using System.Collections.Generic;
using System.Dynamic;

namespace OnlyCarsREST.Controller {

    [Route("jsonpatch/[action]")]
    [ApiController]
    public class HomeController : ControllerBase {
        // <snippet_PatchAction>
        [HttpPatch]
        public IActionResult JsonPatchWithModelState(
            [FromBody] JsonPatchDocument<ParkingPlace> patchDoc) {
            if (patchDoc != null) {
                var customer = CreateParkingPlace();

                patchDoc.ApplyTo(customer, ModelState);

                if (!ModelState.IsValid) {
                    return BadRequest(ModelState);
                }

                return new ObjectResult(customer);
            }
            else {
                return BadRequest(ModelState);
            }
        }
        // </snippet_PatchAction>

        [HttpPatch]
        public IActionResult JsonPatchWithModelStateAndPrefix(
            [FromBody] JsonPatchDocument<ParkingPlace> patchDoc,
            string prefix) {
            var customer = CreateParkingPlace();

            patchDoc.ApplyTo(customer, ModelState, prefix);

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            return new ObjectResult(customer);
        }

        [HttpPatch]
        public IActionResult JsonPatchWithoutModelState([FromBody] JsonPatchDocument<ParkingPlace> patchDoc) {
            var customer = CreateParkingPlace();

            patchDoc.ApplyTo(customer);

            return new ObjectResult(customer);
        }

        // <snippet_Dynamic>
        [HttpPatch]
        public IActionResult JsonPatchForDynamic([FromBody] JsonPatchDocument patch) {
            dynamic obj = new ExpandoObject();
            patch.ApplyTo(obj);

            return Ok(obj);
        }
        // </snippet_Dynamic>

        private ParkingPlace CreateParkingPlace() {
            return new ParkingPlace {
                ParkingNumber=""
            };
        }
    }
}
