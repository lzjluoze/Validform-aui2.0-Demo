////////////////////////////////////////////////
// 生成时间: 2016-08-10 09:14:12
//作者：海南残友
//http://www.canyouhn.com/
////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Linq.Mapping;
using System.Text;

namespace Model
{

    public class DemoModel
    {

        
        /// <summary>
        /// 
        /// </summary>
         // [Display(Name = " ")]
       // [Required(ErrorMessage = "{0}")]
        public Int64 Id
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
         // [Display(Name = " ")]
       // [Required(ErrorMessage = "{0}")]
        public string Name
        {
            set;
            get;
        }
        /// <summary>
        /// 
        /// </summary>
         // [Display(Name = " ")]
       // [Required(ErrorMessage = "{0}")]
        public string Phone
        {
            set;
            get;
        }
        
         
             public const string _Id="Id";
             public const string _Name="Name";
             public const string _Phone="Phone";
           
        
    }
}