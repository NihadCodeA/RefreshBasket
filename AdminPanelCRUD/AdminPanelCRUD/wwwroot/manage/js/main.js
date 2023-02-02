let deleteBtns = document.querySelectorAll(".deleteBtn");

deleteBtns.forEach(btn => btn.addEventListener("click", function () {
    btn.parentElement.remove();
}))

let sliderDeleteBtns = document.querySelectorAll(".sliderDeleteBtn");
let bookDeleteBtns = document.querySelectorAll(".bookDeleteBtn");

function deleteFunc(e, btn) {
    e.preventDefault();
    Swal.fire({
        title: 'Əminsiz?',
        text: "Silinən faylı geri qaytara bilmərsiz!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sil',
        cancelButtonText: 'Ləğv et'
    }).then((result) => {
        if (result.isConfirmed) {
            let url = btn.getAttribute("href");
            fetch(url)
                .then(res => {
                    if (res.status == 200) {
                        window.location.reload(true);
                    }
                    else {
                        Swal.fire(
                            'Xəbərdarlıq!',
                            'File silinə bilmədi',
                            'warning'
                        )
                    }
                })
        }
    })
}

sliderDeleteBtns.forEach(btn => btn.addEventListener("click", function (e) {
    deleteFunc(e, btn)
}))
bookDeleteBtns.forEach(btn => btn.addEventListener("click", function (e) {
    deleteFunc(e, btn)
}))

//AddToBasket

let addToBasketBtns = document.querySelectorAll(".add-to-basket-btn");

addToBasketBtns.forEach(btn => btn.addEventListener("click", function (e) {
    e.preventDefault();
    let url = btn.getAttribute("href");
    fetch('/book/getbasket')
        .then( (response)=>response.json())
        .then((data)=> {
            console.log(data);
        })
    fetch(url).then(res => {
        if (res.status == 200) {
            Toastify({
                text: "Kitab sebete elave olundu!",
                duration: 3000,
                newWindow: true,
                close: true,
                gravity: "top", // `top` or `bottom`
                position: "right", // `left`, `center` or `right`
                stopOnFocus: true, // Prevents dismissing of toast on hover
                style: {
                    background: "linear-gradient(to right, #00b09b, #96c93d)",
                },
            }).showToast();
        }
        else {
            Toastify({
                text: "Kitab sebete elave oluna bilmedi!",
                duration: 3000,
                newWindow: true,
                close: true,
                gravity: "top", // `top` or `bottom`
                position: "right", // `left`, `center` or `right`
                stopOnFocus: true, // Prevents dismissing of toast on hover
                style: {
                    background: "linear-gradient(to right, #ffafcc, #e76f51)",
                },
            }).showToast();
        }})
}))

