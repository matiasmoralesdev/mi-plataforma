<script setup lang="ts">
import AppMenu from './AppMenu.vue';
import { useLayout } from './composables/layout';

const { isSidebarCollapsed, isMobileMenuActive, hideMobileMenu } = useLayout();
</script>

<template>
  <aside
    class="fixed top-16 bottom-0 left-0 z-30 bg-surface-0 dark:bg-surface-900 border-r border-surface-200 dark:border-surface-700 overflow-y-auto overflow-x-hidden transition-all duration-200 max-lg:w-64"
    :class="[isSidebarCollapsed ? 'w-[4.5rem]' : 'w-64', isMobileMenuActive ? 'max-lg:translate-x-0' : 'max-lg:-translate-x-full']">
    <AppMenu :collapsed="isSidebarCollapsed" />
  </aside>

  <div v-if="isMobileMenuActive" class="fixed inset-0 top-16 bg-black/50 z-20 lg:hidden" @click="hideMobileMenu"></div>
</template>
