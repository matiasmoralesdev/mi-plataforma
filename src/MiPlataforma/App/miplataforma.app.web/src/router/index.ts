import { createRouter, createWebHistory } from 'vue-router';
import AppLayout from '@/components/layout/AppLayout.vue';

const router = createRouter({
    history: createWebHistory(),
    routes: [
        {
            path: '/',
            component: AppLayout,
            children: [
                {
                    path: '',
                    name: 'dashboard',
                    component: () => import('@/views/PlaceholderView.vue'),
                    props: { title: 'Dashboard' }
                },
                {
                    path: 'elemento-1',
                    name: 'elemento-1',
                    component: () => import('@/views/PlaceholderView.vue'),
                    props: { title: 'Elemento 1' }
                },
                {
                    path: 'elemento-2',
                    name: 'elemento-2',
                    component: () => import('@/views/PlaceholderView.vue'),
                    props: { title: 'Elemento 2' }
                },
                {
                    path: 'configuracion',
                    name: 'configuracion',
                    component: () => import('@/views/PlaceholderView.vue'),
                    props: { title: 'Configuración' }
                }
            ]
        }
    ]
});

export default router;
