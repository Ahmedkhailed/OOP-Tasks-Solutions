# OOP Task 10: E-Commerce Order Management System (Advanced)

## Objective
Build an advanced E-Commerce Order Management System to practice complex OOP concepts including interfaces, abstract classes, design patterns, SOLID principles, generics, and advanced polymorphism.

**Note:** This task can be completed in any OOP language (Java, C#, PHP, C++, Python, etc.). Adapt the syntax and data structures to your chosen language. This is an advanced task that combines many OOP concepts.

**Code Examples:** Interface and class definitions below use C#-like syntax for illustration. Adapt them to your language's interface/abstract class syntax, naming conventions, and type systems.

## Task Description
Create a comprehensive e-commerce system that manages products, customers, orders, payments, and shipping. The system should demonstrate:
- Multiple inheritance through interfaces
- Abstract base classes and inheritance hierarchies
- Strategy pattern for payment and shipping
- Observer pattern for order notifications
- Factory pattern for object creation
- Generic collections and LINQ operations
- Exception handling and custom exceptions
- Enum types and their usage

## Requirements

### 1. Core Interfaces

#### IProduct Interface
```
interface IProduct
{
    productId: string (read-only)
    name: string (read-only)
    price: decimal/float (read-only)
    stockQuantity: integer (read/write)
    getProductDetails(): string
    isInStock(): boolean
}
```

#### IPaymentMethod Interface (Strategy Pattern)
```
interface IPaymentMethod
{
    paymentType: string (read-only)
    processPayment(amount): boolean
    getPaymentDetails(): string
}
```

#### IShippingMethod Interface (Strategy Pattern)
```
interface IShippingMethod
{
    shippingType: string (read-only)
    calculateShippingCost(weight, destination): decimal/float
    getEstimatedDeliveryDays(): integer
}
```

#### IOrderObserver Interface (Observer Pattern)
```
interface IOrderObserver
{
    onOrderStatusChanged(order, newStatus): void
}
```

### 2. Enums

Define the following enumerations (or use constants/classes based on your language):

```
enum OrderStatus {
    Pending,
    Processing,
    Shipped,
    Delivered,
    Cancelled,
    Refunded
}

enum ProductCategory {
    Electronics,
    Clothing,
    Books,
    Home,
    Sports,
    Food
}

enum CustomerTier {
    Bronze,
    Silver,
    Gold,
    Platinum
}
```

### 3. Abstract Product Class

Create an abstract `Product` class that implements `IProduct`:
- **Properties/Attributes:**
  - `productId`, `name`, `price`, `stockQuantity`
  - `category` (ProductCategory enum)
  - `weight` (decimal/float): Product weight in kg
  - `description` (string)

- **Abstract Methods:**
  - `abstract calculateDiscount()`: Calculate product-specific discount

- **Virtual/Regular Methods:**
  - `virtual getProductDetails()`: Returns formatted product information

### 4. Concrete Product Classes

#### ElectronicProduct (inherits from Product)
- **Additional Properties:**
  - `warrantyMonths` (integer)
  - `brand` (string)
- **Override:**
  - `calculateDiscount()`: 10% discount if warranty > 12 months

#### ClothingProduct (inherits from Product)
- **Additional Properties:**
  - `size` (string)
  - `material` (string)
- **Override:**
  - `calculateDiscount()`: 15% discount for seasonal items

#### BookProduct (inherits from Product)
- **Additional Properties:**
  - `author` (string)
  - `isbn` (string)
  - `pageCount` (integer)
- **Override:**
  - `calculateDiscount()`: 5% discount if page count > 300

### 5. Payment Method Classes (Strategy Pattern)

Implement multiple payment methods that implement `IPaymentMethod`:

#### CreditCardPayment
- Properties: `cardNumber`, `cardHolder`, `expiryDate`, `cvv`
- Process payment with validation

#### PayPalPayment
- Properties: `email`, `accountId`
- Process payment with PayPal-specific logic

#### CryptocurrencyPayment
- Properties: `walletAddress`, `currency`
- Process payment with crypto-specific logic
- Process payment with crypto-specific logic

### 6. Shipping Method Classes (Strategy Pattern)

Implement shipping methods that implement `IShippingMethod`:

#### StandardShipping
- Flat rate based on weight
- 5-7 business days

#### ExpressShipping
- Higher rate, faster delivery
- 2-3 business days

#### OvernightShipping
- Premium rate
- 1 business day

### 7. Customer Class

Create a `Customer` class:
- **Properties/Attributes:**
  - `customerId` (string)
  - `name`, `email`, `phone` (string)
  - `shippingAddress` (string)
  - `tier` (CustomerTier enum)
  - `orderHistory` (List/Array of Order objects)
  - `loyaltyPoints` (integer)

- **Methods:**
  - `getDiscountRate()`: Returns discount based on tier
  - `addLoyaltyPoints(points)`: Add points
  - `redeemLoyaltyPoints(points)`: Redeem points for discount
  - `upgradeTier()`: Upgrade customer tier based on purchase history

### 8. OrderItem Class

Create an `OrderItem` class:
- **Properties/Attributes:**
  - `product` (IProduct interface)
  - `quantity` (integer)
  - `priceAtPurchase` (decimal/float)

- **Methods:**
  - `getSubtotal()`: Returns quantity * price
  - `getItemDetails()`: Returns formatted item information

### 9. Order Class (Subject in Observer Pattern)

Create an `Order` class:
- **Properties/Attributes:**
  - `orderId` (string)
  - `customer` (Customer)
  - `orderItems` (List/Array of OrderItem objects)
  - `orderDate` (Date/DateTime)
  - `status` (OrderStatus enum)
  - `paymentMethod` (IPaymentMethod interface)
  - `shippingMethod` (IShippingMethod interface)
  - `observers` (List/Array of IOrderObserver objects)

- **Methods:**
  - `addItem(product, quantity)`: Add product to order
  - `removeItem(productId)`: Remove product from order
  - `getSubtotal()`: Sum of all items
  - `getShippingCost()`: Calculate shipping using strategy
  - `getTax()`: Calculate tax (e.g., 10% of subtotal)
  - `getTotal()`: Subtotal + shipping + tax - discounts
  - `processOrder()`: Validate and process the order
  - `updateStatus(newStatus)`: Update and notify observers
  - `attachObserver(observer)`: Add observer
  - `detachObserver(observer)`: Remove observer
  - `notifyObservers()`: Notify all observers of status change

### 10. Notification Classes (Observer Pattern)

Implement observer classes:

#### EmailNotification (implements IOrderObserver)
- Sends email notifications on status change

#### SMSNotification (implements IOrderObserver)
- Sends SMS notifications on status change

#### PushNotification (implements IOrderObserver)
- Sends push notifications on status change

### 11. ProductFactory Class (Factory Pattern)

Create a `ProductFactory` class:
- **Static Methods:**
  - `createElectronicProduct(...)`: Creates electronic product
  - `createClothingProduct(...)`: Creates clothing product
  - `createBookProduct(...)`: Creates book product
  - `createProductFromCategory(category, ...)`: Factory method based on category

### 12. OrderManager Class

Create an `OrderManager` class:
- **Properties/Attributes:**
  - `orders` (List/Array of Order objects)
  - `products` (Map/Dictionary with string keys and IProduct values)
  - `customers` (Map/Dictionary with string keys and Customer values)

- **Methods:**
  - `registerCustomer(customer)`: Add customer
  - `addProduct(product)`: Add product to inventory
  - `createOrder(customer)`: Create new order
  - `getOrdersByCustomer(customerId)`: Get customer's orders
  - `getOrdersByStatus(status)`: Get filtered orders
  - `getTopSellingProducts(count)`: Returns top products (use queries/filters)
  - `getCustomersByTier(tier)`: Get filtered customers
  - `calculateTotalRevenue()`: Sum of all completed orders
  - `getLowStockProducts(threshold)`: Products below threshold

### 13. Custom Exceptions

Create custom exception classes (extend your language's base Exception class):
- `InsufficientStockException`
- `InvalidPaymentException`
- `OrderNotFoundException`
- `InvalidOrderStateException`

## Example Usage (Pseudocode)

```
// Initialize the system
manager = new OrderManager()

// Create products using factory
laptop = ProductFactory.createElectronicProduct(
    "E001", "Gaming Laptop", 1299.99, 10, 24, "TechBrand"
)
shirt = ProductFactory.createClothingProduct(
    "C001", "Cotton T-Shirt", 29.99, 50, "M", "Cotton"
)
book = ProductFactory.createBookProduct(
    "B001", "Design Patterns", 49.99, 20, "Gang of Four", "123-456", 395
)

// Add products to inventory
manager.addProduct(laptop)
manager.addProduct(shirt)
manager.addProduct(book)

// Create customer
customer = new Customer(
    "CUST001", "Alice Johnson", "alice@email.com",
    "555-0123", "123 Main St", CustomerTier.Gold
)
manager.registerCustomer(customer)

// Create order
order = manager.createOrder(customer)

// Attach observers
order.attachObserver(new EmailNotification("alice@email.com"))
order.attachObserver(new SMSNotification("555-0123"))
order.attachObserver(new PushNotification())

// Add items to order
order.addItem(laptop, 1)
order.addItem(shirt, 2)

// Set payment and shipping methods
order.paymentMethod = new CreditCardPayment(
    "4111-1111-1111-1111", "Alice Johnson", "12/26", "123"
)
order.shippingMethod = new ExpressShipping()

// Display order summary
print("Subtotal: $" + order.getSubtotal())
print("Shipping: $" + order.getShippingCost())
print("Tax: $" + order.getTax())
print("Total: $" + order.getTotal())

// Process order
try {
    order.processOrder()
    print("Order processed successfully!")
}
catch (InsufficientStockException ex) {
    print("Error: " + ex.message)
}
catch (InvalidPaymentException ex) {
    print("Error: " + ex.message)
}

// Update order status (triggers notifications)
order.updateStatus(OrderStatus.Shipped)
order.updateStatus(OrderStatus.Delivered)

// Get analytics
topProducts = manager.getTopSellingProducts(5)
totalRevenue = manager.calculateTotalRevenue()
lowStock = manager.getLowStockProducts(10)

print("Total Revenue: $" + totalRevenue)
print("Low Stock Products: " + lowStock.length)

// Customer loyalty
customer.addLoyaltyPoints(100)
if (customer.loyaltyPoints >= 500) {
    customer.upgradeTier()
}
```

## Expected Output Example

```
Order Summary:
--------------
Customer: Alice Johnson (Gold Tier - 10% discount)
Order ID: ORD-20251206-001

Items:
1. Gaming Laptop x1 @ $1299.99 = $1299.99
2. Cotton T-Shirt x2 @ $29.99 = $59.98

Subtotal: $1359.97
Customer Discount (10%): -$136.00
Shipping (Express): $25.00
Tax (10%): $124.90
--------------
Total: $1373.87

Payment Method: Credit Card (****1111)
Shipping Method: Express (2-3 business days)

Order processed successfully!

[Email Notification] Order ORD-20251206-001 status changed to: Shipped
[SMS Notification] Your order has been shipped!
[Push Notification] Order update: Shipped

[Email Notification] Order ORD-20251206-001 status changed to: Delivered
[SMS Notification] Your order has been delivered!
[Push Notification] Order update: Delivered

=== Analytics ===
Total Revenue: $45,289.50
Low Stock Products: 3
Top Selling Products:
1. Gaming Laptop (45 sold)
2. Cotton T-Shirt (120 sold)
3. Design Patterns (38 sold)
```

## Bonus Challenges (Optional)
1. Implement a shopping cart system with save/restore functionality
2. Add product reviews and ratings system
3. Implement a promotion/coupon system with validation
4. Add inventory management with automatic reorder points
5. Implement a refund/return system with different policies
6. Create a recommendation engine based on purchase history
7. Add user authentication and authorization
8. Implement order tracking with multiple checkpoints
9. Add support for bundle products (composite pattern)
10. Implement async/await for payment processing
11. Add unit tests for critical business logic
12. Implement data persistence (save to file/database)

## SOLID Principles Applied
- **Single Responsibility**: Each class has one clear purpose
- **Open/Closed**: Use interfaces and abstract classes for extension
- **Liskov Substitution**: Derived classes can replace base classes
- **Interface Segregation**: Multiple specific interfaces instead of one large interface
- **Dependency Inversion**: Depend on abstractions (interfaces) not implementations

## Design Patterns Used
- **Strategy Pattern**: Payment and shipping methods
- **Observer Pattern**: Order status notifications
- **Factory Pattern**: Product creation
- **Template Method**: Order processing workflow

## Learning Goals
- Master interfaces and abstract classes
- Understand and implement design patterns
- Work with generics and query operations
- Apply SOLID principles in practice
- Handle complex object relationships
- Implement proper exception handling
- Use enums effectively
- Manage state transitions
- Build scalable, maintainable systems

## Getting Started
1. Create a new project in your chosen language
2. Implement interfaces first
3. Build abstract classes and enums
4. Implement concrete classes
5. Create the manager class
6. Test with the example usage
7. Add bonus features

This is an advanced task that will take several hours to complete. Break it down into smaller parts and test each component thoroughly.

Create a file for your implementation (e.g., `ECommerceSystem.java`, `ecommerce.php`, `ECommerceSystem.cs`, `ecommerce_system.py`, etc.).
