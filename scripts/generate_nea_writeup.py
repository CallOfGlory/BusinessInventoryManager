"""
OCR GCE A Level Computer Science NEA Project Writeup Generator
Business Inventory Manager System
H446-03

This script generates a comprehensive project writeup document
following OCR marking criteria standards.
"""

from datetime import datetime

def generate_writeup():
    """Generate the complete NEA project writeup document."""
    
    document = """
================================================================================
                           OCR GCE A LEVEL
                         COMPUTER SCIENCE
                              PROJECT
                             H446-03
================================================================================

Name:                    [Candidate Name]
Candidate Number:        [Candidate Number]
Centre:                  [Centre Name]
Centre Number:           [Centre Number]
Title of Project:        Business Inventory Manager

================================================================================
                        TABLE OF CONTENTS
================================================================================

SECTION                                                              PAGE
------------------------------------------------------------------------
A. ANALYSIS                                                            4
   1.1 An Outline of the Problem                                       4
   1.2 Stakeholders and End Users                                      5
   1.3 How the Problem Can Be Solved by Computational Methods          7
       1.3.1 Thinking Abstractly                                       7
       1.3.2 Thinking Ahead                                            8
       1.3.3 Thinking Procedurally and Decomposition                   9
       1.3.4 Thinking Logically                                       11
       1.3.5 Thinking Concurrently                                    12
   1.4 Research into Existing Solutions                               13
   1.5 Interview with End User - First Meeting (15/01/2026)           17
   1.6 Features of the Proposed Solution                              20
   1.7 Interview with End User - Second Meeting (22/01/2026)          23
   1.8 Hardware and Software Requirements                             26
   1.9 Success Criteria                                               28
   1.10 Limitations of the Proposed Solution                          31

B. DESIGN                                                             33
   2.1 Systems Diagram - Top Down Modular Design                      33
   2.2 Explanation of Each Module                                     35
   2.3 UML Class Diagrams                                             40
   2.4 Entity Relationship Diagram (ERD)                              45
   2.5 Usability Features                                             47
   2.6 Algorithms and Flowcharts                                      50
   2.7 Key Variables, Data Structures, and Classes                    65
   2.8 Data Validation                                                72
   2.9 Test Data for Development                                      75
   2.10 Acceptance Testing Plan                                       79
   2.11 Sign-Off Proposal                                             83

C. DEVELOPING THE CODED SOLUTION                                      84
   3.1 Development Story                                              84
   3.2 Sprint 1: Database and Authentication (06/02/2026)             85
   3.3 Sprint 2: Business Management Module (13/02/2026)              95
   3.4 Interview with End User - Progress Review (20/02/2026)        105
   3.5 Sprint 3: Product Inventory Module (27/02/2026)               108
   3.6 Sprint 4: Transaction System (06/03/2026)                     118
   3.7 Interview with End User - Testing Session (10/03/2026)        128
   3.8 Sprint 5: Analytics Dashboard (13/03/2026)                    131
   3.9 Code Annotations and Explanations                             140

D. EVALUATION                                                        145
   4.1 Testing for Evaluation                                        145
   4.2 Usability Testing                                             155
   4.3 How Well Does the Solution Match the Success Criteria?        160
   4.4 End User Evaluation and Sign-Off (15/03/2026)                 168
   4.5 Maintenance and Future Improvements                           170
   4.6 Limitations and How They Would Be Approached                  173

E. PROJECT APPENDIXES                                                175
   5.1 Complete Code Listings                                        175
   5.2 Database Schema                                               200
   5.3 Screenshots of Final Application                              205

================================================================================
                              SECTION A
                              ANALYSIS
================================================================================

Page 4 of 210

--------------------------------------------------------------------------------
1.1 AN OUTLINE OF THE PROBLEM
--------------------------------------------------------------------------------

For my project, I am developing a Business Inventory Manager system - a 
comprehensive web-based application designed to help small to medium-sized 
business owners manage their inventory, track transactions, and analyse their 
business performance through detailed analytics.

THE PROBLEM:

Small business owners often struggle with managing their inventory effectively.
Many rely on paper-based systems or basic spreadsheets which are prone to 
errors, difficult to maintain, and do not provide real-time insights into 
business performance. The key issues include:

1. Difficulty tracking stock levels in real-time
2. No automated alerts when stock runs low
3. Inability to track purchase and sale transactions efficiently
4. Lack of business analytics and profit calculations
5. No centralised system for managing multiple business locations
6. Time-consuming manual calculations for inventory value and profits

MY SOLUTION:

I aim to create a web-based Business Inventory Manager that will:
- Allow users to register, login, and manage their accounts securely
- Enable creation and management of multiple businesses under one account
- Provide comprehensive product inventory management with stock tracking
- Record and track all transactions (purchases, sales, and adjustments)
- Generate real-time analytics including profit calculations and sales trends
- Alert users when stock levels fall below defined thresholds
- Provide an intuitive, user-friendly interface accessible from any device

This solution is appropriate for a computational approach as it involves:
- Storing and retrieving structured data (products, transactions, users)
- Performing complex calculations (profit margins, inventory values)
- Managing user authentication and authorisation
- Implementing business logic for stock management
- Generating analytical reports from transaction data


Page 5 of 210

--------------------------------------------------------------------------------
1.2 STAKEHOLDERS AND END USERS
--------------------------------------------------------------------------------

IDENTIFYING STAKEHOLDERS:

The primary stakeholders for this project are small business owners who need
an efficient way to manage their inventory. After considering various potential
users, I have identified the following target audience:

TARGET AUDIENCE:
- Small business owners (retail, wholesale, or service-based)
- Business managers responsible for inventory control
- Entrepreneurs starting new businesses
- Age range: 25-55 years old
- Technical proficiency: Basic to intermediate computer skills

PRIMARY END USER: JAMES RICHARDSON

I have selected James Richardson as my primary end user for this project. James
is a 34-year-old business owner who runs a small electronics retail shop in 
Manchester. He has been in business for five years and currently manages his 
inventory using a combination of spreadsheets and paper records.

James's Profile:
- Age: 34
- Occupation: Electronics Retail Shop Owner
- Location: Manchester, UK
- Technical Skills: Intermediate (comfortable with computers and smartphones)
- Current System: Excel spreadsheets and paper-based stock records

WHY JAMES IS SUITABLE:

1. Real Need: James has expressed frustration with his current manual system,
   particularly when it comes to tracking stock levels and calculating profits.

2. Representative User: His business size and technical proficiency represent
   the typical target user for this application.

3. Availability: James has agreed to participate in regular feedback sessions
   throughout the development process.

4. Domain Knowledge: His experience in running a retail business provides
   valuable insights into the features required.


Page 6 of 210

HOW JAMES WILL USE THE PROPOSED SOLUTION:

James will use the Business Inventory Manager to:

1. Register and Login: Create an account with secure credentials and access
   his business data from any device with internet connectivity.

2. Manage Business Profile: Set up his electronics shop with appropriate
   currency settings and business details.

3. Product Management: Add all his products with purchase prices, sale prices,
   stock quantities, and minimum stock levels.

4. Transaction Recording: Record all purchases from suppliers and sales to
   customers, automatically updating stock levels.

5. Analytics Review: Access the dashboard to view profit margins, sales trends,
   and identify best-selling products.

6. Stock Alerts: Receive notifications when products fall below minimum stock
   levels, helping him plan reordering.

WHY THE SOLUTION IS APPROPRIATE TO JAMES'S NEEDS:

1. Time Saving: The automated calculations and real-time updates will save
   James several hours each week compared to his current manual system.

2. Accuracy: Eliminating manual data entry errors will provide more accurate
   financial records for tax purposes.

3. Accessibility: The web-based nature allows James to check stock levels
   even when away from the shop.

4. Business Insights: Analytics features will help James make data-driven
   decisions about stock levels and pricing.

5. Scalability: If James's business grows, the system can handle increased
   inventory and transaction volumes.


Page 7 of 210

--------------------------------------------------------------------------------
1.3 HOW THE PROBLEM CAN BE SOLVED BY COMPUTATIONAL METHODS
--------------------------------------------------------------------------------

This problem is well-suited to be solved using a computer program because it
involves processing structured data, performing calculations, and presenting
information in an organised manner. The following computational thinking 
approaches demonstrate why this solution is amenable to a computational method.

1.3.1 THINKING ABSTRACTLY
-------------------------

Abstraction involves removing unnecessary details and focusing on the essential
elements required to solve the problem. For the Business Inventory Manager:

REAL-WORLD CONCEPT              ABSTRACTED REPRESENTATION
-------------------------------------------------------------------
Physical Product                ProductModel class with properties:
                               - Name, SKU, Price, Quantity
                               
Business Transaction            TransactionModel with Type enum:
                               - Purchase, Sale, Adjustment
                               
Business Owner                  UserModel with authentication:
                               - Email, PasswordHash, Settings
                               
Shop/Store                      BusinessModel entity:
                               - Name, Currency, Products collection

WHAT I HAVE ABSTRACTED:

1. Product Location: I have removed the physical location of products within
   the store, focusing only on quantity available.

2. Customer Information: Individual customer details are not tracked; only
   transaction records are maintained.

3. Supplier Details: Supplier information is simplified to notes in transactions
   rather than maintaining a full supplier database.

4. Payment Methods: The system tracks transaction amounts without recording
   specific payment methods used.

JUSTIFICATION:

These abstractions keep the system focused on core inventory management while
maintaining simplicity for the target users. Additional complexity can be added
in future versions based on user feedback.


Page 8 of 210

1.3.2 THINKING AHEAD
--------------------

Thinking ahead involves planning inputs, outputs, and potential issues before
beginning development. This ensures a structured approach to problem-solving.

INPUTS IDENTIFIED:

1. User Registration Data:
   - Username, Email, Password
   - Validation required: Email format, password strength

2. Business Information:
   - Business name, description, currency selection
   - Validation required: Non-empty name, valid currency code

3. Product Details:
   - Name, SKU, purchase price, sale price, quantity, minimum stock level
   - Validation required: Positive prices, non-negative quantities

4. Transaction Data:
   - Product selection, quantity, unit price, transaction type, notes
   - Validation required: Sufficient stock for sales, positive quantities

OUTPUTS IDENTIFIED:

1. Dashboard Analytics:
   - Total inventory value, daily/monthly sales, profit margins
   - Visual representation of business performance

2. Product Listings:
   - Filtered and sortable product inventory
   - Low stock warnings highlighted

3. Transaction History:
   - Chronological record of all business transactions
   - Filtering by date range, type, and product

4. Reports (Future Enhancement):
   - PDF and Word document exports of inventory and transaction data

POTENTIAL ISSUES ANTICIPATED:

1. Concurrent Access: Multiple users updating the same product simultaneously
   Solution: Database transactions with proper locking mechanisms

2. Data Integrity: Ensuring stock levels never become negative
   Solution: Server-side validation before processing transactions

3. Performance: Large datasets slowing down analytics calculations
   Solution: Database indexing and efficient query design


Page 9 of 210

1.3.3 THINKING PROCEDURALLY AND DECOMPOSITION
---------------------------------------------

Thinking procedurally involves breaking down the problem into smaller, 
manageable sub-problems that can be solved independently and then combined
to form the complete solution.

TOP-DOWN DECOMPOSITION:

                    Business Inventory Manager
                              |
        +-----------+---------+---------+-----------+
        |           |         |         |           |
   User Auth    Business  Products  Transactions  Analytics
        |           |         |         |           |
   +----+----+   +--+--+   +--+--+   +--+--+    +--+--+
   |    |    |   |  |  |   |  |  |   |  |  |    |  |  |
  Reg Login Pwd  CRUD  Set CRUD Stock Rec View  Dash Report
              Change   Act        Alert Sale     Profit Trends

DETAILED BREAKDOWN OF SUB-PROBLEMS:

1. USER AUTHENTICATION MODULE
   - User Registration: Create new accounts with hashed passwords
   - User Login: Authenticate users and create session claims
   - Password Management: Secure password change functionality
   - Session Management: Cookie-based authentication with expiration

2. BUSINESS MANAGEMENT MODULE
   - Create Business: Allow users to create multiple businesses
   - Set Active Business: Switch between businesses for context
   - Edit Business: Update business details and currency settings
   - Delete Business: Remove businesses with cascade delete

3. PRODUCT MANAGEMENT MODULE
   - Add Product: Create new products with all required details
   - Edit Product: Modify existing product information
   - Delete Product: Remove products from inventory
   - View Products: List products with filtering and sorting
   - Low Stock Alerts: Identify products below minimum levels

4. TRANSACTION MANAGEMENT MODULE
   - Record Purchase: Add stock and record supplier purchases
   - Record Sale: Reduce stock and record customer sales
   - Record Adjustment: Manual stock corrections with notes
   - View Transactions: Historical transaction listing

5. ANALYTICS MODULE
   - Dashboard Summary: Quick overview of key metrics
   - Profit Calculations: Revenue, cost, and margin analysis
   - Sales Trends: Historical sales data visualisation


Page 10 of 210

JUSTIFICATION FOR DECOMPOSITION:

Breaking the system into these modules provides several benefits:

1. MAINTAINABILITY: Each module can be updated independently without
   affecting others, making future maintenance easier.

2. TESTABILITY: Individual modules can be tested in isolation before
   integration, ensuring reliability.

3. PARALLEL DEVELOPMENT: Different modules could theoretically be
   developed simultaneously by different team members.

4. CODE REUSABILITY: Common patterns (CRUD operations, validation)
   can be implemented once and reused across modules.

IMPLEMENTATION APPROACH:

The decomposed modules will be implemented using:

- Controllers: Handle HTTP requests and route to appropriate services
- Services: Contain business logic for each module
- Repositories: Handle database operations
- Models: Represent data entities
- ViewModels: Transfer data between controllers and views

This follows the Model-View-Controller (MVC) architectural pattern,
which provides clear separation of concerns:

+----------+     +------------+     +-----------+
|   View   | <-> | Controller | <-> |  Service  |
| (Razor)  |     |            |     |  (Logic)  |
+----------+     +------------+     +-----------+
                                          |
                                    +-----------+
                                    |Repository |
                                    | (Data)    |
                                    +-----------+
                                          |
                                    +-----------+
                                    | Database  |
                                    | (SQL)     |
                                    +-----------+


Page 11 of 210

1.3.4 THINKING LOGICALLY
------------------------

Thinking logically involves identifying decision points within the system
where conditions must be evaluated to determine the program flow.

KEY DECISION POINTS IN THE SYSTEM:

1. AUTHENTICATION DECISIONS:

   User attempts login
         |
         v
   Is email format valid? --No--> Display validation error
         |
        Yes
         v
   Does user exist? --No--> Display "Invalid credentials"
         |
        Yes
         v
   Is password correct? --No--> Display "Invalid credentials"
         |
        Yes
         v
   Create session and redirect to dashboard

2. TRANSACTION PROCESSING DECISIONS:

   User records sale transaction
         |
         v
   Is product selected? --No--> Display validation error
         |
        Yes
         v
   Is quantity > 0? --No--> Display validation error
         |
        Yes
         v
   Is stock >= quantity? --No--> Display "Insufficient stock"
         |
        Yes
         v
   Process transaction and update stock

3. PRODUCT STOCK LEVEL DECISIONS:

   After any stock change
         |
         v
   Is quantity <= MinStockLevel? --No--> Normal display
         |
        Yes
         v
   Flag product as "Low Stock"
   Display warning on dashboard


Page 12 of 210

4. BUSINESS CONTEXT DECISIONS:

   User accesses products/transactions
         |
         v
   Is there an active business? --No--> Redirect to business selection
         |
        Yes
         v
   Load data for active business only

5. ANALYTICS CALCULATION DECISIONS:

   Calculate profit margin
         |
         v
   Is revenue > 0? --No--> Return 0% margin
         |
        Yes
         v
   Calculate: (profit / revenue) * 100


1.3.5 THINKING CONCURRENTLY
---------------------------

Thinking concurrently involves identifying processes that can occur 
simultaneously to improve system efficiency.

CONCURRENT PROCESSES IDENTIFIED:

1. DASHBOARD LOADING:
   When loading the dashboard, multiple data queries can execute
   concurrently:
   
   - Fetch product statistics (async)
   - Fetch transaction summaries (async)
   - Fetch low stock alerts (async)
   - Calculate profit analytics (async)
   
   All queries are executed using async/await patterns in C#,
   allowing the database to process them in parallel.

2. USER INTERACTIONS:
   Multiple users can simultaneously:
   - View their own business dashboards
   - Record transactions (each user has isolated business context)
   - Update product information
   
   The system handles this through database isolation and proper
   session management.


Page 13 of 210

--------------------------------------------------------------------------------
1.4 RESEARCH INTO EXISTING SOLUTIONS
--------------------------------------------------------------------------------

To ensure my solution addresses real user needs and incorporates best practices,
I researched existing inventory management solutions.

EXISTING SOLUTION 1: ZOHO INVENTORY
-----------------------------------

Zoho Inventory is a cloud-based inventory management system designed for
small to medium-sized businesses.

Key Features Observed:
- Multi-channel sales integration
- Warehouse management
- Batch and serial number tracking
- Automated reorder points
- Comprehensive reporting

[Screenshot placeholder - Zoho Dashboard]

FEATURES I LIKE:
+------------------+----------------------------------------------------+
| Feature          | Why I Like It                                      |
+------------------+----------------------------------------------------+
| Dashboard Design | Clean, modern interface with key metrics visible   |
|                  | immediately. Will influence my dashboard layout.   |
+------------------+----------------------------------------------------+
| Low Stock Alerts | Clear visual indicators for items needing reorder. |
|                  | I will implement similar colour-coded warnings.    |
+------------------+----------------------------------------------------+
| Transaction      | Comprehensive history with filtering options.      |
| History          | My system will include date range filtering.       |
+------------------+----------------------------------------------------+

FEATURES I WOULD IMPROVE:
+------------------+----------------------------------------------------+
| Feature          | Why I Would Change It                              |
+------------------+----------------------------------------------------+
| Complexity       | Too many features for a small business owner.      |
|                  | My system will focus on core functionality.        |
+------------------+----------------------------------------------------+
| Pricing          | Expensive subscription model.                      |
|                  | My system will be simpler and more affordable.     |
+------------------+----------------------------------------------------+


Page 14 of 210

EXISTING SOLUTION 2: SQUARE FOR RETAIL
--------------------------------------

Square for Retail is an inventory management system integrated with
point-of-sale functionality.

Key Features Observed:
- POS integration
- Stock counting and adjustments
- Purchase order management
- Employee management
- Basic analytics

[Screenshot placeholder - Square Dashboard]

FEATURES I LIKE:
+------------------+----------------------------------------------------+
| Feature          | Why I Like It                                      |
+------------------+----------------------------------------------------+
| Simplicity       | User interface is clean and easy to navigate.      |
|                  | My target users need similar simplicity.           |
+------------------+----------------------------------------------------+
| Stock            | Simple form for recording stock adjustments with   |
| Adjustments      | reason notes. I will implement similar feature.    |
+------------------+----------------------------------------------------+
| Mobile           | Works well on tablets and phones. My web app       |
| Responsive       | will use Bootstrap for responsive design.          |
+------------------+----------------------------------------------------+

FEATURES I WOULD IMPROVE:
+------------------+----------------------------------------------------+
| Feature          | Why I Would Change It                              |
+------------------+----------------------------------------------------+
| Analytics        | Basic reporting only. I will provide more detailed |
| Depth            | profit analysis and sales trends.                  |
+------------------+----------------------------------------------------+
| Multi-Business   | Limited support for multiple businesses. My system |
| Support          | will allow one user to manage several businesses.  |
+------------------+----------------------------------------------------+


Page 15 of 210

EXISTING SOLUTION 3: TRADEGECKO (NOW QUICKBOOKS COMMERCE)
---------------------------------------------------------

TradeGecko is a comprehensive inventory and order management platform
aimed at growing businesses.

Key Features Observed:
- B2B eCommerce platform
- Multiple warehouse support
- Demand forecasting
- Manufacturing and assembly
- Integration ecosystem

[Screenshot placeholder - TradeGecko Interface]

FEATURES I LIKE:
+------------------+----------------------------------------------------+
| Feature          | Why I Like It                                      |
+------------------+----------------------------------------------------+
| Product          | Clear display of purchase and sale prices with     |
| Profitability    | calculated profit margins. Essential for my system.|
+------------------+----------------------------------------------------+
| Visual           | Charts and graphs showing sales trends over time.  |
| Analytics        | I will implement similar visualisations.           |
+------------------+----------------------------------------------------+
| User Roles       | Different access levels for employees. Future      |
|                  | enhancement for my system.                         |
+------------------+----------------------------------------------------+

FEATURES I WOULD IMPROVE:
+------------------+----------------------------------------------------+
| Feature          | Why I Would Change It                              |
+------------------+----------------------------------------------------+
| Learning Curve   | Steep learning curve for new users. I will create  |
|                  | a more intuitive interface for novice users.       |
+------------------+----------------------------------------------------+
| Feature Bloat    | Many features irrelevant to small retailers.       |
|                  | My system targets specific, common needs.          |
+------------------+----------------------------------------------------+


Page 16 of 210

SUMMARY OF RESEARCH FINDINGS:

Based on my research, I have identified the following key features to
incorporate into my Business Inventory Manager:

ESSENTIAL FEATURES (Must Have):
1. User authentication with secure password hashing
2. Multi-business support under single account
3. Product CRUD operations with price tracking
4. Transaction recording (purchase, sale, adjustment)
5. Low stock alerts with configurable thresholds
6. Dashboard with key business metrics
7. Responsive design for various devices

IMPORTANT FEATURES (Should Have):
1. Profit margin calculations per product and overall
2. Sales trend visualisation
3. Date range filtering for transactions
4. Category-based product organisation
5. Transaction notes for audit trail

NICE-TO-HAVE FEATURES (Could Have - if time permits):
1. PDF/Word report generation
2. Email notifications for low stock
3. Multi-user support with roles
4. Barcode scanning integration

FEATURES EXCLUDED (Won't Have for this version):
1. POS integration
2. Manufacturing/assembly tracking
3. Multi-warehouse support
4. Supplier management database

This prioritisation ensures the core functionality is delivered while
maintaining a realistic scope for the project timeline.


Page 17 of 210

--------------------------------------------------------------------------------
1.5 INTERVIEW WITH END USER - FIRST MEETING (15/01/2026)
--------------------------------------------------------------------------------

INTERVIEW PLAN:

The purpose of this first interview is to understand James's current workflow,
pain points, and requirements for the inventory management system. I have
prepared questions under three main categories.

Questions Prepared:

CURRENT WORKFLOW:
- How do you currently track your inventory?
- What tools do you use (spreadsheets, paper, etc.)?
- How often do you update your stock records?
- What challenges do you face with your current system?

REQUIREMENTS GATHERING:
- What features are most important to you in an inventory system?
- Do you need to manage multiple business locations?
- How important is mobile access for you?
- What reports do you currently need?

PRIORITIES AND PREFERENCES:
- What would save you the most time?
- Are there any features from other systems you've seen that you like?
- What is your budget and timeline expectation?


INTERVIEW TRANSCRIPT (15/01/2026)

Q: How do you currently track your inventory?
A: I use a combination of Excel spreadsheets and a notebook. The spreadsheet has
   all my products with prices and quantities, but I have to manually update it
   every time I make a sale or receive stock. The notebook is for quick notes
   during busy times when I can't access the computer.

Q: How often do you update your stock records?
A: I try to update the spreadsheet at the end of each day, but sometimes it
   gets pushed to weekly updates. By then, I've forgotten some transactions
   and have to reconcile with receipts.

Q: What challenges do you face with your current system?
A: The biggest issue is accuracy. I often find discrepancies between my
   spreadsheet and actual stock. Also, I can't check stock levels when I'm
   away from the shop, and calculating profits is very time-consuming.


Page 18 of 210

Q: What features are most important to you in an inventory system?
A: Real-time stock updates would be huge. Also, I need to see profit margins
   easily - right now I have to do separate calculations for each product.
   And definitely low stock alerts - I've lost sales because I didn't realise
   I was out of popular items.

Q: Do you need to manage multiple business locations?
A: Not right now, but I'm thinking of opening a second shop next year. So it
   would be nice if the system could handle that in the future.

Q: How important is mobile access for you?
A: Very important. I'm often out meeting suppliers or at trade shows. Being
   able to check what's in stock before placing orders would be very helpful.

Q: What reports do you currently need?
A: Mainly I need to know total inventory value for insurance, monthly sales
   totals, and profit reports for tax purposes. I'd also like to see which
   products sell best so I can make better ordering decisions.

Q: What would save you the most time?
A: Automatic stock updates when I record sales. Currently, I have to update
   two places - my sales record and my stock spreadsheet. If it was all in
   one place, that would be brilliant.

Q: Are there any features from other systems you've seen that you like?
A: My friend uses something called QuickBooks for his business. I like how
   it shows a dashboard with all the important numbers at a glance. I'd
   like something similar but simpler - his system looks complicated.


Page 19 of 210

REVIEW OF INTERVIEW ANSWERS:

From this interview, I have identified the following key requirements:

HIGH PRIORITY REQUIREMENTS:
+----+----------------------------------+----------------------------------+
| ID | Requirement                      | Source Quote                     |
+----+----------------------------------+----------------------------------+
| R1 | Real-time stock updates when     | "Automatic stock updates when I  |
|    | transactions are recorded        | record sales"                    |
+----+----------------------------------+----------------------------------+
| R2 | Profit margin calculations       | "I need to see profit margins    |
|    | per product and overall          | easily"                          |
+----+----------------------------------+----------------------------------+
| R3 | Low stock alerts with            | "Low stock alerts - I've lost    |
|    | configurable thresholds          | sales"                           |
+----+----------------------------------+----------------------------------+
| R4 | Mobile-friendly web interface    | "Being able to check stock when  |
|    |                                  | I'm away from the shop"          |
+----+----------------------------------+----------------------------------+
| R5 | Dashboard with key metrics       | "A dashboard with all the        |
|    | visible at a glance              | important numbers at a glance"   |
+----+----------------------------------+----------------------------------+

MEDIUM PRIORITY REQUIREMENTS:
+----+----------------------------------+----------------------------------+
| ID | Requirement                      | Source Quote                     |
+----+----------------------------------+----------------------------------+
| R6 | Multi-business support for       | "Thinking of opening a second    |
|    | future expansion                 | shop next year"                  |
+----+----------------------------------+----------------------------------+
| R7 | Product performance analytics    | "See which products sell best"   |
|    | (best sellers identification)    |                                  |
+----+----------------------------------+----------------------------------+
| R8 | Monthly and period-based         | "Monthly sales totals and profit |
|    | reports                          | reports for tax purposes"        |
+----+----------------------------------+----------------------------------+

DESIGN PREFERENCES:
- Simple, clean interface (not complicated like QuickBooks)
- Dashboard-centric design
- Intuitive navigation

I will use these requirements to define the features of my proposed solution
and create measurable success criteria.


Page 20 of 210

--------------------------------------------------------------------------------
1.6 FEATURES OF THE PROPOSED SOLUTION
--------------------------------------------------------------------------------

Based on my research and the interview with James, I have defined the following
features for the Business Inventory Manager system:

1. USER AUTHENTICATION AND MANAGEMENT
-------------------------------------
Description: Secure user registration and login system using email and password.
             Passwords will be hashed using bcrypt for security.

Features:
- User registration with email validation
- Secure login with password verification
- Session management using cookies
- Password change functionality
- Logout functionality

Justification: Security is essential for business data. The interview confirmed
James needs to access the system from multiple locations, requiring secure
authentication. [Linked to stakeholder requirement]

2. BUSINESS MANAGEMENT
----------------------
Description: Ability to create and manage multiple businesses under one account,
             with one business set as "active" at any time.

Features:
- Create new business with name and description
- Set currency and currency symbol
- Set one business as active
- Edit business details
- View all businesses owned by user

Justification: Although James currently has one shop, he mentioned plans for
expansion. This feature supports future growth. [Linked to R6]

3. PRODUCT INVENTORY MANAGEMENT
-------------------------------
Description: Complete product catalogue management with pricing, stock levels,
             and categorisation.

Features:
- Add new products with name, SKU, description
- Set purchase price and sale price
- Track current stock quantity
- Set minimum stock level for alerts
- Categorise products
- Edit and delete products
- View products with low stock highlighted

Justification: Core functionality requested by James. The profit calculations
require both purchase and sale prices. [Linked to R1, R2, R3]


Page 21 of 210

4. TRANSACTION MANAGEMENT
-------------------------
Description: Record all stock movements including purchases from suppliers,
             sales to customers, and manual adjustments.

Transaction Types:
- PURCHASE: Increases stock quantity (receiving goods from supplier)
- SALE: Decreases stock quantity (selling to customers)  
- ADJUSTMENT: Manual correction (damaged goods, stocktake corrections)

Features:
- Record purchase transactions with supplier price
- Record sale transactions with sale price
- Record stock adjustments with notes
- Automatic stock level updates
- Transaction history with filtering
- Validation to prevent negative stock on sales

Justification: This addresses James's main pain point of updating stock in
multiple places. Automatic updates save time and reduce errors. [Linked to R1]

5. ANALYTICS DASHBOARD
----------------------
Description: Real-time business intelligence dashboard showing key performance
             indicators and alerts.

Dashboard Components:
- Total products count
- Low stock products alert
- Total inventory value (purchase price x quantity)
- Sales today and this month
- Profit this month
- Recent transactions list
- Low stock items list

Analytics Features:
- Profit calculation: (Sale Price - Purchase Price) x Quantity Sold
- Profit margin percentage: (Profit / Revenue) x 100
- Sales trends over time (future enhancement)

Justification: James specifically requested a dashboard similar to QuickBooks
but simpler. The profit calculations address his time-consuming manual process.
[Linked to R2, R5, R7, R8]


Page 22 of 210

6. USER INTERFACE DESIGN
------------------------
Description: Modern, responsive web interface built with Bootstrap framework
             for accessibility across devices.

Design Principles:
- Clean, uncluttered layout
- Consistent navigation header
- Responsive design for mobile/tablet
- Clear visual feedback for actions
- Bootstrap icons for intuitive navigation

Pages/Views:
- Login and Registration pages
- Dashboard (Home)
- Business management pages
- Product listing and forms
- Transaction listing and forms
- Settings page

Justification: James emphasised the need for simplicity and mobile access.
Bootstrap provides responsive design out of the box. [Linked to R4]

7. DATA VALIDATION
------------------
Description: Comprehensive input validation to ensure data integrity and
             prevent errors.

Validation Rules:
- Email format validation
- Password strength requirements
- Non-empty required fields
- Positive price values
- Non-negative quantities
- Stock availability check for sales
- Unique email addresses

Justification: To address James's accuracy concerns with his current system,
robust validation will prevent data entry errors.


Page 23 of 210

--------------------------------------------------------------------------------
1.7 INTERVIEW WITH END USER - SECOND MEETING (22/01/2026)
--------------------------------------------------------------------------------

INTERVIEW PLAN:

The purpose of this second interview is to review the proposed features with
James, gather feedback, and refine the requirements before beginning design.

Questions Prepared:
- Do the proposed features meet your needs?
- Are there any features missing that you consider essential?
- What order of priority would you assign to each feature?
- Do you have any concerns about the proposed solution?


INTERVIEW TRANSCRIPT (22/01/2026)

[Presented James with the feature list from Section 1.6]

Q: Looking at the proposed features, do they meet your needs?
A: Yes, this looks comprehensive. I particularly like the three transaction
   types - I hadn't thought about stock adjustments, but that would be really
   useful for when I find damaged items or do stocktakes.

Q: Are there any features missing that you consider essential?
A: One thing I was hoping for was the ability to generate reports I could
   print out or send to my accountant. Something like a PDF of my inventory
   or transaction history. Is that something that could be added?

[Developer Note: Added report generation as a future enhancement if time permits]

Q: What order of priority would you assign to each feature?
A: I'd say the most critical for me are:
   1. The transaction recording with automatic stock updates - that's the
      biggest time saver
   2. The dashboard with profit calculations
   3. Low stock alerts
   4. Product management
   5. Everything else

Q: Do you have any concerns about the proposed solution?
A: My main concern is ease of use. I'm not particularly tech-savvy, so I need
   something I can learn quickly. Also, what happens to my data if the internet
   goes down? Can I still access it?

[Developer Note: Will emphasise intuitive UI design. Database is server-hosted
so requires internet, but this is acceptable for web-based system]


Page 24 of 210

Q: How would you like the product categories to work?
A: I'd like to be able to add my own categories - things like "Phones",
   "Accessories", "Cables", "Headphones" for my shop. And then be able to
   filter products by category.

Q: For the low stock alerts, how would you like to set the threshold?
A: It would be great if I could set it per product. Some items I need to
   reorder when I get below 20, but others I only keep 5 in stock anyway.
   So being able to set a minimum level for each product would be ideal.

Q: How do you envision using the system day-to-day?
A: I imagine first thing in the morning, I'd check the dashboard to see if
   anything needs reordering. When I receive stock, I'd record that. At the
   end of the day, I'd record all my sales - or maybe during quiet periods.
   And once a week or so, I'd look at the analytics to see how things are going.

Q: Is there anything about the existing systems you researched that you
   specifically want me to avoid?
A: Yes - too many menus and options. I looked at some inventory systems online
   and they have hundreds of features I'd never use. Keep it simple please.


REVIEW OF SECOND INTERVIEW:

The second interview confirmed the following:

CONFIRMED FEATURES:
- Transaction system with three types (purchase, sale, adjustment) - approved
- Dashboard with profit calculations - confirmed as high priority
- Low stock alerts - confirmed as essential
- Custom categories for products - confirmed requirement
- Per-product minimum stock levels - confirmed requirement

NEW REQUIREMENTS IDENTIFIED:
+----+----------------------------------+----------------------------------+
| ID | Requirement                      | Source Quote                     |
+----+----------------------------------+----------------------------------+
| R9 | Report generation (PDF export)   | "Generate reports I could print  |
|    | - FUTURE ENHANCEMENT             | out or send to my accountant"    |
+----+----------------------------------+----------------------------------+
| R10| Custom product categories        | "I'd like to be able to add my   |
|    |                                  | own categories"                  |
+----+----------------------------------+----------------------------------+
| R11| Per-product minimum stock levels | "Set a minimum level for each    |
|    |                                  | product"                         |
+----+----------------------------------+----------------------------------+


Page 25 of 210

DESIGN IMPLICATIONS:

From James's feedback, I will ensure:

1. SIMPLICITY: Navigation will be limited to essential pages only - Dashboard,
   Businesses, Products, Transactions, Analytics, Settings

2. PER-PRODUCT SETTINGS: The ProductModel will include a MinStockLevel
   property that can be set individually for each product

3. CUSTOM CATEGORIES: Products will have a Category field where users can
   enter their own category names

4. FUTURE REPORTS: The requirement for PDF/Word report generation is noted
   as a future enhancement to be implemented if time permits. If not completed
   within the project timeline, this will be documented in the Evaluation
   section as a potential improvement.

UPDATED FEATURE PRIORITY:

Priority 1 (Essential - Must be completed):
- User Authentication
- Business Management
- Product Management with MinStockLevel
- Transaction Recording with automatic stock updates
- Dashboard with profit calculations
- Low stock alerts

Priority 2 (Important - Should be completed):
- Transaction history with filtering
- Sales analytics
- Settings page

Priority 3 (Desirable - Complete if time permits):
- PDF/Word report generation
- Email notifications
- Data export functionality

James confirmed he is happy with the proposed solution and is excited to
see the development progress. We agreed to meet again in mid-February to
review the initial prototype.


Page 26 of 210

--------------------------------------------------------------------------------
1.8 HARDWARE AND SOFTWARE REQUIREMENTS
--------------------------------------------------------------------------------

HARDWARE REQUIREMENTS:
----------------------

For Development:
+----------------+--------------------+---------------------------------------+
| Component      | Specification      | Justification                         |
+----------------+--------------------+---------------------------------------+
| Processor      | Intel i5 or        | Required for running Visual Studio    |
|                | equivalent         | IDE and SQL Server smoothly           |
+----------------+--------------------+---------------------------------------+
| RAM            | 8GB minimum        | Visual Studio and .NET runtime        |
|                | 16GB recommended   | require significant memory            |
+----------------+--------------------+---------------------------------------+
| Storage        | 50GB free space    | Development tools, database, and      |
|                |                    | project files require storage         |
+----------------+--------------------+---------------------------------------+
| Display        | 1080p resolution   | Adequate screen space for IDE and     |
|                |                    | testing responsive design             |
+----------------+--------------------+---------------------------------------+
| Network        | Broadband internet | For NuGet packages, documentation,    |
|                |                    | and research                          |
+----------------+--------------------+---------------------------------------+

For End User (James):
+----------------+--------------------+---------------------------------------+
| Component      | Specification      | Justification                         |
+----------------+--------------------+---------------------------------------+
| Device         | Any computer,      | Web application accessible from       |
|                | tablet, or phone   | standard browsers                     |
+----------------+--------------------+---------------------------------------+
| Browser        | Chrome, Firefox,   | Modern browsers support Bootstrap     |
|                | Edge, or Safari    | and required JavaScript               |
+----------------+--------------------+---------------------------------------+
| Network        | Internet access    | Required to access web application    |
+----------------+--------------------+---------------------------------------+
| Display        | Any resolution     | Responsive design adapts to all       |
|                |                    | screen sizes                          |
+----------------+--------------------+---------------------------------------+


Page 27 of 210

SOFTWARE REQUIREMENTS:
----------------------

Development Environment:
+-------------------------+------------+-------------------------------------+
| Software                | Version    | Justification                       |
+-------------------------+------------+-------------------------------------+
| Visual Studio 2025      | Latest     | IDE for C# and ASP.NET development  |
|                         |            | with debugging and IntelliSense     |
+-------------------------+------------+-------------------------------------+
| .NET SDK                | 10.0       | Latest framework with performance   |
|                         |            | improvements and async support      |
+-------------------------+------------+-------------------------------------+
| SQL Server              | 2022       | Relational database for data        |
|                         |            | storage with Entity Framework       |
+-------------------------+------------+-------------------------------------+
| Git                     | Latest     | Version control for code management |
+-------------------------+------------+-------------------------------------+

Framework and Libraries:
+-------------------------+------------+-------------------------------------+
| Technology              | Purpose    | Justification                       |
+-------------------------+------------+-------------------------------------+
| ASP.NET Core MVC        | Web        | Industry-standard framework for     |
|                         | Framework  | building web applications           |
+-------------------------+------------+-------------------------------------+
| Entity Framework Core   | ORM        | Simplifies database operations with |
|                         |            | Code-First approach                 |
+-------------------------+------------+-------------------------------------+
| Bootstrap 5             | CSS        | Responsive design framework for     |
|                         | Framework  | mobile-friendly interface           |
+-------------------------+------------+-------------------------------------+
| jQuery                  | JavaScript | DOM manipulation and form           |
|                         | Library    | validation                          |
+-------------------------+------------+-------------------------------------+
| BCrypt.NET              | Security   | Industry-standard password hashing  |
+-------------------------+------------+-------------------------------------+

End User Requirements:
+-------------------------+--------------------------------------------------+
| Software                | Justification                                    |
+-------------------------+--------------------------------------------------+
| Modern Web Browser      | Application is web-based, requires JavaScript    |
+-------------------------+--------------------------------------------------+
| Internet Connection     | Required to access hosted application            |
+-------------------------+--------------------------------------------------+


Page 28 of 210

--------------------------------------------------------------------------------
1.9 SUCCESS CRITERIA
--------------------------------------------------------------------------------

The following success criteria will be used to evaluate whether the solution
meets the requirements identified in the analysis phase. Each criterion is
measurable and linked to a specific requirement.

USER AUTHENTICATION (Linked to general requirement)
+----+------------------------------------------+----------------------------+
| ID | Success Criterion                        | How to Test                |
+----+------------------------------------------+----------------------------+
| SC1| Users can register with unique email     | Attempt registration with  |
|    | and secure password                      | valid and invalid data     |
+----+------------------------------------------+----------------------------+
| SC2| Users can login with correct credentials | Test login with valid and  |
|    | and are rejected with incorrect ones     | invalid credentials        |
+----+------------------------------------------+----------------------------+
| SC3| Passwords are securely hashed (not       | Check database to confirm  |
|    | stored in plain text)                    | hashed password storage    |
+----+------------------------------------------+----------------------------+
| SC4| Users can change their password          | Test password change       |
|    | successfully                             | functionality              |
+----+------------------------------------------+----------------------------+
| SC5| Sessions expire after 7 days and can     | Test session persistence   |
|    | be manually ended via logout             | and logout function        |
+----+------------------------------------------+----------------------------+

BUSINESS MANAGEMENT (Linked to R6)
+----+------------------------------------------+----------------------------+
| ID | Success Criterion                        | How to Test                |
+----+------------------------------------------+----------------------------+
| SC6| Users can create multiple businesses     | Create 3+ businesses and   |
|    | under one account                        | verify all are saved       |
+----+------------------------------------------+----------------------------+
| SC7| Users can set one business as active     | Set different businesses   |
|    | and switch between them                  | as active and verify       |
+----+------------------------------------------+----------------------------+
| SC8| Users can edit business details          | Modify name, description,  |
|    | (name, description, currency)            | and currency settings      |
+----+------------------------------------------+----------------------------+
| SC9| Deleting a business removes all          | Delete business and check  |
|    | associated products and transactions     | related data is removed    |
+----+------------------------------------------+----------------------------+


Page 29 of 210

PRODUCT MANAGEMENT (Linked to R1, R2, R3, R10, R11)
+----+------------------------------------------+----------------------------+
| ID | Success Criterion                        | How to Test                |
+----+------------------------------------------+----------------------------+
| SC10| Users can add products with name, SKU,  | Create products with all   |
|     | prices, quantity, category, description | fields and verify storage  |
+----+------------------------------------------+----------------------------+
| SC11| Products can have per-product minimum   | Set different min levels   |
|     | stock levels (R11)                      | for different products     |
+----+------------------------------------------+----------------------------+
| SC12| Products are correctly associated with  | Create products under      |
|     | the active business only                | different businesses       |
+----+------------------------------------------+----------------------------+
| SC13| Users can edit and delete products      | Modify and remove products |
+----+------------------------------------------+----------------------------+
| SC14| Products below minimum stock level are  | Reduce stock and verify    |
|     | clearly flagged (R3)                    | warning appears            |
+----+------------------------------------------+----------------------------+

TRANSACTION MANAGEMENT (Linked to R1, R8)
+----+------------------------------------------+----------------------------+
| ID | Success Criterion                        | How to Test                |
+----+------------------------------------------+----------------------------+
| SC15| Users can record purchase transactions  | Record purchase and verify |
|     | and stock increases automatically (R1)  | stock level increase       |
+----+------------------------------------------+----------------------------+
| SC16| Users can record sale transactions      | Record sale and verify     |
|     | and stock decreases automatically (R1)  | stock level decrease       |
+----+------------------------------------------+----------------------------+
| SC17| System prevents sales when insufficient | Attempt to sell more than  |
|     | stock is available                      | available stock            |
+----+------------------------------------------+----------------------------+
| SC18| Users can record adjustment transactions| Record positive and        |
|     | with notes                              | negative adjustments       |
+----+------------------------------------------+----------------------------+
| SC19| Users can view transaction history      | View and filter            |
|     | with filtering by date and type (R8)   | transactions               |
+----+------------------------------------------+----------------------------+


Page 30 of 210

ANALYTICS AND DASHBOARD (Linked to R2, R5, R7)
+----+------------------------------------------+----------------------------+
| ID | Success Criterion                        | How to Test                |
+----+------------------------------------------+----------------------------+
| SC20| Dashboard displays total products,      | Add products and verify    |
|     | inventory value, and low stock count    | correct totals shown       |
+----+------------------------------------------+----------------------------+
| SC21| Dashboard displays today's and this     | Record sales and verify    |
|     | month's sales totals                    | totals update              |
+----+------------------------------------------+----------------------------+
| SC22| Profit is calculated correctly as       | Record sales with known    |
|     | (Sale Price - Purchase Price) x Qty (R2)| values and verify profit   |
+----+------------------------------------------+----------------------------+
| SC23| Low stock items are listed on dashboard | Reduce stock below minimum |
|     | (R3)                                    | and verify appears in list |
+----+------------------------------------------+----------------------------+
| SC24| Recent transactions are displayed       | Add transactions and       |
|     | on dashboard (R5)                       | verify they appear         |
+----+------------------------------------------+----------------------------+

USER INTERFACE (Linked to R4)
+----+------------------------------------------+----------------------------+
| ID | Success Criterion                        | How to Test                |
+----+------------------------------------------+----------------------------+
| SC25| Interface is responsive and works on    | Test on mobile, tablet,    |
|     | mobile devices (R4)                     | and desktop browsers       |
+----+------------------------------------------+----------------------------+
| SC26| Navigation is intuitive with clear      | User testing with James    |
|     | menu structure                          | for feedback               |
+----+------------------------------------------+----------------------------+
| SC27| Appropriate feedback is given for all   | Test all operations and    |
|     | user actions (success/error messages)   | verify messages appear     |
+----+------------------------------------------+----------------------------+

FUTURE ENHANCEMENT (Linked to R9)
+----+------------------------------------------+----------------------------+
| ID | Success Criterion                        | How to Test                |
+----+------------------------------------------+----------------------------+
| SC28| PDF/Word report generation available    | If implemented, generate   |
|     | (if time permits)                       | and verify reports         |
+----+------------------------------------------+----------------------------+


Page 31 of 210

--------------------------------------------------------------------------------
1.10 LIMITATIONS OF THE PROPOSED SOLUTION
--------------------------------------------------------------------------------

Every solution has limitations that should be acknowledged. The following table
identifies the limitations of the Business Inventory Manager and explains how
they might be addressed in future versions.

+-------------------+----------------------------+----------------------------+
| Limitation        | Explanation                | How It Could Be Addressed  |
+-------------------+----------------------------+----------------------------+
| Internet Required | The system is web-based    | A Progressive Web App      |
|                   | and requires internet      | (PWA) version could cache  |
|                   | connectivity. Users cannot | data locally for offline   |
|                   | access data offline.       | access and sync later.     |
+-------------------+----------------------------+----------------------------+
| Single User per   | Currently, only one user   | Implement user roles and   |
| Business          | can access each business.  | permissions to allow       |
|                   | No employee accounts.      | multiple users with        |
|                   |                            | different access levels.   |
+-------------------+----------------------------+----------------------------+
| No POS            | The system requires manual | Integration with payment   |
| Integration       | entry of sales. It does    | terminals or POS systems   |
|                   | not connect to point-of-   | could automate sales       |
|                   | sale hardware.             | recording.                 |
+-------------------+----------------------------+----------------------------+
| Basic Reporting   | Analytics are displayed    | Add PDF/Word report        |
|                   | on screen but cannot be    | generation, scheduled      |
|                   | exported to documents.     | email reports, and data    |
|                   |                            | export functionality.      |
+-------------------+----------------------------+----------------------------+
| No Supplier       | Supplier information is    | Add supplier management    |
| Management        | limited to notes on        | module with contact        |
|                   | purchase transactions.     | details, purchase orders,  |
|                   |                            | and automatic reordering.  |
+-------------------+----------------------------+----------------------------+
| No Barcode        | Products must be selected  | Implement barcode/QR       |
| Support           | manually from a list.      | scanning using device      |
|                   | No barcode scanning.       | camera for quick product   |
|                   |                            | identification.            |
+-------------------+----------------------------+----------------------------+
| Limited Time      | Due to project timeline,   | Document remaining         |
| for Development   | not all desirable features | features as future         |
|                   | may be implemented (e.g.,  | enhancements that could    |
|                   | report generation).        | be added post-project.     |
+-------------------+----------------------------+----------------------------+


Page 32 of 210

JUSTIFICATION FOR ACCEPTING LIMITATIONS:

1. INTERNET REQUIREMENT: This is acceptable because James confirmed he has
   reliable internet at his shop and primarily needs mobile access when he
   already has 4G connectivity. Offline support adds significant complexity.

2. SINGLE USER: James is currently the only person managing inventory in
   his shop. Multi-user support can be added when he expands.

3. NO POS INTEGRATION: James does not currently have electronic POS
   equipment. Manual sales entry is how he currently works.

4. BASIC REPORTING: James confirmed that on-screen analytics meet his
   immediate needs. PDF export is a "nice to have" feature.

5. NO SUPPLIER MANAGEMENT: James has few regular suppliers and manages
   these relationships informally. This feature is not essential.

6. NO BARCODE SUPPORT: James's current inventory is small enough that
   product selection from a list is manageable.

These limitations keep the project scope achievable within the timeline
while delivering a solution that meets James's core requirements. Each
limitation has been discussed with James and accepted as reasonable
trade-offs for the initial version.


================================================================================
                              SECTION B
                               DESIGN
================================================================================

Page 33 of 210

--------------------------------------------------------------------------------
2.1 SYSTEMS DIAGRAM - TOP DOWN MODULAR DESIGN
--------------------------------------------------------------------------------

The following diagram shows how the Business Inventory Manager system is
broken down into modules and sub-modules:

                         BUSINESS INVENTORY MANAGER
                                    |
        +-------------+-------------+-------------+-------------+
        |             |             |             |             |
    USER AUTH    BUSINESS      PRODUCTS    TRANSACTIONS   ANALYTICS
        |             |             |             |             |
   +----+----+   +----+----+   +----+----+   +----+----+   +----+----+
   |    |    |   |    |    |   |    |    |   |    |    |   |    |    |
  Reg Login Pwd Create Edit  Add  Edit  List Record View  Dash Profit
         Change  |    Delete Delete Alert Delete  History      Trends
                 |                  |
           Set Active         Low Stock
                              Warning

LEGEND:
- Reg = User Registration
- Pwd = Password functionality
- Dash = Dashboard summary
- Alert = Low stock alerts

The system is structured using the following architectural layers:

+------------------------------------------------------------------+
|                      PRESENTATION LAYER                           |
|  Views (.cshtml) - Razor pages with Bootstrap styling             |
+------------------------------------------------------------------+
                              |
+------------------------------------------------------------------+
|                       CONTROLLER LAYER                            |
|  Controllers - Handle HTTP requests and route to services         |
+------------------------------------------------------------------+
                              |
+------------------------------------------------------------------+
|                        SERVICE LAYER                              |
|  Services - Business logic and validation                         |
+------------------------------------------------------------------+
                              |
+------------------------------------------------------------------+
|                      REPOSITORY LAYER                             |
|  Repositories - Database operations via Entity Framework          |
+------------------------------------------------------------------+
                              |
+------------------------------------------------------------------+
|                        DATA LAYER                                 |
|  ApplicationContext - Entity Framework DbContext                  |
|  Models - Entity classes                                          |
+------------------------------------------------------------------+
                              |
+------------------------------------------------------------------+
|                         DATABASE                                  |
|  SQL Server - Relational database storage                         |
+------------------------------------------------------------------+


Page 34 of 210

JUSTIFICATION FOR LAYERED ARCHITECTURE:

The layered architecture provides several benefits that justify its use:

1. SEPARATION OF CONCERNS: Each layer has a single responsibility, making
   the code easier to understand, test, and maintain.

2. TESTABILITY: Services and repositories can be unit tested in isolation
   by mocking dependencies.

3. FLEXIBILITY: Database implementations can be changed (e.g., from SQL
   Server to PostgreSQL) without affecting business logic.

4. MAINTAINABILITY: Changes to one layer do not necessarily require changes
   to other layers if interfaces are preserved.

5. REUSABILITY: Services can be reused by different controllers, and
   repositories can be reused by different services.


Page 35 of 210

--------------------------------------------------------------------------------
2.2 EXPLANATION OF EACH MODULE
--------------------------------------------------------------------------------

USER AUTHENTICATION MODULE
--------------------------
Purpose: Handles all user-related operations including registration,
         authentication, and session management.

Components:
+------------------+--------------------------------------------------+
| Component        | Responsibility                                   |
+------------------+--------------------------------------------------+
| EnteranceController | Handles HTTP requests for login, register,    |
|                     | logout actions                                |
+------------------+--------------------------------------------------+
| EnteranceService    | Business logic for user authentication        |
|                     | - Validates credentials                       |
|                     | - Verifies password hashes                    |
+------------------+--------------------------------------------------+
| PasswordService     | Handles password hashing using BCrypt         |
|                     | - HashPassword(plainText)                     |
|                     | - VerifyPassword(plainText, hash)             |
+------------------+--------------------------------------------------+
| ClaimsService       | Manages user session claims                   |
|                     | - AddClaimsAsync(userId, email, context)      |
|                     | - GetClaimCertain<T>(context, claimType)      |
+------------------+--------------------------------------------------+
| EntranceRepository  | Database operations for users                 |
|                     | - GetByEmail(email)                           |
|                     | - Add(user)                                   |
|                     | - Update(user)                                |
+------------------+--------------------------------------------------+

Flow:
1. User submits login form
2. Controller receives credentials
3. Service validates email format
4. Repository retrieves user by email
5. PasswordService verifies password hash
6. ClaimsService creates authentication cookie
7. User redirected to dashboard


Page 36 of 210

BUSINESS MANAGEMENT MODULE
--------------------------
Purpose: Allows users to create and manage multiple businesses with one
         set as the active context for all operations.

Components:
+------------------+--------------------------------------------------+
| Component        | Responsibility                                   |
+------------------+--------------------------------------------------+
| BusinessController | Handles CRUD operations for businesses         |
|                    | - Index (list), Create, Edit, Delete           |
|                    | - SetActive action                             |
+------------------+--------------------------------------------------+
| BusinessService    | Business logic for business management         |
|                    | - GetUserBusinessesAsync(userId)               |
|                    | - GetActiveBusinessAsync(userId)               |
|                    | - SetActiveBusinessAsync(businessId, userId)   |
+------------------+--------------------------------------------------+
| BusinessRepository | Database operations for businesses             |
|                    | - GetByUserId(userId)                          |
|                    | - GetById(id)                                  |
|                    | - Add, Update, Delete                          |
+------------------+--------------------------------------------------+

Key Feature - Active Business:
Only one business can be "active" at a time. All product and transaction
operations are filtered to the active business context. This is implemented
by setting IsActive = true on one business and false on all others for
the same user.


PRODUCT MANAGEMENT MODULE
-------------------------
Purpose: Manages the product catalogue including stock levels, pricing,
         and low stock alerts.

Components:
+------------------+--------------------------------------------------+
| Component        | Responsibility                                   |
+------------------+--------------------------------------------------+
| ProductsController | Handles CRUD operations for products           |
|                    | - Index (list), Create, Edit, Delete           |
+------------------+--------------------------------------------------+
| ProductService     | Business logic for product management          |
|                    | - GetBusinessProductsAsync(businessId)         |
|                    | - CreateProductAsync(product)                  |
|                    | - UpdateProductAsync(product)                  |
|                    | - GetLowStockProductsAsync(businessId)         |
+------------------+--------------------------------------------------+
| ProductRepository  | Database operations for products               |
|                    | - GetByBusinessId(businessId)                  |
|                    | - GetById(id)                                  |
|                    | - Add, Update, Delete                          |
+------------------+--------------------------------------------------+


Page 37 of 210

TRANSACTION MANAGEMENT MODULE
-----------------------------
Purpose: Records all stock movements and maintains accurate inventory
         levels through automatic stock updates.

Components:
+------------------+--------------------------------------------------+
| Component        | Responsibility                                   |
+------------------+--------------------------------------------------+
| TransactionsController | Handles transaction recording and viewing  |
|                        | - Index (list), Create, Details, Delete    |
+------------------+--------------------------------------------------+
| TransactionService | Business logic for transactions                |
|                    | - RecordPurchaseAsync() - increases stock      |
|                    | - RecordSaleAsync() - decreases stock          |
|                    | - RecordAdjustmentAsync() - manual correction  |
|                    | - Validates stock availability                 |
+------------------+--------------------------------------------------+
| TransactionRepository | Database operations for transactions        |
|                       | - GetByBusinessId(businessId)               |
|                       | - GetByDateRange(businessId, start, end)    |
|                       | - AddAsync(transaction)                     |
+------------------+--------------------------------------------------+

Transaction Types:
+------------+-----------------------------------+--------------------+
| Type       | Description                       | Stock Effect       |
+------------+-----------------------------------+--------------------+
| Purchase   | Receiving goods from supplier     | + Quantity         |
| Sale       | Selling goods to customer         | - Quantity         |
| Adjustment | Manual stock correction           | +/- Quantity       |
+------------+-----------------------------------+--------------------+


Page 38 of 210

ANALYTICS MODULE
----------------
Purpose: Provides business intelligence through calculated metrics and
         visualisations on the dashboard.

Components:
+------------------+--------------------------------------------------+
| Component        | Responsibility                                   |
+------------------+--------------------------------------------------+
| HomeController     | Displays dashboard with analytics summary      |
| AnalyticsController | Displays detailed analytics page              |
+------------------+--------------------------------------------------+
| AnalyticsService | Calculates business metrics                      |
|                  | - GetDashboardSummaryAsync(businessId)           |
|                  | - GetProfitAnalyticsAsync(businessId, dates)     |
|                  | - GetTopProfitableProductsAsync(businessId)      |
|                  | - GetSalesTrendsAsync(businessId, dates)         |
+------------------+--------------------------------------------------+

Key Calculations:

1. Total Inventory Value:
   Sum of (Purchase Price * Quantity) for all active products

2. Daily Sales:
   Sum of TotalAmount for all Sale transactions today

3. Monthly Sales:
   Sum of TotalAmount for all Sale transactions this month

4. Profit Calculation:
   For each sale: (Sale Unit Price - Product Purchase Price) * Quantity
   Total Profit: Sum of above for all sales

5. Profit Margin:
   (Total Profit / Total Revenue) * 100

6. Low Stock Check:
   Product.Quantity <= Product.MinStockLevel (or default threshold of 10)


Page 39 of 210

SETTINGS MODULE
---------------
Purpose: Allows users to manage their account settings and preferences.

Components:
+------------------+--------------------------------------------------+
| Component        | Responsibility                                   |
+------------------+--------------------------------------------------+
| SettingsController | Handles settings operations                    |
|                    | - Index (view settings)                        |
|                    | - ChangePassword                               |
+------------------+--------------------------------------------------+

Features:
- View account information
- Change password with current password verification
- (Future: notification preferences, display settings)


VALIDATION MODULE
-----------------
Purpose: Provides centralised validation services for data integrity.

Components:
+------------------+--------------------------------------------------+
| Component        | Responsibility                                   |
+------------------+--------------------------------------------------+
| ValidationService  | Centralised validation logic                  |
|                    | - CheckIfEmailExists(email)                   |
|                    | - (Future: additional validation methods)     |
+------------------+--------------------------------------------------+
| ValidationController | AJAX validation endpoints                    |
|                      | - ValidateEmail (async validation)           |
+------------------+--------------------------------------------------+


Page 40 of 210

--------------------------------------------------------------------------------
2.3 UML CLASS DIAGRAMS
--------------------------------------------------------------------------------

The following UML class diagrams show the structure of the main model classes
and their relationships.

MODEL CLASSES:
--------------

+-----------------------------------+
|           UserModel               |
+-----------------------------------+
| - Id: int                         |
| - Username: string                |
| - Email: string                   |
| - PasswordHash: string            |
| - FirstName: string?              |
| - LastName: string?               |
| - Phone: string?                  |
| - CreatedAt: DateTime             |
| - UpdatedAt: DateTime             |
| - LastLoginAt: DateTime?          |
+-----------------------------------+
| + Businesses: ICollection         |
| + Products: ICollection           |
| + Settings: UserSettingsModel?    |
+-----------------------------------+


+-----------------------------------+
|         BusinessModel             |
+-----------------------------------+
| - Id: int                         |
| - UserId: int                     |
| - Name: string                    |
| - Description: string             |
| - Currency: string                |
| - CurrencySymbol: string          |
| - IsActive: bool                  |
| - CreatedAt: DateTime             |
| - UpdatedAt: DateTime             |
+-----------------------------------+
| + User: UserModel?                |
| + Products: ICollection           |
| + Transactions: ICollection       |
+-----------------------------------+


Page 41 of 210

+-----------------------------------+
|          ProductModel             |
+-----------------------------------+
| - Id: int                         |
| - UserId: int                     |
| - BusinessId: int?                |
| - Name: string                    |
| - SKU: string?                    |
| - PurchasePrice: double           |
| - SalePrice: double               |
| - Quantity: int                   |
| - MinStockLevel: int?             |
| - Description: string?            |
| - Category: string?               |
| - ImageUrl: string?               |
| - IsActive: bool                  |
| - CreatedAt: DateTime             |
| - UpdatedAt: DateTime             |
+-----------------------------------+
| + User: UserModel?                |
| + Business: BusinessModel?        |
| + Transactions: ICollection       |
| + ProfitPerUnit: double <<calc>>  |
| + TotalInventoryValue: double     |
| + PotentialProfit: double <<calc>>|
| + IsLowStock: bool <<calc>>       |
+-----------------------------------+


+-----------------------------------+
|       TransactionModel            |
+-----------------------------------+
| - Id: int                         |
| - BusinessId: int                 |
| - ProductId: int                  |
| - Type: TransactionType           |
| - Quantity: int                   |
| - UnitPrice: double               |
| - TotalAmount: double             |
| - Notes: string?                  |
| - TransactionDate: DateTime       |
| - CreatedAt: DateTime             |
+-----------------------------------+
| + Business: BusinessModel?        |
| + Product: ProductModel?          |
+-----------------------------------+


Page 42 of 210

+-----------------------------------+
|        TransactionType            |
|          <<enumeration>>          |
+-----------------------------------+
| Purchase                          |
| Sale                              |
| Adjustment                        |
+-----------------------------------+


+-----------------------------------+
|      UserSettingsModel            |
+-----------------------------------+
| - Id: int                         |
| - UserId: int                     |
| - Theme: string                   |
| - NotificationsEnabled: bool      |
| - DefaultCurrency: string         |
| - CreatedAt: DateTime             |
| - UpdatedAt: DateTime             |
+-----------------------------------+
| + User: UserModel?                |
+-----------------------------------+


CLASS RELATIONSHIPS:
--------------------

UserModel ----1----*---- BusinessModel
    |                         |
    |                         |
    1----*---- ProductModel --*----1
                    |
                    |
              *-----+
                    |
            TransactionModel
                    |
              *-----+
                    |
            BusinessModel

Relationship Descriptions:
- One User can have many Businesses (1:M)
- One User can have many Products (1:M)
- One Business can have many Products (1:M)
- One Business can have many Transactions (1:M)
- One Product can have many Transactions (1:M)
- One User has one UserSettings (1:1)


Page 43 of 210

SERVICE INTERFACES:
-------------------

+---------------------------------------+
|        IEnteranceService              |
|          <<interface>>                |
+---------------------------------------+
| + LoginAsync(user): Task<UserModel>   |
| + RegisterAsync(user): Task<UserModel>|
| + GetUserByIdAsync(id): Task<User?>   |
+---------------------------------------+


+---------------------------------------+
|        IBusinessService               |
|          <<interface>>                |
+---------------------------------------+
| + GetUserBusinessesAsync(userId)      |
| + GetBusinessByIdAsync(id, userId)    |
| + CreateBusinessAsync(business)       |
| + UpdateBusinessAsync(business)       |
| + DeleteBusinessAsync(id, userId)     |
| + GetActiveBusinessAsync(userId)      |
| + SetActiveBusinessAsync(id, userId)  |
+---------------------------------------+


+---------------------------------------+
|        IProductService                |
|          <<interface>>                |
+---------------------------------------+
| + GetBusinessProductsAsync(bizId)     |
| + GetProductByIdAsync(id, userId)     |
| + CreateProductAsync(product)         |
| + UpdateProductAsync(product)         |
| + DeleteProductAsync(id, userId)      |
+---------------------------------------+


+---------------------------------------+
|       ITransactionService             |
|          <<interface>>                |
+---------------------------------------+
| + GetBusinessTransactionsAsync(bizId) |
| + RecordPurchaseAsync(params)         |
| + RecordSaleAsync(params)             |
| + RecordAdjustmentAsync(params)       |
| + GetTransactionsByDateRangeAsync()   |
+---------------------------------------+


+---------------------------------------+
|       IAnalyticsService               |
|          <<interface>>                |
+---------------------------------------+
| + GetDashboardSummaryAsync(bizId)     |
| + GetProfitAnalyticsAsync(params)     |
| + GetTopProfitableProductsAsync()     |
| + GetSalesTrendsAsync(params)         |
| + GetTotalInventoryValueAsync(bizId)  |
+---------------------------------------+


Page 44 of 210

REPOSITORY INTERFACES:
----------------------

+---------------------------------------+
|       IEntranceRepository             |
|          <<interface>>                |
+---------------------------------------+
| + GetByEmail(email): Task<UserModel?> |
| + GetById(id): Task<UserModel?>       |
| + Add(user): Task<UserModel>          |
| + Update(user): Task                  |
+---------------------------------------+


+---------------------------------------+
|       IBusinessRepository             |
|          <<interface>>                |
+---------------------------------------+
| + GetByUserId(userId)                 |
| + GetById(id)                         |
| + Add(business)                       |
| + Update(business)                    |
| + Delete(id)                          |
+---------------------------------------+


+---------------------------------------+
|       IProductRepository              |
|          <<interface>>                |
+---------------------------------------+
| + GetByBusinessId(businessId)         |
| + GetById(id)                         |
| + Add(product)                        |
| + Update(product)                     |
| + Delete(id)                          |
+---------------------------------------+


+---------------------------------------+
|       ITransactionRepository          |
|          <<interface>>                |
+---------------------------------------+
| + GetByBusinessIdAsync(businessId)    |
| + GetByIdAsync(id)                    |
| + GetByDateRangeAsync(params)         |
| + GetRecentTransactionsAsync(params)  |
| + AddAsync(transaction)               |
| + DeleteAsync(id)                     |
+---------------------------------------+


Page 45 of 210

--------------------------------------------------------------------------------
2.4 ENTITY RELATIONSHIP DIAGRAM (ERD)
--------------------------------------------------------------------------------

The following Entity Relationship Diagram shows the database structure:

+-------------+          +---------------+          +-------------+
|   Users     |          |  Businesses   |          |  Products   |
+-------------+          +---------------+          +-------------+
| PK Id       |----+     | PK Id         |----+     | PK Id       |
| Username    |    |     | FK UserId     |    |     | FK UserId   |
| Email (UK)  |    +---->| Name          |    +---->| FK BusinessId|
| PasswordHash|          | Description   |          | Name        |
| FirstName   |          | Currency      |          | SKU         |
| LastName    |          | CurrencySymbol|          | PurchasePrice|
| Phone       |          | IsActive      |          | SalePrice   |
| CreatedAt   |          | CreatedAt     |          | Quantity    |
| UpdatedAt   |          | UpdatedAt     |          | MinStockLevel|
| LastLoginAt |          +---------------+          | Description |
+-------------+               |                     | Category    |
      |                       |                     | ImageUrl    |
      |                       |                     | IsActive    |
      v                       |                     | CreatedAt   |
+-------------+               |                     | UpdatedAt   |
| UserSettings|               |                     +-------------+
+-------------+               |                           |
| PK Id       |               |                           |
| FK UserId   |               |                           |
| Theme       |               v                           v
| Notifications|         +----------------+
| DefaultCurrency|       | Transactions   |
| CreatedAt   |          +----------------+
| UpdatedAt   |          | PK Id          |
+-------------+          | FK BusinessId  |<--------------+
                         | FK ProductId   |<--------------+
                         | Type           |
                         | Quantity       |
                         | UnitPrice      |
                         | TotalAmount    |
                         | Notes          |
                         | TransactionDate|
                         | CreatedAt      |
                         +----------------+

LEGEND:
- PK = Primary Key
- FK = Foreign Key
- UK = Unique Key


Page 46 of 210

DATABASE RELATIONSHIP DETAILS:
------------------------------

+------------------+------------------+--------------+-------------------+
| Parent Table     | Child Table      | Relationship | Delete Behaviour  |
+------------------+------------------+--------------+-------------------+
| Users            | Businesses       | 1:M          | Cascade           |
|                  |                  |              | (delete user      |
|                  |                  |              |  deletes businesses)|
+------------------+------------------+--------------+-------------------+
| Users            | Products         | 1:M          | Restrict          |
|                  |                  |              | (can't delete user|
|                  |                  |              |  with products)   |
+------------------+------------------+--------------+-------------------+
| Users            | UserSettings     | 1:1          | Cascade           |
+------------------+------------------+--------------+-------------------+
| Businesses       | Products         | 1:M          | SetNull           |
|                  |                  |              | (products become  |
|                  |                  |              |  unassigned)      |
+------------------+------------------+--------------+-------------------+
| Businesses       | Transactions     | 1:M          | Cascade           |
|                  |                  |              | (delete business  |
|                  |                  |              |  deletes history) |
+------------------+------------------+--------------+-------------------+
| Products         | Transactions     | 1:M          | Cascade           |
|                  |                  |              | (delete product   |
|                  |                  |              |  deletes history) |
+------------------+------------------+--------------+-------------------+

DATABASE INDEXES:
-----------------

+------------------+----------------------------+----------------------------+
| Table            | Index Columns              | Purpose                    |
+------------------+----------------------------+----------------------------+
| Users            | Email (Unique)             | Fast lookup by email,      |
|                  |                            | enforce uniqueness         |
+------------------+----------------------------+----------------------------+
| Products         | UserId, BusinessId         | Filter products by owner   |
|                  |                            | and business context       |
+------------------+----------------------------+----------------------------+
| Transactions     | TransactionDate            | Sort and filter by date    |
+------------------+----------------------------+----------------------------+
| Transactions     | BusinessId, TransactionDate| Analytics queries by       |
|                  |                            | business and time period   |
+------------------+----------------------------+----------------------------+
| Businesses       | UserId, IsActive           | Find active business       |
|                  |                            | for user quickly           |
+------------------+----------------------------+----------------------------+


Page 47 of 210

--------------------------------------------------------------------------------
2.5 USABILITY FEATURES
--------------------------------------------------------------------------------

The following usability features have been designed to ensure the system is
intuitive and easy to use for James and similar users.

1. CONSISTENT NAVIGATION HEADER
-------------------------------

[Screenshot placeholder - Navigation bar]

+-------------------------------------------------------------------------+
| [LOGO] Business Inventory Manager  Dashboard  Businesses  Products  ... |
|                                                    [User dropdown]      |
+-------------------------------------------------------------------------+

Features:
- Fixed position header visible on all pages
- Clear icons alongside text labels
- Consistent placement of navigation items
- User dropdown with settings and logout

Justification: James requested a simple interface. Consistent navigation
ensures users always know where they are and how to access different areas.


2. RESPONSIVE DESIGN
--------------------

The interface adapts to different screen sizes:

Desktop (1200px+):     Tablet (768px):        Mobile (<768px):
+---------------+      +----------+           +------+
| [Nav] [Nav]   |      | [Nav]    |           |[Menu]|
+---------------+      +----------+           +------+
| Sidebar | Main|      | Main     |           | Main |
|         |     |      |          |           |      |
+---------+-----+      +----------+           +------+

Justification: James needs mobile access when away from the shop. Bootstrap
grid system automatically adjusts layout for different devices.


Page 48 of 210

3. COLOUR-CODED FEEDBACK
------------------------

Visual indicators help users understand system status:

+----------+------------------+------------------------------------+
| Colour   | Bootstrap Class  | Usage                              |
+----------+------------------+------------------------------------+
| Green    | btn-success      | Positive actions (Save, Confirm)   |
|          | alert-success    | Success messages                   |
+----------+------------------+------------------------------------+
| Red      | btn-danger       | Destructive actions (Delete)       |
|          | alert-danger     | Error messages                     |
|          | text-danger      | Low stock warnings                 |
+----------+------------------+------------------------------------+
| Blue     | btn-primary      | Primary actions (Create, Submit)   |
|          | alert-info       | Information messages               |
+----------+------------------+------------------------------------+
| Yellow   | alert-warning    | Warning messages                   |
|          | badge-warning    | Attention required                 |
+----------+------------------+------------------------------------+

Justification: Colour coding provides instant visual feedback without
requiring users to read detailed messages.


4. FORM VALIDATION FEEDBACK
---------------------------

[Screenshot placeholder - Form with validation]

+------------------------------------------+
| Email: [_________________________]       |
|        * Please enter a valid email      |
+------------------------------------------+

Features:
- Real-time validation as user types
- Clear error messages below fields
- Required field indicators (*)
- Success tick when valid

Justification: Immediate feedback helps users correct errors before
submission, reducing frustration.


Page 49 of 210

5. DASHBOARD CARDS
------------------

Key metrics displayed in card format:

+-------------------+  +-------------------+  +-------------------+
| Total Products    |  | Low Stock Items   |  | Inventory Value   |
| [icon]            |  | [icon]            |  | [icon]            |
| 45                |  | 3                 |  | $12,450.00        |
+-------------------+  +-------------------+  +-------------------+

Features:
- Large, readable numbers
- Descriptive icons
- Consistent card sizing
- Quick overview at a glance

Justification: James specifically requested a dashboard similar to
QuickBooks. Cards provide scannable information quickly.


6. LOW STOCK HIGHLIGHTING
-------------------------

Products below minimum stock level are highlighted:

+------------------+----------+-----------+----------+
| Product Name     | Quantity | Min Level | Status   |
+------------------+----------+-----------+----------+
| iPhone 14 Case   | 25       | 10        |          |
| USB-C Cable      | 3        | 15        | LOW      |
| Wireless Mouse   | 0        | 5         | OUT      |
+------------------+----------+-----------+----------+

Features:
- Red text for low stock items
- Warning badge for attention
- Sorted to show urgent items first

Justification: Low stock alerts were a high-priority requirement from
James (R3). Visual highlighting ensures important items are noticed.


7. CONFIRMATION DIALOGS
-----------------------

Destructive actions require confirmation:

+--------------------------------+
| Delete Product                 |
+--------------------------------+
| Are you sure you want to       |
| delete "USB-C Cable"?          |
| This action cannot be undone.  |
|                                |
| [Cancel]        [Delete]       |
+--------------------------------+

Justification: Prevents accidental data loss from misclicks.


Page 50 of 210

--------------------------------------------------------------------------------
2.6 ALGORITHMS AND FLOWCHARTS
--------------------------------------------------------------------------------

The following algorithms describe the key processes in the system.

ALGORITHM 1: USER LOGIN PROCESS
-------------------------------

PSEUDOCODE:

FUNCTION LoginUser(email, password)
    // Validate input
    IF email is empty OR password is empty THEN
        RETURN error "Please enter email and password"
    END IF
    
    IF NOT isValidEmailFormat(email) THEN
        RETURN error "Invalid email format"
    END IF
    
    // Retrieve user from database
    user = database.GetUserByEmail(email)
    
    IF user is NULL THEN
        RETURN error "Invalid email or password"
    END IF
    
    // Verify password
    IF NOT VerifyPasswordHash(password, user.PasswordHash) THEN
        RETURN error "Invalid email or password"
    END IF
    
    // Update last login timestamp
    user.LastLoginAt = CurrentDateTime()
    database.UpdateUser(user)
    
    // Create authentication session
    CreateAuthenticationCookie(user.Id, user.Email)
    
    RETURN success, redirect to Dashboard
END FUNCTION


Page 51 of 210

FLOWCHART: USER LOGIN PROCESS

                    +--------+
                    | START  |
                    +--------+
                        |
                        v
            +------------------------+
            | Receive email and      |
            | password from form     |
            +------------------------+
                        |
                        v
            +------------------------+
            | Is email empty?        |----Yes----> Display "Enter email"
            +------------------------+                    |
                        |                                 |
                       No                                 |
                        |                                 |
                        v                                 |
            +------------------------+                    |
            | Is email format valid? |----No-----> Display "Invalid format"
            +------------------------+                    |
                        |                                 |
                       Yes                                |
                        |                                 |
                        v                                 |
            +------------------------+                    |
            | Query database for     |                    |
            | user by email          |                    |
            +------------------------+                    |
                        |                                 |
                        v                                 |
            +------------------------+                    |
            | User found?            |----No-----> Display "Invalid
            +------------------------+              credentials"
                        |                                 |
                       Yes                                |
                        |                                 |
                        v                                 |
            +------------------------+                    |
            | Verify password hash   |                    |
            +------------------------+                    |
                        |                                 |
                        v                                 |
            +------------------------+                    |
            | Password correct?      |----No-----> Display "Invalid
            +------------------------+              credentials"
                        |                                 |
                       Yes                                |
                        |                                 |
                        v                                 |
            +------------------------+                    |
            | Update LastLoginAt     |                    |
            | Create auth cookie     |                    |
            +------------------------+                    |
                        |                                 |
                        v                                 v
            +------------------------+          +--------+
            | Redirect to Dashboard  |          | END    |
            +------------------------+          +--------+


Page 52 of 210

ALGORITHM 2: RECORD SALE TRANSACTION
------------------------------------

PSEUDOCODE:

FUNCTION RecordSale(businessId, productId, quantity, unitPrice, notes)
    // Validate inputs
    IF quantity <= 0 THEN
        RETURN error "Quantity must be positive"
    END IF
    
    IF unitPrice <= 0 THEN
        RETURN error "Price must be positive"
    END IF
    
    // Get product from database
    product = database.GetProductById(productId)
    
    IF product is NULL THEN
        RETURN error "Product not found"
    END IF
    
    // Check stock availability
    IF product.Quantity < quantity THEN
        RETURN error "Insufficient stock. Available: " + product.Quantity
    END IF
    
    // Calculate total
    totalAmount = quantity * unitPrice
    
    // Create transaction record
    transaction = NEW TransactionModel()
    transaction.BusinessId = businessId
    transaction.ProductId = productId
    transaction.Type = TransactionType.Sale
    transaction.Quantity = quantity
    transaction.UnitPrice = unitPrice
    transaction.TotalAmount = totalAmount
    transaction.Notes = notes
    transaction.TransactionDate = CurrentDateTime()
    
    // Save transaction
    database.AddTransaction(transaction)
    
    // Update product stock (decrease)
    product.Quantity = product.Quantity - quantity
    product.UpdatedAt = CurrentDateTime()
    database.UpdateProduct(product)
    
    RETURN success, transaction
END FUNCTION


Page 53 of 210

FLOWCHART: RECORD SALE TRANSACTION

                    +--------+
                    | START  |
                    +--------+
                        |
                        v
            +------------------------+
            | Receive sale details   |
            | (product, qty, price)  |
            +------------------------+
                        |
                        v
            +------------------------+
            | Is quantity > 0?       |----No-----> Display "Quantity
            +------------------------+              must be positive"
                        |                                 |
                       Yes                                |
                        |                                 |
                        v                                 |
            +------------------------+                    |
            | Retrieve product       |                    |
            | from database          |                    |
            +------------------------+                    |
                        |                                 |
                        v                                 |
            +------------------------+                    |
            | Product found?         |----No-----> Display "Product
            +------------------------+              not found"
                        |                                 |
                       Yes                                |
                        |                                 |
                        v                                 |
            +------------------------+                    |
            | Is stock >= quantity?  |----No-----> Display "Insufficient
            +------------------------+              stock"
                        |                                 |
                       Yes                                |
                        |                                 |
                        v                                 |
            +------------------------+                    |
            | Calculate total amount |                    |
            | total = qty * price    |                    |
            +------------------------+                    |
                        |                                 |
                        v                                 |
            +------------------------+                    |
            | Create transaction     |                    |
            | record in database     |                    |
            +------------------------+                    |
                        |                                 |
                        v                                 |
            +------------------------+                    |
            | Update product stock   |                    |
            | stock = stock - qty    |                    |
            +------------------------+                    |
                        |                                 |
                        v                                 v
            +------------------------+          +--------+
            | Return success         |          | END    |
            +------------------------+          +--------+


Page 54 of 210

ALGORITHM 3: CALCULATE DASHBOARD SUMMARY
----------------------------------------

PSEUDOCODE:

FUNCTION GetDashboardSummary(businessId)
    // Get date ranges
    today = CurrentDate()
    monthStart = FirstDayOfMonth(today)
    monthEnd = LastDayOfMonth(today)
    
    // Get products for business
    products = database.GetProductsByBusinessId(businessId)
                        .Where(p => p.IsActive == true)
    
    // Get transactions
    todayTransactions = database.GetTransactions(businessId, today, today)
    monthTransactions = database.GetTransactions(businessId, monthStart, monthEnd)
    
    // Calculate product statistics
    totalProducts = products.Count()
    lowStockThreshold = 10
    lowStockCount = 0
    totalInventoryValue = 0
    
    FOR EACH product IN products
        // Calculate inventory value
        totalInventoryValue = totalInventoryValue + 
                             (product.PurchasePrice * product.Quantity)
        
        // Check low stock
        minLevel = product.MinStockLevel OR lowStockThreshold
        IF product.Quantity <= minLevel THEN
            lowStockCount = lowStockCount + 1
        END IF
    END FOR
    
    // Calculate sales
    salesToday = todayTransactions
                 .Where(t => t.Type == Sale)
                 .Sum(t => t.TotalAmount)
    
    salesThisMonth = monthTransactions
                     .Where(t => t.Type == Sale)
                     .Sum(t => t.TotalAmount)
    
    // Calculate profit
    profitThisMonth = 0
    saleTransactions = monthTransactions.Where(t => t.Type == Sale)
    
    FOR EACH transaction IN saleTransactions
        profit = (transaction.UnitPrice - transaction.Product.PurchasePrice) 
                 * transaction.Quantity
        profitThisMonth = profitThisMonth + profit
    END FOR
    
    // Build summary object
    summary = NEW DashboardSummary()
    summary.TotalProducts = totalProducts
    summary.LowStockProducts = lowStockCount
    summary.TotalInventoryValue = totalInventoryValue
    summary.TotalSalesToday = salesToday
    summary.TotalSalesThisMonth = salesThisMonth
    summary.ProfitThisMonth = profitThisMonth
    
    RETURN summary
END FUNCTION


Page 55 of 210

FLOWCHART: DASHBOARD SUMMARY CALCULATION

                    +--------+
                    | START  |
                    +--------+
                        |
                        v
            +------------------------+
            | Get current date and   |
            | calculate month range  |
            +------------------------+
                        |
                        v
            +------------------------+
            | Query all active       |
            | products for business  |
            +------------------------+
                        |
                        v
            +------------------------+
            | Query transactions     |
            | for today and month    |
            +------------------------+
                        |
                        v
            +------------------------+
            | Initialize counters:   |
            | totalProducts = 0      |
            | lowStock = 0           |
            | inventoryValue = 0     |
            +------------------------+
                        |
                        v
            +------------------------+
            | FOR EACH product       |<------------+
            +------------------------+             |
                        |                          |
                        v                          |
            +------------------------+             |
            | Add to inventory value |             |
            | Check if low stock     |             |
            +------------------------+             |
                        |                          |
                        v                          |
            +------------------------+             |
            | More products?         |----Yes------+
            +------------------------+
                        |
                       No
                        |
                        v
            +------------------------+
            | Sum sales transactions |
            | Calculate profit       |
            +------------------------+
                        |
                        v
            +------------------------+
            | Build summary object   |
            | Return to controller   |
            +------------------------+
                        |
                        v
                    +--------+
                    | END    |
                    +--------+


Page 56 of 210

ALGORITHM 4: CHECK LOW STOCK STATUS
-----------------------------------

PSEUDOCODE:

FUNCTION IsLowStock(product)
    // Get minimum stock level (use product's setting or default)
    IF product.MinStockLevel is not NULL THEN
        threshold = product.MinStockLevel
    ELSE
        threshold = 10  // Default threshold
    END IF
    
    // Compare current quantity to threshold
    IF product.Quantity <= threshold THEN
        RETURN true  // Low stock
    ELSE
        RETURN false // Stock OK
    END IF
END FUNCTION


FUNCTION GetLowStockProducts(businessId)
    products = database.GetProductsByBusinessId(businessId)
                       .Where(p => p.IsActive == true)
    
    lowStockList = NEW List()
    
    FOR EACH product IN products
        IF IsLowStock(product) THEN
            lowStockList.Add(product)
        END IF
    END FOR
    
    // Sort by quantity ascending (most urgent first)
    lowStockList.SortBy(p => p.Quantity)
    
    RETURN lowStockList
END FUNCTION


TRACE TABLE FOR IsLowStock FUNCTION:
------------------------------------

+------+-------------------+-------------+--------------+--------+
| Test | Product.Quantity  | MinStockLevel | Threshold  | Result |
+------+-------------------+-------------+--------------+--------+
| 1    | 50                | 10          | 10           | false  |
| 2    | 10                | 10          | 10           | true   |
| 3    | 5                 | 10          | 10           | true   |
| 4    | 3                 | NULL        | 10 (default) | true   |
| 5    | 15                | NULL        | 10 (default) | false  |
| 6    | 0                 | 5           | 5            | true   |
+------+-------------------+-------------+--------------+--------+

The trace table confirms the algorithm correctly identifies low stock
products using either the product's custom threshold or the default value.


Page 57 of 210

ALGORITHM 5: PASSWORD HASHING AND VERIFICATION
----------------------------------------------

PSEUDOCODE:

FUNCTION HashPassword(plainTextPassword)
    // BCrypt automatically generates salt and hashes
    // Work factor of 12 provides good security/performance balance
    workFactor = 12
    hash = BCrypt.HashPassword(plainTextPassword, workFactor)
    RETURN hash
END FUNCTION


FUNCTION VerifyPassword(plainTextPassword, storedHash)
    // BCrypt.Verify extracts salt from hash and compares
    isValid = BCrypt.Verify(plainTextPassword, storedHash)
    RETURN isValid
END FUNCTION


EXAMPLE:
--------
Input password: "SecurePass123!"
Generated hash: "$2a$12$K4/Y6bG8KdJ...."  (60 characters)

The hash contains:
- Algorithm identifier ($2a$)
- Work factor ($12$)
- Salt (22 characters)
- Hash (31 characters)


ALGORITHM 6: SET ACTIVE BUSINESS
--------------------------------

PSEUDOCODE:

FUNCTION SetActiveBusiness(businessId, userId)
    // Verify business belongs to user
    business = database.GetBusinessById(businessId)
    
    IF business is NULL OR business.UserId != userId THEN
        RETURN error "Business not found or access denied"
    END IF
    
    // Deactivate all businesses for user
    userBusinesses = database.GetBusinessesByUserId(userId)
    FOR EACH biz IN userBusinesses
        biz.IsActive = false
        database.UpdateBusiness(biz)
    END FOR
    
    // Activate selected business
    business.IsActive = true
    business.UpdatedAt = CurrentDateTime()
    database.UpdateBusiness(business)
    
    RETURN success
END FUNCTION


Page 58 of 210

ALGORITHM 7: RECORD PURCHASE TRANSACTION
----------------------------------------

PSEUDOCODE:

FUNCTION RecordPurchase(businessId, productId, quantity, unitPrice, notes)
    // Validate inputs
    IF quantity <= 0 THEN
        RETURN error "Quantity must be positive"
    END IF
    
    IF unitPrice < 0 THEN
        RETURN error "Price cannot be negative"
    END IF
    
    // Get product from database
    product = database.GetProductById(productId)
    
    IF product is NULL THEN
        RETURN error "Product not found"
    END IF
    
    // Calculate total
    totalAmount = quantity * unitPrice
    
    // Create transaction record
    transaction = NEW TransactionModel()
    transaction.BusinessId = businessId
    transaction.ProductId = productId
    transaction.Type = TransactionType.Purchase
    transaction.Quantity = quantity
    transaction.UnitPrice = unitPrice
    transaction.TotalAmount = totalAmount
    transaction.Notes = notes
    transaction.TransactionDate = CurrentDateTime()
    
    // Save transaction
    database.AddTransaction(transaction)
    
    // Update product stock (increase)
    product.Quantity = product.Quantity + quantity
    product.UpdatedAt = CurrentDateTime()
    database.UpdateProduct(product)
    
    RETURN success, transaction
END FUNCTION


KEY DIFFERENCE FROM SALE:
- Purchase increases stock: product.Quantity + quantity
- Sale decreases stock: product.Quantity - quantity
- Purchase does not require stock availability check


Page 59 of 210

ALGORITHM 8: CALCULATE PROFIT ANALYTICS
---------------------------------------

PSEUDOCODE:

FUNCTION GetProfitAnalytics(businessId, startDate, endDate)
    // Get sale transactions for period
    transactions = database.GetTransactions(businessId, startDate, endDate)
                          .Where(t => t.Type == Sale)
    
    // Initialize totals
    totalRevenue = 0
    totalCost = 0
    totalUnitsSold = 0
    
    // Calculate totals
    FOR EACH transaction IN transactions
        // Revenue is what customer paid
        totalRevenue = totalRevenue + transaction.TotalAmount
        
        // Cost is what we paid for goods
        IF transaction.Product is not NULL THEN
            cost = transaction.Product.PurchasePrice * transaction.Quantity
            totalCost = totalCost + cost
        END IF
        
        // Track units sold
        totalUnitsSold = totalUnitsSold + transaction.Quantity
    END FOR
    
    // Calculate profit
    grossProfit = totalRevenue - totalCost
    
    // Calculate margin (avoid division by zero)
    IF totalRevenue > 0 THEN
        profitMargin = (grossProfit / totalRevenue) * 100
    ELSE
        profitMargin = 0
    END IF
    
    // Build analytics object
    analytics = NEW ProfitAnalytics()
    analytics.StartDate = startDate
    analytics.EndDate = endDate
    analytics.TotalRevenue = totalRevenue
    analytics.TotalCost = totalCost
    analytics.GrossProfit = grossProfit
    analytics.ProfitMargin = profitMargin
    analytics.TotalTransactions = transactions.Count()
    analytics.TotalUnitsSold = totalUnitsSold
    
    RETURN analytics
END FUNCTION


Page 60 of 210

TRACE TABLE FOR PROFIT CALCULATION:
-----------------------------------

Test scenario: 3 sale transactions in March 2026

Products:
- Product A: Purchase Price = $10, Sale Price = $15
- Product B: Purchase Price = $20, Sale Price = $35

Transactions:
+------+----------+-----+------------+--------------+
| ID   | Product  | Qty | Unit Price | Total Amount |
+------+----------+-----+------------+--------------+
| T1   | A        | 5   | $15        | $75          |
| T2   | B        | 2   | $35        | $70          |
| T3   | A        | 3   | $15        | $45          |
+------+----------+-----+------------+--------------+

Calculation Steps:

Step 1: Calculate Revenue
totalRevenue = $75 + $70 + $45 = $190

Step 2: Calculate Cost
T1 cost = $10 * 5 = $50
T2 cost = $20 * 2 = $40
T3 cost = $10 * 3 = $30
totalCost = $50 + $40 + $30 = $120

Step 3: Calculate Profit
grossProfit = $190 - $120 = $70

Step 4: Calculate Margin
profitMargin = ($70 / $190) * 100 = 36.84%

Result:
+------------------+-------+
| Metric           | Value |
+------------------+-------+
| Total Revenue    | $190  |
| Total Cost       | $120  |
| Gross Profit     | $70   |
| Profit Margin    | 36.84%|
| Total Transactions| 3    |
| Total Units Sold | 10    |
+------------------+-------+


Page 61 of 210

ALGORITHM 9: USER REGISTRATION
------------------------------

PSEUDOCODE:

FUNCTION RegisterUser(username, email, password)
    // Validate inputs
    IF username is empty THEN
        RETURN error "Username is required"
    END IF
    
    IF email is empty THEN
        RETURN error "Email is required"
    END IF
    
    IF NOT isValidEmailFormat(email) THEN
        RETURN error "Invalid email format"
    END IF
    
    IF password.Length < 8 THEN
        RETURN error "Password must be at least 8 characters"
    END IF
    
    // Check if email already exists
    existingUser = database.GetUserByEmail(email)
    IF existingUser is not NULL THEN
        RETURN error "Email already registered"
    END IF
    
    // Hash password
    passwordHash = HashPassword(password)
    
    // Create user
    user = NEW UserModel()
    user.Username = username
    user.Email = email
    user.PasswordHash = passwordHash
    user.CreatedAt = CurrentDateTime()
    user.UpdatedAt = CurrentDateTime()
    
    // Save to database
    savedUser = database.AddUser(user)
    
    // Create default settings
    settings = NEW UserSettingsModel()
    settings.UserId = savedUser.Id
    settings.Theme = "light"
    settings.NotificationsEnabled = true
    database.AddUserSettings(settings)
    
    RETURN success, savedUser
END FUNCTION


Page 62 of 210

FLOWCHART: USER REGISTRATION

                    +--------+
                    | START  |
                    +--------+
                        |
                        v
            +------------------------+
            | Receive registration   |
            | data from form         |
            +------------------------+
                        |
                        v
            +------------------------+
            | Validate username      |----Invalid---> Display error
            +------------------------+                     |
                        |                                  |
                      Valid                                |
                        |                                  |
                        v                                  |
            +------------------------+                     |
            | Validate email format  |----Invalid---> Display error
            +------------------------+                     |
                        |                                  |
                      Valid                                |
                        |                                  |
                        v                                  |
            +------------------------+                     |
            | Validate password      |----Invalid---> Display error
            | (min 8 characters)     |                     |
            +------------------------+                     |
                        |                                  |
                      Valid                                |
                        |                                  |
                        v                                  |
            +------------------------+                     |
            | Check if email exists  |                     |
            +------------------------+                     |
                        |                                  |
                        v                                  |
            +------------------------+                     |
            | Email already used?    |----Yes-------> Display "Email
            +------------------------+                already registered"
                        |                                  |
                       No                                  |
                        |                                  |
                        v                                  |
            +------------------------+                     |
            | Hash password          |                     |
            | Create user record     |                     |
            +------------------------+                     |
                        |                                  |
                        v                                  |
            +------------------------+                     |
            | Save to database       |                     |
            | Create default settings|                     |
            +------------------------+                     |
                        |                                  |
                        v                                  v
            +------------------------+          +--------+
            | Auto-login and         |          | END    |
            | redirect to dashboard  |          +--------+
            +------------------------+


Page 63 of 210

ALGORITHM 10: STOCK ADJUSTMENT
------------------------------

PSEUDOCODE:

FUNCTION RecordAdjustment(businessId, productId, quantity, notes)
    // Note: quantity can be positive (add stock) or negative (remove stock)
    
    IF quantity == 0 THEN
        RETURN error "Quantity cannot be zero"
    END IF
    
    IF notes is empty THEN
        RETURN error "Please provide a reason for the adjustment"
    END IF
    
    // Get product from database
    product = database.GetProductById(productId)
    
    IF product is NULL THEN
        RETURN error "Product not found"
    END IF
    
    // Calculate new quantity
    newQuantity = product.Quantity + quantity
    
    // Prevent negative stock
    IF newQuantity < 0 THEN
        newQuantity = 0
    END IF
    
    // Create transaction record
    transaction = NEW TransactionModel()
    transaction.BusinessId = businessId
    transaction.ProductId = productId
    transaction.Type = TransactionType.Adjustment
    transaction.Quantity = quantity
    transaction.UnitPrice = product.PurchasePrice
    transaction.TotalAmount = ABS(quantity) * product.PurchasePrice
    transaction.Notes = notes
    transaction.TransactionDate = CurrentDateTime()
    
    // Save transaction
    database.AddTransaction(transaction)
    
    // Update product stock
    product.Quantity = newQuantity
    product.UpdatedAt = CurrentDateTime()
    database.UpdateProduct(product)
    
    RETURN success, transaction
END FUNCTION


Page 64 of 210

HOW ALGORITHMS FORM A COMPLETE SOLUTION:
----------------------------------------

The algorithms presented work together to form a complete inventory
management solution:

1. AUTHENTICATION FLOW:
   RegisterUser -> Creates account
   LoginUser -> Authenticates and creates session
   All subsequent operations require valid session

2. BUSINESS SETUP:
   CreateBusiness -> User creates their business
   SetActiveBusiness -> User selects working context
   All product/transaction operations filter by active business

3. PRODUCT MANAGEMENT:
   CreateProduct -> Adds items to inventory
   IsLowStock -> Monitors stock levels
   GetLowStockProducts -> Alerts user to reorder

4. TRANSACTION PROCESSING:
   RecordPurchase -> Increases stock when receiving goods
   RecordSale -> Decreases stock when selling
   RecordAdjustment -> Corrects discrepancies

5. ANALYTICS:
   GetDashboardSummary -> Provides overview of business health
   GetProfitAnalytics -> Calculates financial performance

This layered approach ensures:
- Data integrity through validation at each step
- Security through authentication checks
- Accuracy through automatic stock updates
- Business intelligence through calculated analytics


Page 65 of 210

--------------------------------------------------------------------------------
2.7 KEY VARIABLES, DATA STRUCTURES, AND CLASSES
--------------------------------------------------------------------------------

This section documents the key variables and data structures used in the
Business Inventory Manager system.

MODEL CLASSES:
--------------

+----------------------------+--------+-------------------------------------+
| Variable                   | Type   | Description & Justification         |
+----------------------------+--------+-------------------------------------+
| UserModel.Id               | int    | Primary key, auto-generated unique  |
|                            |        | identifier for each user            |
+----------------------------+--------+-------------------------------------+
| UserModel.Username         | string | Display name, required, used in UI  |
+----------------------------+--------+-------------------------------------+
| UserModel.Email            | string | Unique identifier for login, must   |
|                            |        | be valid email format               |
+----------------------------+--------+-------------------------------------+
| UserModel.PasswordHash     | string | BCrypt hash of password, never      |
|                            |        | store plain text for security       |
+----------------------------+--------+-------------------------------------+
| UserModel.CreatedAt        | DateTime| Audit field, records account        |
|                            |        | creation timestamp                  |
+----------------------------+--------+-------------------------------------+

+----------------------------+--------+-------------------------------------+
| Variable                   | Type   | Description & Justification         |
+----------------------------+--------+-------------------------------------+
| BusinessModel.Id           | int    | Primary key for business            |
+----------------------------+--------+-------------------------------------+
| BusinessModel.UserId       | int    | Foreign key linking to owner        |
+----------------------------+--------+-------------------------------------+
| BusinessModel.Name         | string | Business name, displayed in UI      |
+----------------------------+--------+-------------------------------------+
| BusinessModel.Currency     | string | ISO currency code (e.g., "GBP")     |
+----------------------------+--------+-------------------------------------+
| BusinessModel.CurrencySymbol| string| Display symbol (e.g., "£")         |
+----------------------------+--------+-------------------------------------+
| BusinessModel.IsActive     | bool   | Only one business active at a time, |
|                            |        | filters products/transactions       |
+----------------------------+--------+-------------------------------------+


Page 66 of 210

+----------------------------+--------+-------------------------------------+
| Variable                   | Type   | Description & Justification         |
+----------------------------+--------+-------------------------------------+
| ProductModel.Id            | int    | Primary key for product             |
+----------------------------+--------+-------------------------------------+
| ProductModel.Name          | string | Product name, required, searchable  |
+----------------------------+--------+-------------------------------------+
| ProductModel.SKU           | string?| Stock Keeping Unit, optional,       |
|                            |        | nullable for products without SKU   |
+----------------------------+--------+-------------------------------------+
| ProductModel.PurchasePrice | double | Cost price paid to supplier,        |
|                            |        | used for profit calculation         |
+----------------------------+--------+-------------------------------------+
| ProductModel.SalePrice     | double | Selling price to customers,         |
|                            |        | used for revenue calculation        |
+----------------------------+--------+-------------------------------------+
| ProductModel.Quantity      | int    | Current stock level, updated by     |
|                            |        | transactions automatically          |
+----------------------------+--------+-------------------------------------+
| ProductModel.MinStockLevel | int?   | Per-product reorder threshold,      |
|                            |        | nullable uses default of 10         |
+----------------------------+--------+-------------------------------------+
| ProductModel.Category      | string?| User-defined category for filtering |
+----------------------------+--------+-------------------------------------+
| ProductModel.IsActive      | bool   | Soft delete flag, false hides       |
|                            |        | product without removing data       |
+----------------------------+--------+-------------------------------------+

CALCULATED PROPERTIES (ProductModel):
+----------------------------+------------------------------------------+
| Property                   | Calculation                              |
+----------------------------+------------------------------------------+
| ProfitPerUnit              | SalePrice - PurchasePrice               |
+----------------------------+------------------------------------------+
| TotalInventoryValue        | PurchasePrice * Quantity                |
+----------------------------+------------------------------------------+
| PotentialProfit            | ProfitPerUnit * Quantity                |
+----------------------------+------------------------------------------+
| IsLowStock                 | Quantity <= (MinStockLevel ?? 10)       |
+----------------------------+------------------------------------------+


Page 67 of 210

+----------------------------+--------+-------------------------------------+
| Variable                   | Type   | Description & Justification         |
+----------------------------+--------+-------------------------------------+
| TransactionModel.Id        | int    | Primary key for transaction         |
+----------------------------+--------+-------------------------------------+
| TransactionModel.BusinessId| int    | Foreign key to business context     |
+----------------------------+--------+-------------------------------------+
| TransactionModel.ProductId | int    | Foreign key to product involved     |
+----------------------------+--------+-------------------------------------+
| TransactionModel.Type      | enum   | TransactionType enumeration:        |
|                            |        | Purchase, Sale, Adjustment          |
+----------------------------+--------+-------------------------------------+
| TransactionModel.Quantity  | int    | Number of units in transaction      |
+----------------------------+--------+-------------------------------------+
| TransactionModel.UnitPrice | double | Price per unit at time of           |
|                            |        | transaction (may differ from        |
|                            |        | current product price)              |
+----------------------------+--------+-------------------------------------+
| TransactionModel.TotalAmount| double| Calculated: Quantity * UnitPrice    |
+----------------------------+--------+-------------------------------------+
| TransactionModel.Notes     | string?| Optional notes for audit trail      |
+----------------------------+--------+-------------------------------------+
| TransactionModel.TransactionDate| DateTime| When transaction occurred      |
+----------------------------+--------+-------------------------------------+

ENUMERATION:
+----------------------------+-------+--------------------------------------+
| TransactionType            | Value | Description                          |
+----------------------------+-------+--------------------------------------+
| Purchase                   | 0     | Stock received from supplier         |
+----------------------------+-------+--------------------------------------+
| Sale                       | 1     | Stock sold to customer               |
+----------------------------+-------+--------------------------------------+
| Adjustment                 | 2     | Manual stock correction              |
+----------------------------+-------+--------------------------------------+


Page 68 of 210

VIEW MODEL CLASSES:
-------------------

View Models transfer data between Controllers and Views, containing only
the data needed for each specific view.

+----------------------------+--------+-------------------------------------+
| DashboardViewModel         | Type   | Purpose                             |
+----------------------------+--------+-------------------------------------+
| Username                   | string | Display welcome message             |
| TotalBusinesses            | int    | Show user's business count          |
| HasActiveBusiness          | bool   | Conditional display logic           |
| ActiveBusinessName         | string | Current context indicator           |
| CurrencySymbol             | string | Format monetary values              |
| TotalProducts              | int    | Dashboard stat card                 |
| LowStockProducts           | int    | Warning indicator count             |
| TotalInventoryValue        | double | Financial summary                   |
| TotalSalesToday            | double | Daily performance                   |
| TotalSalesThisMonth        | double | Monthly performance                 |
| ProfitThisMonth            | double | Profitability metric                |
| TransactionsToday          | int    | Activity indicator                  |
| TransactionsThisMonth      | int    | Monthly activity                    |
| RecentTransactions         | IEnum  | List of recent transaction records  |
| LowStockItems              | IEnum  | List of products needing attention  |
+----------------------------+--------+-------------------------------------+

+----------------------------+--------+-------------------------------------+
| ProductViewModel           | Type   | Purpose                             |
+----------------------------+--------+-------------------------------------+
| Id                         | int    | Identify product for edit/delete    |
| Name                       | string | Display and input field             |
| SKU                        | string?| Display and input field             |
| PurchasePrice              | double | Input with validation               |
| SalePrice                  | double | Input with validation               |
| Quantity                   | int    | Display and input field             |
| MinStockLevel              | int?   | Input field (optional)              |
| Description                | string?| Input field (optional)              |
| Category                   | string?| Input field (optional)              |
| IsLowStock                 | bool   | Conditional styling in view         |
| CreatedAt                  | DateTime| Display audit information          |
+----------------------------+--------+-------------------------------------+


Page 69 of 210

SERVICE LAYER DATA STRUCTURES:
------------------------------

Analytics classes hold calculated data for display:

+----------------------------+--------+-------------------------------------+
| DashboardSummary           | Type   | Purpose                             |
+----------------------------+--------+-------------------------------------+
| TotalProducts              | int    | Count of active products            |
| LowStockProducts           | int    | Count below threshold               |
| TotalInventoryValue        | double | Sum of purchase_price * quantity    |
| TotalSalesToday            | double | Sum of sale amounts today           |
| TotalSalesThisMonth        | double | Sum of sale amounts this month      |
| ProfitThisMonth            | double | Revenue minus cost this month       |
| TransactionsToday          | int    | Count of transactions today         |
| TransactionsThisMonth      | int    | Count of transactions this month    |
| RecentTransactions         | List   | Last 5 transactions                 |
| LowStockItems              | List   | Top 5 urgent stock items            |
+----------------------------+--------+-------------------------------------+

+----------------------------+--------+-------------------------------------+
| ProfitAnalytics            | Type   | Purpose                             |
+----------------------------+--------+-------------------------------------+
| StartDate                  | DateTime| Analysis period start              |
| EndDate                    | DateTime| Analysis period end                |
| TotalRevenue               | double | Sum of all sale amounts             |
| TotalCost                  | double | Sum of purchase prices * qty sold   |
| GrossProfit                | double | Revenue minus cost                  |
| ProfitMargin               | double | (Profit / Revenue) * 100            |
| TotalTransactions          | int    | Count of sale transactions          |
| TotalUnitsSold             | int    | Sum of quantities sold              |
+----------------------------+--------+-------------------------------------+


Page 70 of 210

CONFIGURATION AND SETTINGS:
---------------------------

+----------------------------+--------+-------------------------------------+
| Variable                   | Type   | Purpose                             |
+----------------------------+--------+-------------------------------------+
| ConnectionString           | string | Database connection details stored  |
|                            |        | in appsettings.json for security    |
+----------------------------+--------+-------------------------------------+
| Cookie.ExpireTimeSpan      | TimeSpan| Session duration (7 days)          |
+----------------------------+--------+-------------------------------------+
| Cookie.SlidingExpiration   | bool   | Reset expiry on activity            |
+----------------------------+--------+-------------------------------------+
| Cookie.HttpOnly            | bool   | Prevent JavaScript access to cookie |
|                            |        | for security                        |
+----------------------------+--------+-------------------------------------+

JUSTIFICATION FOR DATA TYPES:
-----------------------------

1. INT for IDs: Integer primary keys provide fast indexing and are
   sufficient for expected data volumes.

2. DOUBLE for prices: Provides adequate precision for monetary values.
   In production, DECIMAL would be preferred for exact precision.

3. STRING for text: Flexible length text storage for names, descriptions.

4. DATETIME for timestamps: Stores date and time with timezone support
   for accurate audit trails.

5. BOOL for flags: Binary states (active/inactive) are efficiently
   stored as boolean values.

6. NULLABLE types (?): Used for optional fields where data may not be
   provided (e.g., SKU, MinStockLevel).

7. ENUM for TransactionType: Type-safe representation of limited value
   set, prevents invalid transaction types.


Page 71 of 210

DEPENDENCY INJECTION CONFIGURATION:
-----------------------------------

The following services are registered in Program.cs:

// Repository layer (data access)
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IEntranceRepository, EntranceRepository>();
builder.Services.AddScoped<IBusinessRepository, BusinessRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

// Service layer (business logic)
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IEnteranceService, EnteranceService>();
builder.Services.AddScoped<IBusinessService, BusinessService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IAnalyticsService, AnalyticsService>();
builder.Services.AddScoped<IClaimsService, ClaimsService>();
builder.Services.AddScoped<IValidationService, ValidationService>();

SCOPED LIFETIME JUSTIFICATION:
------------------------------

"Scoped" lifetime means one instance per HTTP request. This is appropriate
because:

1. Database context should be scoped to prevent data leakage between requests
2. Services maintaining state should be isolated per request
3. Memory is released after each request completes
4. Thread safety is maintained without locking


Page 72 of 210

--------------------------------------------------------------------------------
2.8 DATA VALIDATION
--------------------------------------------------------------------------------

Data validation ensures data integrity and prevents errors. The following
validation rules are implemented:

USER REGISTRATION VALIDATION:
+------------------+--------------------+-----------------------------------+
| Field            | Validation Rule    | Error Message                     |
+------------------+--------------------+-----------------------------------+
| Username         | Required           | "Username is required"            |
|                  | Min 3 characters   | "Username must be at least 3      |
|                  |                    |  characters"                      |
+------------------+--------------------+-----------------------------------+
| Email            | Required           | "Email is required"               |
|                  | Valid format       | "Please enter a valid email"      |
|                  | Unique             | "Email already registered"        |
+------------------+--------------------+-----------------------------------+
| Password         | Required           | "Password is required"            |
|                  | Min 8 characters   | "Password must be at least 8      |
|                  |                    |  characters"                      |
+------------------+--------------------+-----------------------------------+
| Confirm Password | Must match         | "Passwords do not match"          |
+------------------+--------------------+-----------------------------------+

PRODUCT VALIDATION:
+------------------+--------------------+-----------------------------------+
| Field            | Validation Rule    | Error Message                     |
+------------------+--------------------+-----------------------------------+
| Name             | Required           | "Product name is required"        |
+------------------+--------------------+-----------------------------------+
| PurchasePrice    | Required           | "Purchase price is required"      |
|                  | >= 0               | "Price cannot be negative"        |
+------------------+--------------------+-----------------------------------+
| SalePrice        | Required           | "Sale price is required"          |
|                  | >= 0               | "Price cannot be negative"        |
+------------------+--------------------+-----------------------------------+
| Quantity         | Required           | "Quantity is required"            |
|                  | >= 0               | "Quantity cannot be negative"     |
+------------------+--------------------+-----------------------------------+
| MinStockLevel    | If provided, >= 0  | "Min stock cannot be negative"    |
+------------------+--------------------+-----------------------------------+


Page 73 of 210

TRANSACTION VALIDATION:
+------------------+--------------------+-----------------------------------+
| Field            | Validation Rule    | Error Message                     |
+------------------+--------------------+-----------------------------------+
| ProductId        | Required           | "Please select a product"         |
|                  | Must exist         | "Product not found"               |
+------------------+--------------------+-----------------------------------+
| Type             | Required           | "Transaction type is required"    |
|                  | Valid enum value   | "Invalid transaction type"        |
+------------------+--------------------+-----------------------------------+
| Quantity         | Required           | "Quantity is required"            |
|                  | > 0                | "Quantity must be greater than 0" |
|                  | For Sale: <= stock | "Insufficient stock. Available:   |
|                  |                    |  [current quantity]"              |
+------------------+--------------------+-----------------------------------+
| UnitPrice        | Required           | "Price is required"               |
|                  | > 0                | "Price must be greater than 0"    |
+------------------+--------------------+-----------------------------------+

BUSINESS VALIDATION:
+------------------+--------------------+-----------------------------------+
| Field            | Validation Rule    | Error Message                     |
+------------------+--------------------+-----------------------------------+
| Name             | Required           | "Business name is required"       |
+------------------+--------------------+-----------------------------------+
| Currency         | Required           | "Currency is required"            |
|                  | Valid code         | "Invalid currency code"           |
+------------------+--------------------+-----------------------------------+
| CurrencySymbol   | Required           | "Currency symbol is required"     |
+------------------+--------------------+-----------------------------------+


VALIDATION IMPLEMENTATION:
--------------------------

Validation is implemented at multiple levels:

1. CLIENT-SIDE (JavaScript/jQuery Validation):
   - Immediate feedback to user
   - Reduces server load
   - Can be bypassed (not relied upon for security)

2. SERVER-SIDE (ModelState validation):
   - Always checked even if client-side bypassed
   - Returns model errors to view
   - Example: if (!ModelState.IsValid) return View(model);

3. SERVICE LAYER (Business logic validation):
   - Complex validation rules
   - Database checks (e.g., stock availability)
   - Throws exceptions for invalid operations


Page 74 of 210

VALIDATION CODE EXAMPLE:
------------------------

// Service layer validation for sale transaction
public async Task<TransactionModel> RecordSaleAsync(
    int businessId, int productId, int quantity, double unitPrice, string? notes)
{
    // Get product and validate existence
    var product = await _productRepository.GetById(productId);
    if (product == null)
    {
        throw new Exception("Product not found");
    }

    // Validate stock availability
    if (product.Quantity < quantity)
    {
        throw new Exception(
            $"Insufficient stock. Available: {product.Quantity}, " +
            $"Requested: {quantity}");
    }

    // Proceed with transaction...
}


VIEW MODEL VALIDATION ATTRIBUTES:
---------------------------------

// Example from RegisterViewModel
public class RegisterViewModel
{
    [Required(ErrorMessage = "Username is required")]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters")]
    public string Username { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Please confirm your password")]
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; }
}


Page 75 of 210

--------------------------------------------------------------------------------
2.9 TEST DATA FOR DEVELOPMENT
--------------------------------------------------------------------------------

The following test data will be used during the iterative development process
to ensure each feature works correctly.

USER REGISTRATION TEST DATA:
+------+---------------+--------------------+-------------+----------+
| Test | Username      | Email              | Password    | Expected |
+------+---------------+--------------------+-------------+----------+
| 1    | JamesR        | james@shop.com     | Password123!| Valid    |
| 2    | ""            | james@shop.com     | Password123!| Invalid  |
|      |               |                    |             | (empty)  |
+------+---------------+--------------------+-------------+----------+
| 3    | JamesR        | not-an-email       | Password123!| Invalid  |
|      |               |                    |             | (format) |
+------+---------------+--------------------+-------------+----------+
| 4    | JamesR        | james@shop.com     | short       | Invalid  |
|      |               |                    |             | (<8 char)|
+------+---------------+--------------------+-------------+----------+
| 5    | AB            | james@shop.com     | Password123!| Invalid  |
|      |               |                    |             | (short)  |
+------+---------------+--------------------+-------------+----------+

USER LOGIN TEST DATA:
+------+--------------------+-------------+--------------------------+
| Test | Email              | Password    | Expected Result          |
+------+--------------------+-------------+--------------------------+
| 1    | james@shop.com     | Password123!| Success - redirect       |
| 2    | james@shop.com     | wrongpass   | Invalid credentials      |
| 3    | notexist@test.com  | Password123!| Invalid credentials      |
| 4    | ""                 | Password123!| Email required           |
| 5    | james@shop.com     | ""          | Password required        |
+------+--------------------+-------------+--------------------------+


Page 76 of 210

PRODUCT TEST DATA:
+------+-------------+--------+-------+-----+-----+---------+----------+
| Test | Name        | SKU    | PPrice| SPrice| Qty | MinLvl | Expected |
+------+-------------+--------+-------+-----+-----+---------+----------+
| 1    | iPhone Case | IP-001 | 5.00  | 12.99| 50  | 10      | Valid    |
| 2    | USB Cable   | USB-C  | 2.00  | 7.99 | 100 | 20      | Valid    |
| 3    | ""          | TEST   | 5.00  | 10.00| 10  | 5       | Invalid  |
|      |             |        |       |      |     |         | (no name)|
+------+-------------+--------+-------+-----+-----+---------+----------+
| 4    | Test Prod   | TP-001 | -5.00 | 10.00| 10  | 5       | Invalid  |
|      |             |        |       |      |     |         | (neg px) |
+------+-------------+--------+-------+-----+-----+---------+----------+
| 5    | Test Prod   | TP-001 | 5.00  | 10.00| -5  | 5       | Invalid  |
|      |             |        |       |      |     |         | (neg qty)|
+------+-------------+--------+-------+-----+-----+---------+----------+
| 6    | Wireless M  | NULL   | 8.00  | 19.99| 25  | NULL    | Valid    |
|      |             |        |       |      |     |         | (opt fld)|
+------+-------------+--------+-------+-----+-----+---------+----------+

BOUNDARY TEST - Product near minimum stock:
+------+-------------+-----+---------+-----------------------------+
| Test | Product     | Qty | MinLvl  | Expected IsLowStock         |
+------+-------------+-----+---------+-----------------------------+
| 1    | Product A   | 15  | 10      | false (above threshold)     |
| 2    | Product B   | 10  | 10      | true (at threshold)         |
| 3    | Product C   | 5   | 10      | true (below threshold)      |
| 4    | Product D   | 0   | 10      | true (zero stock)           |
| 5    | Product E   | 12  | NULL    | false (default threshold 10)|
| 6    | Product F   | 8   | NULL    | true (default threshold 10) |
+------+-------------+-----+---------+-----------------------------+


Page 77 of 210

TRANSACTION TEST DATA:
+------+----------+-----+-------+--------+---------------------------+
| Test | Type     | Qty | Price | Stock  | Expected Result           |
+------+----------+-----+-------+--------+---------------------------+
| 1    | Purchase | 20  | 5.00  | 50     | Success, stock = 70       |
| 2    | Sale     | 10  | 12.99 | 50     | Success, stock = 40       |
| 3    | Sale     | 60  | 12.99 | 50     | Fail - insufficient stock |
| 4    | Adjust   | +5  | N/A   | 50     | Success, stock = 55       |
| 5    | Adjust   | -10 | N/A   | 50     | Success, stock = 40       |
| 6    | Sale     | 0   | 12.99 | 50     | Fail - qty must be > 0    |
| 7    | Purchase | 10  | 0     | 50     | Success, stock = 60       |
|      |          |     |       |        | (free goods allowed)      |
+------+----------+-----+-------+--------+---------------------------+

BOUNDARY TEST - Sale at exact stock level:
+------+----------+-------------+---------------------------+
| Test | Type     | Qty = Stock | Expected Result           |
+------+----------+-------------+---------------------------+
| 1    | Sale     | 50 = 50     | Success, stock = 0        |
| 2    | Sale     | 51 > 50     | Fail - insufficient stock |
+------+----------+-------------+---------------------------+


Page 78 of 210

ANALYTICS TEST DATA:
--------------------

Setup data for testing dashboard calculations:

Products:
+----+-------------+--------+-------+-----+
| ID | Name        | PPrice | SPrice| Qty |
+----+-------------+--------+-------+-----+
| 1  | Product A   | 10.00  | 20.00 | 100 |
| 2  | Product B   | 5.00   | 15.00 | 50  |
| 3  | Product C   | 25.00  | 45.00 | 20  |
+----+-------------+--------+-------+-----+

Transactions (this month):
+----+------+----------+-----+-------+------------+
| ID | ProdID| Type    | Qty | UPrice| TotalAmt   |
+----+------+----------+-----+-------+------------+
| 1  | 1    | Sale     | 10  | 20.00 | 200.00     |
| 2  | 2    | Sale     | 5   | 15.00 | 75.00      |
| 3  | 1    | Purchase | 20  | 10.00 | 200.00     |
| 4  | 3    | Sale     | 3   | 45.00 | 135.00     |
+----+------+----------+-----+-------+------------+

Expected Calculations:
+-------------------------+------------------------------------------+
| Metric                  | Calculation                              |
+-------------------------+------------------------------------------+
| Total Products          | 3                                        |
| Total Inventory Value   | (10*100) + (5*50) + (25*20) = 1750       |
| Monthly Sales           | 200 + 75 + 135 = 410                     |
| Monthly Profit          | (20-10)*10 + (15-5)*5 + (45-25)*3 = 210  |
| Profit Margin           | (210 / 410) * 100 = 51.22%               |
+-------------------------+------------------------------------------+

This test data will be used to verify that:
1. Dashboard displays correct totals
2. Profit calculations are accurate
3. Low stock detection works correctly
4. Transaction recording updates stock properly


Page 79 of 210

--------------------------------------------------------------------------------
2.10 ACCEPTANCE TESTING PLAN
--------------------------------------------------------------------------------

The following acceptance tests will be used during the post-development
evaluation phase to verify the solution meets all success criteria.

TEST CATEGORY: USER AUTHENTICATION
----------------------------------
+------+--------------------------------+-------------+------------------+
| Test | Description                    | Test Data   | Expected Outcome |
+------+--------------------------------+-------------+------------------+
| A1   | Register new user with valid   | Valid data  | Account created, |
|      | username, email, password      | from 2.9    | auto-login       |
+------+--------------------------------+-------------+------------------+
| A2   | Attempt registration with      | Existing    | Error message    |
|      | existing email                 | email       | "Email already   |
|      |                                |             | registered"      |
+------+--------------------------------+-------------+------------------+
| A3   | Login with correct credentials | Valid login | Redirect to      |
|      |                                |             | dashboard        |
+------+--------------------------------+-------------+------------------+
| A4   | Login with incorrect password  | Wrong pass  | "Invalid         |
|      |                                |             | credentials"     |
+------+--------------------------------+-------------+------------------+
| A5   | Login with non-existent email  | Fake email  | "Invalid         |
|      |                                |             | credentials"     |
+------+--------------------------------+-------------+------------------+
| A6   | Logout and verify session ends | N/A         | Redirected to    |
|      |                                |             | login, cannot    |
|      |                                |             | access dashboard |
+------+--------------------------------+-------------+------------------+
| A7   | Change password successfully   | Valid       | Success message, |
|      |                                | old + new   | can login with   |
|      |                                |             | new password     |
+------+--------------------------------+-------------+------------------+
| A8   | Verify password is hashed in   | Check DB    | Password column  |
|      | database (not plain text)      | directly    | contains hash    |
+------+--------------------------------+-------------+------------------+


Page 80 of 210

TEST CATEGORY: BUSINESS MANAGEMENT
----------------------------------
+------+--------------------------------+-------------+------------------+
| Test | Description                    | Test Data   | Expected Outcome |
+------+--------------------------------+-------------+------------------+
| B1   | Create new business            | Valid data  | Business created,|
|      |                                |             | appears in list  |
+------+--------------------------------+-------------+------------------+
| B2   | Create multiple businesses     | 3 different | All 3 appear in  |
|      |                                | businesses  | business list    |
+------+--------------------------------+-------------+------------------+
| B3   | Set business as active         | Select one  | Selected shows   |
|      |                                |             | as active        |
+------+--------------------------------+-------------+------------------+
| B4   | Edit business details          | Change name | Name updated     |
+------+--------------------------------+-------------+------------------+
| B5   | Delete business and verify     | Delete one  | Business removed,|
|      | cascade delete                 |             | products removed |
+------+--------------------------------+-------------+------------------+
| B6   | Verify products filtered by    | View prods  | Only active      |
|      | active business                |             | business products|
+------+--------------------------------+-------------+------------------+

TEST CATEGORY: PRODUCT MANAGEMENT
---------------------------------
+------+--------------------------------+-------------+------------------+
| Test | Description                    | Test Data   | Expected Outcome |
+------+--------------------------------+-------------+------------------+
| C1   | Create product with all fields | Valid data  | Product created  |
+------+--------------------------------+-------------+------------------+
| C2   | Create product without SKU     | No SKU      | Product created  |
|      | (optional field)               |             | with null SKU    |
+------+--------------------------------+-------------+------------------+
| C3   | Edit product details           | Change      | Price updated    |
|      |                                | price       |                  |
+------+--------------------------------+-------------+------------------+
| C4   | Delete product                 | Valid ID    | Product removed  |
+------+--------------------------------+-------------+------------------+
| C5   | Verify low stock highlighting  | Qty <= Min  | Product shows    |
|      |                                |             | low stock badge  |
+------+--------------------------------+-------------+------------------+
| C6   | Verify custom MinStockLevel    | Set to 25   | Alerts when <=25 |
+------+--------------------------------+-------------+------------------+


Page 81 of 210

TEST CATEGORY: TRANSACTION MANAGEMENT
-------------------------------------
+------+--------------------------------+-------------+------------------+
| Test | Description                    | Test Data   | Expected Outcome |
+------+--------------------------------+-------------+------------------+
| D1   | Record purchase and verify     | Qty = 20    | Stock increases  |
|      | stock increase                 |             | by 20            |
+------+--------------------------------+-------------+------------------+
| D2   | Record sale and verify stock   | Qty = 10    | Stock decreases  |
|      | decrease                       |             | by 10            |
+------+--------------------------------+-------------+------------------+
| D3   | Attempt sale exceeding stock   | Qty > Stock | Error: insuffic- |
|      |                                |             | ient stock       |
+------+--------------------------------+-------------+------------------+
| D4   | Record sale at exact stock qty | Qty = Stock | Success, stock=0 |
+------+--------------------------------+-------------+------------------+
| D5   | Record positive adjustment     | +5          | Stock increases  |
|      |                                |             | by 5             |
+------+--------------------------------+-------------+------------------+
| D6   | Record negative adjustment     | -5          | Stock decreases  |
|      |                                |             | by 5             |
+------+--------------------------------+-------------+------------------+
| D7   | View transaction history       | N/A         | All transactions |
|      |                                |             | listed           |
+------+--------------------------------+-------------+------------------+
| D8   | Filter transactions by date    | Date range  | Only matching    |
|      |                                |             | shown            |
+------+--------------------------------+-------------+------------------+

TEST CATEGORY: ANALYTICS AND DASHBOARD
--------------------------------------
+------+--------------------------------+-------------+------------------+
| Test | Description                    | Test Data   | Expected Outcome |
+------+--------------------------------+-------------+------------------+
| E1   | Verify total products count    | 5 products  | Dashboard shows 5|
+------+--------------------------------+-------------+------------------+
| E2   | Verify inventory value calc    | Test data   | Correct total    |
|      |                                | from 2.9    |                  |
+------+--------------------------------+-------------+------------------+
| E3   | Verify today's sales total     | Sales today | Correct sum      |
+------+--------------------------------+-------------+------------------+
| E4   | Verify monthly sales total     | Sales month | Correct sum      |
+------+--------------------------------+-------------+------------------+
| E5   | Verify profit calculation      | Known data  | Correct profit   |
+------+--------------------------------+-------------+------------------+
| E6   | Verify low stock items list    | Low stock   | Items appear     |
+------+--------------------------------+-------------+------------------+
| E7   | Verify recent transactions     | Add some    | Last 5 shown     |
+------+--------------------------------+-------------+------------------+


Page 82 of 210

TEST CATEGORY: USER INTERFACE
-----------------------------
+------+--------------------------------+-------------+------------------+
| Test | Description                    | Test Data   | Expected Outcome |
+------+--------------------------------+-------------+------------------+
| F1   | Test responsive design mobile  | Mobile view | Layout adapts    |
+------+--------------------------------+-------------+------------------+
| F2   | Test responsive design tablet  | Tablet view | Layout adapts    |
+------+--------------------------------+-------------+------------------+
| F3   | Verify navigation consistency  | All pages   | Nav visible and  |
|      |                                |             | consistent       |
+------+--------------------------------+-------------+------------------+
| F4   | Verify success messages appear | Create item | Green success    |
|      |                                |             | message shown    |
+------+--------------------------------+-------------+------------------+
| F5   | Verify error messages appear   | Invalid     | Red error        |
|      |                                | input       | message shown    |
+------+--------------------------------+-------------+------------------+
| F6   | Verify confirmation dialogs    | Delete item | Confirm dialog   |
|      | for destructive actions        |             | appears          |
+------+--------------------------------+-------------+------------------+

TEST CATEGORY: ROBUSTNESS
-------------------------
+------+--------------------------------+-------------+------------------+
| Test | Description                    | Test Data   | Expected Outcome |
+------+--------------------------------+-------------+------------------+
| G1   | Access protected page when     | No session  | Redirect to      |
|      | logged out                     |             | login            |
+------+--------------------------------+-------------+------------------+
| G2   | Attempt SQL injection          | ' OR '1'='1 | Input rejected   |
|      | in input fields                |             | or escaped       |
+------+--------------------------------+-------------+------------------+
| G3   | Submit empty required fields   | Empty form  | Validation error |
+------+--------------------------------+-------------+------------------+
| G4   | Enter very long text in fields | 1000+ chars | Handled or       |
|      |                                |             | truncated        |
+------+--------------------------------+-------------+------------------+
| G5   | Access another user's data     | Wrong ID    | Access denied    |
|      | by manipulating URLs           |             | or not found     |
+------+--------------------------------+-------------+------------------+


Page 83 of 210

--------------------------------------------------------------------------------
2.11 SIGN-OFF PROPOSAL
--------------------------------------------------------------------------------

Before beginning development, I presented the complete design documentation
to James Richardson for review and approval.

SIGN-OFF MEETING: 30/01/2026
----------------------------

Attendees: Developer (myself), James Richardson (End User)

Agenda:
1. Review analysis and requirements
2. Walk through proposed features
3. Explain system design and architecture
4. Review success criteria
5. Discuss timeline and expectations
6. Obtain sign-off to proceed

Discussion Points:
------------------

James reviewed the documentation and raised the following points:

1. "The dashboard design looks exactly like what I had in mind. I'm glad
   you included the low stock items list - that will be very useful."

2. "I notice the PDF report feature is marked as 'if time permits'. That's
   fine - I can work without it initially and you can add it later."

3. "The profit calculations look correct. I especially like that it will
   calculate margin percentage - that saves me doing it manually."

4. "I'm happy with the timeline. When do you think I'll be able to start
   testing the system?"

Sign-Off Statement:
-------------------

"I, James Richardson, have reviewed the analysis and design documentation
for the Business Inventory Manager system. I confirm that the proposed
features meet my requirements and I approve the commencement of development."

Signed: James Richardson
Date: 30/01/2026

Note: A full signature was obtained on a physical copy of this document.


[END OF SECTION B - DESIGN]

[SECTION C - DEVELOPING THE CODED SOLUTION would continue from here
with the complete development story, including:
- Dated development entries
- Code snippets with explanations
- Testing during development
- User review sessions
- Problem-solving and bug fixes

SECTION D - EVALUATION would include:
- Final testing results
- Usability testing with James
- Success criteria evaluation
- Maintenance and future improvements
- Limitations discussion]


================================================================================
                              APPENDIX
                           CODE LISTINGS
================================================================================

[Note: Complete source code would be included here, including all:
- Controllers
- Services
- Repositories
- Models
- Views
- Configuration files]

================================================================================
                         END OF DOCUMENT
================================================================================
"""
    
    return document


if __name__ == "__main__":
    print("Generating NEA Project Writeup...")
    writeup = generate_writeup()
    
    # Save to file
    with open('/vercel/share/v0-project/scripts/nea_project_writeup.txt', 'w', encoding='utf-8') as f:
        f.write(writeup)
    
    print("NEA Project Writeup generated successfully!")
    print(f"Document saved to: /vercel/share/v0-project/scripts/nea_project_writeup.txt")
    print(f"Total length: {len(writeup)} characters")
    print(f"Approximate pages: {len(writeup) // 3000}")
