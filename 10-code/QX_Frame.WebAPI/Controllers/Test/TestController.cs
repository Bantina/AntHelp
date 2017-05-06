using QX_Frame.Helper_DG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace QX_Frame.WebAPI.Controllers
{
    public class TestController : ApiController
    {
        #region RESTful Test
        //url: http://localhost:3999/api/Test
        public IHttpActionResult GetQX()
        {
            var result = new { TFMark = true, Msg = "this is HttpGET Method" };
            return Json<dynamic>(result);
        }

        //the return Type Test
        /*
         it should to added the request HEADERS : Content-Type: application/json; charset=UTF-8
         */
        public IHttpActionResult PostQX(dynamic query)
        {
            try
            {
                if (query != null)
                {
                    #region Return Type Test About Status-Code

                    if (query.param == "2_1")
                    {
                        return Ok();
                    }
                    if (query.param == "2_2")
                    {
                        return Ok("this is OK(...)");
                    }
                    if (query.param == "2_3")
                    {
                        return Ok<string>("this is OK<string>(...)");
                    }
                    if (query.param == "2_4")
                    {
                        return NotFound();
                    }
                    if (query.param == "2_5")
                    {
                        return Content<string>(HttpStatusCode.OK, "OK-qixiao");
                    }
                    if (query.param == "2_6")
                    {
                        return BadRequest();
                    }
                    if (query.param == "2_7")
                    {
                        return Redirect("http://www.dong666.com");
                    }

                    #endregion

                    #region return Json Test

                    if (query.param == "3_1")
                    {
                        var result = new { ID = "aaaa", NO = "111", NAME = "222", DESC = "3333" };

                        return Json(result);
                    }
                    if (query.param == "3_2")
                    {
                        var result = new { ID = "aaaa", NO = "111", NAME = "222", DESC = "3333" };

                        return Json<dynamic>(result);
                    }
                    if (query.param == "3_3")
                    {
                        var result = new List<dynamic>();

                        result.Add(new { ID = "aaaa", NO = "111", NAME = "222", DESC = "3333" });
                        result.Add(new { ID = "bbbb", NO = "444", NAME = "555", DESC = "6666" });

                        return Json<dynamic>(result);
                    }

                    #endregion
                }
                else
                {
                    var result = new { TFMark = true, Msg = "this is HttpPOST Method and The query=null" };
                    return Json<dynamic>(result);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        public IHttpActionResult PutQX(dynamic query)
        {
            try
            {
                var list = new List<dynamic>();

                list.Add(new { ID = "aaaa", NO = "111", NAME = "1111", DESC = "11111" });
                list.Add(new { ID = "bbbb", NO = "222", NAME = "2222", DESC = "22222" });
                list.Add(new { ID = "cccc", NO = "333", NAME = "3333", DESC = "33333" });
                list.Add(new { ID = "dddd", NO = "444", NAME = "4444", DESC = "44444" });

                list.Remove(list.Where(li => li.ID == query.ID.ToString()).FirstOrDefault());

                list.Add(new { ID = "eeee", NO = "666", NAME = "6666", DESC = "66666" });

                var result = new { TFMark = true, Msg = "this is HttpPUT Method", list = list };
                return Json<dynamic>(result);
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        public IHttpActionResult DeleteQX(dynamic query)
        {
            try
            {
                var list = new List<dynamic>();

                list.Add(new { ID = "aaaa", NO = "111", NAME = "1111", DESC = "11111" });
                list.Add(new { ID = "bbbb", NO = "222", NAME = "2222", DESC = "22222" });
                list.Add(new { ID = "cccc", NO = "333", NAME = "3333", DESC = "33333" });
                list.Add(new { ID = "dddd", NO = "444", NAME = "4444", DESC = "44444" });

                list.Remove(list.Where(li => li.ID == query.ID.ToString()).FirstOrDefault());

                //var result = new { TFMark = true, Msg = "this is HttpDELETE Method", list = list };
                //return Json<dynamic>(result);
                return Json<dynamic>(Return_Helper_DG.Success_Msg_Data_DCount_HttpCode("this is HttpDELETE Method", list, list.Count));
            }
            catch (Exception ex)
            {
                return Ok(ex);
            }
        }
        #endregion
    }
}
