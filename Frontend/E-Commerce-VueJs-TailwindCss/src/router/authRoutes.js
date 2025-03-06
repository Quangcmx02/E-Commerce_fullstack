import PublicLayout from "@/layouts/PublicLayout.vue";

export default [
    {
        path: "/auth",
        component: PublicLayout,
        children: [
            {
                path: "login",
                name: "login",
                component: () => import("@/views/auth/LoginView.vue"),
            },
            {
                path: "register",
                name: "register",
                component: () => import("@/views/auth/RegisterView.vue"),
            },
            {
                path: "forgot-password",
                name: "forgot-password",
                component: () => import("@/views/auth/ForgotPasswordView.vue"),
            },
        ],
    },
];
