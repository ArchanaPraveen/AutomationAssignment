Feature: E2EAutomation


@tag1
Scenario:1Register user 
Given initialize browser with chromedriver
And Navigate to the "Automation Practice"  site
When user all the credentials
Then verify user is successfully registered



@tag2
Scenario:2 Products and Product view Verification
Given login with "Testing.12345@gmail.com" and "123@1"
When select category and type from navigation bar
| category | type     |
| Women    |  T-shirts |
And Verify the product view
| view |
| list |
And navigate to selected option page and select color
| color |
| blue  |
Then add item to cart and continue shopping


@tag3
Scenario:3 Search bar and Sortby verification
Given Enter Searchitem on search bar
| Searchitem |
| dresses    |
When user navigates to searchitem page 
Then select option in which element has to be sorted and verify
| option              |
| Price: Lowest first |



@tag4
Scenario:4 Payment validation
Given select item and go to homepage
And click on homepage and select checkout
When verify payment
Then signout