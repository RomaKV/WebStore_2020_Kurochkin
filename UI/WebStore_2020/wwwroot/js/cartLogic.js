Cart = {
    _properties: {
        addToCartLink: '',
        getCartViewLink: ''
    },

    init: function(properties) {
        $.extend(Cart._properties, properties);

        $('a.callAddToCart').on('click', Cart.addToCart);
        $('a.cart_quantity_delete').on('click', Cart.removeFromCart);
        $('a.cart_quantity_up').on('click', Cart.incrementItem);
        $('a.cart_quantity_down').on('click', Cart.decrementItem);
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
    },

    removeFromCart: function(event) {
        var button = $(this);
        event.preventDefault();
        var id = button.data('id');
        $.get(Cart._properties.removeFromCartLink + '/' + id)
            .done(function() {
                button.closest('tr').remove();
                Cart.refreshCartView();
            })
            .fail(function() {
                    console.log('removeFromCart error');

                }
            );
    },

    refreshPrice: function(container) {
        var quantity = parseInt($('cart_quantity_input', container).val());
        var price = parseFloat($('cart_price', container).data('rice'));
        var totalPrice = quantity * price;
        var value = totalPrice.toLocaleString('en-US', { style: 'currency', currency: 'USD' });

        $('.cart_total_price', container).data('price', totalPrice);
        $('.cart_total_price', container).html(value);
    },

    incrementItem: function(event) {
        var button = $(this);
        var container = button.closest('tr');
        event.preventDefault();
        var id = button.data('id');

        $.get(Cart._properties.addToCartLink + '/' + id).done(function() {
            var value = parseInt($('.cart_quantity_input', container).val());
            $('.cart_quantity_input', container).val(value + 1);
            Cart.refreshCartView();
        }).fail(function() { console.log('incrementItem error'); });
    },
    decrementItem: function (event) {
        var button = $(this);
        var container = button.closest('tr');
        event.preventDefault();
        var id = button.data('id');

        $.get(Cart._properties.decrementFromCartLink + '/' + id).done(function () {
            var value = parseInt($('.cart_quantity_input', container).val());
            value = value - 1;
            if (value > 0) {
                $('.cart_quantity_input', container).val(value);
            } else {
                $.get(Cart._properties.removeFromCartLink + '/' + id)
                    .done(function () {
                        button.closest('tr').remove();
                        Cart.refreshCartView();
                    })
                    .fail(function () {
                            console.log('removeFromCart error');

                        }
                    );
            }

            Cart.refreshCartView();
        }).fail(function () { console.log('incrementItem error'); });
    }




}