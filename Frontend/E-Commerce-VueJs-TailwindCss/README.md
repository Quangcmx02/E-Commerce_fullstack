# E-Commerce-VueJs-TailwindCss

An innovative e-commerce platform built with Vue.js and TailwindCSS, designed for modern online shopping experiences. This project offers a responsive and user-friendly interface, fast loading times, and seamless integration of essential e-commerce features such as product management, shopping cart, secure checkout, and more. Focused on scalability, performance, and customization, it's the ideal foundation for any online store.

## Technologies (languages & frameworks)

- Html
- Css
- JavaScript
- TypeScript
- VueJs
- TailwindCss

## Packages & Libraries

- HeadlessUi
- HeroIcons
- Pinia
- Cypress
- ESLint
- Vue-Toastification

## Setup

1. Install packages

```sh
npm install
```

2. Run Project

```sh
npm run dev
```

## Essential Terminal Commands

- Type-Check, Compile and Minify for Production

```sh
npm run build
```

- Run Unit Tests with Vitest

```sh
npm run test:unit
```

- Run End-to-End Tests with Cypress

```sh
npm run test:e2e:dev
```

This runs the end-to-end tests against the Vite development server.
It is much faster than the production build.

But it's still recommended to test the production build with `test:e2e` before deploying (e.g. in CI environments)

- Lint with ESLint

```sh
npm run lint
```

## Pages

- Public
    - Home [localhost:5173/](http://localhost:5173/)
    - About [localhost:5173/about](http://localhost:5173/about)
    - Products [localhost:5173/products](http://localhost:5173/products)
    - Product Detail [localhost:5173/products/:id](http://localhost:5173/products/:id)
    - Categories [localhost:5173/categories](http://localhost:5173/categories)
    - Category Products [localhost:5173/category/:id](http://localhost:5173/category/:id)
    - Contact [localhost:5173/contact](http://localhost:5173/contact)
    - Careers [localhost:5173/careers](http://localhost:5173/careers)
    - Career Detail [localhost:5173/careers/:id](http://localhost:5173/careers/:id)
    - Blog [localhost:5173/blog](http://localhost:5173/blog)
    - Blog Detail [localhost:5173/blog/:slug](http://localhost:5173/blog/:slug)
    - Faq [localhost:5173/faq](http://localhost:5173/faq)
    - Shipping [localhost:5173/shipping](http://localhost:5173/shipping)
    - Return Policy [localhost:5173/return-policy](http://localhost:5173/return-policy)
    - Privacy Policy [localhost:5173/privacy-policy](http://localhost:5173/privacy-policy)
    - Cart [localhost:5173/cart](http://localhost:5173/cart)
    - Checkout [localhost:5173/checkout](http://localhost:5173/checkout)
- Auth
    - Login [localhost:5173/login](http://localhost:5173/login)
    - Register [localhost:5173/register](http://localhost:5173/register)
- Customer
    - Customer Dashboard [localhost:5173/customer/dashboard](http://localhost:5173/customer/dashboard)
    - Customer Addresses [localhost:5173/customer/addresses](http://localhost:5173/customer/addresses)
    - Customer Favorites [localhost:5173/customer/favorites](http://localhost:5173/customer/favorites)
    - Customer Profile Settings [localhost:5173/customer/profile](http://localhost:5173/customer/profile)
    - Customer Password Change [localhost:5173/customer/profile/password](http://localhost:5173/customer/profile/password)
    - Customer Notification Settings [localhost:5173/customer/profile/notifications](http://localhost:5173/customer/profile/notifications)
    - Customer Social Media Account Settings [localhost:5173/customer/profile/social](http://localhost:5173/customer/profile/social)
    - Customer Orders [localhost:5173/customer/orders](http://localhost:5173/customer/orders)
    - Customer Order Detail [localhost:5173/customer/orders/:id](http://localhost:5173/customer/orders/:id)
    - Customer Order Track [localhost:5173/customer/orders/:id/track](http://localhost:5173/customer/orders/:id/track)
    - Customer Order Return [localhost:5173/customer/orders/:id/track](http://localhost:5173/customer/:id/track)
- Seller
    - Seller Dashboard [localhost:5173/seller/dashboard](http://localhost:5173/seller/dashboard)
    - Seller Analytics [localhost:5173/seller/analytics](http://localhost:5173/seller/analytics)
    - Seller Profile Settings [localhost:5173/seller/profile](http://localhost:5173/seller/profile)
    - Seller Products [localhost:5173/seller/products](http://localhost:5173/seller/products)
    - Seller Product Create [localhost:5173/seller/products/create](http://localhost:5173/seller/products/create)
    - Seller Product Detail [localhost:5173/seller/products/:id](http://localhost:5173/seller/products/:id)
    - Seller Product Edit [localhost:5173/seller/products/:id/edit](http://localhost:5173/seller/products/:id/edit)
    - Seller Orders [localhost:5173/seller/orders](http://localhost:5173/seller/orders)
    - Seller Order Detail [localhost:5173/seller/orders/:id](http://localhost:5173/seller/orders/:id)
