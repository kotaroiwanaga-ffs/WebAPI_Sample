using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_Sample.Models;

namespace WebAPI_Sample.Controllers
{
    public class SampleController : ApiController
    {
        //static List<Image> imgList = new List<Image>();
        private static ImageList imgList = new ImageList();
        //private static int nextId = 0;
        private static List<int> deletedIds = new List<int>();

        /// <summary>
        /// 画像情報の一覧を取得できる
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/img/")]
        public ImageList Get()
        {
            imgList.Images = imgList.Images.OrderBy(p => p.Id).Select(p => p).ToList();
            return imgList;
        }

        /// <summary>
        /// 画像情報をIdを指定して取得できる
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/img/{Id}")]
        public Image Get(int Id)
        {
            return
                imgList.Images
                .SingleOrDefault(p => p.Id == Id);
        }


        /// <summary>
        /// 新しい画像情報を追加できる
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/img")]
        public int Post([FromBody]Image image)
        {
            Image img = new Image();
            if(deletedIds.Count > 0)
            {
                img.Id = deletedIds.First();
                deletedIds.RemoveAt(0);
            }
            else
            {
                img.Id = imgList.Images.Count;
            }
            img.Tags = image.Tags;
            img.Path = image.Path;

            imgList.Images.Add(img);

            return imgList.Images.Last().Id;
        }

        /// <summary>
        /// タグの情報を更新できる
        /// </summary>
        /// <param name="image"></param>
        [HttpPut]
        [Route("api/img/{id}")]
        public void Put(int id, [FromBody]List<string> tags)
        {
            var img = imgList.Images
                .SingleOrDefault(p => p.Id == id);

            if(img != null)
            {
                img.Tags = tags;
            }
            
        }

        /// <summary>
        /// 画像情報を削除できる
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("api/img/{id}")]
        public void Delete(int Id)
        {
            var img = imgList.Images.SingleOrDefault(p => p.Id == Id);

            if(img != null)
            {
                deletedIds.Add(Id);
                imgList.Images.Remove(img);
            }
         
        }

    }

}
