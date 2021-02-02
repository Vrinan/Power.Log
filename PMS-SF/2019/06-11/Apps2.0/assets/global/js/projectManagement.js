/**
 * Created by DELL on 2017-4-27.
 */

(function () {
    var projectManagement = {
        init: function () {
            this.events();
        },


        events: function () {
            $( '#example1' ).sliderPro({
                width: 960,
                height: 500,
                arrows: false,
                buttons: false,
                waitForLayers: true,
                thumbnailWidth: 200,
                thumbnailHeight: 100,
                thumbnailPointer: true,
                autoplay: true,
                autoScaleLayers: true,
                breakpoints: {
                    500: {
                        thumbnailWidth: 120,
                        thumbnailHeight: 50
                    }
                },

                gotoSlide: function( event ) {
                    var index =  event.index ;
                    $(".project-slider-bars .project-slider-bar")
                        .eq(index)
                        .addClass("activeSlider")
                        .siblings(".project-slider-bar")
                        .removeClass("activeSlider")
                }
            });

        }
    };

    $(function () {
        projectManagement.init();
    });

})();