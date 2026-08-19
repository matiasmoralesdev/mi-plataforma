<script setup lang="ts">
import { useRouter } from 'vue-router';
import { useLayout } from './composables/layout';

const { isDarkTheme, toggleDarkMode, toggleMenu } = useLayout();
const router = useRouter();

function goToProfile() {
  router.push('/perfil');
}

function logout() {
  // TODO: conecta esto con tu lógica real de autenticación
  router.push('/');
}
</script>

<template>
  <div class="layout-topbar">
    <div class="layout-topbar-logo-container">
      <button type="button" class="layout-topbar-action" @click="toggleMenu">
        <i class="pi pi-bars"></i>
      </button>
      <router-link to="/" class="layout-topbar-logo">MiPlataforma</router-link>
    </div>

    <div class="layout-topbar-actions">
      <button type="button" class="layout-topbar-action" @click="toggleDarkMode">
        <i :class="isDarkTheme ? 'pi pi-sun' : 'pi pi-moon'"></i>
      </button>

      <div class="relative">
        <button
          type="button"
          class="layout-topbar-action"
          v-styleclass="{
            selector: '@next',
            enterFromClass: 'hidden',
            enterActiveClass: 'p-anchored-overlay-enter-active',
            leaveToClass: 'hidden',
            leaveActiveClass: 'p-anchored-overlay-leave-active',
            hideOnOutsideClick: true,
          }"
        >
          <i class="pi pi-user"></i>
        </button>

        <div class="layout-topbar-menu hidden">
          <button type="button" class="layout-topbar-menu-item" @click="goToProfile">
            <i class="pi pi-user"></i>
            <span>Perfil</span>
          </button>
          <button type="button" class="layout-topbar-menu-item" @click="logout">
            <i class="pi pi-sign-out"></i>
            <span>Cerrar sesión</span>
          </button>
        </div>
      </div>
    </div>
  </div>
</template>
