
//新闻ajax分页加载数据,第二种加载结合aui-scroll.js使用

(function( window, undefined ) {
    "use strict";
    var NewsAjaxPage = function () {

    };
    var newsSendData;//提交数据
    var page = 1;//第几页
    var pageSize = 10;//每页取的数据
    var newsSendurl;//提交url
    var pageType;
    var isLoad = true;//是否继续加载，用于第二种加载
    NewsAjaxPage.prototype = {
    params: {
        newsSendurl: '',//访问链接
        pageSize:10,//每页显示的数目
        sendData: '',//提交数据
        pageType:1//分页类型1分批加载，2到底部加载
        
    },
    create: function (params, callback) {
        var self = this;
        newsSendData = params.sendData ? params.sendData : self.params.sendData;
        pageSize = params.pageSize ? params.pageSize : self.params.pageSize;
        newsSendurl = params.url ? params.url : self.params.url;
        pageType = params.pageType ? params.pageType : self.params.pageType;
        if (pageType == 1) {
            callback({
                data: self.ajaxPage()
            });
        }
        if (pageType == 2)
        {
            callback({
                data: self.ajaxPage2()
            });
        }
        return
    },
    ajaxPage: function () {//数据分批加载
        
        var self = this;
    $("#loadHint").html('正在加载。。。')
    $.ajax({
    type: "Post",
    data: newsSendData,
    dataType: "json",
    url: newsSendurl+'&page='+page+'&pageSize='+pageSize,
    success: function (data, textStatus) {
        if (data.status == 1) {
            AjaxPageEach(data);
            $("#loadHint").html('')
            page += 1;
           self.ajaxPage();
        }
        else {
            //$("#loadHint").html('')
            return false;
        }


    },
    error: function (XMLHttpRequest, textStatus, errorThrown) {
        $("#loadHint").html('')

    }
    });
        return
    },
    ajaxPage2: function () {//浏览到底部加载
       
        var self = this;
        if (isLoad) {
            isLoad = false;//防止卡顿出现乱加载
            $("#loadHint").html('正在加载。。。')
            $.ajax({
                type: "Post",
                data: newsSendData,
                dataType: "json",
                url: newsSendurl + '&page=' + page + '&pageSize=' + pageSize,
                success: function (data, textStatus) {
                    if (data.status == 1) {
                        AjaxPageEach(data);
                       // $("#loadHint").html('')
                        page += 1;
                        isLoad = true;
                   
                    }
                    else {
                        isLoad = false;
                        // $("#loadHint").html('')
                        return false;
                    }


                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $("#loadHint").html('')

                }
            });
        }
        return
    }

}
    window.NewsAjaxPage = NewsAjaxPage;
})(window);



