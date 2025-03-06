import CustomerLayout from "@/layouts/CustomerLayout.vue";

export default [
    {
        path: "/customer",
        component: () => CustomerLayout,
        children: [
            {
                path: "dashboard",
                name: "customer-dashboard",
                component: () => import("@/views/customer/DashboardView.vue"),
            },
            {
                path: "addresses",
                name: "customer-addresses",
                component: () => import("@/views/customer/AddressesView.vue"),
            },
            {
                path: "favorites",
                name: "customer-favorites",
                component: () => import("@/views/customer/FavoritesView.vue"),
            },
            {
                path: "profile",
                children: [
                    {
                        path: "",
                        name: "customer-profile",
                        component: () => import("@/views/customer/profile/ProfileInfoView.vue"),
                    },
                    {
                        path: "password",
                        name: "customer-profile-password",
                        component: () => import("@/views/customer/profile/PasswordView.vue"),
                    },
                    {
                        path: "notifications",
                        name: "customer-profile-notifications",
                        component: () => import("@/views/customer/profile/NotificationsView.vue"),
                    },
                    {
                        path: "social",
                        name: "customer-profile-social",
                        component: () => import("@/views/customer/profile/SocialAccountsView.vue"),
                    },
                ],
            },
            {
                path: "orders",
                name: "customer-orders",
                component: () => import("@/views/customer/orders/OrdersView.vue"),
            },
            {
                path: "orders/1",
                name: "customer-order-detail",
                component: () => import("@/views/customer/orders/OrderDetailView.vue"),
            },
            {
                path: "orders/1/track",
                name: "customer-order-track",
                component: () => import("@/views/customer/orders/OrderTrackView.vue"),
            },
            {
                path: "orders/1/return",
                name: "customer-order-return",
                component: () => import("@/views/customer/orders/OrderReturnView.vue"),
            },
            {
                path: "notifications",
                name: "customer-notifications",
                component: () => import("@/views/customer/CustomerNotificationsView.vue"),
            },
        ],
    },
];
