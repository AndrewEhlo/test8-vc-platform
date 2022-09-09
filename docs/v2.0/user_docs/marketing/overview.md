# Overview

Virto Commerce Marketing is a dedicated module for managing various marketing activities, campaigns, and promotions you may run within your online store. This section will guide you through its key features and concepts, and will briefly tell you how to work with those.

## Related Components
To view the source code of Virto Commerce Marketing module, check out our [GitHub repository](https://github.com/VirtoCommerce/vc-module-marketing).

To download the latest Marketing module release, click [here](https://github.com/VirtoCommerce/vc-module-marketing/releases).

## Key Features
Virto's Marketing module provides the following key features:
 
+ Managing [dynamic content](#dynamic-content) for Storefront
+ Managing [published content](#working-with-dynamic-content)
+ Creating and running [promotions](#promotions)

## Dynamic Content

The Dynamic Content feature allows you to create personalized shopping experiences for customers. Using this feature, you can deliver elements of shopping experience based on a set of conditions or context.

When displaying Dynamic Content to your customers, you will need to consider the following:

* Type of content you are going to display
* Target audience who will see the content
* Time frame within which the content will be visible
* Content location (which part of the webpage will house the content in question)

Dynamic Content is configurable through Virto Commerce Platform Manager, which means your marketing team can set it up without any developer or system admin effort. For images or Flash animations, they may need a graphic designer to create a file and upload it to Assets. However, once this is done, marketing can configure rules for displaying content without any assistance from technical teams.

Dynamic Content consists of four independent components:

+ ***Dynamic Content***
+ ***Published Content***
+ ***Content Type***
+ ***Content Placeholder***

The first two components, ***Dynamic Content*** and ***Content Publishing***, can be configured through Virto Commerce Platform Manager by the marketing team members. Dynamic Content provides a name and a description of the type of content to be displayed, while the Content Publishing object specifies when, under what conditions, and where the Dynamic Content will appear.

The ***Content Placeholder*** is also created via Virto Commerce platform manager, but they are created by developers, web designers and system management personnel. As soon as the  web developer adds the Content Place to a template, the developer or another user with appropriate permissions must register it in Virto Commerce platform manager.

The ***Content type*** is a template used to define the Dynamic Content Type. It describes how a particular content type is displayed and what information is required for it to be displayed. Virto Commerce includes several Content types for the most common types of Dynamic Content. For example, there is a Content type to display images with links (banner). Another one to display product data (product with image and price).

The following Dynamic ***Content Types*** are shipped with Virto Commerce out-of-the-box. Each of them requires one or more parameter values to specify things such as: what image file should be displayed or what the target web page should display after clicking on the element.


| Content type | Description | Parameters |
|--------------|-------------|------------|
|Flash | Displays an animated Flash file that cycles through three images. This Flash animation shows each of three images in succession, each having a clickable link that shows the shopper a different promotion. You will need to specify the URLs for each link within the Flash file.| FlashFilePath - path to the Flash animation file, Link1Url, Link2Url, Link3Url - enter the complete URL to the target page (item, promotion etc)|
| Html | Displays HTML content | RawHtml - enter raw Html formatted text here |
|ImageClickable |Displays an image that can be clicked to perform some action. For example, redirect to another page, product or promotion |Alternative text - text if the image can not be displayed. ImageUrl - link to the image. TargetUrl - link to the target when image clicked. Title - text (optional) |
| ImageNonClickable |Displays an image. For example, use this type to alert customers to a shopping cart promotion that will give them a discount on checkout |Alternative text - text if image can not be displayed. ImageFilePath - path to the image file |
|ProductsWithinCategory |Displays products of the category as slideshow |Category code - code of the category. Title - user friendly title of the category. Item count - how many items will be presented in the slideshow. New items - switch to show only new items.|

For more information on managing dynamic content, please refer to these dedicated guides:

[Managing Content Items](managing-content-items.md)

[Managing Content Placeholders](managing-content-placeholders.md)

[Managing Content Publishing](managing-published-content.md)

### Tags

The Dynamic Content functionality can be used to show specific content to targeted customers. The system determines the customers properties via Tags. Virto Commerce incorporates tagging system that is used to set and evaluate tags that the user can use to segment Customers, and to decide when, where and to which Customer this content should be displayed.

The tagging data about a customer is captured in a variety of ways, including the following:

1. Information provided in a registered customer account;
1. Information entered by a Customer Service about a customer during the customer's service call;
1. Target and referring URLs and search terms captured when the user clicks a link that brings them to a storefront;
1. Customer Geo location.

Information captured by the tags is stored in the user’s session while he shops in on storefront. The information can then be used to evaluate whether the customer meets the conditions set for displaying the Dynamic Content. Tag information is captured only when the customer first visits the storefront during the browser session.

A Marketer or other Manager user with granted Dynamic Content permissions, uses the tags when creating conditions that determine whether a customer will see a piece of Dynamic Content or not.

!!! tip
	Refer to [this article](publishing-conditions.md) if you want to learn more about publishing conditions.

## Promotions

***Promotion*** is a marketing tool used to boost sales. In Virto Commerce, you can add a lot of various kinds of promotions to your stores that would yield such rewards as discounts, shipping discounts, or gifts. You can also create or import coupons that could be later used by your customers.

Each promotion is valid under specific [conditions](promotion-rules.md) you can configure, and may provide one or more rewards.

!!! note
	In Virto, promotions are highly customizable and include conditions for customers matching speficic criteria, currencies, products, stock quantity, etc.
	
	For instance, you can configure that customers residing in NYC and grabbing two last spartphones would get 75% off for shipping and two phone cases as a gift.

!!! note
	Promotions may be both store-specific and shared across multiple stores.

For more information on managing promotions, please refer to these dedicated guides:

[Promotion Rules](promotion-rules.md)

[Managing Promotions](managing-promotions.md)

[Combining Active Promotions](combining-active-promotions.md)