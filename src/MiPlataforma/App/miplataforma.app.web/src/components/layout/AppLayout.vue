<script setup lang="ts">
import { watch } from 'vue';
import { useRoute } from 'vue-router';
import AppTopbar from './AppTopbar.vue';
import AppSidebar from './AppSidebar.vue';
import AppFooter from './AppFooter.vue';
import { useLayout } from './composables/layout';

const { isSidebarCollapsed, isMobileMenuActive, hideMobileMenu } = useLayout();

const route = useRoute();
watch(
  () => route.fullPath,
  () => hideMobileMenu()
);
</script>

<template>
  <div class="layout-wrapper layout-static"
    :class="{ 'layout-static-inactive': isSidebarCollapsed, 'layout-mobile-active': isMobileMenuActive }">
    <AppTopbar />
    <AppSidebar />

    <div class="layout-main-container">
      <main class="layout-main">
        <router-view />
      </main>
      <AppFooter />
    </div>

    <div class="layout-mask" @click="hideMobileMenu"></div>
  </div>
  <Toast />
</template>
