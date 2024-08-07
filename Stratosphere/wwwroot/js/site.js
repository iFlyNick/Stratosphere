$(document).ready(function () {
    $('#darkModeToggle').on('click', function () {
        toggleDarkModeTheme();
    });

    $('#createModal').on('hidden.bs.modal', function () {
        $(this).find('form').trigger('reset');
    });
});

function toggleDarkModeTheme() {
    var currentTheme = $('body').attr('data-theme');
    var newTheme = (currentTheme === 'dark' || currentTheme === undefined || currentTheme === null) ? 'light' : 'dark';

    //update theme and local storage
    $('body').attr('data-theme', newTheme);
    $('body').attr('data-bs-theme', newTheme);
    setLocalStorageKeyValue('theme', newTheme);

    //update icon
    setDarkModeIcon(newTheme);
}

function setDarkModeIcon(theme) {
    var darkModeIcon = 'bi-moon-stars-fill';
    var lightModeIcon = 'bi-brightness-high-fill';

    $('#darkModeToggle > span > i').removeClass(`${darkModeIcon} ${lightModeIcon}`).addClass(theme === 'dark' ? darkModeIcon : lightModeIcon);
}

function setLocalStorageKeyValue(key, val) {
    localStorage.setItem(key, val);
}