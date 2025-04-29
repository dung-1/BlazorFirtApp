window.setupCarousel = function (id, dotNetHelper) {
    const carousel = document.getElementById('carousel-' + id);

    if (carousel) {
        carousel.addEventListener('mouseenter', function () {
            dotNetHelper.invokeMethodAsync('PauseAutoPlay');
        });

        carousel.addEventListener('mouseleave', function () {
            dotNetHelper.invokeMethodAsync('ResumeAutoPlay');
        });
    }
};
