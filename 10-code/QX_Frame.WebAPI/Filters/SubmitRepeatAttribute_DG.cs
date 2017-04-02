using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QX_Frame.WebAPI.Filters
{
    public class SubmitRepeatAttribute_DG
    {
        /*
         在页面生成时同时回传一个 token_repeat 并同时保存到session
         下次请求时必须同时传递一个token_repeat 并验证是否和session的一致，如果一致则清楚session并继续执行，并且重新生成session，回传token_repeat，如果不一致，则拒绝执行 提示不能重复提交
         刷新页面会重新回传一个token
         */
    }
}