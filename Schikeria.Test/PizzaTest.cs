using Schikeria.Constants.Discounts;
using Schikeria.Model.Discounts;
using Schikeria.Model.Pizzas;
using Schikeria.Model.Toppings;

namespace Schikeria.Test
{
    public class PizzaTest
    {
        [Fact]
        public void Calculate_Price_WithoutDiscount()
        {
            // Arrange
            var pizza = new Pizza
            {
                Name = "Test",
                CurrentSize = Sizes.Large,
                Toppings = [
                    new Topping {Name = "T1", Price = 0.5m},
                    new Topping {Name = "T1", Price = 1m},
                    new Topping {Name = "T1", Price = 1.5m}
                    ]
            };

            pizza.Sizes.Add(Sizes.Small, 10);
            pizza.Sizes.Add(Sizes.Medium, 20);
            pizza.Sizes.Add(Sizes.Large, 30);

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(33, price);
            });
        }

        [Fact]
        public void Calculate_Price_WithDiscount()
        {
            // Arrange
            var pizza = new Pizza
            {
                Name = "Test",
                CurrentSize = Sizes.Large,
                Toppings = [
                    new Topping {Name = "T1", Price = 0.5m},
                    new Topping {Name = "T1", Price = 1m},
                    new Topping {Name = "T1", Price = 1.5m}
                    ]
            };

            pizza.Sizes.Add(Sizes.Small, 10);
            pizza.Sizes.Add(Sizes.Medium, 20);
            pizza.Sizes.Add(Sizes.Large, 30);

            pizza.CurrentDiscounts = [
                new Discount
                {
                    Name = "D1",
                    Value = 0.1m
                }];

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(29.70m, price);
            });
        }

        [Fact]
        public void Calculate_Price_WithDiscount_MinPriceIsLess()
        {
            // Arrange
            var pizza = new Pizza
            {
                Name = "Test",
                CurrentSize = Sizes.Large,
                Toppings = [
                    new Topping {Name = "T1", Price = 0.5m},
                    new Topping {Name = "T1", Price = 1m},
                    new Topping {Name = "T1", Price = 1.5m}
                    ]
            };

            pizza.Sizes.Add(Sizes.Small, 10);
            pizza.Sizes.Add(Sizes.Medium, 20);
            pizza.Sizes.Add(Sizes.Large, 30);

            pizza.CurrentDiscounts = [
                new PriceDiscount
                {
                    Name = "D1",
                    Value = 0.1m,
                    MinPrice = 30m
                }];

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(29.70m, price);
            });
        }

        [Fact]
        public void Calculate_Price_WithDiscount_MinPriceIsGrater()
        {
            // Arrange
            var pizza = new Pizza
            {
                Name = "Test",
                CurrentSize = Sizes.Large,
                Toppings = [
                    new Topping {Name = "T1", Price = 0.5m},
                    new Topping {Name = "T1", Price = 1m},
                    new Topping {Name = "T1", Price = 1.5m}
                    ]
            };

            pizza.Sizes.Add(Sizes.Small, 10);
            pizza.Sizes.Add(Sizes.Medium, 20);
            pizza.Sizes.Add(Sizes.Large, 30);

            pizza.CurrentDiscounts = [
                new PriceDiscount
                {
                    Name = "D1",
                    Value = 0.1m,
                    MinPrice = 35m
                }];

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(33, price);
            });
        }

        [Fact]
        public void Calculate_Price_WithDiscount_MinPriceIsEqual()
        {
            // Arrange
            var pizza = new Pizza
            {
                Name = "Test",
                CurrentSize = Sizes.Large,
                Toppings = [
                    new Topping {Name = "T1", Price = 0.5m},
                    new Topping {Name = "T1", Price = 1m},
                    new Topping {Name = "T1", Price = 1.5m}
                    ]
            };

            pizza.Sizes.Add(Sizes.Small, 10);
            pizza.Sizes.Add(Sizes.Medium, 20);
            pizza.Sizes.Add(Sizes.Large, 30);

            pizza.CurrentDiscounts = [
                new PriceDiscount
                {
                    Name = "D1",
                    Value = 0.1m,
                    MinPrice = 33m
                }];

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(29.70m, price);
            });
        }

        [Fact]
        public void Calculate_Price_GroupDiscout_CountIsLessThanGroupDiscountCount()
        {
            // Arrange
            var pizza = new Pizza
            {
                Name = "Test",
                CurrentSize = Sizes.Large,
                Toppings = [
                    new Topping {Name = "T1", Price = 0.5m},
                    new Topping {Name = "T1", Price = 1m},
                    new Topping {Name = "T1", Price = 1.5m}
                    ],
                Count = 2
            };

            pizza.Sizes.Add(Sizes.Small, 10);
            pizza.Sizes.Add(Sizes.Medium, 20);
            pizza.Sizes.Add(Sizes.Large, 30);

            pizza.CurrentDiscounts = [
                new GroupDiscount
                {
                    Name = "D1",
                    Value = 0.1m,
                    MinCount = 3
                }];

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(33, price);
            });
        }

        [Fact]
        public void Calculate_Price_GroupDiscout_CountIsEqualGroupDiscountCount()
        {
            // Arrange
            var pizza = new Pizza
            {
                Name = "Test",
                CurrentSize = Sizes.Large,
                Toppings = [
                    new Topping {Name = "T1", Price = 0.5m},
                    new Topping {Name = "T1", Price = 1m},
                    new Topping {Name = "T1", Price = 1.5m}
                    ],
                Count = 3
            };

            pizza.Sizes.Add(Sizes.Small, 10);
            pizza.Sizes.Add(Sizes.Medium, 20);
            pizza.Sizes.Add(Sizes.Large, 30);

            pizza.CurrentDiscounts = [
                new GroupDiscount
                {
                    Name = "D1",
                    Value = 0.1m,
                    MinCount = 3
                }];

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(29.70m, price);
            });
        }

        [Fact]
        public void Calculate_Price_GroupDiscout_CountIsGreaterThanGroupDiscountCount()
        {
            // Arrange
            var pizza = new Pizza
            {
                Name = "Test",
                CurrentSize = Sizes.Large,
                Toppings = [
                    new Topping {Name = "T1", Price = 0.5m},
                    new Topping {Name = "T1", Price = 1m},
                    new Topping {Name = "T1", Price = 1.5m}
                    ],
                Count = 5
            };

            pizza.Sizes.Add(Sizes.Small, 10);
            pizza.Sizes.Add(Sizes.Medium, 20);
            pizza.Sizes.Add(Sizes.Large, 30);

            pizza.CurrentDiscounts = [
                new GroupDiscount
                {
                    Name = "D1",
                    Value = 0.1m,
                    MinCount = 3
                }];

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(29.70m, price);
            });
        }

        [Theory]
        [InlineData(Names.VIP)]
        [InlineData(Names.Student)]
        public void Calculate_Price_WithNormalDiscount_Combination_Successfully(
            string secondDiscountName)
        {
            // Arrange
            var pizza = new Pizza
            {
                Name = "Test",
                CurrentSize = Sizes.Large,
                Toppings = [
                    new Topping {Name = "T1", Price = 0.5m},
                    new Topping {Name = "T1", Price = 1m},
                    new Topping {Name = "T1", Price = 1.5m}
                    ]
            };

            pizza.Sizes.Add(Sizes.Small, 10);
            pizza.Sizes.Add(Sizes.Medium, 20);
            pizza.Sizes.Add(Sizes.Large, 30);

            pizza.CurrentDiscounts = [
                new Discount
                {
                    Name = Names.Monday,
                    Value = 0.1m
                },
                new Discount
                {
                    Name = secondDiscountName,
                    Value = 0.15m
                }
            ];

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(24.75m, price);
            });
        }

        [Theory]
        [InlineData(0.15, 0.2)]
        [InlineData(0.2, 0.15)]
        public void Calculate_Price_WithMondayDiscount_AndOtherDiscountsCombination(
            decimal vipValue, decimal studentValue)
        {
            // Arrange
            var pizza = new Pizza
            {
                Name = "Test",
                CurrentSize = Sizes.Large,
                Toppings = [
                    new Topping {Name = "T1", Price = 0.5m},
                    new Topping {Name = "T1", Price = 1m},
                    new Topping {Name = "T1", Price = 1.5m}
                    ]
            };

            pizza.Sizes.Add(Sizes.Small, 10);
            pizza.Sizes.Add(Sizes.Medium, 20);
            pizza.Sizes.Add(Sizes.Large, 30);

            pizza.CurrentDiscounts = [
                new Discount
                {
                    Name = Names.Monday,
                    Value = 0.1m
                },
                new Discount
                {
                    Name = Names.VIP,
                    Value = vipValue
                },
                new Discount
                {
                    Name = Names.Student,
                    Value = studentValue
                }
            ];

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(23.1m, price);
            });
        }

        [Fact]
        public void Calculate_Price_WithNormalDiscounts_MaxDiscountValue()
        {
            // Arrange
            var pizza = new Pizza
            {
                Name = "Test",
                CurrentSize = Sizes.Large,
                Toppings = [
                    new Topping {Name = "T1", Price = 0.5m},
                    new Topping {Name = "T1", Price = 1m},
                    new Topping {Name = "T1", Price = 1.5m}
                    ]
            };

            pizza.Sizes.Add(Sizes.Small, 10);
            pizza.Sizes.Add(Sizes.Medium, 20);
            pizza.Sizes.Add(Sizes.Large, 30);

            pizza.CurrentDiscounts = [
                new Discount
                {
                    Name = Names.Monday,
                    Value = 0.1m
                },
                new Discount
                {
                    Name = "D1",
                    Value = 0.15m
                },
                new Discount
                {
                    Name = "D2",
                    Value = 0.2m
                }
            ];

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(26.4m, price);
            });
        }

        [Fact]
        public void Calculate_Price_GroupDiscout_Combination_Successfully()
        {
            // Arrange
            var pizza = new Pizza
            {
                Name = "Test",
                CurrentSize = Sizes.Large,
                Toppings = [
                    new Topping {Name = "T1", Price = 0.5m},
                    new Topping {Name = "T1", Price = 1m},
                    new Topping {Name = "T1", Price = 1.5m}
                    ],
                Count = 2
            };

            pizza.Sizes.Add(Sizes.Small, 10);
            pizza.Sizes.Add(Sizes.Medium, 20);
            pizza.Sizes.Add(Sizes.Large, 30);

            pizza.CurrentDiscounts = [
                new GroupDiscount
                {
                    Name = "D1",
                    Value = 0.1m,
                    MinCount = 3
                },
                new Discount
                {
                    Name = Names.VIP,
                    Value = 0.12m,
                }
            ];

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(25.74m, price);
            });
        }

        [Fact]
        public void Calculate_Price_DiffrentDiscouts_TakeMaxGroupDiscountValue()
        {
            // Arrange
            var pizza = new Pizza
            {
                Name = "Test",
                CurrentSize = Sizes.Large,
                Toppings = [
                    new Topping {Name = "T1", Price = 0.5m},
                    new Topping {Name = "T1", Price = 1m},
                    new Topping {Name = "T1", Price = 1.5m}
                    ],
                Count = 2
            };

            pizza.Sizes.Add(Sizes.Small, 10);
            pizza.Sizes.Add(Sizes.Medium, 20);
            pizza.Sizes.Add(Sizes.Large, 30);

            pizza.CurrentDiscounts = [            
                new Discount
                {
                    Name = "D1",
                    Value = 0.12m,
                },
                new GroupDiscount
                {
                    Name = "GD1",
                    Value = 0.2m,
                    MinCount = 3
                },
                new Discount
                {
                    Name = "D2",
                    Value = 0.25m,
                }
            ];

            // Act
            var price = pizza.Price;

            // Assert
            Assert.Multiple(() =>
            {
                Assert.Equal(26.4m, price);
            });
        }

        // 2. Niektóre rabaty można łączyć.

        //Przykładowo:

        //student + poniedziałek → można połączyć,
        //VIP +poniedziałek → można połączyć,

        //rabat grupowy + VIP → można.

        //rabat grupowy + inny niz vip → zawsze grupowy,

        //jesli wiele rabatow i kazda z powyzszych regul nie zachodzi, to tylko rabat grupowy
        //jesli wiele rabatow i kazda z powyzszych regul nie zachodzi, zaden grupowy, to najwyzszy rabat

        //Dochodzi też zasada:

        //maksymalny łączny rabat to 30%.
    }
}
