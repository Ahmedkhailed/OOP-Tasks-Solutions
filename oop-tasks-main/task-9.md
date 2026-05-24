# OOP Task 9: Inventory and Supply Chain System

## Objective
Build an Inventory and Supply Chain Management System to practice advanced OOP concepts including generics, delegates/events/observers, query operations, and design patterns.

**Note:** This task can be completed in any OOP language (Java, C#, PHP, C++, Python, etc.). Adapt the syntax and data structures to your chosen language. Generics, events/delegates, and LINQ concepts have equivalents in different languages (templates in C++, generics in Java, type hints in PHP 7+, callbacks/observers for events, streams/filters for queries).

**Code Examples:** The code examples below may use C#-like syntax for illustration. Adapt them to your language's syntax and conventions (generics, event handling, query operations, etc.).

## Task Description
Create a comprehensive supply chain system that manages products, warehouses, suppliers, orders, and shipping. The system should demonstrate:
- Generic classes and methods
- Event handling with delegates
- LINQ for complex queries
- Observer pattern for stock alerts
- Factory and Strategy patterns
- Working with complex business workflows

## Requirements

### 1. Product Class with Generics
Create a generic `Product<T>` class where T is the identifier type:
- **Properties/Attributes:**
  - `productId` (T): Generic product identifier
  - `name` (string)
  - `category` (string)
  - `description` (string)
  - `unitPrice` (decimal/float)
  - `weight` (double/float): In kg
  - `dimensions` (string): LxWxH
  - `sku` (string): Stock Keeping Unit
  - `supplier` (Supplier)

- **Methods:**
  - Constructor
  - `getProductInfo()`: Returns formatted information
  - `calculateShippingCost(distance)`: Calculates shipping based on weight

### 2. StockItem Class
Create a `StockItem` class to track inventory:
- **Properties/Attributes:**
  - `product` (Product): The product being tracked
  - `quantity` (integer): Current stock quantity
  - `reorderLevel` (integer): Minimum quantity before reorder
  - `reorderQuantity` (integer): How much to order when restocking
  - `location` (string): Warehouse location code
  - `lastRestockDate` (Date/DateTime): Last restock timestamp

- **Events/Observers:**
  - Stock level low event: Triggered when stock is low
  - Stock depleted event: Triggered when out of stock

- **Methods:**
  - Constructor
  - `addStock(quantity)`: Increases stock
  - `removeStock(quantity)`: Decreases stock and triggers events if needed
  - `isLowStock()`: Checks if below reorder level
  - `getStockValue()`: Returns total value (quantity * unit price)

### 3. StockAlertEventArgs Class
Create a `StockAlertEventArgs` class for event data:
- **Properties/Attributes:**
  - `product` (Product): The product with stock alert
  - `currentQuantity` (integer): Current stock quantity
  - `reorderLevel` (integer): Reorder threshold
  - `alertTime` (Date/DateTime): When alert was triggered

### 4. Supplier Class
Create a `Supplier` class:
- **Properties/Attributes:**
  - `supplierId` (string)
  - `companyName` (string)
  - `contactPerson` (string)
  - `email` (string)
  - `phone` (string)
  - `address` (string)
  - `rating` (double/float): 0-5 scale
  - `productsCatalog` (List/Array of Product objects)

- **Methods:**
  - Constructor
  - `addProductToCatalog(product)`: Adds product
  - `getSupplierInfo()`: Returns formatted information
  - `canSupply(product)`: Checks if product available

### 5. Warehouse Class
Create a `Warehouse` class:
- **Properties/Attributes:**
  - `warehouseId` (string)
  - `name` (string)
  - `location` (string)
  - `capacity` (integer): Maximum items
  - `stockItems` (Map/Dictionary by product SKU): Stock items indexed by SKU
  - `manager` (string)

- **Methods:**
  - Constructor
  - `addProduct(product, quantity, reorderLevel)`: Adds new product to inventory
  - `updateStock(sku, quantityChange)`: Updates stock level
  - `getStockItem(sku)`: Returns stock item
  - `getTotalInventoryValue()`: Sum of all stock values
  - `getLowStockItems()`: Returns items below reorder level (use queries/filters)
  - `searchProducts(keyword)`: Search products (use queries/filters)
  - `getProductsByCategory(category)`: Filter by category (use queries/filters)
  - `getTopValueProducts(count)`: Returns highest value items (use queries/filters)

### 6. PurchaseOrder Class
Create a `PurchaseOrder` class:
- **Properties/Attributes:**
  - `orderId` (string)
  - `supplier` (Supplier)
  - `orderDate` (Date/DateTime)
  - `expectedDeliveryDate` (Date/DateTime)
  - `orderItems` (List/Array of OrderItem objects)
  - `status` (string): "Pending", "Approved", "Shipped", "Delivered", "Cancelled"
  - `totalCost` (decimal/float)

- **Methods:**
  - Constructor
  - `addItem(product, quantity)`: Adds item to order
  - `calculateTotal()`: Calculates total order cost
  - `approveOrder()`: Changes status to approved
  - `completeOrder()`: Marks as delivered and updates warehouse stock
  - `getOrderSummary()`: Returns formatted order information

### 7. OrderItem Class
### 7. OrderItem Class
Create an `OrderItem` class:
- **Properties/Attributes:**
  - `product` (Product): The product ordered
  - `quantity` (integer): Quantity ordered
  - `pricePerUnit` (decimal/float): Price per unit at time of order

- **Methods:**
  - `getTotal()`: Returns quantity * pricePerUnit

### 8. IShippingStrategy Interface (Strategy Pattern)
Create an interface for shipping strategies with:
- **Methods:**
  - `calculateCost(weight, distance)`: Returns shipping cost
  - `getEstimatedDays(distance)`: Returns estimated delivery days
  - `getShippingMethod()`: Returns shipping method name

### 9. Shipping Strategy Classes
Implement multiple shipping strategies:

#### StandardShipping
- Lower cost, longer delivery
- Cost calculation based on weight and distance

#### ExpressShipping
- Higher cost, faster delivery
- Premium pricing

#### FreightShipping
- For heavy items
- Special calculation for bulk orders

### 10. Shipment Class
Create a `Shipment` class:
- **Properties/Attributes:**
  - `shipmentId` (string)
  - `order` (PurchaseOrder)
  - `shippingStrategy` (IShippingStrategy/ShippingStrategy interface)
  - `origin` (string)
  - `destination` (string)
  - `distance` (double/float)
  - `shipDate` (Date/DateTime)
  - `estimatedDelivery` (Date/DateTime)
  - `actualDelivery` (Date/DateTime, nullable)
  - `trackingNumber` (string)

- **Methods:**
  - Constructor
  - `calculateShippingCost()`: Uses strategy pattern
  - `getEstimatedDeliveryDate()`: Calculates based on strategy
  - `markAsDelivered()`: Updates delivery date
  - `getShipmentInfo()`: Returns formatted information

### 11. SupplyChainManager Class
Create a main management class:
- **Properties/Attributes:**
  - `warehouses` (List/Array of Warehouse objects)
  - `suppliers` (List/Array of Supplier objects)
  - `purchaseOrders` (List/Array of PurchaseOrder objects)
  - `shipments` (List/Array of Shipment objects)

- **Methods:**
  - Constructor
  - `registerWarehouse(warehouse)`: Adds warehouse
  - `registerSupplier(supplier)`: Adds supplier
  - `createPurchaseOrder(supplier, warehouse)`: Creates new order
  - `processShipment(order, strategy)`: Creates shipment
  - `getInventoryReport()`: Comprehensive inventory status
  - `getSupplierPerformance()`: Analytics on suppliers (use queries/filters)
  - `getLowStockAlert()`: All low stock items across warehouses (use queries/filters)
  - `calculateTotalInventoryValue()`: Total value across all warehouses
  - `getOrderHistory(startDate, endDate)`: Historical orders (use queries/filters)
  - `findOptimalSupplier(product)`: Best supplier based on rating and price
  - `forecastDemand(sku, days)`: Simple demand forecasting

## Example Usage (Pseudocode)

```
// Initialize system
scm = new SupplyChainManager()

// Create suppliers
supplier1 = new Supplier("SUP001", "Tech Supplies Inc", "John Doe",
                         "john@techsupplies.com", "555-0100", "123 Supply St")
supplier1.rating = 4.5

supplier2 = new Supplier("SUP002", "Global Parts Co", "Jane Smith",
                         "jane@globalparts.com", "555-0200", "456 Parts Ave")
supplier2.rating = 4.2

scm.registerSupplier(supplier1)
scm.registerSupplier(supplier2)

// Create products (using generic type parameter for ID)
laptop = new Product("PROD001", "Business Laptop",
                     "Electronics", 999.99, supplier1)
laptop.sku = "LAPTOP-001"
laptop.weight = 2.5

mouse = new Product("PROD002", "Wireless Mouse",
                    "Electronics", 29.99, supplier1)
mouse.sku = "MOUSE-001"
mouse.weight = 0.2

// Create warehouse
mainWarehouse = new Warehouse("WH001", "Main Distribution Center",
                              "New York", 10000)
mainWarehouse.manager = "Alice Johnson"

scm.registerWarehouse(mainWarehouse)

// Add products to warehouse
mainWarehouse.addProduct(laptop, 50, 10)
mainWarehouse.addProduct(mouse, 200, 50)

// Set up stock alert observers/listeners
laptopStock = mainWarehouse.getStockItem("LAPTOP-001")

// Register callback/observer for low stock alert
laptopStock.onStockLevelLow(function(eventData) {
    print("⚠️ LOW STOCK ALERT:")
    print("Product: " + eventData.product.name)
    print("Current: " + eventData.currentQuantity + ", Reorder Level: " + eventData.reorderLevel)
    print("Alert Time: " + eventData.alertTime)
})

// Register callback/observer for stock depleted
laptopStock.onStockDepleted(function(eventData) {
    print("🚨 STOCK DEPLETED:")
    print("Product: " + eventData.product.name + " is OUT OF STOCK!")
})

// Simulate sales (removing stock)
print("Processing sales...")
mainWarehouse.updateStock("LAPTOP-001", -45)  // Triggers low stock alert

// Create purchase order to restock
order = scm.createPurchaseOrder(supplier1, mainWarehouse)
order.addItem(laptop, 50)
order.addItem(mouse, 100)
order.expectedDeliveryDate = getCurrentDate().addDays(7)

print(order.getOrderSummary())

// Approve and process order
order.approveOrder()

// Create shipment with strategy pattern
shipping = new ExpressShipping()  // Using strategy pattern
shipment = scm.processShipment(order, shipping)
shipment.origin = "Tech Supplies Inc Warehouse"
shipment.destination = mainWarehouse.location
shipment.distance = 250

print("Shipment Cost: $" + shipment.calculateShippingCost())
print("Estimated Delivery: " + shipment.getEstimatedDeliveryDate())

// Query operations (use filters/queries/streams based on your language)
print("=== Low Stock Items ===")
lowStockItems = mainWarehouse.getLowStockItems()
for each item in lowStockItems:
    print("- " + item.product.name + ": " + item.quantity + " units (Reorder: " + item.reorderLevel + ")")

print("=== Top 3 Value Products ===")
topProducts = mainWarehouse.getTopValueProducts(3)
for each item in topProducts:
    print("- " + item.product.name + ": $" + item.getStockValue())

// Inventory report
scm.getInventoryReport()

// Complete shipment and update inventory
shipment.markAsDelivered()
order.completeOrder()

print("✅ Order completed! Stock updated.")
print("Laptops in stock: " + mainWarehouse.getStockItem("LAPTOP-001").quantity)
```

## Expected Output Example

```
Processing sales...

⚠️ LOW STOCK ALERT:
Product: Business Laptop
Current: 5, Reorder Level: 10
Alert Time: 12/06/2025 4:15:23 PM

=== Purchase Order Summary ===
Order ID: PO-20251206-001
Supplier: Tech Supplies Inc
Order Date: 12/06/2025
Expected Delivery: 12/13/2025
Status: Pending

Items:
- Business Laptop x50 @ $999.99 = $49,999.50
- Wireless Mouse x100 @ $29.99 = $2,999.00

Total: $52,998.50

Shipment Cost: $825.50
Estimated Delivery: 12/09/2025

=== Low Stock Items ===
- Business Laptop: 5 units (Reorder: 10)

=== Top 3 Value Products ===
- Business Laptop: $4,999.50
- Wireless Mouse: $5,998.00

=== Inventory Report ===
Warehouse: Main Distribution Center (WH001)
Location: New York
Manager: Alice Johnson
Capacity: 10,000 units
Current Stock: 205 units (2.05% full)
Total Inventory Value: $10,997.50

Products in Stock:
1. Business Laptop (LAPTOP-001)
   Quantity: 5
   Value: $4,999.50
   Status: ⚠️ Low Stock

2. Wireless Mouse (MOUSE-001)
   Quantity: 200
   Value: $5,998.00
   Status: ✓ Adequate

✅ Order completed! Stock updated.
Laptops in stock: 55
```

## Bonus Challenges (Optional)
1. Implement batch processing for multiple orders
2. Add quality control and inspection tracking
3. Create automated reordering system
4. Implement ABC analysis for inventory classification
5. Add barcode/RFID tracking simulation
6. Create warehouse transfer functionality
7. Implement first-in-first-out (FIFO) tracking
8. Add seasonal demand patterns
9. Create multi-currency support for international suppliers
10. Implement advanced forecasting algorithms
11. Add return/defective item handling
12. Create audit trail for all inventory changes

## Learning Goals
- Working with generic types (templates in C++, generics in Java, type parameters in other languages)
- Implementing and using event handlers/observers/callbacks for notifications
- Query operations for complex data filtering and sorting
- Strategy pattern for flexible algorithms
- Event-driven programming with observer pattern
- Complex business logic implementation
- Working with maps/dictionaries and advanced collections
- Real-time notification systems

## Getting Started
Create a file for your implementation (e.g., `SupplyChainSystem.java`, `supply_chain.php`, `SupplyChainSystem.cs`, `supply_chain.py`, etc.). Start with the Product and StockItem classes with event handling, then build the warehouse and order management, finally add shipping strategies and the main manager class.

Adapt generic types, event handling, and query operations to your language's conventions.
