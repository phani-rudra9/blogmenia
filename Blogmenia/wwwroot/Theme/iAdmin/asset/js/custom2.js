$(document).ready(function(){

    $(".sidebar-toggle").on("click", function() {
        $(".sidebar").toggleClass("toggled").one("transitionend", function() {
            setTimeout(function() {
                window.dispatchEvent(new Event("resize"))
            }, 100)
        })
    });
    var e = $(".sidebar .active");
    if (e.length && e.parent(".collapse").length) {
        var l = e.parent(".collapse");
        l.prev("a").attr("aria-expanded", !0), l.addClass("show")
    }
    
  /*  $("#txtPostTitle").on('input',function(){
        var strTitle=$(this).val();
         strTitle=strTitle.replace(/\s+/g, '-').toLowerCase();
         $("#txtPermalink").val(strTitle);
    });
    */
  
   /*  $('#summernote').summernote({
        height:250

     });
    */
});


