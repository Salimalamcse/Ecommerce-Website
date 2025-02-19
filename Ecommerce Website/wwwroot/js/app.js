window.addEventListener("click", function (e) {
  const responsiveHeader = document.querySelector(".header-responsive");
  const sidebar = document.querySelector(".header-content");
  if (e.target.classList.contains("bx-menu")) {
    responsiveHeader.classList.add("show");
    sidebar.classList.add("toRight");
  } else if (
    e.target.classList.contains("close-sidebar") ||
    e.target.classList.contains("header-responsive")
  ) {
    responsiveHeader.classList.remove("show");
    sidebar.classList.remove("toRight");
  }

  const searchArea = document.querySelector(".search-area");
  if (e.target.classList.contains("bx-search")) {
    searchArea.classList.add("show");
  } else if (e.target.classList.contains("close-search")) {
    searchArea.classList.remove("show");
  }
});

const collectionBtn = document.querySelector(".collection-open");
const collectionMenu = document.querySelector(".collection-sub-menu");
const pagesBtn = document.querySelector(".pages-open");
const pagesMenu = document.querySelector(".pages-sub-menu");

collectionBtn.addEventListener("click", function () {
  pagesMenu.classList.remove("active");
  pagesBtn.classList.remove("active");
  collectionMenu.classList.toggle("active");
  this.classList.toggle("active");
});

pagesBtn.addEventListener("click", function () {
  collectionMenu.classList.remove("active");
  collectionBtn.classList.remove("active");
  pagesMenu.classList.toggle("active");
  this.classList.toggle("active");
});

const accessoriesBtn = document.querySelector(".accessories-open");
const accessoriesMenu = document.querySelector(".accessories-sub-menu");
const fabricBtn = document.querySelector(".fabric-open");
const fabricMenu = document.querySelector(".fabric-sub-menu");
const arrivalsBtn = document.querySelector(".arrivals-open");
const arrivalsMenu = document.querySelector(".arrivals-sub-menu");

accessoriesBtn.addEventListener("click", function () {
  fabricMenu.classList.remove("active");
  fabricBtn.classList.remove("active");
  arrivalsMenu.classList.remove("active");
  arrivalsBtn.classList.remove("active");
  accessoriesMenu.classList.toggle("active");
  this.classList.toggle("active");
});

fabricBtn.addEventListener("click", function () {
  accessoriesMenu.classList.remove("active");
  accessoriesBtn.classList.remove("active");
  arrivalsMenu.classList.remove("active");
  arrivalsBtn.classList.remove("active");
  fabricMenu.classList.toggle("active");
  this.classList.toggle("active");
});

arrivalsBtn.addEventListener("click", function () {
  accessoriesMenu.classList.remove("active");
  accessoriesBtn.classList.remove("active");
  fabricMenu.classList.remove("active");
  fabricBtn.classList.remove("active");
  arrivalsMenu.classList.toggle("active");
  this.classList.toggle("active");
});

// INTRO section slider
const swiper = new Swiper(".intro__slider", {
  spaceBetween: 30,
  effect: "fade",
  loop: true,
  navigation: {
    nextEl: ".swiper-button-next",
    prevEl: ".swiper-button-prev",
  },
  pagination: {
    el: ".swiper-pagination",
    clickable: true,
  },
});

// DAILY PRODUCT slider
const swiper2 = new Swiper(".dailySwiper", {
  slidesPerView: 1,
  spaceBetween: 10,
  navigation: {
    nextEl: ".swiper-button-next",
    prevEl: ".swiper-button-prev",
  },
  breakpoints: {
    640: {
      slidesPerView: 2,
      spaceBetween: 10,
    },
    768: {
      slidesPerView: 3,
      spaceBetween: 15,
    },
    1024: {
      slidesPerView: 5,
      spaceBetween: 20,
    },
  },
});

// CATEGORY slider
const swiper3 = new Swiper(".categorySwiper", {
  slidesPerView: 1,
  spaceBetween: 10,
  loop: true,
  breakpoints: {
    640: {
      slidesPerView: 2,
      spaceBetween: 10,
    },
    768: {
      slidesPerView: 3,
      spaceBetween: 15,
    },
    1024: {
      slidesPerView: 4,
      spaceBetween: 20,
    },
    1280: {
      slidesPerView: 6,
      spaceBetween: 20,
    },
  },
});

// COMMENTS slider
const swiper4 = new Swiper(".commentSwiper", {
  slidesPerView: 1,
  spaceBetween: 10,
  pagination: {
    el: ".commentSwiper .swiper-pagination",
  },
  loop: true,
  breakpoints: {
    640: {
      slidesPerView: 2,
      spaceBetween: 15,
    },
    1024: {
      slidesPerView: 3,
      spaceBetween: 30,
    },
  },
});
