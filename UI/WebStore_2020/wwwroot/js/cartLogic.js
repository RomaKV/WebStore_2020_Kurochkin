﻿Cart = {
    _properties: {
        addToCartLink: '',
        getCartViewLink: ''
    },

    init: function(properties) {
        $.extend(Cart._properties, properties);

        $('a.callAddToCart').on('click', Cart.addToCart);
    },

    addToCart: function(event) {
        var button = $(this);
        event.preventDefault();
        var id = button.data('id');
        $.get(Cart._properties.addToCartLink + '/' + id).done(function() {
            Cart.showToolTip(button);
            Cart.refreshCartView();
        }).fail(function() { console.log('addToCart error'); });
    },

    refreshCartView() {
        var container = $('#cartContainer');

        $.get(Cart._properties.getCartViewLink).done(function(result) {
            container.html(result);
        }).fail(function() { console.log('refreshCartView error'); });
    },

    showToolTip: function(button) {
        button.tooltip({
            title: 'Добавлено в корзину'
        }).tooltip('show');

        setTimeout(function() {
                button.tooltip('destroy');
            },
            500);
    }
}