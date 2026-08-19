<script setup lang="ts">
import { watch } from 'vue';
import { useRoute } from 'vue-router';
import AppTopbar from './AppTopbar.vue';
import AppSidebar from './AppSidebar.vue';
import AppFooter from './AppFooter.vue';
import { useLayout } from './composables/layout';

const { isSidebarCollapsed, hideMobileMenu } = useLayout();

const route = useRoute();
watch(
  () => route.fullPath,
  () => hideMobileMenu()
);
</script>

<template>
  <div class="min-h-screen bg-surface-50 dark:bg-surface-950">
    <AppTopbar />
    <AppSidebar />

    <div class="flex flex-col min-h-screen pt-16 transition-all duration-200"
      :class="isSidebarCollapsed ? 'lg:pl-[4.5rem]' : 'lg:pl-64'">
      <main class="flex-1 p-6">
        <router-view />
      </main>
      <AppFooter />
    </div>
  </div>
</template>
