import AdminLayout from "@/layouts/AdminLayout.vue";

export default [
    {
        path: "/admin",
        component: AdminLayout,
        children: [
            {
                path: "dashboard",
                name: "admin-dashboard",
                component: () => import("@/views/admin/DashboardView.vue"),
            },
            {
                path: "users",
                name: "admin-users",
                component: () => import("@/views/admin/UsersView.vue"),
            },
            {
                path: "sellers",
                name: "admin-sellers",
                component: () => import("@/views/admin/SellersView.vue"),
            },
            {
                path: "products",
                name: "admin-products",
                component: () => import("@/views/admin/ProductsView.vue"),
            },
            {
                path: "categories",
                name: "admin-categories",
                component: () => import("@/views/admin/CategoriesView.vue"),
            },
            {
                path: "orders",
                name: "admin-orders",
                component: () => import("@/views/admin/OrdersView.vue"),
            },
            {
                path: "discounts",
                name: "admin-discounts",
                component: () => import("@/views/admin/DiscountsView.vue"),
            },
            {
                path: "analytics",
                name: "admin-analytics",
                component: () => import("@/views/admin/AnalyticsView.vue"),
            },
            {
                path: "settings",
                name: "admin-settings",
                component: () => import("@/views/admin/SettingsView.vue"),
            },
            {
                path: "profile",
                name: "admin-profile",
                component: () => import("@/views/admin/ProfileView.vue"),
            },
            {
                path: "notifications",
                name: "admin-notifications",
                component: () => import("@/views/admin/AdminNotificationsView.vue"),
            },
        ],
    },
]; 