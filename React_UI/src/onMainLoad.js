import $ from 'jquery';

export default function LoadPage()  {
    let mainbottom = $('#root').offset().top;

    // Снижает нагрузку
    $(window).on('scroll', () => {
        let stop = Math.round($(window).scrollTop());
        if (stop > mainbottom) {
            $('.navbar').addClass('past-main');
            $('.navbar').addClass('effect-main')
        } else {
            $('.navbar').removeClass('past-main');
        }
    });

    // При перезагрузке страницы свернуть navbar
    $(document).on('click.nav','.navbar-collapse.in', (e) => {
        if( $(e.target).is('a') ) {
            $(this).removeClass('in').addClass('collapse');
        }
    });

     // Плавная прокрутка
    (function someFunc() {
        $('a.js-scroll-trigger[href*="#"]:not([href="#"])').on('click', () => {
            if (document.location.pathname.replace(/^\//, '') === this.pathname.replace(/^\//, '')
                && document.location.hostname === this.hostname)
            {
                var target = $(this.hash);
                target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
                if (target.length) {
                    $('html, body').animate(
                                        { scrollTop: (target.offset().top - 54) },
                                        1000,
                                        "easeInOutExpo");
                    return false;
                }
            }
        }
    );

    // Закрытие navbar при нажатии на кнопку
    $('.js-scroll-trigger').on('click', function() {
      $(".navbar-collapse").removeClass("show");
    });
  })();
};